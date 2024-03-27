// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models {
    public class TodoItemIdentifierCollectionResponseDocument : IBackedModel, IParsable {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<TodoItemIdentifier>? Data {
            get { return BackingStore?.Get<List<TodoItemIdentifier>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public List<TodoItemIdentifier> Data {
            get { return BackingStore?.Get<List<TodoItemIdentifier>>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ResourceIdentifierCollectionTopLevelLinks? Links {
            get { return BackingStore?.Get<ResourceIdentifierCollectionTopLevelLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public ResourceIdentifierCollectionTopLevelLinks Links {
            get { return BackingStore?.Get<ResourceIdentifierCollectionTopLevelLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public TodoItemIdentifierCollectionResponseDocument_meta? Meta {
            get { return BackingStore?.Get<TodoItemIdentifierCollectionResponseDocument_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public TodoItemIdentifierCollectionResponseDocument_meta Meta {
            get { return BackingStore?.Get<TodoItemIdentifierCollectionResponseDocument_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new todoItemIdentifierCollectionResponseDocument and sets the default values.
        /// </summary>
        public TodoItemIdentifierCollectionResponseDocument() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static TodoItemIdentifierCollectionResponseDocument CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TodoItemIdentifierCollectionResponseDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"data", n => { Data = n.GetCollectionOfObjectValues<TodoItemIdentifier>(TodoItemIdentifier.CreateFromDiscriminatorValue)?.ToList(); } },
                {"links", n => { Links = n.GetObjectValue<ResourceIdentifierCollectionTopLevelLinks>(ResourceIdentifierCollectionTopLevelLinks.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<TodoItemIdentifierCollectionResponseDocument_meta>(TodoItemIdentifierCollectionResponseDocument_meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<TodoItemIdentifier>("data", Data);
            writer.WriteObjectValue<ResourceIdentifierCollectionTopLevelLinks>("links", Links);
            writer.WriteObjectValue<TodoItemIdentifierCollectionResponseDocument_meta>("meta", Meta);
        }
    }
}
