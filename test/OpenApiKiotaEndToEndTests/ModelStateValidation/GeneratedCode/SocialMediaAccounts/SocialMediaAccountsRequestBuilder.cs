// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models;
using OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.Item;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts
{
    /// <summary>
    /// Builds and executes requests for operations under \socialMediaAccounts
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class SocialMediaAccountsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.socialMediaAccounts.item collection</summary>
        /// <param name="position">The identifier of the socialMediaAccount to update.</param>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.Item.SocialMediaAccountsItemRequestBuilder"/></returns>
        public global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.Item.SocialMediaAccountsItemRequestBuilder this[Guid position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("id", position);
                return new global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.Item.SocialMediaAccountsItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.SocialMediaAccountsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public SocialMediaAccountsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/socialMediaAccounts{?query*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.SocialMediaAccountsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public SocialMediaAccountsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/socialMediaAccounts{?query*}", rawUrl)
        {
        }
        /// <summary>
        /// Creates a new socialMediaAccount.
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.SocialMediaAccountPrimaryResponseDocument"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.ErrorResponseDocument">When receiving a 403 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.ErrorResponseDocument">When receiving a 409 status code</exception>
        /// <exception cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.ErrorResponseDocument">When receiving a 422 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.SocialMediaAccountPrimaryResponseDocument?> PostAsync(global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.CreateSocialMediaAccountRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.SocialMediaAccountsRequestBuilder.SocialMediaAccountsRequestBuilderPostQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.SocialMediaAccountPrimaryResponseDocument> PostAsync(global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.CreateSocialMediaAccountRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.SocialMediaAccountsRequestBuilder.SocialMediaAccountsRequestBuilderPostQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "403", global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "409", global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "422", global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.SocialMediaAccountPrimaryResponseDocument>(requestInfo, global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.SocialMediaAccountPrimaryResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Creates a new socialMediaAccount.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.CreateSocialMediaAccountRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.SocialMediaAccountsRequestBuilder.SocialMediaAccountsRequestBuilderPostQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.CreateSocialMediaAccountRequestDocument body, Action<RequestConfiguration<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.SocialMediaAccountsRequestBuilder.SocialMediaAccountsRequestBuilderPostQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/vnd.api+json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/vnd.api+json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.SocialMediaAccountsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.SocialMediaAccountsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.SocialMediaAccounts.SocialMediaAccountsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Creates a new socialMediaAccount.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class SocialMediaAccountsRequestBuilderPostQueryParameters 
        {
            /// <summary>For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("query")]
            public string? Query { get; set; }
#nullable restore
#else
            [QueryParameter("query")]
            public string Query { get; set; }
#endif
        }
    }
}
#pragma warning restore CS0618
