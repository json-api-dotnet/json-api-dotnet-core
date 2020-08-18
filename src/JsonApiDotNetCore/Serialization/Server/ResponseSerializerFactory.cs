using System;
using JsonApiDotNetCore.Internal;
using JsonApiDotNetCore.RequestServices.Contracts;
using JsonApiDotNetCore.Services;

namespace JsonApiDotNetCore.Serialization.Server
{
    /// <summary>
    /// A factory class to abstract away the initialization of the serializer from the
    /// .net core formatter pipeline.
    /// </summary>
    public class ResponseSerializerFactory : IJsonApiSerializerFactory
    {
        private readonly IServiceProvider _provider;
        private readonly IJsonApiRequest _request;

        public ResponseSerializerFactory(IJsonApiRequest request, IScopedServiceProvider provider)
        {
            _request = request;
            _provider = provider;
        }

        /// <summary>
        /// Initializes the server serializer using the <see cref="ResourceContext"/>
        /// associated with the current request.
        /// </summary>
        public IJsonApiSerializer GetSerializer()
        {
            var targetType = GetDocumentType();

            var serializerType = typeof(ResponseSerializer<>).MakeGenericType(targetType);
            var serializer = (IResponseSerializer)_provider.GetService(serializerType);
            if (_request.Kind == EndpointKind.Relationship && _request.Relationship != null)
                serializer.RequestRelationship = _request.Relationship;

            return (IJsonApiSerializer)serializer;
        }

        private Type GetDocumentType()
        {
            var resourceContext = _request.SecondaryResource ?? _request.PrimaryResource;
            return resourceContext.ResourceType;
        }
    }
}
