// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages
{
    /// <summary>
    /// Builds and executes requests for operations under \countries\{id}\relationships\languages
    /// </summary>
    public class LanguagesRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public LanguagesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/countries/{id}/relationships/languages{?query*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public LanguagesRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/countries/{id}/relationships/languages{?query*}", rawUrl)
        {
        }
        /// <summary>
        /// Removes existing languages from the languages relationship of an individual country.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 409 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task DeleteAsync(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task DeleteAsync(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToDeleteRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "409", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Retrieves the related language identities of an individual country&apos;s languages relationship.
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageIdentifierCollectionResponseDocument"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageIdentifierCollectionResponseDocument?> GetAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder.LanguagesRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageIdentifierCollectionResponseDocument> GetAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder.LanguagesRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageIdentifierCollectionResponseDocument>(requestInfo, OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageIdentifierCollectionResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task HeadAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder.LanguagesRequestBuilderHeadQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task HeadAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder.LanguagesRequestBuilderHeadQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToHeadRequestInformation(requestConfiguration);
            await RequestAdapter.SendNoContentAsync(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Assigns existing languages to the languages relationship of an individual country.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 409 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task PatchAsync(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task PatchAsync(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "409", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Adds existing languages to the languages relationship of an individual country.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument">When receiving a 409 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task PostAsync(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task PostAsync(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "409", OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Removes existing languages from the languages relationship of an individual country.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.DELETE, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/vnd.api+json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/vnd.api+json", body);
            return requestInfo;
        }
        /// <summary>
        /// Retrieves the related language identities of an individual country&apos;s languages relationship.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder.LanguagesRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder.LanguagesRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/vnd.api+json");
            return requestInfo;
        }
        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder.LanguagesRequestBuilderHeadQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder.LanguagesRequestBuilderHeadQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.HEAD, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            return requestInfo;
        }
        /// <summary>
        /// Assigns existing languages to the languages relationship of an individual country.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.PATCH, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/vnd.api+json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/vnd.api+json", body);
            return requestInfo;
        }
        /// <summary>
        /// Adds existing languages to the languages relationship of an individual country.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ToManyLanguageInRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder WithUrl(string rawUrl)
        {
            return new OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Countries.Item.Relationships.Languages.LanguagesRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Retrieves the related language identities of an individual country&apos;s languages relationship.
        /// </summary>
        public class LanguagesRequestBuilderGetQueryParameters 
        {
            /// <summary>For syntax, see the documentation for the [`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</summary>
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
        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        public class LanguagesRequestBuilderHeadQueryParameters 
        {
            /// <summary>For syntax, see the documentation for the [`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</summary>
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
