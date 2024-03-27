// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models {
    public class ReadOnlyChannelCollectionResponseDocument : IBackedModel, IParsable {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ReadOnlyChannelDataInResponse>? Data {
            get { return BackingStore?.Get<List<ReadOnlyChannelDataInResponse>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public List<ReadOnlyChannelDataInResponse> Data {
            get { return BackingStore?.Get<List<ReadOnlyChannelDataInResponse>>("data"); }
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
        public ResourceCollectionTopLevelLinks? Links {
            get { return BackingStore?.Get<ResourceCollectionTopLevelLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public ResourceCollectionTopLevelLinks Links {
            get { return BackingStore?.Get<ResourceCollectionTopLevelLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ReadOnlyChannelCollectionResponseDocument_meta? Meta {
            get { return BackingStore?.Get<ReadOnlyChannelCollectionResponseDocument_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public ReadOnlyChannelCollectionResponseDocument_meta Meta {
            get { return BackingStore?.Get<ReadOnlyChannelCollectionResponseDocument_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new readOnlyChannelCollectionResponseDocument and sets the default values.
        /// </summary>
        public ReadOnlyChannelCollectionResponseDocument() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ReadOnlyChannelCollectionResponseDocument CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ReadOnlyChannelCollectionResponseDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"data", n => { Data = n.GetCollectionOfObjectValues<ReadOnlyChannelDataInResponse>(ReadOnlyChannelDataInResponse.CreateFromDiscriminatorValue)?.ToList(); } },
                {"included", n => { Included = n.GetCollectionOfObjectValues<DataInResponse>(DataInResponse.CreateFromDiscriminatorValue)?.ToList(); } },
                {"links", n => { Links = n.GetObjectValue<ResourceCollectionTopLevelLinks>(ResourceCollectionTopLevelLinks.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<ReadOnlyChannelCollectionResponseDocument_meta>(ReadOnlyChannelCollectionResponseDocument_meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<ReadOnlyChannelDataInResponse>("data", Data);
            writer.WriteCollectionOfObjectValues<DataInResponse>("included", Included);
            writer.WriteObjectValue<ResourceCollectionTopLevelLinks>("links", Links);
            writer.WriteObjectValue<ReadOnlyChannelCollectionResponseDocument_meta>("meta", Meta);
        }
    }
}
