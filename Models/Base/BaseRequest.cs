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
        public bool test { get; set; }
    
        /// <summary>
        /// Determines the language of the negotiation. Should be a two character value, like 'en'.
        /// </summary>
        public string language { get; set; }
    
        /// <summary>
        /// The command to execute within the endpoint.
        /// </summary>
        public string command { get; set; }
    
        /// <summary>
        /// The issuer of the request. Counts as API authorization.
        /// </summary>
        public Merchant merchant { get; set; }
    }
}