namespace PayU.Core
{
    /// <summary>
    /// Provides the multiple access points for the PayU API.
    /// </summary>
    public class ApiEndpoint
    {
        private string Endpoint { get; }

        private static string SandboxBase = "https://sandbox.api.payulatam.com/";
        private static string ProductionBase = "https://api.payulatam.com/";
        private static string VersionAppend = "/4.0/service.cgi";

        private ApiEndpoint(string endpoint) => Endpoint = endpoint;
        
        /// <summary>
        /// Builds an endpoint URL depending on if the environment is under test or production mode.
        /// </summary>
        /// <param name="target">The action target.</param>
        /// <param name="testMode">Determines whether the sandbox endpoint should be used or not.</param>
        /// <returns></returns>
        private static ApiEndpoint ConstructEndpoint(string target, bool testMode) => testMode
            ? new ApiEndpoint(SandboxBase + target + VersionAppend)
            : new ApiEndpoint(ProductionBase + target + VersionAppend);

        /// <summary>
        /// Endpoint for the payments (Pagos) API of PayU.
        /// More info: http://developers.payulatam.com/es/api/payments.html
        /// </summary>
        /// <param name="testMode">Determines whether the sandbox endpoint should be used or not.</param>
        /// <returns></returns>
        public static string Payments(bool testMode) => ConstructEndpoint("payments-api", testMode).Endpoint;

        /// <summary>
        /// Endpoint for the queries (Consultas) API of PayU.
        /// More info: http://developers.payulatam.com/es/api/queries.html
        /// </summary>
        /// <param name="testMode">Determines whether the sandbox endpoint should be used or not.</param>
        /// <returns></returns>
        public static string Queries(bool testMode) => ConstructEndpoint("reports-api", testMode).Endpoint;

        public override string ToString() => Endpoint;
    }
}