// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models {
    public class ToOneNodeInResponse : IBackedModel, IParsable {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NodeIdentifier? Data {
            get { return BackingStore?.Get<NodeIdentifier?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public NodeIdentifier Data {
            get { return BackingStore?.Get<NodeIdentifier>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RelationshipLinks? Links {
            get { return BackingStore?.Get<RelationshipLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public RelationshipLinks Links {
            get { return BackingStore?.Get<RelationshipLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ToOneNodeInResponse_meta? Meta {
            get { return BackingStore?.Get<ToOneNodeInResponse_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public ToOneNodeInResponse_meta Meta {
            get { return BackingStore?.Get<ToOneNodeInResponse_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new toOneNodeInResponse and sets the default values.
        /// </summary>
        public ToOneNodeInResponse() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ToOneNodeInResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ToOneNodeInResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"data", n => { Data = n.GetObjectValue<NodeIdentifier>(NodeIdentifier.CreateFromDiscriminatorValue); } },
                {"links", n => { Links = n.GetObjectValue<RelationshipLinks>(RelationshipLinks.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<ToOneNodeInResponse_meta>(ToOneNodeInResponse_meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<NodeIdentifier>("data", Data);
            writer.WriteObjectValue<RelationshipLinks>("links", Links);
            writer.WriteObjectValue<ToOneNodeInResponse_meta>("meta", Meta);
        }
    }
}
