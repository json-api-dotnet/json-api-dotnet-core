// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiNSwagEndToEndTests.QueryStrings.GeneratedCode.Models {
    public class NullableNodeIdentifierResponseDocument : IBackedModel, IParsable {
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
        public LinksInResourceIdentifierDocument? Links {
            get { return BackingStore?.Get<LinksInResourceIdentifierDocument?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public LinksInResourceIdentifierDocument Links {
            get { return BackingStore?.Get<LinksInResourceIdentifierDocument>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NullableNodeIdentifierResponseDocument_meta? Meta {
            get { return BackingStore?.Get<NullableNodeIdentifierResponseDocument_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public NullableNodeIdentifierResponseDocument_meta Meta {
            get { return BackingStore?.Get<NullableNodeIdentifierResponseDocument_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new nullableNodeIdentifierResponseDocument and sets the default values.
        /// </summary>
        public NullableNodeIdentifierResponseDocument() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static NullableNodeIdentifierResponseDocument CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NullableNodeIdentifierResponseDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"data", n => { Data = n.GetObjectValue<NodeIdentifier>(NodeIdentifier.CreateFromDiscriminatorValue); } },
                {"links", n => { Links = n.GetObjectValue<LinksInResourceIdentifierDocument>(LinksInResourceIdentifierDocument.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<NullableNodeIdentifierResponseDocument_meta>(NullableNodeIdentifierResponseDocument_meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<NodeIdentifier>("data", Data);
            writer.WriteObjectValue<LinksInResourceIdentifierDocument>("links", Links);
            writer.WriteObjectValue<NullableNodeIdentifierResponseDocument_meta>("meta", Meta);
        }
    }
}
