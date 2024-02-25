// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Store;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Form;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Multipart;
using Microsoft.Kiota.Serialization.Text;
using OpenApiKiotaClientExample.GeneratedCode.Api;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode {
    /// <summary>
    /// The main entry point of the SDK, exposes the configuration and the fluent API.
    /// </summary>
    public class ExampleApiClient : BaseRequestBuilder {
        /// <summary>The api property</summary>
        public ApiRequestBuilder Api { get =>
            new ApiRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new ExampleApiClient and sets the default values.
        /// </summary>
        /// <param name="backingStore">The backing store to use for the models.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ExampleApiClient(IRequestAdapter requestAdapter, IBackingStoreFactory backingStore = default) : base(requestAdapter, "{+baseurl}", new Dictionary<string, object>()) {
            ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<TextSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<FormSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<MultipartSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<TextParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<FormParseNodeFactory>();
            if (string.IsNullOrEmpty(RequestAdapter.BaseUrl)) {
                RequestAdapter.BaseUrl = "https://localhost:44340";
            }
            PathParameters.TryAdd("baseurl", RequestAdapter.BaseUrl);
            RequestAdapter.EnableBackingStore(backingStore);
        }
    }
}
