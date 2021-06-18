using Newtonsoft.Json;

namespace PayU.Models.Base.Subcomponents
{

    /// <summary>
    /// Values or amounts associated with the order. In this field, one amount per entry is sent.
    /// </summary>
    public class AdditionalValues
    {
        /// <summary>
        /// Total amount of the transaction.
        /// Use helper function TransactionValue to aid with this matter.
        /// </summary>
        [JsonProperty("TX_VALUE")]
        public AdditionalValue Value { get; set; }
        
        /// <summary>
        /// Value of VAT collected.
        /// Use helper function TaxValue to aid with this matter.
        /// </summary>
        [JsonProperty("TX_TAX")]
        public AdditionalValue Tax { get; set; }
        
        /// <summary>
        /// Base value on which the VAT is calculated.
        /// Use helper function TaxReturnBase to aid with this matter.
        /// </summary>
        [JsonProperty("TX_TAX_RETURN_BASE")]
        public AdditionalValue TaxBase { get; set; }
        
        /// <summary>
        /// Should be sent within the additional parameters array as TX_VALUE.
        /// It is the total amount of the transaction.
        /// </summary>
        /// <param name="value">
        /// The value of the transaction.  It can contain two decimal digits, like 10000.00 and 10000.
        /// </param>
        /// <param name="currency">
        /// The ISO currency code associated with the amount of the additional value.
        /// See http://developers.payulatam.com/en/api/variables_table.html for available codes.
        /// </param>
        /// <returns>An Additional Value object describing the transaction's value.</returns>
        public static AdditionalValue TransactionValue(string value, string currency) =>
            new AdditionalValue(value, currency);
        
        /// <summary>
        /// Should be sent within the additional parameters array as TX_TAX.
        /// It is the value of the VAT (Value Added Tax only valid for Colombia) of the transaction, if no VAT is sent,
        /// the system will apply 19% automatically. If VAT does not apply, it should be sent as 0.
        /// </summary>
        /// <param name="value">
        /// The amount of the tax collected. It can contain two decimal digits, like 19000 and 19000.00.
        /// </param>
        /// <param name="currency">
        /// The ISO currency code associated with the amount of the additional value.
        /// See http://developers.payulatam.com/en/api/variables_table.html for available codes.
        /// </param>
        /// <returns>An Additional Value object describing this transaction's VAT Taxation.</returns>
        public static AdditionalValue TaxValue(string value, string currency) => new AdditionalValue(value, currency);

        /// <summary>
        /// Should be sent within the additional parameters array as TX_TAX_RETURN_BASE.
        /// It is the base value on which VAT (only valid for Colombia) is calculated. If VAT does not apply,
        /// it should be sent as 0.
        /// </summary>
        /// <param name="value">
        /// The base amount under which the VAT is collected. It can contain two decimal digits, like 19000 and 19000.00.
        /// </param>
        /// <param name="currency">
        /// The ISO currency code associated with the amount of the additional value.
        /// See http://developers.payulatam.com/en/api/variables_table.html for available codes.
        /// </param>
        /// <returns>An Additional Value object describing this transaction's VAT Base.</returns>
        public static AdditionalValue TaxReturnBase(string value, string currency) => new AdditionalValue(value, currency);
    }
    
    /// <summary>
    /// Values or amounts associated with the order. In this field, one amount per entry is sent.
    /// </summary>
    public class AdditionalValue
    {
        public AdditionalValue()
        {
        }

        public AdditionalValue(string value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        /// <summary>
        ///  The value associated to the additional value.
        ///  For example: 1000.00
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
        
        /// <summary>
        /// The ISO currency code associated with the amount of the additional value.
        /// See http://developers.payulatam.com/en/api/variables_table.html for available codes.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

    }
}