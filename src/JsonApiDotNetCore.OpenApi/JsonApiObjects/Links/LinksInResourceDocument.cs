using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace JsonApiDotNetCore.OpenApi.JsonApiObjects.Links;

[UsedImplicitly(ImplicitUseTargetFlags.Members)]
internal sealed class LinksInResourceDocument
{
    [Required]
    public string Self { get; set; } = null!;

    public string Describedby { get; set; } = null!;
}
