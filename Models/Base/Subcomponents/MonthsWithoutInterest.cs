using Newtonsoft.Json;

namespace PayU.Models.Base.Subcomponents
{
    /// <summary>
    /// Parameter applicable to Mexico where months without interest are allowed.
    /// </summary>
    public class MonthsWithoutInterest
    {
        /// <summary>
        /// The number of months without interests with which the purchase wants to be made.
        /// The options are: 3, 6, 9 or 12.
        /// </summary>
        [JsonProperty("months")]
        public int Months { get; set; }
        
        /// <summary>
        /// The bank of the credit card with which the purchase is going to be made with months without interest.
        /// </summary>
        [JsonProperty("bank")]
        public string Bank { get; set; }
    }
}