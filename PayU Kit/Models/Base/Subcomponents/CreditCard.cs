using Newtonsoft.Json;

namespace PayU.Models.Base.Subcomponents
{
    /// <summary>
    /// Describes a credit card's information.
    /// </summary>
    public class CreditCard : Card
    {
        
        /// <summary>
        /// Determines whether to process the transaction without verifying the security code.
        /// This is only available in accounts based in Brazil, Colombia and Mexico.
        /// Requires authorization by PayU to be used.
        /// </summary>
        [JsonProperty("processWithoutCvv2")]
        public bool ProcessWithoutCVV2 { get; set; }
        
    }
}