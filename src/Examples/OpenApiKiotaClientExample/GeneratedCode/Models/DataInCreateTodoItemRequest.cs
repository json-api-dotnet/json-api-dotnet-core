// <auto-generated/>
#nullable enable
#pragma warning disable CS8625
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class DataInCreateTodoItemRequest : global::OpenApiKiotaClientExample.GeneratedCode.Models.ResourceInCreateRequest, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The attributes property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTodoItemRequest? Attributes
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTodoItemRequest?>("attributes"); }
            set { BackingStore?.Set("attributes", value); }
        }

        /// <summary>The lid property</summary>
        public string? Lid
        {
            get { return BackingStore?.Get<string?>("lid"); }
            set { BackingStore?.Set("lid", value); }
        }

        /// <summary>The relationships property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTodoItemRequest? Relationships
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTodoItemRequest?>("relationships"); }
            set { BackingStore?.Set("relationships", value); }
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTodoItemRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTodoItemRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTodoItemRequest();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "attributes", n => { Attributes = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTodoItemRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTodoItemRequest.CreateFromDiscriminatorValue); } },
                { "lid", n => { Lid = n.GetStringValue(); } },
                { "relationships", n => { Relationships = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTodoItemRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTodoItemRequest.CreateFromDiscriminatorValue); } },
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
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTodoItemRequest>("attributes", Attributes);
            writer.WriteStringValue("lid", Lid);
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.RelationshipsInCreateTodoItemRequest>("relationships", Relationships);
        }
    }
}
#pragma warning restore CS0618
