// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class NullableNodeIdentifierResponseDocument : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeIdentifier? Data
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeIdentifier?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeIdentifier Data
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeIdentifier>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierTopLevelLinks? Links
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierTopLevelLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierTopLevelLinks Links
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierTopLevelLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument_meta? Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument_meta Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument"/> and sets the default values.
        /// </summary>
        public NullableNodeIdentifierResponseDocument()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeIdentifier>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeIdentifier.CreateFromDiscriminatorValue); } },
                { "links", n => { Links = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierTopLevelLinks>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierTopLevelLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument_meta>(OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument_meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NodeIdentifier>("data", Data);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.ResourceIdentifierTopLevelLinks>("links", Links);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.NullableNodeIdentifierResponseDocument_meta>("meta", Meta);
        }
    }
}
