// This file was generated by liblab | https://liblab.com/

using System.Text.Json.Serialization;

namespace JsonApiDotNetCoreClientExample.Models;

public record TodoItemIdentifierCollectionResponseDocument(
    [property: JsonPropertyName("links")] ResourceIdentifierCollectionTopLevelLinks Links,
    [property: JsonPropertyName("data")] List<TodoItemIdentifier> Data,
    [property: JsonPropertyName("meta")] object? Meta = null
);
