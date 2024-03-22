// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models {
    public class ErrorResponseDocument : ApiException, IBackedModel, IParsable {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The errors property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ErrorObject>? Errors {
            get { return BackingStore?.Get<List<ErrorObject>?>("errors"); }
            set { BackingStore?.Set("errors", value); }
        }
#nullable restore
#else
        public List<ErrorObject> Errors {
            get { return BackingStore?.Get<List<ErrorObject>>("errors"); }
            set { BackingStore?.Set("errors", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public LinksInErrorDocument? Links {
            get { return BackingStore?.Get<LinksInErrorDocument?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public LinksInErrorDocument Links {
            get { return BackingStore?.Get<LinksInErrorDocument>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The primary error message.</summary>
        public override string Message { get => base.Message; }
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ErrorResponseDocument_meta? Meta {
            get { return BackingStore?.Get<ErrorResponseDocument_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public ErrorResponseDocument_meta Meta {
            get { return BackingStore?.Get<ErrorResponseDocument_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new errorResponseDocument and sets the default values.
        /// </summary>
        public ErrorResponseDocument() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ErrorResponseDocument CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ErrorResponseDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"errors", n => { Errors = n.GetCollectionOfObjectValues<ErrorObject>(ErrorObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"links", n => { Links = n.GetObjectValue<LinksInErrorDocument>(LinksInErrorDocument.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<ErrorResponseDocument_meta>(ErrorResponseDocument_meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<ErrorObject>("errors", Errors);
            writer.WriteObjectValue<LinksInErrorDocument>("links", Links);
            writer.WriteObjectValue<ErrorResponseDocument_meta>("meta", Meta);
        }
    }
}
