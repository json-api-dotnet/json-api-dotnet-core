using System.Collections.Generic;
using System.Linq;
using Bogus;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Hooks.Internal.Execution;
using JsonApiDotNetCoreExample.Models;
using Microsoft.Extensions.Logging.Abstractions;
using Person = JsonApiDotNetCoreExample.Models.Person;

namespace UnitTests.ResourceHooks
{
    public class HooksDummyData
    {
        protected IResourceGraph ResourceGraph { get; }
        protected ResourceHook[] NoHooks { get; } = new ResourceHook[0];
        protected ResourceHook[] EnableDbValues { get; } = { ResourceHook.BeforeUpdate, ResourceHook.BeforeUpdateRelationship };
        protected ResourceHook[] DisableDbValues { get; } = new ResourceHook[0];
        protected readonly Faker<TodoItem> _todoFaker;
        protected readonly Faker<Person> _personFaker;
        protected readonly Faker<Article> _articleFaker;
        protected readonly Faker<Tag> _tagFaker;
        protected readonly Faker<ArticleTag> _articleTagFaker;
        protected readonly Faker<IdentifiableArticleTag> _identifiableArticleTagFaker;
        protected readonly Faker<Passport> _passportFaker;

        public HooksDummyData()
        {
            ResourceGraph = new ResourceGraphBuilder(new JsonApiOptions(), NullLoggerFactory.Instance)
                .Add<TodoItem>()
                .Add<Person>()
                .Add<Passport>()
                .Add<Article>()
                .Add<IdentifiableArticleTag>()
                .Add<Tag>()
                .Build();

            // @formatter:wrap_chained_method_calls chop_always
            // @formatter:keep_existing_linebreaks true

            _todoFaker = new Faker<TodoItem>()
                .RuleFor(x => x.Id, f => f.UniqueIndex + 1);

            _personFaker = new Faker<Person>()
                .RuleFor(x => x.Id, f => f.UniqueIndex + 1);

            _articleFaker = new Faker<Article>()
                .RuleFor(x => x.Id, f => f.UniqueIndex + 1);

            _tagFaker = new Faker<Tag>()
                .RuleFor(x => x.Id, f => f.UniqueIndex + 1);

            _articleTagFaker = new Faker<ArticleTag>();

            _identifiableArticleTagFaker = new Faker<IdentifiableArticleTag>()
                .RuleFor(x => x.Id, f => f.UniqueIndex + 1);

            _passportFaker = new Faker<Passport>()
                .RuleFor(x => x.Id, f => f.UniqueIndex + 1);

            // @formatter:wrap_chained_method_calls restore
            // @formatter:keep_existing_linebreaks restore
        }

        protected List<TodoItem> CreateTodoWithToOnePerson()
        {
            var todoItem = _todoFaker.Generate();
            var person = _personFaker.Generate();
            var todoList = new List<TodoItem> { todoItem };
            person.OneToOneTodoItem = todoItem;
            todoItem.OneToOnePerson = person;
            return todoList;
        }

        protected HashSet<TodoItem> CreateTodoWithOwner()
        {
            var todoItem = _todoFaker.Generate();
            var person = _personFaker.Generate();
            var todoList = new HashSet<TodoItem> { todoItem };
            person.AssignedTodoItems = todoList;
            todoItem.Owner = person;
            return todoList;
        }

        protected (List<Article>, List<ArticleTag>, List<Tag>) CreateManyToManyData()
        {
            var tagsSubset = _tagFaker.Generate(3);
            var joinsSubSet = _articleTagFaker.Generate(3);
            var articleTagsSubset = _articleFaker.Generate();
            articleTagsSubset.ArticleTags = joinsSubSet.ToHashSet();
            for (int i = 0; i < 3; i++)
            {
                joinsSubSet[i].Article = articleTagsSubset;
                joinsSubSet[i].Tag = tagsSubset[i];
            }

            var allTags = _tagFaker.Generate(3).Concat(tagsSubset).ToList();
            var completeJoin = _articleTagFaker.Generate(6);

            var articleWithAllTags = _articleFaker.Generate();
            articleWithAllTags.ArticleTags = completeJoin.ToHashSet();

            for (int i = 0; i < 6; i++)
            {
                completeJoin[i].Article = articleWithAllTags;
                completeJoin[i].Tag = allTags[i];
            }

            var allJoins = joinsSubSet.Concat(completeJoin).ToList();

            var articles = new List<Article> { articleTagsSubset, articleWithAllTags };
            return (articles, allJoins, allTags);
        }

        protected (List<Article>, List<IdentifiableArticleTag>, List<Tag>) CreateIdentifiableManyToManyData()
        {
            var tagsSubset = _tagFaker.Generate(3);
            var joinsSubSet = _identifiableArticleTagFaker.Generate(3);
            var articleTagsSubset = _articleFaker.Generate();
            articleTagsSubset.IdentifiableArticleTags = joinsSubSet.ToHashSet();
            for (int i = 0; i < 3; i++)
            {
                joinsSubSet[i].Article = articleTagsSubset;
                joinsSubSet[i].Tag = tagsSubset[i];
            }
            var allTags = _tagFaker.Generate(3).Concat(tagsSubset).ToList();
            var completeJoin = _identifiableArticleTagFaker.Generate(6);

            var articleWithAllTags = _articleFaker.Generate();
            articleWithAllTags.IdentifiableArticleTags = joinsSubSet.ToHashSet();

            for (int i = 0; i < 6; i++)
            {
                completeJoin[i].Article = articleWithAllTags;
                completeJoin[i].Tag = allTags[i];
            }

            var allJoins = joinsSubSet.Concat(completeJoin).ToList();
            var articles = new List<Article> { articleTagsSubset, articleWithAllTags };
            return (articles, allJoins, allTags);
        }
    }
}
