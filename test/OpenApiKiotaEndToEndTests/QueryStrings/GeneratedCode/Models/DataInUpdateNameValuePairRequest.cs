// <auto-generated/>
#nullable enable
#pragma warning disable CS8625
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class DataInUpdateNameValuePairRequest : global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.DataInUpdateRequest, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInUpdateNameValuePairRequest? Attributes
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInUpdateNameValuePairRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }

        /// <summary>The id property</summary>
        public string? Id
        {
            get { return BackingStore?.Get<string?>("id"); }
            set { BackingStore?.Set("id", value); }
        }

        /// <summary>The relationships property</summary>
        public global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInUpdateNameValuePairRequest? Relationships
        {
            get { return BackingStore?.Get<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInUpdateNameValuePairRequest?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.DataInUpdateNameValuePairRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.DataInUpdateNameValuePairRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.DataInUpdateNameValuePairRequest();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "attributes", n => { Attributes = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInUpdateNameValuePairRequest>(global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInUpdateNameValuePairRequest.CreateFromDiscriminatorValue); } },
                { "id", n => { Id = n.GetStringValue(); } },
                { "relationships", n => { Relationships = n.GetObjectValue<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInUpdateNameValuePairRequest>(global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInUpdateNameValuePairRequest.CreateFromDiscriminatorValue); } },
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
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.AttributesInUpdateNameValuePairRequest>("attributes", Attributes);
            writer.WriteStringValue("id", Id);
            writer.WriteObjectValue<global::OpenApiKiotaEndToEndTests.QueryStrings.GeneratedCode.Models.RelationshipsInUpdateNameValuePairRequest>("relationships", Relationships);
        }
    }
}
#pragma warning restore CS0618
