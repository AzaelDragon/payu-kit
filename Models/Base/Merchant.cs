using Newtonsoft.Json;

namespace PayU.Models.Base
{
    /// <summary>
    /// Describes the issuer of the requests.
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// Authorization login key supplied by PayU.
        /// </summary>
        [JsonProperty("apiLogin")]
        public string ApiLogin { get; set; }
        
        /// <summary>
        /// Authorization password key supplied by PayU.
        /// </summary>
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
}