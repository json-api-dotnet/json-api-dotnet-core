﻿namespace JsonApiDotNetCore.QueryServices.Contracts
{
    /// <summary>
    /// Base interface that all query parameter services should inherit.
    /// </summary>
    public interface IQueryParameterService
    {
        /// <summary>
        /// Parses the value of the query parameter. Invoked in the middleware.
        /// </summary>
        /// <param name="value">the value of the query parameter as parsed from the url</param>
        void Parse(string value);
        /// <summary>
        /// Name of the parameter as appearing in the url, used internally for matching.
        /// Case sensitive.
        /// </summary>
        string Name { get; }
    }
}
