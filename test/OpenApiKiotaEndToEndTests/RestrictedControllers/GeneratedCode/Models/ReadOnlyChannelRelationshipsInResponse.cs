// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class ReadOnlyChannelRelationshipsInResponse : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The audioStreams property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse? AudioStreams
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse?>("audioStreams"); }
            set { BackingStore?.Set("audioStreams", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse AudioStreams
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse>("audioStreams"); }
            set { BackingStore?.Set("audioStreams", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The ultraHighDefinitionVideoStream property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse? UltraHighDefinitionVideoStream
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse?>("ultraHighDefinitionVideoStream"); }
            set { BackingStore?.Set("ultraHighDefinitionVideoStream", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse UltraHighDefinitionVideoStream
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse>("ultraHighDefinitionVideoStream"); }
            set { BackingStore?.Set("ultraHighDefinitionVideoStream", value); }
        }
#endif
        /// <summary>The videoStream property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse? VideoStream
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse?>("videoStream"); }
            set { BackingStore?.Set("videoStream", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse VideoStream
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse>("videoStream"); }
            set { BackingStore?.Set("videoStream", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ReadOnlyChannelRelationshipsInResponse"/> and sets the default values.
        /// </summary>
        public ReadOnlyChannelRelationshipsInResponse()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ReadOnlyChannelRelationshipsInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ReadOnlyChannelRelationshipsInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ReadOnlyChannelRelationshipsInResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "audioStreams", n => { AudioStreams = n.GetObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse>(OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse.CreateFromDiscriminatorValue); } },
                { "ultraHighDefinitionVideoStream", n => { UltraHighDefinitionVideoStream = n.GetObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse>(OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse.CreateFromDiscriminatorValue); } },
                { "videoStream", n => { VideoStream = n.GetObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse>(OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToManyDataStreamInResponse>("audioStreams", AudioStreams);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.NullableToOneDataStreamInResponse>("ultraHighDefinitionVideoStream", UltraHighDefinitionVideoStream);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.RestrictedControllers.GeneratedCode.Models.ToOneDataStreamInResponse>("videoStream", VideoStream);
        }
    }
}
