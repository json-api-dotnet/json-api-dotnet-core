using JsonApiDotNetCore.Models;

namespace JsonApiDotNetCore.Serialization.Serializer
{
    /// <summary>
    /// Options used to configure how fields of a model get serialized into
    /// a json:api <see cref="Document"/>.
    /// </summary>
    public class SerializerSettings 
    {
        /// <param name="omitNullValuedAttributes">Omit null values from attributes</param>
        public SerializerSettings(bool omitNullValuedAttributes = false, bool omitDefaultValuedAttributes = false)
        {
            OmitNullValuedAttributes = omitNullValuedAttributes;
            OmitDefaultValuedAttributes = omitDefaultValuedAttributes;
        }

        /// <summary>
        /// Prevent attributes with null values from being included in the response.
        /// This property is internal and if you want to enable this behavior, you
        /// should do so on the <see cref="Configuration.ISerializerOptions" />.
        /// </summary>
        /// <example>
        /// <code>
        /// options.NullAttributeResponseBehavior = new NullAttributeResponseBehavior(true);
        /// </code>
        /// </example>
        public bool OmitNullValuedAttributes { get; }

        /// <summary>
        /// Prevent attributes with default values from being included in the response.
        /// This property is internal and if you want to enable this behavior, you
        /// should do so on the <see cref="Configuration.ISerializerOptions" />.
        /// </summary>
        /// <example>
        /// <code>
        /// options.DefaultAttributeResponseBehavior = new DefaultAttributeResponseBehavior(true);
        /// </code>
        /// </example>
        public bool OmitDefaultValuedAttributes { get; }
    }

}

