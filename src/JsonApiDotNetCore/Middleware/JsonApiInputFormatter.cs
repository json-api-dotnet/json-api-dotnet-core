using JsonApiDotNetCore.Serialization.Request;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace JsonApiDotNetCore.Middleware;

/// <inheritdoc cref="IJsonApiInputFormatter" />
public sealed class JsonApiInputFormatter : IJsonApiInputFormatter
{
    /// <inheritdoc />
    public bool CanRead(InputFormatterContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.HttpContext.IsJsonApiRequest();
    }

    /// <inheritdoc />
    public async Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var reader = context.HttpContext.RequestServices.GetRequiredService<IJsonApiReader>();

        object? model = await reader.ReadAsync(context.HttpContext.Request);

        return model == null ? await InputFormatterResult.NoValueAsync() : await InputFormatterResult.SuccessAsync(model);
    }
}
