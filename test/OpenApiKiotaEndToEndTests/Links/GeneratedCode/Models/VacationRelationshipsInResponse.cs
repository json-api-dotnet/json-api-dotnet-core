// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class VacationRelationshipsInResponse : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The accommodation property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInResponse? Accommodation
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInResponse?>("accommodation"); }
            set { BackingStore?.Set("accommodation", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInResponse Accommodation
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInResponse>("accommodation"); }
            set { BackingStore?.Set("accommodation", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The excursions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToManyExcursionInResponse? Excursions
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToManyExcursionInResponse?>("excursions"); }
            set { BackingStore?.Set("excursions", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToManyExcursionInResponse Excursions
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToManyExcursionInResponse>("excursions"); }
            set { BackingStore?.Set("excursions", value); }
        }
#endif
        /// <summary>The transport property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse? Transport
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse?>("transport"); }
            set { BackingStore?.Set("transport", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse Transport
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse>("transport"); }
            set { BackingStore?.Set("transport", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.VacationRelationshipsInResponse"/> and sets the default values.
        /// </summary>
        public VacationRelationshipsInResponse()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.VacationRelationshipsInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.VacationRelationshipsInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.VacationRelationshipsInResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "accommodation", n => { Accommodation = n.GetObjectValue<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInResponse>(OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInResponse.CreateFromDiscriminatorValue); } },
                { "excursions", n => { Excursions = n.GetObjectValue<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToManyExcursionInResponse>(OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToManyExcursionInResponse.CreateFromDiscriminatorValue); } },
                { "transport", n => { Transport = n.GetObjectValue<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse>(OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToOneAccommodationInResponse>("accommodation", Accommodation);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.ToManyExcursionInResponse>("excursions", Excursions);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.Links.GeneratedCode.Models.NullableToOneTransportInResponse>("transport", Transport);
        }
    }
}
