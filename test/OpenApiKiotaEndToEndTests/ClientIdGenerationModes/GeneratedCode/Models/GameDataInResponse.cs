// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class GameDataInResponse : OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.DataInResponse, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.GameAttributesInResponse? Attributes
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.GameAttributesInResponse?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.GameAttributesInResponse Attributes
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.GameAttributesInResponse>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>The id property</summary>
        public Guid? Id
        {
            get { return BackingStore?.Get<Guid?>("id"); }
            set { BackingStore?.Set("id", value); }
        }
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.ResourceLinks? Links
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.ResourceLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.ResourceLinks Links
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.ResourceLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.Meta Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.Meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.GameDataInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.GameDataInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.GameDataInResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "attributes", n => { Attributes = n.GetObjectValue<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.GameAttributesInResponse>(OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.GameAttributesInResponse.CreateFromDiscriminatorValue); } },
                { "id", n => { Id = n.GetGuidValue(); } },
                { "links", n => { Links = n.GetObjectValue<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.ResourceLinks>(OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.ResourceLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.Meta>(OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.GameAttributesInResponse>("attributes", Attributes);
            writer.WriteGuidValue("id", Id);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.ResourceLinks>("links", Links);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.ClientIdGenerationModes.GeneratedCode.Models.Meta>("meta", Meta);
        }
    }
}
