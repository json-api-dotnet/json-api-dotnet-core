// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models {
    public class AccommodationDataInPatchRequest : IBackedModel, IParsable {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public AccommodationAttributesInPatchRequest? Attributes {
            get { return BackingStore?.Get<AccommodationAttributesInPatchRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public AccommodationAttributesInPatchRequest Attributes {
            get { return BackingStore?.Get<AccommodationAttributesInPatchRequest>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The id property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id {
            get { return BackingStore?.Get<string?>("id"); }
            set { BackingStore?.Set("id", value); }
        }
#nullable restore
#else
        public string Id {
            get { return BackingStore?.Get<string>("id"); }
            set { BackingStore?.Set("id", value); }
        }
#endif
        /// <summary>The type property</summary>
        public AccommodationResourceType? Type {
            get { return BackingStore?.Get<AccommodationResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new accommodationDataInPatchRequest and sets the default values.
        /// </summary>
        public AccommodationDataInPatchRequest() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static AccommodationDataInPatchRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccommodationDataInPatchRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"attributes", n => { Attributes = n.GetObjectValue<AccommodationAttributesInPatchRequest>(AccommodationAttributesInPatchRequest.CreateFromDiscriminatorValue); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"type", n => { Type = n.GetEnumValue<AccommodationResourceType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<AccommodationAttributesInPatchRequest>("attributes", Attributes);
            writer.WriteStringValue("id", Id);
            writer.WriteEnumValue<AccommodationResourceType>("type", Type);
        }
    }
}
