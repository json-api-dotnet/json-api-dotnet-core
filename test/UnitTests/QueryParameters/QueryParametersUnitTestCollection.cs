﻿using System;
using JsonApiDotNetCore.Builders;
using JsonApiDotNetCore.Internal;
using JsonApiDotNetCore.Internal.Contracts;
using JsonApiDotNetCore.Managers.Contracts;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Query;
using Moq;
using UnitTests.TestModels;

namespace UnitTests.QueryParameters
{
    public class QueryParametersUnitTestCollection
    {
        protected readonly ContextEntity _articleResourceContext;
        protected readonly IResourceGraph _graph;

        public QueryParametersUnitTestCollection()
        {
            var builder = new ResourceGraphBuilder();
            builder.AddResource<Article>();
            builder.AddResource<Person>();
            builder.AddResource<Blog>();
            builder.AddResource<Food>();
            builder.AddResource<Song>();
            _graph = builder.Build();
            _articleResourceContext = _graph.GetContextEntity<Article>();
        }

        public ICurrentRequest MockCurrentRequest(ContextEntity requestResource = null)
        {
            var mock = new Mock<ICurrentRequest>();

            if (requestResource != null)
                mock.Setup(m => m.GetRequestResource()).Returns(requestResource);

            return mock.Object;
        }

        public IResourceDefinitionProvider MockResourceDefinitionProvider(params (Type, IResourceDefinition)[] rds)
        {
            var mock = new Mock<IResourceDefinitionProvider>();

            foreach (var (type, resourceDefinition) in rds)
                mock.Setup(m => m.Get(type)).Returns(resourceDefinition);

            return mock.Object;
        }
    }
}