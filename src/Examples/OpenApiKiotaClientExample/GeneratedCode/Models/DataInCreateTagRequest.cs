// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    #pragma warning disable CS1591
    public partial class DataInCreateTagRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTagRequest? Attributes
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTagRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTagRequest Attributes
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTagRequest>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The lid property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Lid
        {
            get { return BackingStore?.Get<string?>("lid"); }
            set { BackingStore?.Set("lid", value); }
        }
#nullable restore
#else
        public string Lid
        {
            get { return BackingStore?.Get<string>("lid"); }
            set { BackingStore?.Set("lid", value); }
        }
#endif
        /// <summary>The relationships property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTagRequest? Relationships
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTagRequest?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#nullable restore
#else
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTagRequest Relationships
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTagRequest>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#endif
        /// <summary>The type property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType? Type
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTagRequest"/> and sets the default values.
        /// </summary>
        public DataInCreateTagRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTagRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTagRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTagRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "attributes", n => { Attributes = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTagRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTagRequest.CreateFromDiscriminatorValue); } },
                { "lid", n => { Lid = n.GetStringValue(); } },
                { "relationships", n => { Relationships = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTagRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTagRequest.CreateFromDiscriminatorValue); } },
                { "type", n => { Type = n.GetEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTagRequest>("attributes", Attributes);
            writer.WriteStringValue("lid", Lid);
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTagRequest>("relationships", Relationships);
            writer.WriteEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.TagResourceType>("type", Type);
        }
    }
}
#pragma warning restore CS0618
