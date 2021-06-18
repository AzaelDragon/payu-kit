using Newtonsoft.Json;

namespace PayU.Models.Payments
{
    public class TransactionalNotification
    {
    [JsonProperty("merchant_id")]
    public string MerchantId { get; set; }

    [JsonProperty("state_pol")]
    public string StatePol { get; set; }

    [JsonProperty("risk")]
    public string Risk { get; set; }

    [JsonProperty("response_code_pol")]
    public string ResponseCodePol { get; set; }

    [JsonProperty("reference_sale")]
    public string ReferenceSale { get; set; }

    [JsonProperty("reference_pol")]
    public string ReferencePol { get; set; }

    [JsonProperty("sign")]
    public string Sign { get; set; }

    [JsonProperty("extra1")]
    public string Extra1 { get; set; }

    [JsonProperty("extra2")]
    public string Extra2 { get; set; }

    [JsonProperty("payment_method")]
    public string PaymentMethod { get; set; }

    [JsonProperty("payment_method_type")]
    public string PaymentMethodType { get; set; }

    [JsonProperty("installments_number")]
    public string InstallmentsNumber { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("tax")]
    public string Tax { get; set; }

    [JsonProperty("additional_value")]
    public string AdditionalValue { get; set; }

    [JsonProperty("transaction_date")]
    public string TransactionDate { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("email_buyer")]
    public string EmailBuyer { get; set; }

    [JsonProperty("cus")]
    public string Cus { get; set; }

    [JsonProperty("pse_bank")]
    public string PseBank { get; set; }

    [JsonProperty("test")]
    public string Test { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("billing_address")]
    public string BillingAddress { get; set; }

    [JsonProperty("shipping_address")]
    public string ShippingAddress { get; set; }

    [JsonProperty("phone")]
    public string Phone { get; set; }

    [JsonProperty("office_phone")]
    public string OfficePhone { get; set; }

    [JsonProperty("account_number_ach")]
    public string AccountNumberAch { get; set; }

    [JsonProperty("account_type_ach")]
    public string AccountTypeAch { get; set; }

    [JsonProperty("administrative_fee")]
    public string AdministrativeFee { get; set; }

    [JsonProperty("administrative_fee_base")]
    public string AdministrativeFeeBase { get; set; }

    [JsonProperty("administrative_fee_tax")]
    public string AdministrativeFeeTax { get; set; }

    [JsonProperty("airline_code")]
    public string AirlineCode { get; set; }

    [JsonProperty("attempts")]
    public string Attempts { get; set; }

    [JsonProperty("authorization_code")]
    public string AuthorizationCode { get; set; }

    [JsonProperty("travel_agency_authorization_code")]
    public string TravelAgencyAuthorizationCode { get; set; }

    [JsonProperty("bank_id")]
    public string BankId { get; set; }

    [JsonProperty("billing_city")]
    public string BillingCity { get; set; }

    [JsonProperty("billing_country")]
    public string BillingCountry { get; set; }

    [JsonProperty("commision_pol")]
    public string CommisionPol { get; set; }

    [JsonProperty("commision_pol_currency")]
    public string CommisionPolCurrency { get; set; }

    [JsonProperty("customer_number")]
    public string CustomerNumber { get; set; }

    [JsonProperty("date")]
    public string Date { get; set; }

    [JsonProperty("error_code_bank")]
    public string ErrorCodeBank { get; set; }

    [JsonProperty("error_message_bank")]
    public string ErrorMessageBank { get; set; }

    [JsonProperty("exchange_rate")]
    public string ExchangeRate { get; set; }

    [JsonProperty("ip")]
    public string Ip { get; set; }

    [JsonProperty("nickname_buyer")]
    public string NicknameBuyer { get; set; }

    [JsonProperty("nickname_seller")]
    public string NicknameSeller { get; set; }

    [JsonProperty("payment_method_id")]
    public string PaymentMethodId { get; set; }

    [JsonProperty("payment_request_state")]
    public string PaymentRequestState { get; set; }

    [JsonProperty("pseReference1")]
    public string PseReference1 { get; set; }

    [JsonProperty("pseReference2")]
    public string PseReference2 { get; set; }

    [JsonProperty("pseReference3")]
    public string PseReference3 { get; set; }

    [JsonProperty("response_message_pol")]
    public string ResponseMessagePol { get; set; }

    [JsonProperty("shipping_city")]
    public string ShippingCity { get; set; }

    [JsonProperty("shipping_country")]
    public string ShippingCountry { get; set; }

    [JsonProperty("transaction_bank_id")]
    public string TransactionBankId { get; set; }

    [JsonProperty("transaction_id")]
    public string TransactionId { get; set; }

    [JsonProperty("payment_method_name")]
    public string PaymentMethodName { get; set; }
    }
}