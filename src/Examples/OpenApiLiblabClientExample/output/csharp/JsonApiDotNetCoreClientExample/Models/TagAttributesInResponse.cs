// This file was generated by liblab | https://liblab.com/

using System.Text.Json.Serialization;

namespace JsonApiDotNetCoreClientExample.Models;

public record TagAttributesInResponse(
    [property:
        JsonPropertyName("name"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Name = null
);
