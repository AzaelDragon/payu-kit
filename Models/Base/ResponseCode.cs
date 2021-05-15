namespace PayU.Models.Base
{
    /// <summary>
    /// Provides the possible response codes from the PayU API.
    /// </summary>
    public class ResponseCode
    {
        public string Code { get; }

        private ResponseCode(string code) => Code = code;

        /// <summary>
        /// Determines that the transaction was completed successfully.
        /// </summary>
        public static string Success => new ResponseCode("SUCCESS").Code;

        /// <summary>
        /// Determines that the transaction could be completed and has an error, which can be
        /// visualized through the error property of the request.
        /// </summary>
        public static string Error => new ResponseCode("ERROR").Code;

        public override string ToString() => Code;
    }
}