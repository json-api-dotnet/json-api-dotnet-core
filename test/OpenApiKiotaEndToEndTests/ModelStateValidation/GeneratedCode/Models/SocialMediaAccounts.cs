// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models {
    #pragma warning disable CS1591
    public class SocialMediaAccounts : DataInResponse, IParsable 
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public SocialMediaAccountAttributesInResponse? Attributes {
            get { return BackingStore?.Get<SocialMediaAccountAttributesInResponse?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#nullable restore
#else
        public SocialMediaAccountAttributesInResponse Attributes {
            get { return BackingStore?.Get<SocialMediaAccountAttributesInResponse>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }
#endif
        /// <summary>The links property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ResourceLinks? Links {
            get { return BackingStore?.Get<ResourceLinks?>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#nullable restore
#else
        public ResourceLinks Links {
            get { return BackingStore?.Get<ResourceLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
#endif
        /// <summary>The meta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public SocialMediaAccounts_meta? Meta {
            get { return BackingStore?.Get<SocialMediaAccounts_meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#nullable restore
#else
        public SocialMediaAccounts_meta Meta {
            get { return BackingStore?.Get<SocialMediaAccounts_meta>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="SocialMediaAccounts"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new SocialMediaAccounts CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SocialMediaAccounts();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                {"attributes", n => { Attributes = n.GetObjectValue<SocialMediaAccountAttributesInResponse>(SocialMediaAccountAttributesInResponse.CreateFromDiscriminatorValue); } },
                {"links", n => { Links = n.GetObjectValue<ResourceLinks>(ResourceLinks.CreateFromDiscriminatorValue); } },
                {"meta", n => { Meta = n.GetObjectValue<SocialMediaAccounts_meta>(SocialMediaAccounts_meta.CreateFromDiscriminatorValue); } },
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
            writer.WriteObjectValue<SocialMediaAccountAttributesInResponse>("attributes", Attributes);
            writer.WriteObjectValue<ResourceLinks>("links", Links);
            writer.WriteObjectValue<SocialMediaAccounts_meta>("meta", Meta);
        }
    }
}
