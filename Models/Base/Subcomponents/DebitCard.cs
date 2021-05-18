using Newtonsoft.Json;

namespace PayU.Models.Base.Subcomponents
{
    /// <summary>
    /// Describes a basic implementable card.
    /// </summary>
    public class DebitCard
    {
    
        /// <summary>
        /// The card's number.
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// The card's secondary security verification code (CVC2, CVV2 or CID)
        /// </summary>
        [JsonProperty("securityCode")]
        public int SecurityCode { get; set; }

        /// <summary>
        /// The card's expiration date. Must follow a YYYY/MM format.
        /// </summary>
        [JsonProperty("expirationDate")]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// The cardholder's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}