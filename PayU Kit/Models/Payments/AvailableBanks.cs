using System.Collections.Generic;
using Newtonsoft.Json;
using PayU.Models.Base;

namespace PayU.Models.Payments
{

    /// <summary>
    /// Defines a bank usable for a Bank-related transaction.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// The internal UUID for the specified bank.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        
        /// <summary>
        /// The full name of the specified bank.
        /// </summary>
        [JsonProperty("description")]
        public string Name { get; set; }
        
        /// <summary>
        /// The internal PSE code used for transaction generation.
        /// See <see cref="RequestExtraParameters.FinancialInstitutionCode"/>.
        /// </summary>
        [JsonProperty("pseCode")]
        public string PSECode { get; set; }
    }
    
    /// <summary>
    /// Describes the bank list to fetch with the transaction.
    /// </summary>
    public class BankListInformation
    {
        /// <summary>
        /// The payment method to fetch the payment methods for.
        /// Use PSE for colombian bank transfers.
        /// </summary>
        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }
        
        /// <summary>
        /// The country from where to fetch the payment methods from.
        /// Use CO for PSE.
        /// </summary>
        [JsonProperty("paymentCountry")]
        public string PaymentCountry { get; set; }
    }

    /// <summary>
    /// The request structure used to request a list of banks available for transfers in a specific country.
    /// </summary>
    public class AvailableBanksRequest : BaseRequest
    {
        /// <summary>
        /// The parameters to fetch the banks from.
        /// </summary>
        [JsonProperty("bankListInformation")]
        public BankListInformation BankList { get; set; }
    }

    public class AvailableBanks : BaseResponse
    {
        /// <summary>
        /// The list of available banks for a specific country.
        /// </summary>
        [JsonProperty("banks")]
        public List<Bank> Banks { get; set; }
    }
}