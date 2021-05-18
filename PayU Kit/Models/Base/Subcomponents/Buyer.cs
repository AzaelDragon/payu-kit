using Newtonsoft.Json;

namespace PayU.Models.Base.Subcomponents
{
    /// <summary>
    /// Describes the details of the buyer for the transaction.
    /// </summary>
    public class Buyer
    {
        /// <summary>
        /// The Buyer’s identifier of the buyer in the shop’s system.
        /// </summary>
        [JsonProperty("merchantBuyerId")]
        public string MerchantBuyerId { get; set; }
        
        /// <summary>
        /// The Buyer’s full name.
        /// </summary>
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        
        /// <summary>
        /// The Buyer's email.
        /// </summary>
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        
        /// <summary>
        /// The Buyer's contact phone.
        /// </summary>
        [JsonProperty("contactPhone")]
        public string ContactPhone { get; set; }
        
        /// <summary>
        /// The Buyer’s national identification number.
        /// For Brazil, an algorithm must be used to validate the CPF, and must be formatted XXX.XXX.XXX-XX.
        /// For example: 811.807.405-64
        /// </summary>
        [JsonProperty("dniNumber")]
        public string DNINumber { get; set; }
        
        /// <summary>
        /// The Buyer's CNPJ identification number if said customer is a legal person in Brazil.
        /// For Brazil, an algorithm must be used to validate the CNPJ, and must be formatted XXXXXXXXXXXXXX.
        /// For example: 32593371000110
        /// </summary>
        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }
        
        /// <summary>
        /// The Buyer's shipping address.
        /// </summary>
        [JsonProperty("shippingAddress")]
        public Address ShippingAddress { get; set; }
    }
}