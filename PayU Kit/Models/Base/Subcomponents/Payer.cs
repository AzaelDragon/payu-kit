using Newtonsoft.Json;

namespace PayU.Models.Base.Subcomponents
{
    /// <summary>
    /// Describes the details of the Payer for the transaction.
    /// </summary>
    public class Payer
    {
        /// <summary>
        /// The Payer's identifier of the buyer in the shop’s system.
        /// </summary>
        [JsonProperty("merchantPayerId")]
        public string MerchantPayerId { get; set; }
        
        /// <summary>
        /// The Payer's full name.
        /// </summary>
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        
        /// <summary>
        /// The Payer's email.
        /// </summary>
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        
        /// <summary>
        /// The Payer's contact phone.
        /// </summary>
        [JsonProperty("contactPhone")]
        public string ContactPhone { get; set; }
        
        /// <summary>
        /// The Payer's date of birth.
        /// </summary>
        [JsonProperty("birthDate")]
        public string BirthDate { get; set; }
        
        /// <summary>
        /// The type of identification number of the Payer.
        /// See http://developers.payulatam.com/en/api/variables_table.html for available types.
        /// </summary>
        [JsonProperty("dniType")]
        public string DNIType { get; set; }
        
        /// <summary>
        /// The Payer's national identification number.
        /// For Brazil, an algorithm must be used to validate the CPF, and must be formatted XXX.XXX.XXX-XX.
        /// For example: 811.807.405-64
        /// </summary>
        [JsonProperty("dniNumber")]
        public string DNINumber { get; set; }

        /// <summary>
        /// The Payer's shipping address.
        /// </summary>
        [JsonProperty("billingAddress")]
        public Address BillingAddress { get; set; }
    }
}