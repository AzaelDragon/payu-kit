using Newtonsoft.Json;

namespace PayU.Models.Base.Subcomponents
{
    /// <summary>
    /// Describes a shipping address for a particular order.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// First line of the address.
        /// </summary>
        [JsonProperty("street1")]
        public string Street1 { get; set; }
        
        /// <summary>
        /// Second line of the address.
        /// </summary>
        [JsonProperty("street2")]
        public string Street2 { get; set; }
        
        /// <summary>
        /// The city of the address.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }
        
        /// <summary>
        /// State or province.
        /// For Brazil send only 2 characters.
        /// For example: If it is Sao Paulo then send SP.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
        
        /// <summary>
        /// The country of the address.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
        
        /// <summary>
        /// The postal code of the address.
        /// </summary>
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        
        /// <summary>
        /// Phone number associated with the address.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}