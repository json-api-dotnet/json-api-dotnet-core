// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class LanguageDataInResponse : OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.DataInResponse, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse? Attributes
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse Attributes
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks? Links
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks Links
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse_meta? Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse_meta Meta
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "attributes", n => { Attributes = n.GetObjectValue<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse>(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse.CreateFromDiscriminatorValue); } },
                { "links", n => { Links = n.GetObjectValue<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks>(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks.CreateFromDiscriminatorValue); } },
                { "meta", n => { Meta = n.GetObjectValue<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse_meta>(OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse_meta.CreateFromDiscriminatorValue); } },
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
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageAttributesInResponse>("attributes", Attributes);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.ResourceLinks>("links", Links);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.Headers.GeneratedCode.Models.LanguageDataInResponse_meta>("meta", Meta);
        }
    }
}
