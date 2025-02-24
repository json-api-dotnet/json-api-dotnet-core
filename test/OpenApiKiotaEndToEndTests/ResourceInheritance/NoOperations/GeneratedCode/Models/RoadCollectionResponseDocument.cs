// <auto-generated/>
#nullable enable
#pragma warning disable CS8625
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class RoadCollectionResponseDocument : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The data property</summary>
        public List<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.DataInRoadResponse>? Data
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.DataInRoadResponse>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }

        /// <summary>The included property</summary>
        public List<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.DataInResponse>? Included
        {
            get { return BackingStore?.Get<List<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.DataInResponse>?>("included"); }
            set { BackingStore?.Set("included", value); }
        }

        /// <summary>The links property</summary>
        public global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ResourceCollectionTopLevelLinks? Links
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ResourceCollectionTopLevelLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }

        /// <summary>The meta property</summary>
        public global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RoadCollectionResponseDocument"/> and sets the default values.
        /// </summary>
        public RoadCollectionResponseDocument()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RoadCollectionResponseDocument"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RoadCollectionResponseDocument CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.RoadCollectionResponseDocument();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.DataInRoadResponse>(global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.DataInRoadResponse.CreateFromDiscriminatorValue)?.AsList(); } },
                { "included", n => { Included = n.GetCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.DataInResponse>(global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.DataInResponse.CreateFromDiscriminatorValue)?.AsList(); } },
                { "links", n => { Links = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ResourceCollectionTopLevelLinks>(global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ResourceCollectionTopLevelLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.Meta>(global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.DataInRoadResponse>("data", Data);
            writer.WriteCollectionOfObjectValues<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.DataInResponse>("included", Included);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.ResourceCollectionTopLevelLinks>("links", Links);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.ResourceInheritance.NoOperations.GeneratedCode.Models.Meta>("meta", Meta);
        }
    }
}
#pragma warning restore CS0618
