// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class UpdateSocialMediaAccountRequestDocument : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest? Data
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest Data
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.UpdateSocialMediaAccountRequestDocument"/> and sets the default values.
        /// </summary>
        public UpdateSocialMediaAccountRequestDocument()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.UpdateSocialMediaAccountRequestDocument"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.UpdateSocialMediaAccountRequestDocument CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.UpdateSocialMediaAccountRequestDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetObjectValue<OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest>(OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.DataInUpdateSocialMediaAccountRequest>("data", Data);
        }
    }
}
