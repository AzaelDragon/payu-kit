using System;
using Newtonsoft.Json;

namespace PayU.Models.Base.Subcomponents
{
    /// <summary>
    /// Describes additional parameters or data associated with a request transaction.
    /// These parameters may vary according to the payment means or shop’s preferences.
    /// </summary>
    public class RequestExtraParameters
    {
        /// <summary>
        /// Determines the amount of installments in which to differ a purchase.
        /// </summary>
        [JsonProperty("INSTALLMENTS_NUMBER")]
        public int? InstallmentsNumber { get; set; }
        
        /// <summary>
        /// Where to send the buyer once the payment flow finishes.
        /// Used only for PSE in Colombia.
        /// </summary>
        [JsonProperty("RESPONSE_URL")]
        public string ResponseURL { get; set; }
        
        /// <summary>
        /// The target bank's internal code, obtained through a previous request using <see cref=""/>.
        /// Used only for PSE in Colombia.
        /// </summary>
        [JsonProperty("FINANCIAL_INSTITUTION_CODE")]
        public string FinancialInstitutionCode { get; set; }
        
        /// <summary>
        /// Determines the kind of user that will be paying for the order.
        /// It's possible values are N for a natural person, or J for a legal person.
        /// Used only for PSE in Colombia.
        /// </summary>
        [JsonProperty("USER_TYPE")]
        public string UserType { get; set; }
        
        /// <summary>
        /// The user's IP address, used for verification purposes.
        /// Used only for PSE in Colombia.
        /// </summary>
        [JsonProperty("PSE_REFERENCE1")]
        public string UserIP { get; set; }
        
        /// <summary>
        /// The user's ISO National ID type. Can be CC for citizenship card, CE for foreign citizenship card,
        /// NIT for a company, TI for an identity card, PP for passport, IDC for unique customer, CEL for mobile line,
        /// RC for birth certificate, or DE for foreign identification.
        /// Used only for PSE in Colombia.
        /// </summary>
        [JsonProperty("PSE_REFERENCE2")]
        public string DocumentType { get; set; }
        
        /// <summary>
        /// The user's identification number, matching with <see cref="DocumentType"/>.
        /// Used only for PSE in Colombia.
        /// </summary>
        [JsonProperty("PSE_REFERENCE3")]
        public string UserDNI { get; set; }
    }

    /// <summary>
    /// Describes additional parameters or data associated with a response transaction.
    /// These parameters may vary according to the payment means or shop’s preferences.
    /// </summary>
    public class ResponseExtraParameters
    {
        /// <summary>
        /// Cash only parameter!
        /// The payment voucher used for cash and bank payments.
        /// </summary>
        [JsonProperty("URL_PAYMENT_RECEIPT_HTML")]
        public string PaymentReceiptURL { get; set; }
        
        /// <summary>
        /// Cash only parameter!
        /// The date in which the cash or bank transfer transaction will be invalidated and marked as expired.
        /// </summary>
        [JsonProperty("EXPIRATION_DATE")]
        public DateTime ExpirationDate { get; set; }
        
        /// <summary>
        /// Cash only parameter!
        /// The reference of the payment voucher generated.
        /// </summary>
        [JsonProperty("REFERENCE")]
        public int Reference { get; set; }
        
        /// <summary>
        /// OXXO and Pago Facil only parameter!
        /// The bar code of the generated payment voucher.
        /// </summary>
        [JsonProperty("BAR_CODE")]
        public string Barcode { get; set; }
        
        /// <summary>
        /// Boleto Bancario only parameter!
        /// The url to redirect a user to in the beginning of the payment flow.
        /// </summary>
        [JsonProperty("URL_BOLETO_BANCARIO")]
        public string BoletoURL { get; set; }
        
        /// <summary>
        /// PSE only parameter!
        /// The url to redirect a payer to during the start of a PSE payment flow.
        /// </summary>
        [JsonProperty("BANK_URL")]
        public string BankURL { get; set; }
    }

}