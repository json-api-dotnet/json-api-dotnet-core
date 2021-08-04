using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Controllers.Annotations;
using JsonApiDotNetCore.QueryStrings;
using JsonApiDotNetCore.Services;
using Microsoft.Extensions.Logging;

namespace JsonApiDotNetCoreExampleTests.IntegrationTests.RestrictedControllers
{
    [NoHttpDelete]
    [DisableQueryString(JsonApiQueryStringParameters.Sort | JsonApiQueryStringParameters.Page)]
    public sealed class BlockingHttpDeleteController : JsonApiController<Sofa>
    {
        public BlockingHttpDeleteController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<Sofa> resourceService)
            : base(options, loggerFactory, resourceService)
        {
        }
    }
}
