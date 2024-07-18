using System.Reflection;

#pragma warning disable AV1008 // Class should not be static

namespace JsonApiDotNetCoreExample.CustomFunctions.Decrypt;

internal static class FunctionStub
{
    public static readonly MethodInfo DecryptMethod = typeof(FunctionStub).GetMethod(nameof(Decrypt), [typeof(string)])!;

    // ReSharper disable once UnusedParameter.Global
    public static string Decrypt(string text)
    {
        throw new InvalidOperationException($"The '{nameof(Decrypt)}' function cannot be called client-side.");
    }
}
