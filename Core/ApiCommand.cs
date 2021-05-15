namespace PayU.Core
{
    /// <summary>
    /// Provides the multiple available operations with the PayU API.
    /// </summary>
    public class ApiCommand
    {
    
        private string Command { get; }

        private ApiCommand(string command)
        {
            Command = command;
        }

        /// <summary>
        /// Method to find all the available payment methods to the merchant.
        /// Command: GET_PAYMENT_METHODS
        /// </summary>
        public static string GetPaymentMethods => new ApiCommand("GET_PAYMENT_METHODS").Command;

        public override string ToString() => Command;
    }
}