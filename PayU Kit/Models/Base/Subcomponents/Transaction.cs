using System;
using Newtonsoft.Json;

namespace PayU.Models.Base.Subcomponents
{
    /// <summary>
    /// Describes a transaction's data.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The order's data.
        /// </summary>
        [JsonProperty("order")]
        public Order Order { get; set; }
        
        /// <summary>
        /// The payer's data.
        /// </summary>
        [JsonProperty("payer")]
        public Payer Payer { get; set; }
        
        /// <summary>
        /// The credit card's data if said payment method is being used.
        /// </summary>
        [JsonProperty("creditCard")]
        public CreditCard CreditCard { get; set; }
        
        /// <summary>
        /// The debit card's data if said payment method is being used.
        /// </summary>
        [JsonProperty("debitCard")]
        public DebitCard DebitCard { get; set; }
        
        /// <summary>
        /// Additional parameters or data associated with a transaction.
        /// These parameters may vary according to the payment means or shop’s preferences.
        /// </summary>
        [JsonProperty("extraParameters")]
        public RequestExtraParameters ExtraParameters { get; set; }
        
        /// <summary>
        /// The type of transaction to execute.
        /// See <see cref="TransactionType"/>'s helper functions to learn more.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        
        /// <summary>
        /// The Payment method to use in the transaction.
        /// See <see cref="PayU.Models.Payments.AvailableMethods"/> 
        /// </summary>
        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }
        
        /// <summary>
        /// The country where the payment will be processed. Must be a two character st ring.
        /// See http://developers.payulatam.com/en/api/variables_table.html for more information.
        /// </summary>
        [JsonProperty("paymentCountry")]
        public string PaymentCountry { get; set; }
        
        /// <summary>
        /// The session identifier of the device where the transaction was performed from.
        /// </summary>
        [JsonProperty("deviceSessionId")]
        public string DeviceSessionID { get; set; }
        
        /// <summary>
        /// The IP address of the buyer.
        /// </summary>
        [JsonProperty("ipAddress")]
        public string IPAddress { get; set; }
        
        /// <summary>
        /// The cookie stored on the device where the transaction was performed from.
        /// </summary>
        [JsonProperty("cookie")]
        public string Cookie { get; set; }
        
        /// <summary>
        /// The user agent of the browser from which the transaction was performed.
        /// </summary>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }
        
        /// <summary>
        /// 3DS 2.0 data.
        /// This object does not replace the card information or the required fields to start a transaction. This object is additional.
        /// This object corresponds to a Pass Through scenario where the shop performs the 3DS Authentication on its own. Currently, this scenario is only available for Colombia and Brazil.
        /// </summary>
        [JsonProperty("threeDomainSecure")]
        public ThreeDomainSecure ThreeDomainSecure { get; set; }

    }

    public class TransactionResponse
    {
        /// <summary>
        /// The generated or existing order identifier within PayU.
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderID { get; set; }
        
        /// <summary>
        /// The identifier of the transaction within PayU.
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionID { get; set; }
        
        /// <summary>
        /// The status of the transaction.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
        
        /// <summary>
        /// The response code associated with the status.
        /// </summary>
        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }
        
        /// <summary>
        /// The specific error code for the transaction, if any.
        /// </summary>
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
        
        /// <summary>
        /// The response code returned by the financial network.
        /// </summary>
        [JsonProperty("paymentNetworkResponseCode")]
        public string PaymentResponseCode { get; set; }

        /// <summary>
        /// The error message returned by the financial network.
        /// </summary>
        [JsonProperty("paymentNetworkResponseErrorMessage")]
        public string PaymentResponseError { get; set; }
        
        /// <summary>
        /// The traceability code returned by the financial network.
        /// </summary>
        [JsonProperty("trazabilityCode")]
        public string TraceabilityCode { get; set; }
        
        /// <summary>
        /// The authorization code returned by the financial network.
        /// </summary>
        [JsonProperty("authorizationCode")]
        public string AuthorizationCode { get; set; }
        
        /// <summary>
        /// The reason of why the payment was set as pending.
        /// </summary>
        [JsonProperty("pendingReason")]
        public string PendingReason { get; set; }

        /// <summary>
        /// Additional message for response.
        /// </summary>
        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }
        
        /// <summary>
        /// The date in which the transaction was made.
        /// </summary>
        [JsonProperty("transactionDate")]
        public DateTime TransactionDate { get; set; }
        
        /// <summary>
        /// The time in which the transaction was made.
        /// </summary>
        [JsonProperty("transactionTime")]
        public DateTime TransactionTime { get; set; }
        
        /// <summary>
        /// The date in which the operation was made.
        /// </summary>
        [JsonProperty("operationDate")]
        public DateTime OperationDate { get; set; }
        
        /// <summary>
        /// Additional parameters or data associated with the response.
        /// Extra parameters can vary with payment means, shop, country of payment, among others.
        /// </summary>
        [JsonProperty("extraParameters")]
        public ResponseExtraParameters ExtraParameters { get; set; }
    }

    public class TransactionType
    {
        /// <summary>
        /// The transaction type associated with the request.
        /// </summary>
        public readonly string Value;

        public TransactionType()
        {
        }

        public TransactionType(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the transaction to both authorize and capture a transaction's funds.
        /// </summary>
        /// <returns></returns>
        public static string AuthorizeAndCapture() => new TransactionType("AUTHORIZATION_AND_CAPTURE").Value;

        /// <summary>
        /// Sets the transaction to authorize only. A capture will be needed later on.
        /// </summary>
        /// <returns></returns>
        public static string Authorize() => new TransactionType("AUTHORIZATION").Value;

        /// <summary>
        /// Sets the transaction to capture only. An authorization should have been previously made.
        /// </summary>
        /// <returns></returns>
        public static string Capture() => new TransactionType("CAPTURE").Value;

    }
}