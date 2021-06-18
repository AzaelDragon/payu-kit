using Newtonsoft.Json;
using PayU.Models.Base;
using PayU.Models.Base.Subcomponents;

namespace PayU.Models.Payments
{
    public class PaymentTransactionRequest : BaseRequest
    {
        /// <summary>
        /// The transaction's data.
        /// </summary>
        [JsonProperty("transaction")]
        public Transaction Transaction { get; set; }
    }

    public class PaymentTransaction : BaseResponse
    {
        /// <summary>
        /// The transaction's result.
        /// </summary>
        [JsonProperty("transactionResponse")]
        public TransactionResponse TransactionResponse { get; set; }
    }

    public class TransactionPrototype
    {
        public string Country { get; set; }
        
        public string Currency { get; set; }
        
        public double Value { get; set; }
        
        public string AccountID { get; set; }
        
        public string Description { get; set; }
        
        public string NotifyURL { get; set; }
        
        public Address Address { get; set; }
        public string ReferenceCode { get; set; }
        
        public string Cookie { get; set; }
        
        public string UserAgent { get; set; }
        
        public string IPAddress { get; set; }
        
        public string DeviceSessionID { get; set; }
        
        public ThreeDomainSecure ThreeDomainSecure { get; set; }
    }
}