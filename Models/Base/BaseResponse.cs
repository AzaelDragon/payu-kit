namespace PayU.Models.Base
{
    /// <summary>
    /// Describes all basic responses from the PayU API.
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Determines whether a transaction was successful or not.
        /// </summary>
        public string code { get; set; }
        
        /// <summary>
        /// Describes the error generated if a transaction was unsuccessful.
        /// </summary>
        public string error { get; set; }
        
        /// <summary>
        /// Describes additional reasons for errors or unsuccessful transactions.
        /// </summary>
        public string reason { get; set; }
    }
}