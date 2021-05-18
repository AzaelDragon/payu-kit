using Newtonsoft.Json;

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
        [JsonProperty("code")]
        public string Code { get; set; }
        
        /// <summary>
        /// Describes the error generated if a transaction was unsuccessful.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
        
        /// <summary>
        /// Describes additional reasons for errors or unsuccessful transactions.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}