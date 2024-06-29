// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class NodeDataInResponse : OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.DataInResponse, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeAttributesInResponse? Attributes
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeAttributesInResponse?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeAttributesInResponse Attributes
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeAttributesInResponse>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceLinks? Links
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceLinks Links
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeDataInResponse_meta? Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeDataInResponse_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeDataInResponse_meta Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeDataInResponse_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>The relationships property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeRelationshipsInResponse? Relationships
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeRelationshipsInResponse?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeRelationshipsInResponse Relationships
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeRelationshipsInResponse>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeDataInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeDataInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeDataInResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "attributes", n => { Attributes = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeAttributesInResponse>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeAttributesInResponse.CreateFromDiscriminatorValue); } },
                { "links", n => { Links = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceLinks>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeDataInResponse_meta>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeDataInResponse_meta.CreateFromDiscriminatorValue); } },
                { "relationships", n => { Relationships = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeRelationshipsInResponse>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeRelationshipsInResponse.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeAttributesInResponse>("attributes", Attributes);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceLinks>("links", Links);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeDataInResponse_meta>("meta", Meta);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeRelationshipsInResponse>("relationships", Relationships);
        }
    }
}
