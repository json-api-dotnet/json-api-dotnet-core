﻿using Microsoft.Extensions.Logging;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using JsonApiDotNetCoreTests.IntegrationTests.QueryStrings;

namespace JsonApiDotNetCoreTests.IntegrationTests.QueryStrings;

public sealed partial class BlogPostsController : JsonApiController<BlogPost, int>
{
    public BlogPostsController(IJsonApiOptions options, IResourceGraph resourceGraph, ILoggerFactory loggerFactory,
        IResourceService<BlogPost, int> resourceService)
        : base(options, resourceGraph, loggerFactory, resourceService)
    {
    }
}
