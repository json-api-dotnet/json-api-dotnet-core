// This file was generated by liblab | https://liblab.com/

using System.Text.Json.Serialization;

namespace JsonApiDotNetCoreClientExample.Models;

public record NullablePersonIdentifierResponseDocument(
    [property: JsonPropertyName("links")] ResourceIdentifierTopLevelLinks Links,
    [property: JsonPropertyName("data")] PersonIdentifier Data,
    [property: JsonPropertyName("meta")] object? Meta = null
);
