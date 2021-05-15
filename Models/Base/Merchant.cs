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
        public string apiLogin { get; set; }
        
        /// <summary>
        /// Authorization password key supplied by PayU.
        /// </summary>
        public string apiKey { get; set; }
    }
}