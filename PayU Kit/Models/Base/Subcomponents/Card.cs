using Newtonsoft.Json;
using PayU.Core;

namespace PayU.Models.Base.Subcomponents
{
    /// <summary>
    /// Describes a basic implementable card.
    /// </summary>
    public class Card
    {
    
        /// <summary>
        /// The card's number.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// The card's secondary security verification code (CVC2, CVV2 or CID)
        /// </summary>
        [JsonProperty("securityCode")]
        public int SecurityCode { get; set; }

        /// <summary>
        /// The card's expiration date. Must follow a YYYY/MM format.
        /// </summary>
        [JsonProperty("expirationDate")]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// The cardholder's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Determines the franchise code for this specific card.
        /// </summary>
        /// <param name="forceDebit">Whether the card should be detected as a debit card or not.</param>
        /// <returns></returns>
        public string FranchiseCode(bool forceDebit) => CardValidation.DetectCardFranchise(Number, forceDebit);

        /// <summary>
        /// Converts an existing card model into a credit card model, if required.
        /// </summary>
        /// <param name="dontUseCVV">Whether to include a request to not verify the CVV.</param>
        /// <returns></returns>
        public CreditCard ToCreditCard(bool dontUseCVV) => new CreditCard
        {
            Number = Number,
            SecurityCode = SecurityCode,
            ExpirationDate = ExpirationDate,
            Name = Name,
            ProcessWithoutCVV2 = dontUseCVV
        };
    }
}