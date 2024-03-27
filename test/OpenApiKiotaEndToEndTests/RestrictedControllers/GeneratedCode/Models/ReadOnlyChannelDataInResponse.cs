// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models {
    public class ReadOnlyChannelDataInResponse : DataInResponse, IParsable {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ReadOnlyChannelAttributesInResponse? Attributes {
            get { return BackingStore?.Get<ReadOnlyChannelAttributesInResponse?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public ReadOnlyChannelAttributesInResponse Attributes {
            get { return BackingStore?.Get<ReadOnlyChannelAttributesInResponse>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ResourceLinks? Links {
            get { return BackingStore?.Get<ResourceLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public ResourceLinks Links {
            get { return BackingStore?.Get<ResourceLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ReadOnlyChannelDataInResponse_meta? Meta {
            get { return BackingStore?.Get<ReadOnlyChannelDataInResponse_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public ReadOnlyChannelDataInResponse_meta Meta {
            get { return BackingStore?.Get<ReadOnlyChannelDataInResponse_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>The relationships property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ReadOnlyChannelRelationshipsInResponse? Relationships {
            get { return BackingStore?.Get<ReadOnlyChannelRelationshipsInResponse?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#nullable restore
#else
        public ReadOnlyChannelRelationshipsInResponse Relationships {
            get { return BackingStore?.Get<ReadOnlyChannelRelationshipsInResponse>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new ReadOnlyChannelDataInResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ReadOnlyChannelDataInResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"attributes", n => { Attributes = n.GetObjectValue<ReadOnlyChannelAttributesInResponse>(ReadOnlyChannelAttributesInResponse.CreateFromDiscriminatorValue); } },
                {"links", n => { Links = n.GetObjectValue<ResourceLinks>(ResourceLinks.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<ReadOnlyChannelDataInResponse_meta>(ReadOnlyChannelDataInResponse_meta.CreateFromDiscriminatorValue); } },
                {"relationships", n => { Relationships = n.GetObjectValue<ReadOnlyChannelRelationshipsInResponse>(ReadOnlyChannelRelationshipsInResponse.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ReadOnlyChannelAttributesInResponse>("attributes", Attributes);
            writer.WriteObjectValue<ResourceLinks>("links", Links);
            writer.WriteObjectValue<ReadOnlyChannelDataInResponse_meta>("meta", Meta);
            writer.WriteObjectValue<ReadOnlyChannelRelationshipsInResponse>("relationships", Relationships);
        }
    }
}
