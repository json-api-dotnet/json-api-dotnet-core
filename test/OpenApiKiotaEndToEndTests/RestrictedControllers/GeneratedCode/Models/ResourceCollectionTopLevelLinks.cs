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
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class ResourceCollectionTopLevelLinks : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The describedby property</summary>
        public string? Describedby
        {
            get { return BackingStore?.Get<string?>("describedby"); }
            set { BackingStore?.Set("describedby", value); }
        }

        /// <summary>The first property</summary>
        public string? First
        {
            get { return BackingStore?.Get<string?>("first"); }
            set { BackingStore?.Set("first", value); }
        }

        /// <summary>The last property</summary>
        public string? Last
        {
            get { return BackingStore?.Get<string?>("last"); }
            set { BackingStore?.Set("last", value); }
        }

        /// <summary>The next property</summary>
        public string? Next
        {
            get { return BackingStore?.Get<string?>("next"); }
            set { BackingStore?.Set("next", value); }
        }

        /// <summary>The prev property</summary>
        public string? Prev
        {
            get { return BackingStore?.Get<string?>("prev"); }
            set { BackingStore?.Set("prev", value); }
        }

        /// <summary>The self property</summary>
        public string? Self
        {
            get { return BackingStore?.Get<string?>("self"); }
            set { BackingStore?.Set("self", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceCollectionTopLevelLinks"/> and sets the default values.
        /// </summary>
        public ResourceCollectionTopLevelLinks()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceCollectionTopLevelLinks"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceCollectionTopLevelLinks CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ResourceCollectionTopLevelLinks();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "describedby", n => { Describedby = n.GetStringValue(); } },
                { "first", n => { First = n.GetStringValue(); } },
                { "last", n => { Last = n.GetStringValue(); } },
                { "next", n => { Next = n.GetStringValue(); } },
                { "prev", n => { Prev = n.GetStringValue(); } },
                { "self", n => { Self = n.GetStringValue(); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("describedby", Describedby);
            writer.WriteStringValue("first", First);
            writer.WriteStringValue("last", Last);
            writer.WriteStringValue("next", Next);
            writer.WriteStringValue("prev", Prev);
            writer.WriteStringValue("self", Self);
        }
    }
}
#pragma warning restore CS0618
