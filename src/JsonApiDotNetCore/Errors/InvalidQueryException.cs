using System.Net;
using JetBrains.Annotations;
using JsonApiDotNetCore.Queries;
using JsonApiDotNetCore.Serialization.Objects;

namespace JsonApiDotNetCore.Errors;

/// <summary>
/// The error that is thrown when translating a <see cref="QueryLayer" /> to Entity Framework Core fails.
/// </summary>
[PublicAPI]
public sealed class InvalidQueryException(string reason, Exception? innerException)
    : JsonApiException(new ErrorObject(HttpStatusCode.BadRequest)
    {
        Title = reason,
        Detail = innerException?.Message
    }, innerException);
