using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JsonApiDotNetCore.Controllers;

/// <summary>
/// The base class to derive resource-specific controllers from. This class delegates all work to <see cref="BaseJsonApiController{TResource, TId}" />
/// but adds attributes for routing templates. If you want to provide routing templates yourself, you should derive from BaseJsonApiController directly.
/// </summary>
/// <typeparam name="TResource">
/// The resource type.
/// </typeparam>
/// <typeparam name="TId">
/// The resource identifier type.
/// </typeparam>
public abstract class JsonApiController<TResource, TId> : BaseJsonApiController<TResource, TId>
    where TResource : class, IIdentifiable<TId>
{
    /// <inheritdoc />
    protected JsonApiController(IJsonApiOptions options, IResourceGraph resourceGraph, ILoggerFactory loggerFactory,
        IResourceService<TResource, TId> resourceService)
        : base(options, resourceGraph, loggerFactory, resourceService)
    {
    }

    /// <inheritdoc />
    protected JsonApiController(IJsonApiOptions options, IResourceGraph resourceGraph, ILoggerFactory loggerFactory,
        IGetAllService<TResource, TId>? getAll = null, IGetByIdService<TResource, TId>? getById = null,
        IGetSecondaryService<TResource, TId>? getSecondary = null, IGetRelationshipService<TResource, TId>? getRelationship = null,
        ICreateService<TResource, TId>? create = null, IAddToRelationshipService<TResource, TId>? addToRelationship = null,
        IUpdateService<TResource, TId>? update = null, ISetRelationshipService<TResource, TId>? setRelationship = null,
        IDeleteService<TResource, TId>? delete = null, IRemoveFromRelationshipService<TResource, TId>? removeFromRelationship = null)
        : base(options, resourceGraph, loggerFactory, getAll, getById, getSecondary, getRelationship, create, addToRelationship, update, setRelationship,
            delete, removeFromRelationship)
    {
    }

    /// <inheritdoc />
    [HttpGet]
    [HttpHead]
    public override async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        return await base.GetAsync(cancellationToken);
    }

    /// <inheritdoc />
    [HttpGet("{id}")]
    [HttpHead("{id}")]
    public override async Task<IActionResult> GetAsync([Required] [DisallowNull] TId id, CancellationToken cancellationToken)
    {
        return await base.GetAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    [HttpGet("{id}/{relationshipName}")]
    [HttpHead("{id}/{relationshipName}")]
    public override async Task<IActionResult> GetSecondaryAsync([Required] [DisallowNull] TId id, [Required] string relationshipName,
        CancellationToken cancellationToken)
    {
        return await base.GetSecondaryAsync(id, relationshipName, cancellationToken);
    }

    /// <inheritdoc />
    [HttpGet("{id}/relationships/{relationshipName}")]
    [HttpHead("{id}/relationships/{relationshipName}")]
    public override async Task<IActionResult> GetRelationshipAsync([Required] [DisallowNull] TId id, [Required] string relationshipName,
        CancellationToken cancellationToken)
    {
        return await base.GetRelationshipAsync(id, relationshipName, cancellationToken);
    }

    /// <inheritdoc />
    [HttpPost]
    public override async Task<IActionResult> PostAsync([Required] TResource resource, CancellationToken cancellationToken)
    {
        return await base.PostAsync(resource, cancellationToken);
    }

    /// <inheritdoc />
    [HttpPost("{id}/relationships/{relationshipName}")]
    public override async Task<IActionResult> PostRelationshipAsync([Required] [DisallowNull] TId id, [Required] string relationshipName,
        [Required] ISet<IIdentifiable> rightResourceIds, CancellationToken cancellationToken)
    {
        return await base.PostRelationshipAsync(id, relationshipName, rightResourceIds, cancellationToken);
    }

    /// <inheritdoc />
    [HttpPatch("{id}")]
    public override async Task<IActionResult> PatchAsync([Required] [DisallowNull] TId id, [Required] TResource resource, CancellationToken cancellationToken)
    {
        return await base.PatchAsync(id, resource, cancellationToken);
    }

    /// <inheritdoc />
    [HttpPatch("{id}/relationships/{relationshipName}")]
    // Parameter `[Required] object? rightValue` makes Swashbuckle generate the OpenAPI request body as required. We don't actually validate ModelState, so it doesn't hurt.
    public override async Task<IActionResult> PatchRelationshipAsync([Required] [DisallowNull] TId id, [Required] string relationshipName,
        [Required] object? rightValue, CancellationToken cancellationToken)
    {
        return await base.PatchRelationshipAsync(id, relationshipName, rightValue, cancellationToken);
    }

    /// <inheritdoc />
    [HttpDelete("{id}")]
    public override async Task<IActionResult> DeleteAsync([Required] [DisallowNull] TId id, CancellationToken cancellationToken)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    [HttpDelete("{id}/relationships/{relationshipName}")]
    public override async Task<IActionResult> DeleteRelationshipAsync([Required] [DisallowNull] TId id, [Required] string relationshipName,
        [Required] ISet<IIdentifiable> rightResourceIds, CancellationToken cancellationToken)
    {
        return await base.DeleteRelationshipAsync(id, relationshipName, rightResourceIds, cancellationToken);
    }
}
