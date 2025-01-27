// <auto-generated/>
#nullable enable
#pragma warning disable CS8625
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class DataInCreateWriteOnlyChannelRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.AttributesInCreateWriteOnlyChannelRequest? Attributes
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.AttributesInCreateWriteOnlyChannelRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }

        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The meta property</summary>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }

        /// <summary>The relationships property</summary>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipsInCreateWriteOnlyChannelRequest? Relationships
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipsInCreateWriteOnlyChannelRequest?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }

        /// <summary>The type property</summary>
        public global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelResourceType? Type
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest"/> and sets the default values.
        /// </summary>
        public DataInCreateWriteOnlyChannelRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.DataInCreateWriteOnlyChannelRequest();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "attributes", n => { Attributes = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.AttributesInCreateWriteOnlyChannelRequest>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.AttributesInCreateWriteOnlyChannelRequest.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
                { "relationships", n => { Relationships = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipsInCreateWriteOnlyChannelRequest>(global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipsInCreateWriteOnlyChannelRequest.CreateFromDiscriminatorValue); } },
                { "type", n => { Type = n.GetEnumValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelResourceType>(); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.AttributesInCreateWriteOnlyChannelRequest>("attributes", Attributes);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.Meta>("meta", Meta);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.RelationshipsInCreateWriteOnlyChannelRequest>("relationships", Relationships);
            writer.WriteEnumValue<global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.WriteOnlyChannelResourceType>("type", Type);
        }
    }
}
#pragma warning restore CS0618
