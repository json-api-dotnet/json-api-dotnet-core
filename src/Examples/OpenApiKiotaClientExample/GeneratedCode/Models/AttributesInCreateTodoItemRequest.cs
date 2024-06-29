// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace OpenApiKiotaClientExample.GeneratedCode.Models
{
    #pragma warning disable CS1591
    public class AttributesInCreateTodoItemRequest : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The description property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description
        {
            get { return BackingStore?.Get<string?>("description"); }
            set { BackingStore?.Set("description", value); }
        }
#nullable restore
#else
        public string Description
        {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
#endif
        /// <summary>The durationInHours property</summary>
        public long? DurationInHours
        {
            get { return BackingStore?.Get<long?>("durationInHours"); }
            set { BackingStore?.Set("durationInHours", value); }
        }
        /// <summary>The priority property</summary>
        public OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemPriority? Priority
        {
            get { return BackingStore?.Get<OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemPriority?>("priority"); }
            set { BackingStore?.Set("priority", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTodoItemRequest"/> and sets the default values.
        /// </summary>
        public AttributesInCreateTodoItemRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTodoItemRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTodoItemRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OpenApiKiotaClientExample.GeneratedCode.Models.AttributesInCreateTodoItemRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "description", n => { Description = n.GetStringValue(); } },
                { "durationInHours", n => { DurationInHours = n.GetLongValue(); } },
                { "priority", n => { Priority = n.GetEnumValue<OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemPriority>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("description", Description);
            writer.WriteLongValue("durationInHours", DurationInHours);
            writer.WriteEnumValue<OpenApiKiotaClientExample.GeneratedCode.Models.TodoItemPriority>("priority", Priority);
        }
    }
}
