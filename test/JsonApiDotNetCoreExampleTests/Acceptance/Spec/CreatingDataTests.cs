using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Serialization.Objects;
using JsonApiDotNetCoreExample;
using JsonApiDotNetCoreExample.Data;
using JsonApiDotNetCoreExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Person = JsonApiDotNetCoreExample.Models.Person;

namespace JsonApiDotNetCoreExampleTests.Acceptance.Spec
{
    public sealed class CreatingDataTests : IClassFixture<IntegrationTestContext<Startup, AppDbContext>>
    {
        private readonly IntegrationTestContext<Startup, AppDbContext> _testContext;

        private readonly Faker<TodoItem> _todoItemFaker = new Faker<TodoItem>()
            .RuleFor(t => t.Description, f => f.Lorem.Sentence())
            .RuleFor(t => t.Ordinal, f => f.Random.Number())
            .RuleFor(t => t.CreatedDate, f => f.Date.Past());

        private readonly Faker<Person> _personFaker = new Faker<Person>()
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName());

        public CreatingDataTests(IntegrationTestContext<Startup, AppDbContext> testContext)
        {
            _testContext = testContext;

            var options = (JsonApiOptions) testContext.Factory.Services.GetRequiredService<IJsonApiOptions>();
            options.AllowClientGeneratedIds = false;
        }

