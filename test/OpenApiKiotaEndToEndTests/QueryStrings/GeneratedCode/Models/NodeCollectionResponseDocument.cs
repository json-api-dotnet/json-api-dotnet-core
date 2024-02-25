// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiNSwagEndToEndTests.QueryStrings.GeneratedCode.Models {
    public class NodeCollectionResponseDocument : IBackedModel, IParsable {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<NodeDataInResponse>? Data {
            get { return BackingStore?.Get<List<NodeDataInResponse>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public List<NodeDataInResponse> Data {
            get { return BackingStore?.Get<List<NodeDataInResponse>>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The included property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<DataInResponse>? Included {
            get { return BackingStore?.Get<List<DataInResponse>?>("included"); }
            set { BackingStore?.Set("included", value); }
        }
#nullable restore
#else
        public List<DataInResponse> Included {
            get { return BackingStore?.Get<List<DataInResponse>>("included"); }
            set { BackingStore?.Set("included", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public LinksInResourceCollectionDocument? Links {
            get { return BackingStore?.Get<LinksInResourceCollectionDocument?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public LinksInResourceCollectionDocument Links {
            get { return BackingStore?.Get<LinksInResourceCollectionDocument>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NodeCollectionResponseDocument_meta? Meta {
            get { return BackingStore?.Get<NodeCollectionResponseDocument_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public NodeCollectionResponseDocument_meta Meta {
            get { return BackingStore?.Get<NodeCollectionResponseDocument_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new nodeCollectionResponseDocument and sets the default values.
        /// </summary>
        public NodeCollectionResponseDocument() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static NodeCollectionResponseDocument CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NodeCollectionResponseDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"data", n => { Data = n.GetCollectionOfObjectValues<NodeDataInResponse>(NodeDataInResponse.CreateFromDiscriminatorValue)?.ToList(); } },
                {"included", n => { Included = n.GetCollectionOfObjectValues<DataInResponse>(DataInResponse.CreateFromDiscriminatorValue)?.ToList(); } },
                {"links", n => { Links = n.GetObjectValue<LinksInResourceCollectionDocument>(LinksInResourceCollectionDocument.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<NodeCollectionResponseDocument_meta>(NodeCollectionResponseDocument_meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<NodeDataInResponse>("data", Data);
            writer.WriteCollectionOfObjectValues<DataInResponse>("included", Included);
            writer.WriteObjectValue<LinksInResourceCollectionDocument>("links", Links);
            writer.WriteObjectValue<NodeCollectionResponseDocument_meta>("meta", Meta);
        }
    }
}
