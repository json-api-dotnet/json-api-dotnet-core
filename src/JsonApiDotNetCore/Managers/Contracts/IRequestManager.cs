using System;
using System.Collections.Generic;
using System.Text;
using JsonApiDotNetCore.Internal;
using JsonApiDotNetCore.Internal.Query;
using JsonApiDotNetCore.Services;

namespace JsonApiDotNetCore.Managers.Contracts
{
    public interface IRequestManager : IQueryRequest
    {
        /// <summary>
        /// The request namespace. This may be an absolute or relative path
        /// depending upon the configuration.
        /// </summary>
        /// <example>
        /// Absolute: https://example.com/api/v1
        /// 
        /// Relative: /api/v1
        /// </example>
        string BasePath { get; set; }
        QuerySet QuerySet { get; set; }
        /// <summary>
        /// Gets the relationships as set in the query parameters
        /// </summary>
        /// <returns></returns>
        List<string> GetRelationships();
        /// <summary>
        /// Gets the sparse fields
        /// </summary>
        /// <returns></returns>
        List<string> GetFields();
        /// <summary>
        /// Sets the current context entity for this entire request
        /// </summary>
        /// <param name="contextEntityCurrent"></param>
        void SetContextEntity(ContextEntity contextEntityCurrent);

        ContextEntity GetContextEntity();
    }
}
