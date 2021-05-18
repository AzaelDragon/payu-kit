using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayU.Models.Base.Subcomponents
{
    /// <summary>
    /// Describes the transaction's order information.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The identifier of the account.
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; }
        
        /// <summary>
        /// The reference code of the order. It represents the identifier of the transaction in the shop’s system.
        /// </summary>
        [JsonProperty("referenceCode")]
        public string ReferenceCode { get; set; }
        
        /// <summary>
        /// The description of the order.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// The language used in the emails that are sent to the buyer and seller.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }
        
        /// <summary>
        /// The URL used for notification or order confirmation.
        /// </summary>
        [JsonProperty("notifyUrl")]
        public string NotifyURL { get; set; }
        
        /// <summary>
        /// The partnerID within PayU (If applicable).
        /// </summary>
        [JsonProperty("partnerId")]
        public string PartnerID { get; set; }
        
        /// <summary>
        /// The signature associated with the order.
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }
        
        /// <summary>
        /// The shipping address for the order.
        /// </summary>
        [JsonProperty("shippingAddress")]
        public Address ShippingAddress { get; set; }
        
        /// <summary>
        /// The details of the buyer.
        /// </summary>
        [JsonProperty("buyer")]
        public Buyer Buyer { get; set; }

        /// <summary>
        /// Values or amounts associated with the order. In this field, one amount per entry is sent.
        /// </summary>
        [JsonProperty("additionalValues")]
        public AdditionalValues AdditionalValues { get; set; }
    }
}