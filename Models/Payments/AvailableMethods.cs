using System.Collections.Generic;
using Newtonsoft.Json;
using PayU.Models.Base;

namespace PayU.Models.Payments
{
    /// <summary>
    /// Defines a particular payment method.
    /// </summary>
    public class PaymentMethod
    {
        /// <summary>
        /// Unique identifier for the payment method.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Short description of the payment method.
        /// </summary>
        [JsonProperty("decription")]
        public string Description { get; set; }
        
        /// <summary>
        /// Country in which this payment method operates
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
        
        /// <summary>
        /// Describes whether a particular payment method is enabled or not.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        
        /// <summary>
        /// Additional notes regarding the payment method.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }

    /// <summary>
    /// Defines all the available payment methods for the specified account.
    /// </summary>
    public class AvailableMethods: BaseResponse
    {
        [JsonProperty("paymentMethods")]
        public List<PaymentMethod> PaymentMethods { get; set; }
    }
}