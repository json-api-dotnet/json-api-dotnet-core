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
    public partial class CreateTagOperation : global::OpenApiKiotaClientExample.GeneratedCode.Models.AtomicOperation, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The data property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTagRequest? Data
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTagRequest?>("data"); }
            set { BackingStore?.Set("data", value); }
        }

        /// <summary>The op property</summary>
        public global::OpenApiKiotaClientExample.GeneratedCode.Models.AddOperationCode? Op
        {
            get { return BackingStore?.Get<global::OpenApiKiotaClientExample.GeneratedCode.Models.AddOperationCode?>("op"); }
            set { BackingStore?.Set("op", value); }
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaClientExample.GeneratedCode.Models.CreateTagOperation"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::OpenApiKiotaClientExample.GeneratedCode.Models.CreateTagOperation CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaClientExample.GeneratedCode.Models.CreateTagOperation();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "data", n => { Data = n.GetObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTagRequest>(global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTagRequest.CreateFromDiscriminatorValue); } },
                { "op", n => { Op = n.GetEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.AddOperationCode>(); } },
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
            writer.WriteObjectValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.DataInCreateTagRequest>("data", Data);
            writer.WriteEnumValue<global::OpenApiKiotaClientExample.GeneratedCode.Models.AddOperationCode>("op", Op);
        }
    }
}
#pragma warning restore CS0618
