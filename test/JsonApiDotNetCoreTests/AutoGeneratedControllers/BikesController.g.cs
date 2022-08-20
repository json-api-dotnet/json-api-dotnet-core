﻿using Microsoft.Extensions.Logging;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using JsonApiDotNetCoreTests.IntegrationTests.ResourceInheritance.Models;

namespace JsonApiDotNetCoreTests.IntegrationTests.ResourceInheritance;

public sealed partial class BikesController : JsonApiController<Bike, long>
{
    public BikesController(IJsonApiOptions options, IResourceGraph resourceGraph, ILoggerFactory loggerFactory,
        IResourceService<Bike, long> resourceService)
        : base(options, resourceGraph, loggerFactory, resourceService)
    {
    }
}
