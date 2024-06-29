// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class DataInUpdateTagRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest? Attributes
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest Attributes
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The id property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id
        {
            get { return BackingStore?.Get<string?>("id"); }
            set { BackingStore?.Set("id", value); }
        }
#nullable restore
#else
        public string Id
        {
            get { return BackingStore?.Get<string>("id"); }
            set { BackingStore?.Set("id", value); }
        }
#endif
        /// <summary>The relationships property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest? Relationships
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#nullable restore
#else
        public OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest Relationships
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#endif
        /// <summary>The type property</summary>
        public OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType? Type
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaClientExample.GeneratedCode.Models.DataInUpdateTagRequest"/> and sets the default values.
        /// </summary>
        public DataInUpdateTagRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaClientExample.GeneratedCode.Models.DataInUpdateTagRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaClientExample.GeneratedCode.Models.DataInUpdateTagRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaClientExample.GeneratedCode.Models.DataInUpdateTagRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "attributes", n => { Attributes = n.GetObjectValue<OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest>(OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest.CreateFromDiscriminatorValue); } },
                { "id", n => { Id = n.GetStringValue(); } },
                { "relationships", n => { Relationships = n.GetObjectValue<OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest>(OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest.CreateFromDiscriminatorValue); } },
                { "type", n => { Type = n.GetEnumValue<OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInUpdateTagRequest>("attributes", Attributes);
            writer.WriteStringValue("id", Id);
            writer.WriteObjectValue<OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInUpdateTagRequest>("relationships", Relationships);
            writer.WriteEnumValue<OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType>("type", Type);
        }
    }
}
