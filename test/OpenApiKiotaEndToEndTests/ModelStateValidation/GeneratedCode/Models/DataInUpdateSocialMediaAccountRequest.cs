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
namespace OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class DataInUpdateSocialMediaAccountRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
        public global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.AttributesInUpdateSocialMediaAccountRequest? Attributes
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.AttributesInUpdateSocialMediaAccountRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }

        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }

        /// <summary>The id property</summary>
        public Guid? Id
        {
            get { return BackingStore?.Get<Guid?>("id"); }
            set { BackingStore?.Set("id", value); }
        }

        /// <summary>The meta property</summary>
        public global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.Meta? Meta
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.Meta?>("meta"); }
            set { BackingStore?.Set("meta", value); }
        }

        /// <summary>The type property</summary>
        public global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.SocialMediaAccountResourceType? Type
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.SocialMediaAccountResourceType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }

        /// <summary>
        /// Instantiates a new <see cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest"/> and sets the default values.
        /// </summary>
        public DataInUpdateSocialMediaAccountRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "attributes", n => { Attributes = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.AttributesInUpdateSocialMediaAccountRequest>(global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.AttributesInUpdateSocialMediaAccountRequest.CreateFromDiscriminatorValue); } },
                { "id", n => { Id = n.GetGuidValue(); } },
                { "meta", n => { Meta = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.Meta>(global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.Meta.CreateFromDiscriminatorValue); } },
                { "type", n => { Type = n.GetEnumValue<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.SocialMediaAccountResourceType>(); } },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.AttributesInUpdateSocialMediaAccountRequest>("attributes", Attributes);
            writer.WriteGuidValue("id", Id);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.Meta>("meta", Meta);
            writer.WriteEnumValue<global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.SocialMediaAccountResourceType>("type", Type);
        }
    }
}
#pragma warning restore CS0618
