// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models {
    public class Transports : DataInResponse, IParsable {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public TransportAttributesInResponse? Attributes {
            get { return BackingStore?.Get<TransportAttributesInResponse?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public TransportAttributesInResponse Attributes {
            get { return BackingStore?.Get<TransportAttributesInResponse>("attributes"); }
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
        public Transports_meta? Meta {
            get { return BackingStore?.Get<Transports_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public Transports_meta Meta {
            get { return BackingStore?.Get<Transports_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Transports CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Transports();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"attributes", n => { Attributes = n.GetObjectValue<TransportAttributesInResponse>(TransportAttributesInResponse.CreateFromDiscriminatorValue); } },
                {"links", n => { Links = n.GetObjectValue<ResourceLinks>(ResourceLinks.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<Transports_meta>(Transports_meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<TransportAttributesInResponse>("attributes", Attributes);
            writer.WriteObjectValue<ResourceLinks>("links", Links);
            writer.WriteObjectValue<Transports_meta>("meta", Meta);
        }
    }
}
