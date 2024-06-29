// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class AddToCourseTaughtByRelationshipOperation : OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AtomicOperation, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.TeacherIdentifierInRequest>? Data
        {
            get { return BackingStore?.Get<List<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.TeacherIdentifierInRequest>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public List<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.TeacherIdentifierInRequest> Data
        {
            get { return BackingStore?.Get<List<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.TeacherIdentifierInRequest>>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The op property</summary>
        public OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddOperationCode? Op
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddOperationCode?>("op"); }
            set { BackingStore?.Set("op", value); }
        }
        /// <summary>The ref property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseTaughtByRelationshipIdentifier? Ref
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseTaughtByRelationshipIdentifier?>("ref"); }
            set { BackingStore?.Set("ref", value); }
        }
#nullable restore
#else
        public OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseTaughtByRelationshipIdentifier Ref
        {
            get { return BackingStore?.Get<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseTaughtByRelationshipIdentifier>("ref"); }
            set { BackingStore?.Set("ref", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddToCourseTaughtByRelationshipOperation"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddToCourseTaughtByRelationshipOperation CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddToCourseTaughtByRelationshipOperation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "data", n => { Data = n.GetCollectionOfObjectValues<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.TeacherIdentifierInRequest>(OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.TeacherIdentifierInRequest.CreateFromDiscriminatorValue)?.ToList(); } },
                { "op", n => { Op = n.GetEnumValue<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddOperationCode>(); } },
                { "ref", n => { Ref = n.GetObjectValue<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseTaughtByRelationshipIdentifier>(OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseTaughtByRelationshipIdentifier.CreateFromDiscriminatorValue); } },
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
            writer.WriteCollectionOfObjectValues<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.TeacherIdentifierInRequest>("data", Data);
            writer.WriteEnumValue<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.AddOperationCode>("op", Op);
            writer.WriteObjectValue<OpenApiKiotaEndToEndTests.AtomicOperations.GeneratedCode.Models.CourseTaughtByRelationshipIdentifier>("ref", Ref);
        }
    }
}
