// This file was generated by liblab | https://liblab.com/

using System.Net.Http.Json;
using JsonApiDotNetCoreClientExample.Http;
using JsonApiDotNetCoreClientExample.Http.Serialization;
using JsonApiDotNetCoreClientExample.Models;

namespace JsonApiDotNetCoreClientExample.Services;

public class TodoItemsService : BaseService
{
    internal TodoItemsService(HttpClient httpClient)
        : base(httpClient) { }

    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task<TodoItemCollectionResponseDocument> GetTodoItemCollectionAsync(
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        var request = new RequestBuilder(HttpMethod.Get, "api/todoItems")
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response
                .Content.ReadFromJsonAsync<TodoItemCollectionResponseDocument>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <param name="input">The attributes and relationships of the todoItem to create.</param>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    public async Task<TodoItemPrimaryResponseDocument> PostTodoItemAsync(
        TodoItemPostRequestDocument input,
        object? query = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));

        var request = new RequestBuilder(HttpMethod.Post, "api/todoItems")
            .SetQueryParameter("query", query)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response
                .Content.ReadFromJsonAsync<TodoItemPrimaryResponseDocument>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.</summary>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task HeadTodoItemCollectionAsync(
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        var request = new RequestBuilder(HttpMethod.Head, "api/todoItems")
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <param name="id">The identifier of the todoItem to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task<TodoItemPrimaryResponseDocument> GetTodoItemAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Get, "api/todoItems/{id}")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response
                .Content.ReadFromJsonAsync<TodoItemPrimaryResponseDocument>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <param name="input">The attributes and relationships of the todoItem to update. Omitted fields are left unchanged.</param>
    /// <param name="id">The identifier of the todoItem to update.</param>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    public async Task<TodoItemPrimaryResponseDocument> PatchTodoItemAsync(
        TodoItemPatchRequestDocument input,
        string id,
        object? query = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Patch, "api/todoItems/{id}")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response
                .Content.ReadFromJsonAsync<TodoItemPrimaryResponseDocument>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <param name="id">The identifier of the todoItem to delete.</param>
    public async Task DeleteTodoItemAsync(string id, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Delete, "api/todoItems/{id}")
            .SetPathParameter("id", id)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.</summary>
    /// <param name="id">The identifier of the todoItem to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task HeadTodoItemAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Head, "api/todoItems/{id}")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <param name="id">The identifier of the todoItem whose related person to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task<NullablePersonSecondaryResponseDocument> GetTodoItemAssigneeAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Get, "api/todoItems/{id}/assignee")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response
                .Content.ReadFromJsonAsync<NullablePersonSecondaryResponseDocument>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.</summary>
    /// <param name="id">The identifier of the todoItem whose related person to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task HeadTodoItemAssigneeAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Head, "api/todoItems/{id}/assignee")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <param name="id">The identifier of the todoItem whose related person identity to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task<NullablePersonIdentifierResponseDocument> GetTodoItemAssigneeRelationshipAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(
            HttpMethod.Get,
            "api/todoItems/{id}/relationships/assignee"
        )
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response
                .Content.ReadFromJsonAsync<NullablePersonIdentifierResponseDocument>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <param name="input">The identity of the person to assign to the assignee relationship, or `null` to clear the relationship.</param>
    /// <param name="id">The identifier of the todoItem whose assignee relationship to assign or clear.</param>
    public async Task PatchTodoItemAssigneeRelationshipAsync(
        NullableToOnePersonInRequest input,
        string id,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(
            HttpMethod.Patch,
            "api/todoItems/{id}/relationships/assignee"
        )
            .SetPathParameter("id", id)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.</summary>
    /// <param name="id">The identifier of the todoItem whose related person identity to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task HeadTodoItemAssigneeRelationshipAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(
            HttpMethod.Head,
            "api/todoItems/{id}/relationships/assignee"
        )
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <param name="id">The identifier of the todoItem whose related person to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task<PersonSecondaryResponseDocument> GetTodoItemOwnerAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Get, "api/todoItems/{id}/owner")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response
                .Content.ReadFromJsonAsync<PersonSecondaryResponseDocument>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.</summary>
    /// <param name="id">The identifier of the todoItem whose related person to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task HeadTodoItemOwnerAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Head, "api/todoItems/{id}/owner")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <param name="id">The identifier of the todoItem whose related person identity to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task<PersonIdentifierResponseDocument> GetTodoItemOwnerRelationshipAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Get, "api/todoItems/{id}/relationships/owner")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response
                .Content.ReadFromJsonAsync<PersonIdentifierResponseDocument>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <param name="input">The identity of the person to assign to the owner relationship.</param>
    /// <param name="id">The identifier of the todoItem whose owner relationship to assign.</param>
    public async Task PatchTodoItemOwnerRelationshipAsync(
        ToOnePersonInRequest input,
        string id,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Patch, "api/todoItems/{id}/relationships/owner")
            .SetPathParameter("id", id)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.</summary>
    /// <param name="id">The identifier of the todoItem whose related person identity to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task HeadTodoItemOwnerRelationshipAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Head, "api/todoItems/{id}/relationships/owner")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <param name="id">The identifier of the todoItem whose related tags to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task<TagCollectionResponseDocument> GetTodoItemTagsAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Get, "api/todoItems/{id}/tags")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response
                .Content.ReadFromJsonAsync<TagCollectionResponseDocument>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.</summary>
    /// <param name="id">The identifier of the todoItem whose related tags to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`include`](https://www.jsonapi.net/usage/reading/including-relationships.html)/[`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task HeadTodoItemTagsAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Head, "api/todoItems/{id}/tags")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <param name="id">The identifier of the todoItem whose related tag identities to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task<TagIdentifierCollectionResponseDocument> GetTodoItemTagsRelationshipAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Get, "api/todoItems/{id}/relationships/tags")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response
                .Content.ReadFromJsonAsync<TagIdentifierCollectionResponseDocument>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <param name="input">The identities of the tags to add to the tags relationship.</param>
    /// <param name="id">The identifier of the todoItem to add tags to.</param>
    public async Task PostTodoItemTagsRelationshipAsync(
        ToManyTagInRequest input,
        string id,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Post, "api/todoItems/{id}/relationships/tags")
            .SetPathParameter("id", id)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <param name="input">The identities of the tags to assign to the tags relationship, or an empty array to clear the relationship.</param>
    /// <param name="id">The identifier of the todoItem whose tags relationship to assign.</param>
    public async Task PatchTodoItemTagsRelationshipAsync(
        ToManyTagInRequest input,
        string id,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Patch, "api/todoItems/{id}/relationships/tags")
            .SetPathParameter("id", id)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <param name="input">The identities of the tags to remove from the tags relationship.</param>
    /// <param name="id">The identifier of the todoItem to remove tags from.</param>
    public async Task DeleteTodoItemTagsRelationshipAsync(
        ToManyTagInRequest input,
        string id,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Delete, "api/todoItems/{id}/relationships/tags")
            .SetPathParameter("id", id)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>Compare the returned ETag HTTP header with an earlier one to determine if the response has changed since it was fetched.</summary>
    /// <param name="id">The identifier of the todoItem whose related tag identities to retrieve.</param>
    /// <param name="query">For syntax, see the documentation for the [`filter`](https://www.jsonapi.net/usage/reading/filtering.html)/[`sort`](https://www.jsonapi.net/usage/reading/sorting.html)/[`page`](https://www.jsonapi.net/usage/reading/pagination.html)/[`fields`](https://www.jsonapi.net/usage/reading/sparse-fieldset-selection.html) query string parameters.</param>
    /// <param name="ifNoneMatch">A list of ETags, resulting in HTTP status 304 without a body, if one of them matches the current fingerprint.</param>
    public async Task HeadTodoItemTagsRelationshipAsync(
        string id,
        object? query = null,
        string? ifNoneMatch = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var request = new RequestBuilder(HttpMethod.Head, "api/todoItems/{id}/relationships/tags")
            .SetPathParameter("id", id)
            .SetQueryParameter("query", query)
            .SetOptionalHeader("If-None-Match", ifNoneMatch)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }
}
