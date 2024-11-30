// <auto-generated/>
#nullable enable
#pragma warning disable CS8625
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models;
using OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels
{
    /// <summary>
    /// Builds and executes requests for operations under \writeOnlyChannels
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class WriteOnlyChannelsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.writeOnlyChannels.item collection</summary>
        /// <param name="position">The identifier of the writeOnlyChannel to update.</param>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.WriteOnlyChannelsItemRequestBuilder"/></returns>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.WriteOnlyChannelsItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("id", position);
                return new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.Item.WriteOnlyChannelsItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.WriteOnlyChannelsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WriteOnlyChannelsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/writeOnlyChannels{?query*}", pathParameters)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.WriteOnlyChannelsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WriteOnlyChannelsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/writeOnlyChannels{?query*}", rawUrl)
        {
        }

        /// <summary>
        /// Creates a new writeOnlyChannel.
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelPrimaryResponseDocument"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 403 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 409 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 422 status code</exception>
        public async Task<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelPrimaryResponseDocument?> PostAsync(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.CreateWriteOnlyChannelRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.WriteOnlyChannelsRequestBuilder.WriteOnlyChannelsRequestBuilderPostQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "403", global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "409", global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "422", global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelPrimaryResponseDocument>(requestInfo, global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelPrimaryResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new writeOnlyChannel.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        public RequestInformation ToPostRequestInformation(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.CreateWriteOnlyChannelRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.WriteOnlyChannelsRequestBuilder.WriteOnlyChannelsRequestBuilderPostQueryParameters>>? requestConfiguration = default)
        {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/vnd.api+json;ext=openapi");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/vnd.api+json;ext=openapi", body);
            return requestInfo;
        }

        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.WriteOnlyChannelsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.WriteOnlyChannelsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.WriteOnlyChannels.WriteOnlyChannelsRequestBuilder(rawUrl, RequestAdapter);
        }

        /// <summary>
        /// Creates a new writeOnlyChannel.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class WriteOnlyChannelsRequestBuilderPostQueryParameters 
        {
            /// <summary>For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</summary>
            [QueryParameter("query")]
            public string? Query { get; set; }
        }
    }
}
#pragma warning restore CS0618
