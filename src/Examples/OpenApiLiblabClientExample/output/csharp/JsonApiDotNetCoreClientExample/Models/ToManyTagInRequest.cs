// This file was generated by liblab | https://liblab.com/

using System.Text.Json.Serialization;

namespace JsonApiDotNetCoreClientExample.Models;

public record ToManyTagInRequest([property: JsonPropertyName("data")] List<TagIdentifier> Data);
