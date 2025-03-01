using System.Net;
using FluentAssertions;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Serialization.Objects;
using Microsoft.Extensions.DependencyInjection;
using TestBuildingBlocks;
using Xunit;

namespace JsonApiDotNetCoreTests.IntegrationTests.QueryStrings.Includes;

public sealed class IncludeTests : IClassFixture<IntegrationTestContext<TestableStartup<QueryStringDbContext>, QueryStringDbContext>>
{
    private readonly IntegrationTestContext<TestableStartup<QueryStringDbContext>, QueryStringDbContext> _testContext;
    private readonly QueryStringFakers _fakers = new();

    public IncludeTests(IntegrationTestContext<TestableStartup<QueryStringDbContext>, QueryStringDbContext> testContext)
    {
        _testContext = testContext;

        testContext.UseController<BlogPostsController>();
        testContext.UseController<BlogsController>();
        testContext.UseController<CommentsController>();
        testContext.UseController<WebAccountsController>();
        testContext.UseController<CalendarsController>();

        var options = (JsonApiOptions)testContext.Factory.Services.GetRequiredService<IJsonApiOptions>();
        options.MaximumIncludeDepth = null;
    }

    [Fact]
    public async Task Can_include_in_primary_resources()
    {
        // Arrange
        BlogPost post = _fakers.BlogPost.GenerateOne();
        post.Author = _fakers.WebAccount.GenerateOne();

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            await dbContext.ClearTableAsync<BlogPost>();
            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();
        });

        const string route = "blogPosts?include=author";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.ManyValue.Should().HaveCount(1);
        responseDocument.Data.ManyValue[0].Id.Should().Be(post.StringId);
        responseDocument.Data.ManyValue[0].Attributes.ShouldContainKey("caption").With(value => value.Should().Be(post.Caption));

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("webAccounts");
        responseDocument.Included[0].Id.Should().Be(post.Author.StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("displayName").With(value => value.Should().Be(post.Author.DisplayName));
    }

    [Fact]
    public async Task Can_include_in_primary_resource_by_ID()
    {
        // Arrange
        BlogPost post = _fakers.BlogPost.GenerateOne();
        post.Author = _fakers.WebAccount.GenerateOne();

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();
        });

        string route = $"blogPosts/{post.StringId}?include=author";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Id.Should().Be(post.StringId);
        responseDocument.Data.SingleValue.Attributes.ShouldContainKey("caption").With(value => value.Should().Be(post.Caption));

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("webAccounts");
        responseDocument.Included[0].Id.Should().Be(post.Author.StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("displayName").With(value => value.Should().Be(post.Author.DisplayName));
    }

    [Fact]
    public async Task Can_include_in_secondary_resource()
    {
        // Arrange
        Blog blog = _fakers.Blog.GenerateOne();
        blog.Owner = _fakers.WebAccount.GenerateOne();
        blog.Owner.Posts = _fakers.BlogPost.GenerateList(1);

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Blogs.Add(blog);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/blogs/{blog.StringId}/owner?include=posts";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Id.Should().Be(blog.Owner.StringId);
        responseDocument.Data.SingleValue.Attributes.ShouldContainKey("displayName").With(value => value.Should().Be(blog.Owner.DisplayName));

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("blogPosts");
        responseDocument.Included[0].Id.Should().Be(blog.Owner.Posts[0].StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("caption").With(value => value.Should().Be(blog.Owner.Posts[0].Caption));
    }

    [Fact]
    public async Task Can_include_in_secondary_resources()
    {
        // Arrange
        Blog blog = _fakers.Blog.GenerateOne();
        blog.Posts = _fakers.BlogPost.GenerateList(1);
        blog.Posts[0].Author = _fakers.WebAccount.GenerateOne();

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Blogs.Add(blog);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/blogs/{blog.StringId}/posts?include=author";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.ManyValue.Should().HaveCount(1);
        responseDocument.Data.ManyValue[0].Id.Should().Be(blog.Posts[0].StringId);
        responseDocument.Data.ManyValue[0].Attributes.ShouldContainKey("caption").With(value => value.Should().Be(blog.Posts[0].Caption));

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("webAccounts");
        responseDocument.Included[0].Id.Should().Be(blog.Posts[0].Author!.StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("displayName").With(value => value.Should().Be(blog.Posts[0].Author!.DisplayName));
    }

    [Fact]
    public async Task Can_include_ToOne_relationships()
    {
        // Arrange
        Comment comment = _fakers.Comment.GenerateOne();
        comment.Author = _fakers.WebAccount.GenerateOne();
        comment.Parent = _fakers.BlogPost.GenerateOne();

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Comments.Add(comment);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/comments/{comment.StringId}?include=author,parent";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Id.Should().Be(comment.StringId);
        responseDocument.Data.SingleValue.Attributes.ShouldContainKey("text").With(value => value.Should().Be(comment.Text));

        responseDocument.Included.Should().HaveCount(2);

        responseDocument.Included[0].Type.Should().Be("webAccounts");
        responseDocument.Included[0].Id.Should().Be(comment.Author.StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("userName").With(value => value.Should().Be(comment.Author.UserName));

        responseDocument.Included[1].Type.Should().Be("blogPosts");
        responseDocument.Included[1].Id.Should().Be(comment.Parent.StringId);
        responseDocument.Included[1].Attributes.ShouldContainKey("caption").With(value => value.Should().Be(comment.Parent.Caption));
    }

    [Fact]
    public async Task Can_include_OneToMany_relationship()
    {
        // Arrange
        BlogPost post = _fakers.BlogPost.GenerateOne();
        post.Comments = _fakers.Comment.GenerateSet(1);

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();
        });

        string route = $"blogPosts/{post.StringId}?include=comments";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Id.Should().Be(post.StringId);
        responseDocument.Data.SingleValue.Attributes.ShouldContainKey("caption").With(value => value.Should().Be(post.Caption));

        DateTime createdAt = post.Comments.Single().CreatedAt;

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("comments");
        responseDocument.Included[0].Id.Should().Be(post.Comments.Single().StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("createdAt").With(value => value.Should().Be(createdAt));
    }

    [Fact]
    public async Task Can_include_ManyToMany_relationship()
    {
        // Arrange
        BlogPost post = _fakers.BlogPost.GenerateOne();
        post.Labels = _fakers.Label.GenerateSet(1);

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();
        });

        string route = $"blogPosts/{post.StringId}?include=labels";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Id.Should().Be(post.StringId);
        responseDocument.Data.SingleValue.Attributes.ShouldContainKey("caption").With(value => value.Should().Be(post.Caption));

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("labels");
        responseDocument.Included[0].Id.Should().Be(post.Labels.Single().StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("name").With(value => value.Should().Be(post.Labels.Single().Name));
    }

    [Fact]
    public async Task Can_include_ManyToMany_relationship_at_secondary_endpoint()
    {
        // Arrange
        BlogPost post = _fakers.BlogPost.GenerateOne();
        post.Labels = _fakers.Label.GenerateSet(1);

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/blogPosts/{post.StringId}/labels?include=posts";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.ManyValue.Should().HaveCount(1);
        responseDocument.Data.ManyValue[0].Type.Should().Be("labels");
        responseDocument.Data.ManyValue[0].Id.Should().Be(post.Labels.ElementAt(0).StringId);
        responseDocument.Data.ManyValue[0].Attributes.ShouldContainKey("name").With(value => value.Should().Be(post.Labels.Single().Name));

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("blogPosts");
        responseDocument.Included[0].Id.Should().Be(post.StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("caption").With(value => value.Should().Be(post.Caption));
    }

    [Fact]
    public async Task Can_include_chain_of_ToOne_relationships()
    {
        // Arrange
        Comment comment = _fakers.Comment.GenerateOne();
        comment.Parent = _fakers.BlogPost.GenerateOne();
        comment.Parent.Author = _fakers.WebAccount.GenerateOne();
        comment.Parent.Author.Preferences = _fakers.AccountPreferences.GenerateOne();

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Comments.Add(comment);
            await dbContext.SaveChangesAsync();
        });

        string route = $"comments/{comment.StringId}?include=parent.author.preferences";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Id.Should().Be(comment.StringId);
        responseDocument.Data.SingleValue.Attributes.ShouldContainKey("text").With(value => value.Should().Be(comment.Text));

        responseDocument.Included.Should().HaveCount(3);

        responseDocument.Included[0].Type.Should().Be("blogPosts");
        responseDocument.Included[0].Id.Should().Be(comment.Parent.StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("caption").With(value => value.Should().Be(comment.Parent.Caption));

        responseDocument.Included[1].Type.Should().Be("webAccounts");
        responseDocument.Included[1].Id.Should().Be(comment.Parent.Author.StringId);
        responseDocument.Included[1].Attributes.ShouldContainKey("displayName").With(value => value.Should().Be(comment.Parent.Author.DisplayName));

        bool useDarkTheme = comment.Parent.Author.Preferences.UseDarkTheme;

        responseDocument.Included[2].Type.Should().Be("accountPreferences");
        responseDocument.Included[2].Id.Should().Be(comment.Parent.Author.Preferences.StringId);
        responseDocument.Included[2].Attributes.ShouldContainKey("useDarkTheme").With(value => value.Should().Be(useDarkTheme));
    }

    [Fact]
    public async Task Can_include_chain_of_OneToMany_relationships()
    {
        // Arrange
        Blog blog = _fakers.Blog.GenerateOne();
        blog.Posts = _fakers.BlogPost.GenerateList(1);
        blog.Posts[0].Comments = _fakers.Comment.GenerateSet(1);

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Blogs.Add(blog);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/blogs/{blog.StringId}?include=posts.comments";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Id.Should().Be(blog.StringId);
        responseDocument.Data.SingleValue.Attributes.ShouldContainKey("title").With(value => value.Should().Be(blog.Title));

        responseDocument.Included.Should().HaveCount(2);

        responseDocument.Included[0].Type.Should().Be("blogPosts");
        responseDocument.Included[0].Id.Should().Be(blog.Posts[0].StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("caption").With(value => value.Should().Be(blog.Posts[0].Caption));

        DateTime createdAt = blog.Posts[0].Comments.Single().CreatedAt;

        responseDocument.Included[1].Type.Should().Be("comments");
        responseDocument.Included[1].Id.Should().Be(blog.Posts[0].Comments.Single().StringId);
        responseDocument.Included[1].Attributes.ShouldContainKey("createdAt").With(value => value.Should().Be(createdAt));
    }

    [Fact]
    public async Task Can_include_chain_of_recursive_relationships()
    {
        // Arrange
        Comment comment = _fakers.Comment.GenerateOne();
        comment.Parent = _fakers.BlogPost.GenerateOne();
        comment.Parent.Author = _fakers.WebAccount.GenerateOne();
        comment.Parent.Comments = _fakers.Comment.GenerateSet(2);
        comment.Parent.Comments.ElementAt(0).Author = _fakers.WebAccount.GenerateOne();

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Comments.Add(comment);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/comments/{comment.StringId}?include=parent.comments.author";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Id.Should().Be(comment.StringId);
        responseDocument.Data.SingleValue.Attributes.ShouldContainKey("text").With(value => value.Should().Be(comment.Text));

        responseDocument.Included.Should().HaveCount(4);

        responseDocument.Included[0].Type.Should().Be("blogPosts");
        responseDocument.Included[0].Id.Should().Be(comment.Parent.StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("caption").With(value => value.Should().Be(comment.Parent.Caption));

        responseDocument.Included[1].Type.Should().Be("comments");
        responseDocument.Included[1].Id.Should().Be(comment.Parent.Comments.ElementAt(0).StringId);
        responseDocument.Included[1].Attributes.ShouldContainKey("text").With(value => value.Should().Be(comment.Parent.Comments.ElementAt(0).Text));

        string userName = comment.Parent.Comments.ElementAt(0).Author!.UserName;

        responseDocument.Included[2].Type.Should().Be("webAccounts");
        responseDocument.Included[2].Id.Should().Be(comment.Parent.Comments.ElementAt(0).Author!.StringId);
        responseDocument.Included[2].Attributes.ShouldContainKey("userName").With(value => value.Should().Be(userName));

        responseDocument.Included[3].Type.Should().Be("comments");
        responseDocument.Included[3].Id.Should().Be(comment.Parent.Comments.ElementAt(1).StringId);
        responseDocument.Included[3].Attributes.ShouldContainKey("text").With(value => value.Should().Be(comment.Parent.Comments.ElementAt(1).Text));
    }

    [Fact]
    public async Task Can_include_chain_of_relationships_with_multiple_paths()
    {
        // Arrange
        Blog blog = _fakers.Blog.GenerateOne();
        blog.Posts = _fakers.BlogPost.GenerateList(1);
        blog.Posts[0].Author = _fakers.WebAccount.GenerateOne();
        blog.Posts[0].Author!.Preferences = _fakers.AccountPreferences.GenerateOne();
        blog.Posts[0].Comments = _fakers.Comment.GenerateSet(2);
        blog.Posts[0].Comments.ElementAt(0).Author = _fakers.WebAccount.GenerateOne();
        blog.Posts[0].Comments.ElementAt(0).Author!.Posts = _fakers.BlogPost.GenerateList(1);

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Blogs.Add(blog);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/blogs/{blog.StringId}?include=posts.author.preferences,posts.comments.author.posts";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Id.Should().Be(blog.StringId);

        responseDocument.Data.SingleValue.Relationships.ShouldContainKey("posts").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.ManyValue.ShouldNotBeEmpty();
            value.Data.ManyValue[0].Type.Should().Be("blogPosts");
            value.Data.ManyValue[0].Id.Should().Be(blog.Posts[0].StringId);
        });

        responseDocument.Included.Should().HaveCount(7);

        responseDocument.Included[0].Type.Should().Be("blogPosts");
        responseDocument.Included[0].Id.Should().Be(blog.Posts[0].StringId);

        responseDocument.Included[0].Relationships.ShouldContainKey("author").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("webAccounts");
            value.Data.SingleValue.Id.Should().Be(blog.Posts[0].Author!.StringId);
        });

        responseDocument.Included[0].Relationships.ShouldContainKey("comments").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.ManyValue.ShouldNotBeEmpty();
            value.Data.ManyValue[0].Type.Should().Be("comments");
            value.Data.ManyValue[0].Id.Should().Be(blog.Posts[0].Comments.ElementAt(0).StringId);
        });

        responseDocument.Included[1].Type.Should().Be("webAccounts");
        responseDocument.Included[1].Id.Should().Be(blog.Posts[0].Author!.StringId);

        responseDocument.Included[1].Relationships.ShouldContainKey("preferences").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("accountPreferences");
            value.Data.SingleValue.Id.Should().Be(blog.Posts[0].Author!.Preferences!.StringId);
        });

        responseDocument.Included[1].Relationships.ShouldContainKey("posts").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.Value.Should().BeNull();
        });

        responseDocument.Included[2].Type.Should().Be("accountPreferences");
        responseDocument.Included[2].Id.Should().Be(blog.Posts[0].Author!.Preferences!.StringId);

        responseDocument.Included[3].Type.Should().Be("comments");
        responseDocument.Included[3].Id.Should().Be(blog.Posts[0].Comments.ElementAt(0).StringId);

        responseDocument.Included[3].Relationships.ShouldContainKey("author").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("webAccounts");
            value.Data.SingleValue.Id.Should().Be(blog.Posts[0].Comments.ElementAt(0).Author!.StringId);
        });

        responseDocument.Included[4].Type.Should().Be("webAccounts");
        responseDocument.Included[4].Id.Should().Be(blog.Posts[0].Comments.ElementAt(0).Author!.StringId);

        responseDocument.Included[4].Relationships.ShouldContainKey("posts").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.ManyValue.ShouldNotBeEmpty();
            value.Data.ManyValue[0].Type.Should().Be("blogPosts");
            value.Data.ManyValue[0].Id.Should().Be(blog.Posts[0].Comments.ElementAt(0).Author!.Posts[0].StringId);
        });

        responseDocument.Included[4].Relationships.ShouldContainKey("preferences").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.Value.Should().BeNull();
        });

        responseDocument.Included[5].Type.Should().Be("blogPosts");
        responseDocument.Included[5].Id.Should().Be(blog.Posts[0].Comments.ElementAt(0).Author!.Posts[0].StringId);

        responseDocument.Included[5].Relationships.ShouldContainKey("author").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.Value.Should().BeNull();
        });

        responseDocument.Included[5].Relationships.ShouldContainKey("comments").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.Value.Should().BeNull();
        });

        responseDocument.Included[6].Type.Should().Be("comments");
        responseDocument.Included[6].Id.Should().Be(blog.Posts[0].Comments.ElementAt(1).StringId);

        responseDocument.Included[5].Relationships.ShouldContainKey("author").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.Value.Should().BeNull();
        });
    }

    [Fact]
    public async Task Can_include_chain_of_relationships_with_reused_resources()
    {
        WebAccount author = _fakers.WebAccount.GenerateOne();
        author.Preferences = _fakers.AccountPreferences.GenerateOne();
        author.LoginAttempts = _fakers.LoginAttempt.GenerateList(1);

        WebAccount reviewer = _fakers.WebAccount.GenerateOne();
        reviewer.Preferences = _fakers.AccountPreferences.GenerateOne();
        reviewer.LoginAttempts = _fakers.LoginAttempt.GenerateList(1);

        BlogPost post1 = _fakers.BlogPost.GenerateOne();
        post1.Author = author;
        post1.Reviewer = reviewer;

        WebAccount person = _fakers.WebAccount.GenerateOne();
        person.Preferences = _fakers.AccountPreferences.GenerateOne();
        person.LoginAttempts = _fakers.LoginAttempt.GenerateList(1);

        BlogPost post2 = _fakers.BlogPost.GenerateOne();
        post2.Author = person;
        post2.Reviewer = person;

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            await dbContext.ClearTableAsync<BlogPost>();
            dbContext.Posts.AddRange(post1, post2);
            await dbContext.SaveChangesAsync();
        });

        const string route = "/blogPosts?include=reviewer.loginAttempts,author.preferences";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.ManyValue.Should().HaveCount(2);

        responseDocument.Data.ManyValue[0].Type.Should().Be("blogPosts");
        responseDocument.Data.ManyValue[0].Id.Should().Be(post1.StringId);

        responseDocument.Data.ManyValue[0].Relationships.ShouldContainKey("author").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("webAccounts");
            value.Data.SingleValue.Id.Should().Be(author.StringId);
        });

        responseDocument.Data.ManyValue[0].Relationships.ShouldContainKey("reviewer").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("webAccounts");
            value.Data.SingleValue.Id.Should().Be(reviewer.StringId);
        });

        responseDocument.Data.ManyValue[1].Type.Should().Be("blogPosts");
        responseDocument.Data.ManyValue[1].Id.Should().Be(post2.StringId);

        responseDocument.Data.ManyValue[1].Relationships.ShouldContainKey("author").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("webAccounts");
            value.Data.SingleValue.Id.Should().Be(person.StringId);
        });

        responseDocument.Data.ManyValue[1].Relationships.ShouldContainKey("reviewer").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("webAccounts");
            value.Data.SingleValue.Id.Should().Be(person.StringId);
        });

        responseDocument.Included.Should().HaveCount(7);

        responseDocument.Included[0].Type.Should().Be("webAccounts");
        responseDocument.Included[0].Id.Should().Be(author.StringId);

        responseDocument.Included[0].Relationships.ShouldContainKey("preferences").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("accountPreferences");
            value.Data.SingleValue.Id.Should().Be(author.Preferences.StringId);
        });

        responseDocument.Included[0].Relationships.ShouldContainKey("loginAttempts").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.Value.Should().BeNull();
        });

        responseDocument.Included[1].Type.Should().Be("accountPreferences");
        responseDocument.Included[1].Id.Should().Be(author.Preferences.StringId);

        responseDocument.Included[2].Type.Should().Be("webAccounts");
        responseDocument.Included[2].Id.Should().Be(reviewer.StringId);

        responseDocument.Included[2].Relationships.ShouldContainKey("preferences").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.Value.Should().BeNull();
        });

        responseDocument.Included[2].Relationships.ShouldContainKey("loginAttempts").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.ManyValue.ShouldNotBeEmpty();
            value.Data.ManyValue[0].Type.Should().Be("loginAttempts");
            value.Data.ManyValue[0].Id.Should().Be(reviewer.LoginAttempts[0].StringId);
        });

        responseDocument.Included[3].Type.Should().Be("loginAttempts");
        responseDocument.Included[3].Id.Should().Be(reviewer.LoginAttempts[0].StringId);

        responseDocument.Included[4].Type.Should().Be("webAccounts");
        responseDocument.Included[4].Id.Should().Be(person.StringId);

        responseDocument.Included[4].Relationships.ShouldContainKey("preferences").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("accountPreferences");
            value.Data.SingleValue.Id.Should().Be(person.Preferences.StringId);
        });

        responseDocument.Included[4].Relationships.ShouldContainKey("loginAttempts").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.ManyValue.ShouldNotBeEmpty();
            value.Data.ManyValue[0].Type.Should().Be("loginAttempts");
            value.Data.ManyValue[0].Id.Should().Be(person.LoginAttempts[0].StringId);
        });

        responseDocument.Included[5].Type.Should().Be("accountPreferences");
        responseDocument.Included[5].Id.Should().Be(person.Preferences.StringId);

        responseDocument.Included[6].Type.Should().Be("loginAttempts");
        responseDocument.Included[6].Id.Should().Be(person.LoginAttempts[0].StringId);
    }

    [Fact]
    public async Task Can_include_chain_with_cyclic_dependency()
    {
        List<BlogPost> posts = _fakers.BlogPost.GenerateList(1);

        Blog blog = _fakers.Blog.GenerateOne();
        blog.Posts = posts;
        blog.Posts[0].Author = _fakers.WebAccount.GenerateOne();
        blog.Posts[0].Author!.Posts = posts;

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Blogs.Add(blog);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/blogs/{blog.StringId}?include=posts.author.posts.author.posts.author";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Type.Should().Be("blogs");
        responseDocument.Data.SingleValue.Id.Should().Be(blog.StringId);

        responseDocument.Data.SingleValue.Relationships.ShouldContainKey("posts").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.ManyValue.ShouldNotBeEmpty();
            value.Data.ManyValue[0].Type.Should().Be("blogPosts");
            value.Data.ManyValue[0].Id.Should().Be(blog.Posts[0].StringId);
        });

        responseDocument.Included.Should().HaveCount(2);

        responseDocument.Included[0].Type.Should().Be("blogPosts");
        responseDocument.Included[0].Id.Should().Be(blog.Posts[0].StringId);

        responseDocument.Included[0].Relationships.ShouldContainKey("author").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("webAccounts");
            value.Data.SingleValue.Id.Should().Be(blog.Posts[0].Author!.StringId);
        });

        responseDocument.Included[1].Type.Should().Be("webAccounts");
        responseDocument.Included[1].Id.Should().Be(blog.Posts[0].Author!.StringId);

        responseDocument.Included[1].Relationships.ShouldContainKey("posts").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.ManyValue.ShouldNotBeEmpty();
            value.Data.ManyValue[0].Type.Should().Be("blogPosts");
            value.Data.ManyValue[0].Id.Should().Be(blog.Posts[0].StringId);
        });
    }

    [Fact]
    public async Task Prevents_duplicate_includes_over_single_resource()
    {
        // Arrange
        WebAccount account = _fakers.WebAccount.GenerateOne();

        BlogPost post = _fakers.BlogPost.GenerateOne();
        post.Author = account;
        post.Reviewer = account;

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/blogPosts/{post.StringId}?include=author&include=reviewer";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Id.Should().Be(post.StringId);
        responseDocument.Data.SingleValue.Attributes.ShouldContainKey("caption").With(value => value.Should().Be(post.Caption));

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("webAccounts");
        responseDocument.Included[0].Id.Should().Be(account.StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("userName").With(value => value.Should().Be(account.UserName));
    }

    [Fact]
    public async Task Prevents_duplicate_includes_over_multiple_resources()
    {
        // Arrange
        WebAccount account = _fakers.WebAccount.GenerateOne();

        List<BlogPost> posts = _fakers.BlogPost.GenerateList(2);
        posts[0].Author = account;
        posts[1].Author = account;

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            await dbContext.ClearTableAsync<BlogPost>();
            dbContext.Posts.AddRange(posts);
            await dbContext.SaveChangesAsync();
        });

        const string route = "/blogPosts?include=author";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.ManyValue.Should().HaveCount(2);

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("webAccounts");
        responseDocument.Included[0].Id.Should().Be(account.StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("userName").With(value => value.Should().Be(account.UserName));
    }

    [Fact]
    public async Task Can_select_empty_includes()
    {
        // Arrange
        WebAccount account = _fakers.WebAccount.GenerateOne();

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Accounts.Add(account);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/webAccounts/{account.StringId}?include=";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();

        responseDocument.Included.Should().BeEmpty();
    }

    [Fact]
    public async Task Cannot_include_unknown_relationship()
    {
        // Arrange
        var parameterValue = new MarkedText($"^{Unknown.Relationship}", '^');
        string route = $"/webAccounts?include={parameterValue.Text}";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.BadRequest);

        responseDocument.Errors.Should().HaveCount(1);

        ErrorObject error = responseDocument.Errors[0];
        error.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        error.Title.Should().Be("The specified include is invalid.");
        error.Detail.Should().Be($"Relationship '{Unknown.Relationship}' does not exist on resource type 'webAccounts'. {parameterValue}");
        error.Source.ShouldNotBeNull();
        error.Source.Parameter.Should().Be("include");
    }

    [Fact]
    public async Task Cannot_include_unknown_nested_relationship()
    {
        // Arrange
        var parameterValue = new MarkedText($"posts.^{Unknown.Relationship}", '^');
        string route = $"/blogs?include={parameterValue.Text}";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.BadRequest);

        responseDocument.Errors.Should().HaveCount(1);

        ErrorObject error = responseDocument.Errors[0];
        error.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        error.Title.Should().Be("The specified include is invalid.");
        error.Detail.Should().Be($"Relationship '{Unknown.Relationship}' does not exist on resource type 'blogPosts'. {parameterValue}");
        error.Source.ShouldNotBeNull();
        error.Source.Parameter.Should().Be("include");
    }

    [Fact]
    public async Task Cannot_include_relationship_when_inclusion_blocked()
    {
        // Arrange
        var parameterValue = new MarkedText("^parent", '^');
        string route = $"/blogPosts?include={parameterValue.Text}";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.BadRequest);

        responseDocument.Errors.Should().HaveCount(1);

        ErrorObject error = responseDocument.Errors[0];
        error.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        error.Title.Should().Be("The specified include is invalid.");
        error.Detail.Should().Be($"Including the relationship 'parent' on 'blogPosts' is not allowed. {parameterValue}");
        error.Source.ShouldNotBeNull();
        error.Source.Parameter.Should().Be("include");
    }

    [Fact]
    public async Task Cannot_include_relationship_when_nested_inclusion_blocked()
    {
        // Arrange
        var parameterValue = new MarkedText("posts.^parent", '^');
        string route = $"/blogs?include={parameterValue.Text}";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.BadRequest);

        responseDocument.Errors.Should().HaveCount(1);

        ErrorObject error = responseDocument.Errors[0];
        error.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        error.Title.Should().Be("The specified include is invalid.");
        error.Detail.Should().Be($"Including the relationship 'parent' on 'blogPosts' is not allowed. {parameterValue}");
        error.Source.ShouldNotBeNull();
        error.Source.Parameter.Should().Be("include");
    }

    [Fact]
    public async Task Hides_relationship_and_related_resources_when_viewing_blocked()
    {
        // Arrange
        Calendar calendar = _fakers.Calendar.GenerateOne();
        calendar.Appointments = _fakers.Appointment.GenerateSet(2);

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Calendars.Add(calendar);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/calendars/{calendar.StringId}?include=appointments";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Type.Should().Be("calendars");
        responseDocument.Data.SingleValue.Id.Should().Be(calendar.StringId);

        responseDocument.Data.SingleValue.Relationships.ShouldNotBeEmpty();
        responseDocument.Data.SingleValue.Relationships.Should().NotContainKey("appointments");

        responseDocument.Included.Should().BeEmpty();
    }

    [Fact]
    public async Task Hides_relationship_but_includes_related_resource_when_viewing_blocked_but_accessible_via_other_path()
    {
        // Arrange
        Calendar calendar = _fakers.Calendar.GenerateOne();
        calendar.MostRecentAppointment = _fakers.Appointment.GenerateOne();

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Calendars.Add(calendar);
            await dbContext.SaveChangesAsync();

            calendar.Appointments = new[]
            {
                _fakers.Appointment.GenerateOne(),
                calendar.MostRecentAppointment
            }.ToHashSet();

            await dbContext.SaveChangesAsync();
        });

        string route = $"/calendars/{calendar.StringId}?include=appointments,mostRecentAppointment";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.SingleValue.ShouldNotBeNull();
        responseDocument.Data.SingleValue.Type.Should().Be("calendars");
        responseDocument.Data.SingleValue.Id.Should().Be(calendar.StringId);

        responseDocument.Data.SingleValue.Relationships.ShouldContainKey("mostRecentAppointment").With(value =>
        {
            value.ShouldNotBeNull();
            value.Data.SingleValue.ShouldNotBeNull();
            value.Data.SingleValue.Type.Should().Be("appointments");
            value.Data.SingleValue.Id.Should().Be(calendar.MostRecentAppointment.StringId);
        });

        responseDocument.Data.SingleValue.Relationships.Should().NotContainKey("appointments");

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("appointments");
        responseDocument.Included[0].Id.Should().Be(calendar.MostRecentAppointment.StringId);
    }

    [Fact]
    public async Task Ignores_null_parent_in_nested_include()
    {
        // Arrange
        List<BlogPost> posts = _fakers.BlogPost.GenerateList(2);
        posts[0].Reviewer = _fakers.WebAccount.GenerateOne();

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            await dbContext.ClearTableAsync<BlogPost>();
            dbContext.Posts.AddRange(posts);
            await dbContext.SaveChangesAsync();
        });

        const string route = "/blogPosts?include=reviewer.preferences";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);

        responseDocument.Data.ManyValue.Should().HaveCount(2);

        responseDocument.Data.ManyValue.Should().OnlyContain(resource => resource.Relationships.ShouldContainKey("reviewer") != null);

        ResourceObject[] postWithReviewer = responseDocument.Data.ManyValue
            .Where(resource => resource.Relationships!.First(pair => pair.Key == "reviewer").Value!.Data.SingleValue != null).ToArray();

        postWithReviewer.Should().HaveCount(1);
        postWithReviewer[0].Attributes.ShouldContainKey("caption").With(value => value.Should().Be(posts[0].Caption));

        ResourceObject[] postWithoutReviewer = responseDocument.Data.ManyValue
            .Where(resource => resource.Relationships!.First(pair => pair.Key == "reviewer").Value!.Data.SingleValue == null).ToArray();

        postWithoutReviewer.Should().HaveCount(1);
        postWithoutReviewer[0].Attributes.ShouldContainKey("caption").With(value => value.Should().Be(posts[1].Caption));

        responseDocument.Included.Should().HaveCount(1);
        responseDocument.Included[0].Type.Should().Be("webAccounts");
        responseDocument.Included[0].Id.Should().Be(posts[0].Reviewer!.StringId);
        responseDocument.Included[0].Attributes.ShouldContainKey("userName").With(value => value.Should().Be(posts[0].Reviewer!.UserName));
    }

    [Fact]
    public async Task Can_include_at_configured_maximum_inclusion_depth()
    {
        // Arrange
        var options = (JsonApiOptions)_testContext.Factory.Services.GetRequiredService<IJsonApiOptions>();
        options.MaximumIncludeDepth = 1;

        Blog blog = _fakers.Blog.GenerateOne();

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Blogs.Add(blog);
            await dbContext.SaveChangesAsync();
        });

        string route = $"/blogs/{blog.StringId}/posts?include=author,comments";

        // Act
        (HttpResponseMessage httpResponse, _) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Cannot_exceed_configured_maximum_inclusion_depth()
    {
        // Arrange
        var options = (JsonApiOptions)_testContext.Factory.Services.GetRequiredService<IJsonApiOptions>();
        options.MaximumIncludeDepth = 1;

        var parameterValue = new MarkedText("^posts.comments", '^');
        string route = $"/blogs/123/owner?include={parameterValue.Text}";

        // Act
        (HttpResponseMessage httpResponse, Document responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

        // Assert
        httpResponse.ShouldHaveStatusCode(HttpStatusCode.BadRequest);

        responseDocument.Errors.Should().HaveCount(1);

        ErrorObject error = responseDocument.Errors[0];
        error.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        error.Title.Should().Be("The specified include is invalid.");
        error.Detail.Should().Be($"Including 'posts.comments' exceeds the maximum inclusion depth of 1. {parameterValue}");
        error.Source.ShouldNotBeNull();
        error.Source.Parameter.Should().Be("include");
    }
}
