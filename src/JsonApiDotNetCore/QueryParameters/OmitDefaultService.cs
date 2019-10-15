using System.Collections.Generic;
using JsonApiDotNetCore.Configuration;
using Microsoft.Extensions.Primitives;

namespace JsonApiDotNetCore.Query
{
    public class OmitDefaultService : QueryParameterService, IOmitDefaultService
    {
        private readonly IJsonApiOptions _options;

        public OmitDefaultService(IJsonApiOptions options)
        {
            Config = options.DefaultAttributeResponseBehavior.OmitDefaultValuedAttributes;
            _options = options;
        }

        public bool Config { get; private set; }

        public override void Parse(KeyValuePair<string, StringValues> queryParameter)
        {
            if (!_options.DefaultAttributeResponseBehavior.AllowClientOverride)
                return;

            if (!bool.TryParse(queryParameter.Value, out var config))
                return;

            Config = config;
        }
    }
}
