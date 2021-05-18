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

        /// <summary>
        /// Method to submit a transactional request.
        /// Command: SUBMIT_TRANSACTION
        /// </summary>
        public static string SubmitTransaction => new ApiCommand("SUBMIT_TRANSACTION").Command;

        /// <summary>
        /// Method to submit a ping check.
        /// Command: PING
        /// </summary>
        public static string Ping => new ApiCommand("PING").Command;

        /// <summary>
        /// Method to get all the available banks available for transfers in a country.
        /// Command: GET_BANKS_LIST
        /// </summary>
        public static string GetBanks => new ApiCommand("GET_BANKS_LIST").Command;

        public override string ToString() => Command;
    }
}