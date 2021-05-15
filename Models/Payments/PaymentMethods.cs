using System.Collections.Generic;
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
        public string id { get; set; }
        
        /// <summary>
        /// Short description of the payment method.
        /// </summary>
        public string description { get; set; }
        
        /// <summary>
        /// Country in which this payment method operates
        /// </summary>
        public string country { get; set; }
        
        /// <summary>
        /// Describes whether a particular payment method is enabled or not.
        /// </summary>
        public bool enabled { get; set; }
        
        /// <summary>
        /// Additional notes regarding the payment method.
        /// </summary>
        public string reason { get; set; }
    }

    /// <summary>
    /// Defines all the available payment methods for the specified account.
    /// </summary>
    public class PaymentMethods: BaseResponse
    {
        public List<PaymentMethod> paymentMethods { get; set; }
    }
}