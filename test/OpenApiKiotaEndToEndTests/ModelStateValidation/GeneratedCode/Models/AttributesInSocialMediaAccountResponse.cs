// <auto-generated/>
#nullable enable
#pragma warning disable CS8625
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System;
namespace OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class AttributesInSocialMediaAccountResponse : global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.AttributesInResponse, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The age property</summary>
        public double? Age
        {
            get { return BackingStore?.Get<double?>("age"); }
            set { BackingStore?.Set("age", value); }
        }

        /// <summary>The alternativeId property</summary>
        public Guid? AlternativeId
        {
            get { return BackingStore?.Get<Guid?>("alternativeId"); }
            set { BackingStore?.Set("alternativeId", value); }
        }

        /// <summary>The backgroundPicture property</summary>
        public string? BackgroundPicture
        {
            get { return BackingStore?.Get<string?>("backgroundPicture"); }
            set { BackingStore?.Set("backgroundPicture", value); }
        }

        /// <summary>The countryCode property</summary>
        public string? CountryCode
        {
            get { return BackingStore?.Get<string?>("countryCode"); }
            set { BackingStore?.Set("countryCode", value); }
        }

        /// <summary>The creditCard property</summary>
        public string? CreditCard
        {
            get { return BackingStore?.Get<string?>("creditCard"); }
            set { BackingStore?.Set("creditCard", value); }
        }

        /// <summary>The email property</summary>
        public string? Email
        {
            get { return BackingStore?.Get<string?>("email"); }
            set { BackingStore?.Set("email", value); }
        }

        /// <summary>The firstName property</summary>
        public string? FirstName
        {
            get { return BackingStore?.Get<string?>("firstName"); }
            set { BackingStore?.Set("firstName", value); }
        }

        /// <summary>The lastName property</summary>
        public string? LastName
        {
            get { return BackingStore?.Get<string?>("lastName"); }
            set { BackingStore?.Set("lastName", value); }
        }

        /// <summary>The nextRevalidation property</summary>
        public string? NextRevalidation
        {
            get { return BackingStore?.Get<string?>("nextRevalidation"); }
            set { BackingStore?.Set("nextRevalidation", value); }
        }

        /// <summary>The password property</summary>
        public string? Password
        {
            get { return BackingStore?.Get<string?>("password"); }
            set { BackingStore?.Set("password", value); }
        }

        /// <summary>The phone property</summary>
        public string? Phone
        {
            get { return BackingStore?.Get<string?>("phone"); }
            set { BackingStore?.Set("phone", value); }
        }

        /// <summary>The planet property</summary>
        public string? Planet
        {
            get { return BackingStore?.Get<string?>("planet"); }
            set { BackingStore?.Set("planet", value); }
        }

        /// <summary>The profilePicture property</summary>
        public string? ProfilePicture
        {
            get { return BackingStore?.Get<string?>("profilePicture"); }
            set { BackingStore?.Set("profilePicture", value); }
        }

        /// <summary>The tags property</summary>
        public List<string>? Tags
        {
            get { return BackingStore?.Get<List<string>?>("tags"); }
            set { BackingStore?.Set("tags", value); }
        }

        /// <summary>The userName property</summary>
        public string? UserName
        {
            get { return BackingStore?.Get<string?>("userName"); }
            set { BackingStore?.Set("userName", value); }
        }

        /// <summary>The validatedAt property</summary>
        public DateTimeOffset? ValidatedAt
        {
            get { return BackingStore?.Get<DateTimeOffset?>("validatedAt"); }
            set { BackingStore?.Set("validatedAt", value); }
        }

        /// <summary>The validatedAtDate property</summary>
        public Date? ValidatedAtDate
        {
            get { return BackingStore?.Get<Date?>("validatedAtDate"); }
            set { BackingStore?.Set("validatedAtDate", value); }
        }

        /// <summary>The validatedAtTime property</summary>
        public Time? ValidatedAtTime
        {
            get { return BackingStore?.Get<Time?>("validatedAtTime"); }
            set { BackingStore?.Set("validatedAtTime", value); }
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.AttributesInSocialMediaAccountResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.AttributesInSocialMediaAccountResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::OpenApiKiotaEndToEndTests.ModelStateValidation.GeneratedCode.Models.AttributesInSocialMediaAccountResponse();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "age", n => { Age = n.GetDoubleValue(); } },
                { "alternativeId", n => { AlternativeId = n.GetGuidValue(); } },
                { "backgroundPicture", n => { BackgroundPicture = n.GetStringValue(); } },
                { "countryCode", n => { CountryCode = n.GetStringValue(); } },
                { "creditCard", n => { CreditCard = n.GetStringValue(); } },
                { "email", n => { Email = n.GetStringValue(); } },
                { "firstName", n => { FirstName = n.GetStringValue(); } },
                { "lastName", n => { LastName = n.GetStringValue(); } },
                { "nextRevalidation", n => { NextRevalidation = n.GetStringValue(); } },
                { "password", n => { Password = n.GetStringValue(); } },
                { "phone", n => { Phone = n.GetStringValue(); } },
                { "planet", n => { Planet = n.GetStringValue(); } },
                { "profilePicture", n => { ProfilePicture = n.GetStringValue(); } },
                { "tags", n => { Tags = n.GetCollectionOfPrimitiveValues<string>()?.AsList(); } },
                { "userName", n => { UserName = n.GetStringValue(); } },
                { "validatedAt", n => { ValidatedAt = n.GetDateTimeOffsetValue(); } },
                { "validatedAtDate", n => { ValidatedAtDate = n.GetDateValue(); } },
                { "validatedAtTime", n => { ValidatedAtTime = n.GetTimeValue(); } },
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
            writer.WriteDoubleValue("age", Age);
            writer.WriteGuidValue("alternativeId", AlternativeId);
            writer.WriteStringValue("backgroundPicture", BackgroundPicture);
            writer.WriteStringValue("countryCode", CountryCode);
            writer.WriteStringValue("creditCard", CreditCard);
            writer.WriteStringValue("email", Email);
            writer.WriteStringValue("firstName", FirstName);
            writer.WriteStringValue("lastName", LastName);
            writer.WriteStringValue("nextRevalidation", NextRevalidation);
            writer.WriteStringValue("password", Password);
            writer.WriteStringValue("phone", Phone);
            writer.WriteStringValue("planet", Planet);
            writer.WriteStringValue("profilePicture", ProfilePicture);
            writer.WriteCollectionOfPrimitiveValues<string>("tags", Tags);
            writer.WriteStringValue("userName", UserName);
            writer.WriteDateTimeOffsetValue("validatedAt", ValidatedAt);
            writer.WriteDateValue("validatedAtDate", ValidatedAtDate);
            writer.WriteTimeValue("validatedAtTime", ValidatedAtTime);
        }
    }
}
#pragma warning restore CS0618
