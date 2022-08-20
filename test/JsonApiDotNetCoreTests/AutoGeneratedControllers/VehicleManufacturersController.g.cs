﻿using Microsoft.Extensions.Logging;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using JsonApiDotNetCoreTests.IntegrationTests.ResourceInheritance.Models;

namespace JsonApiDotNetCoreTests.IntegrationTests.ResourceInheritance;

public sealed partial class VehicleManufacturersController : JsonApiController<VehicleManufacturer, long>
{
    public VehicleManufacturersController(IJsonApiOptions options, IResourceGraph resourceGraph, ILoggerFactory loggerFactory,
        IResourceService<VehicleManufacturer, long> resourceService)
        : base(options, resourceGraph, loggerFactory, resourceService)
    {
    }
}
