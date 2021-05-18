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
        private Transaction Transaction { get; set; }
    }

    public class PaymentTransaction : BaseResponse
    {
        /// <summary>
        /// The transaction's result.
        /// </summary>
        [JsonProperty("transactionResponse")]
        private TransactionResponse TransactionResponse { get; set; }
    }
}