        [Fact]
        public async Task CreateResource_ModelWithEntityFrameworkInheritance_IsCreated()
        {
            // Arrange
            var requestBody = new
            {
                data = new
                {
                    type = "superUsers",
                    attributes = new
                    {
                        securityLevel = 1337,
                        userName = "Jack",
                        password = "secret"
                    }
                }
            };

            var route = "/api/v1/superUsers";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            responseDocument.SingleData.Should().NotBeNull();
            responseDocument.SingleData.Attributes["securityLevel"].Should().Be(1337);
            responseDocument.SingleData.Attributes["userName"].Should().Be("Jack");

            var newSuperUserId = responseDocument.SingleData.Id;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var superUserInDatabase = await dbContext.Set<SuperUser>()
                    .Where(superUser => superUser.Id == int.Parse(newSuperUserId))
                    .SingleAsync();

                superUserInDatabase.Password.Should().Be("secret");
            });
        }

        [Fact]
        public async Task CreateResource_GuidResource_IsCreated()
        {
            // Arrange
            var requestBody = new
            {
                data = new
                {
                    type = "todoCollections",
                    attributes = new
                    {
                        name = "Jack"
                    }
                }
            };

            var route = "/api/v1/todoCollections";

            // Act
            var (httpResponse, _) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);
        }

        [Fact]
        public async Task ClientGeneratedId_IntegerIdAndNotEnabled_IsForbidden()
        {
            // Arrange
            var requestBody = new
            {
                data = new
                {
                    type = "todoItems",
                    id = "9999",
                    attributes = new
                    {
                        description = "some",
                    }
                }
            };

            var route = "/api/v1/todoItems";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<ErrorDocument>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Forbidden);

            responseDocument.Errors.Should().HaveCount(1);
            responseDocument.Errors[0].StatusCode.Should().Be(HttpStatusCode.Forbidden);
            responseDocument.Errors[0].Title.Should().Be("Specifying the resource ID in POST requests is not allowed.");
            responseDocument.Errors[0].Detail.Should().BeNull();
        }

        [Fact]
        public async Task CreateWithRelationship_HasMany_IsCreated()
        {
            // Arrange
            var existingTodoItem = _todoItemFaker.Generate();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.TodoItems.Add(existingTodoItem);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "todoCollections",
                    relationships = new
                    {
                        todoItems = new
                        {
                            data = new[]
                            {
                                new
                                {
                                    type = "todoItems",
                                    id = existingTodoItem.StringId
                                }
                            }
                        }
                    }
                }
            };

            var route = "/api/v1/todoCollections";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            var newTodoCollectionId = responseDocument.SingleData.Id;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var todoCollectionsInDatabase = await dbContext.TodoItemCollections
                    .Include(collection => collection.TodoItems)
                    .ToListAsync();

                var newTodoCollectionInDatabase = todoCollectionsInDatabase.Single(c => c.StringId == newTodoCollectionId);
                newTodoCollectionInDatabase.TodoItems.Should().HaveCount(1);
                newTodoCollectionInDatabase.TodoItems.ElementAt(0).Id.Should().Be(existingTodoItem.Id);
            });
        }

        [Fact]
        public async Task CreateWithRelationship_HasManyAndInclude_IsCreatedAndIncluded()
        {
            // Arrange
            var existingTodoItem = _todoItemFaker.Generate();
            existingTodoItem.Owner = _personFaker.Generate();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.TodoItems.Add(existingTodoItem);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "todoCollections",
                    relationships = new
                    {
                        todoItems = new
                        {
                            data = new[]
                            {
                                new
                                {
                                    type = "todoItems",
                                    id = existingTodoItem.StringId
                                }
                            }
                        }
                    }
                }
            };

            var route = "/api/v1/todoCollections?include=todoItems";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            responseDocument.SingleData.Should().NotBeNull();

            responseDocument.Included.Should().HaveCount(1);
            responseDocument.Included[0].Type.Should().Be("todoItems");
            responseDocument.Included[0].Id.Should().Be(existingTodoItem.StringId);
            responseDocument.Included[0].Attributes["description"].Should().Be(existingTodoItem.Description);
        }

        [Fact]
        public async Task CreateWithRelationship_HasManyAndIncludeAndSparseFieldset_IsCreatedAndIncluded()
        {
            // Arrange
            var existingTodoItem = _todoItemFaker.Generate();
            existingTodoItem.Owner = _personFaker.Generate();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.TodoItems.Add(existingTodoItem);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "todoCollections",
                    attributes = new
                    {
                        name = "Jack"
                    },
                    relationships = new
                    {
                        todoItems = new
                        {
                            data = new[]
                            {
                                new
                                {
                                    type = "todoItems",
                                    id = existingTodoItem.StringId
                                }
                            }
                        },
                        owner = new
                        {
                            data = new
                            {
                                type = "people",
                                id = existingTodoItem.Owner.StringId
                            }
                        }
                    }
                }
            };

            var route = "/api/v1/todoCollections?include=todoItems&fields=name&fields[todoItems]=ordinal";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            responseDocument.SingleData.Should().NotBeNull();
            responseDocument.SingleData.Attributes["name"].Should().Be("Jack");

            responseDocument.Included.Should().HaveCount(1);
            responseDocument.Included[0].Type.Should().Be("todoItems");
            responseDocument.Included[0].Id.Should().Be(existingTodoItem.StringId);
            responseDocument.Included[0].Attributes["ordinal"].Should().Be(existingTodoItem.Ordinal);
            responseDocument.Included[0].Attributes.Should().NotContainKey("description");
        }

        [Fact]
        public async Task CreateWithRelationship_HasOne_IsCreated()
        {
            // Arrange
            var existingOwner = _personFaker.Generate();
            
            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.People.Add(existingOwner);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "todoItems",
                    relationships = new
                    {
                        owner = new
                        {
                            data = new
                            {
                                type = "people",
                                id = existingOwner.StringId
                            }
                        }
                    }
                }
            };

            var route = "/api/v1/todoItems";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            var newTodoItemId = responseDocument.SingleData.Id;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var todoItemInDatabase = await dbContext.TodoItems
                    .Include(item => item.Owner)
                    .Where(item => item.Id == int.Parse(newTodoItemId))
                    .SingleAsync();

                todoItemInDatabase.Owner.Id.Should().Be(existingOwner.Id);
            });
        }

        [Fact]
        public async Task CreateWithRelationship_HasOneAndInclude_IsCreatedAndIncluded()
        {
            // Arrange
            var existingOwner = _personFaker.Generate();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.People.Add(existingOwner);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "todoItems",
                    attributes = new
                    {
                        description = "some"
                    },
                    relationships = new
                    {
                        owner = new
                        {
                            data = new
                            {
                                type = "people",
                                id = existingOwner.StringId
                            }
                        }
                    }
                }
            };

            var route = "/api/v1/todoItems?include=owner";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            responseDocument.SingleData.Should().NotBeNull();
            responseDocument.SingleData.Attributes["description"].Should().Be("some");

            responseDocument.Included.Should().HaveCount(1);
            responseDocument.Included[0].Type.Should().Be("people");
            responseDocument.Included[0].Id.Should().Be(existingOwner.StringId);
            responseDocument.Included[0].Attributes["firstName"].Should().Be(existingOwner.FirstName);
            responseDocument.Included[0].Attributes["lastName"].Should().Be(existingOwner.LastName);
        }

        [Fact]
        public async Task CreateWithRelationship_HasOneAndIncludeAndSparseFieldset_IsCreatedAndIncluded()
        {
            // Arrange
            var existingOwner = _personFaker.Generate();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.People.Add(existingOwner);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "todoItems",
                    attributes = new
                    {
                        ordinal = 123,
                        description = "some"
                    },
                    relationships = new
                    {
                        owner = new
                        {
                            data = new
                            {
                                type = "people",
                                id = existingOwner.StringId
                            }
                        }
                    }
                }
            };

            var route = "/api/v1/todoItems?include=owner&fields=ordinal&fields[owner]=firstName";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            responseDocument.SingleData.Should().NotBeNull();
            responseDocument.SingleData.Attributes["ordinal"].Should().Be(123);
            responseDocument.SingleData.Attributes.Should().NotContainKey("description");

            responseDocument.Included.Should().HaveCount(1);
            responseDocument.Included[0].Type.Should().Be("people");
            responseDocument.Included[0].Id.Should().Be(existingOwner.StringId);
            responseDocument.Included[0].Attributes["firstName"].Should().Be(existingOwner.FirstName);
            responseDocument.Included[0].Attributes.Should().NotContainKey("lastName");
        }

        [Fact]
        public async Task CreateWithRelationship_HasOneFromIndependentSide_IsCreated()
        {
            // Arrange
            var existingPerson = new Person();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.People.Add(existingPerson);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "personRoles",
                    relationships = new
                    {
                        person = new
                        {
                            data = new
                            {
                                type = "people",
                                id = existingPerson.StringId
                            }
                        }
                    }
                }
            };

            var route = "/api/v1/personRoles";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            var newPersonRoleId = responseDocument.SingleData.Id;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var personRoleInDatabase = await dbContext.PersonRoles
                    .Include(role => role.Person)
                    .Where(role => role.Id == int.Parse(newPersonRoleId))
                    .SingleAsync();

                personRoleInDatabase.Person.Id.Should().Be(existingPerson.Id);
            });
        }

        [Fact]
        public async Task CreateResource_SimpleResource_HeaderLocationsAreCorrect()
        {
            // Arrange
            var todoItem = _todoItemFaker.Generate();

            var requestBody = new
            {
                data = new
                {
                    type = "todoItems",
                    attributes = new
                    {
                        createdDate = todoItem.CreatedDate,
                        description = todoItem.Description,
                        ordinal = todoItem.Ordinal
                    }
                }
            };

            var route = "/api/v1/todoItems";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            var newTodoItemId = responseDocument.SingleData.Id;
            httpResponse.Headers.Location.Should().Be("/api/v1/todoItems/" + newTodoItemId);
        }

        [Fact]
        public async Task CreateResource_UnknownResourceType_Fails()
        {
            // Arrange
            var requestBody = new
            {
                data = new
                {
                    type = "something"
                }
            };

            var route = "/api/v1/todoItems";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<ErrorDocument>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.UnprocessableEntity);

            responseDocument.Errors.Should().HaveCount(1);
            responseDocument.Errors[0].StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
            responseDocument.Errors[0].Title.Should().Be("Failed to deserialize request body: Payload includes unknown resource type.");
            responseDocument.Errors[0].Detail.Should().StartWith("The resource 'something' is not registered on the resource graph.");
            responseDocument.Errors[0].Detail.Should().Contain("Request body: <<");
        }

        [Fact]
        public async Task CreateResource_Blocked_Fails()
        {
            // Arrange
            var requestBody = new
            {
                data = new
                {
                    type = "todoItems",
                    attributes = new Dictionary<string, object>
                    {
                        ["alwaysChangingValue"] = "X"
                    }
                }
            };

            var route = "/api/v1/todoItems";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<ErrorDocument>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.UnprocessableEntity);

            responseDocument.Errors.Should().HaveCount(1);
            responseDocument.Errors[0].StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
            responseDocument.Errors[0].Title.Should().Be("Failed to deserialize request body: Assigning to the requested attribute is not allowed.");
            responseDocument.Errors[0].Detail.Should().StartWith("Assigning to 'alwaysChangingValue' is not allowed. - Request body:");
        }

        [Fact]
        public async Task CreateRelationship_ToOneWithImplicitRemove_IsCreated()
        {
            // Arrange
            var existingPerson = _personFaker.Generate();

            Passport passport = null;
            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                await dbContext.ClearTableAsync<Person>();

                passport = new Passport(dbContext);
                existingPerson.Passport = passport;

                dbContext.People.Add(existingPerson);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "people",
                    relationships = new
                    {
                        passport = new
                        {
                            data = new
                            {
                                type = "passports",
                                id = passport.StringId
                            }
                        }
                    }
                }
            };

            var route = "/api/v1/people";
            
            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            var newPersonId = responseDocument.SingleData.Id;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var personsInDatabase = await dbContext.People
                    .Include(p => p.Passport)
                    .ToListAsync();

                var existingPersonInDatabase = personsInDatabase.Single(p => p.Id == existingPerson.Id);
                existingPersonInDatabase.Passport.Should().BeNull();

                var newPersonInDatabase = personsInDatabase.Single(p => p.StringId == newPersonId);
                newPersonInDatabase.Passport.Id.Should().Be(passport.Id);
            });
        }

        [Fact]
        public async Task CreateRelationship_ToManyWithImplicitRemove_IsCreated()
        {
            // Arrange
            var todoItems = _todoItemFaker.Generate(3);

            var existingPerson = _personFaker.Generate();
            existingPerson.TodoItems = todoItems.ToHashSet();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.People.Add(existingPerson);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "people",
                    relationships = new
                    {
                        todoItems = new
                        {
                            data = new[]
                            {
                                new
                                {
                                    type = "todoItems",
                                    id = todoItems[0].StringId
                                },
                                new
                                {
                                    type = "todoItems",
                                    id = todoItems[1].StringId
                                }
                            }
                        }
                    }
                }
            };

            var route = "/api/v1/people";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            var newPersonId = responseDocument.SingleData.Id;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var personsInDatabase = await dbContext.People
                    .Include(p => p.TodoItems)
                    .ToListAsync();

                var existingPersonInDatabase = personsInDatabase.Single(p => p.Id == existingPerson.Id);
                existingPersonInDatabase.TodoItems.Should().HaveCount(1);
                existingPersonInDatabase.TodoItems.Should().ContainSingle(item => item.Id == todoItems[2].Id);

                var newPersonInDatabase = personsInDatabase.Single(p => p.StringId == newPersonId);
                newPersonInDatabase.TodoItems.Should().HaveCount(2);
                newPersonInDatabase.TodoItems.Should().ContainSingle(item => item.Id == todoItems[0].Id);
                newPersonInDatabase.TodoItems.Should().ContainSingle(item => item.Id == todoItems[1].Id);
            });
        }
    }
}
