// This file was generated by liblab | https://liblab.com/

using System.Text.Json.Serialization;

namespace JsonApiDotNetCoreClientExample.Models;

public record TagPatchRequestDocument(
    [property: JsonPropertyName("data")] TagDataInPatchRequest Data
);
