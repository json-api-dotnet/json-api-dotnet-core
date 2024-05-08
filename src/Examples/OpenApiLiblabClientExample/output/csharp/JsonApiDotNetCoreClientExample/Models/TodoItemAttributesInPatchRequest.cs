// This file was generated by liblab | https://liblab.com/

using System.Text.Json.Serialization;

namespace JsonApiDotNetCoreClientExample.Models;

public record TodoItemAttributesInPatchRequest(
    [property:
        JsonPropertyName("description"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Description = null,
    [property:
        JsonPropertyName("priority"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        TodoItemPriority? Priority = null,
    [property: JsonPropertyName("durationInHours")] long? DurationInHours = null
);
