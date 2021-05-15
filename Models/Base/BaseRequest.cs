using Newtonsoft.Json;

namespace PayU.Models.Base
{
    /// <summary>
    /// Describes all basic requests with the PayU API.
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// Determines whether the environment is in production mode or not.
        /// </summary>
        [JsonProperty("test")]
        public bool Test { get; set; }
    
        /// <summary>
        /// Determines the language of the negotiation. Should be a two character value, like 'en'.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }
    
        /// <summary>
        /// The command to execute within the endpoint.
        /// </summary>
        [JsonProperty("command")]
        public string Command { get; set; }
    
        /// <summary>
        /// The issuer of the request. Counts as API authorization.
        /// </summary>
        [JsonProperty("merchant")]
        public Merchant Merchant { get; set; }
    }
}