using System.Text.RegularExpressions;

namespace PayU.Core
{
    public class CardValidation
    {
        // Process as: AMEX
        private static readonly Regex AmexRegex =
            new Regex("^3[47][0-9]{13}$");
        
        // Process as: VISA || VISA_DEBIT
        private static readonly Regex VisaRegex = 
            new Regex("^4");
        
        // Process as: VISA_DEBIT
        private static readonly Regex VisaElectronRegex = 
            new Regex("^(4026|417500|4508|4844|491(3|7))");
        
        // Process as: MASTERCARD_DEBIT
        private static readonly Regex MaestroRegex = 
            new Regex("^(5018|5020|5038|6304|6759|6761|6763)[0-9]{8,15}$");
        
        // Process as: MASTERCARD || MASTERCARD_DEBIT
        private static readonly Regex MastercardRegex = 
            new Regex("^(5[1-5][0-9]{14}|2(22[1-9][0-9]{12}|2[3-9][0-9]{13}|[3-6][0-9]{14}|7[0-1][0-9]{13}|720[0-9]{12}))$");
        
        // Process as: DISCOVER
        private static readonly Regex DiscoverRegex = 
            new Regex("^65[4-9][0-9]{13}|64[4-9][0-9]{13}|6011[0-9]{12}|(622(?:12[6-9]|1[3-9][0-9]|[2-8][0-9][0-9]|9[01][0-9]|92[0-5])[0-9]{10})$");
        
        // Process as: DINERS
        private static readonly Regex CarteBlancheRegex = 
            new Regex("^389[0-9]{11}$");
        
        private static readonly Regex DinersRegex = 
            new Regex("^3(?:0[0-5]|[68][0-9])[0-9]{11}$");

        /// <summary>
        /// Determines the franchise of card and returns the corresponding payment type matching with PayU's API.
        /// </summary>
        /// <param name="cardNumber">The card number to analyze and match the regexes for.</param>
        /// <param name="forceDebit">Force whether the returned payment method should be matching to a debit method with Visa and Mastercard.</param>
        /// <returns>A string containing the valid payment method name for the given string. Will return UNKNOWN if no regexes match.</returns>
        public static string DetectCardFranchise(string cardNumber, bool forceDebit = false)
        {
            if (AmexRegex.IsMatch(cardNumber)) 
                return "AMEX";

            if (VisaRegex.IsMatch(cardNumber)) 
                return "VISA";

            if (VisaElectronRegex.IsMatch(cardNumber) || VisaRegex.IsMatch(cardNumber) && forceDebit) 
                return "VISA_DEBIT";

            if (MastercardRegex.IsMatch(cardNumber)) 
                return "MASTERCARD";

            if (MaestroRegex.IsMatch(cardNumber) || MaestroRegex.IsMatch(cardNumber) && forceDebit)
                return "MASTERCARD_DEBIT";

            if (DiscoverRegex.IsMatch(cardNumber))
                return "DISCOVER";

            if (CarteBlancheRegex.IsMatch(cardNumber) || DinersRegex.IsMatch(cardNumber))
                return "DINERS";
            
            return "UNKNOWN";
        }

    }
}