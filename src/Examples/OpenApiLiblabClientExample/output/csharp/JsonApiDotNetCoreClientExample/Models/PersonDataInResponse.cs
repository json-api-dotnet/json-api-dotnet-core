// This file was generated by liblab | https://liblab.com/

using System.Text.Json.Serialization;

namespace JsonApiDotNetCoreClientExample.Models;

public record PersonDataInResponse(
    [property: JsonPropertyName("type")] string Type_,
    [property: JsonPropertyName("id")] string Id,
    [property:
        JsonPropertyName("attributes"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        PersonAttributesInResponse? Attributes = null,
    [property:
        JsonPropertyName("relationships"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        PersonRelationshipsInResponse? Relationships = null,
    [property:
        JsonPropertyName("links"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        ResourceLinks? Links = null,
    [property: JsonPropertyName("meta")] object? Meta = null
);
