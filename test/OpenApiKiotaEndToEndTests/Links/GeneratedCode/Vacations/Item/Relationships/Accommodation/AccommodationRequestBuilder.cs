// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation
{
    /// <summary>
    /// Builds and executes requests for operations under \vacations\{id}\relationships\accommodation
    /// </summary>
    public class AccommodationRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AccommodationRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/vacations/{id}/relationships/accommodation{?query*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AccommodationRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/vacations/{id}/relationships/accommodation{?query*}", rawUrl)
        {
        }
        /// <summary>
        /// Retrieves the related accommodation identity of an individual vacation&apos;s accommodation relationship.
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.AccommodationIdentifierResponseDocument"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.AccommodationIdentifierResponseDocument?> GetAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder.AccommodationRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.AccommodationIdentifierResponseDocument> GetAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder.AccommodationRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.AccommodationIdentifierResponseDocument>(requestInfo, OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.AccommodationIdentifierResponseDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task HeadAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder.AccommodationRequestBuilderHeadQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task HeadAsync(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder.AccommodationRequestBuilderHeadQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToHeadRequestInformation(requestConfiguration);
            await RequestAdapter.SendNoContentAsync(requestInfo, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Assigns an existing accommodation to the accommodation relationship of an individual vacation.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ErrorResponseDocument">When receiving a 400 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ErrorResponseDocument">When receiving a 404 status code</exception>
        /// <exception cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ErrorResponseDocument">When receiving a 409 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task PatchAsync(OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task PatchAsync(OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "404", OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
                { "409", OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ErrorResponseDocument.CreateFromDiscriminatorValue },
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Retrieves the related accommodation identity of an individual vacation&apos;s accommodation relationship.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder.AccommodationRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder.AccommodationRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder.AccommodationRequestBuilderHeadQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToHeadRequestInformation(Action<RequestConfiguration<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder.AccommodationRequestBuilderHeadQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.HEAD, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            return requestInfo;
        }
        /// <summary>
        /// Assigns an existing accommodation to the accommodation relationship of an individual vacation.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
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
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder WithUrl(string rawUrl)
        {
            return new OpenApiKiotaEndToEndTests.Links.GeneratedCode.Vacations.Item.Relationships.Accommodation.AccommodationRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Retrieves the related accommodation identity of an individual vacation&apos;s accommodation relationship.
        /// </summary>
        public class AccommodationRequestBuilderGetQueryParameters 
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
        public class AccommodationRequestBuilderHeadQueryParameters 
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
