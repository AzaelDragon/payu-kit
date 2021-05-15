using System;
using System.Threading.Tasks;
using Flurl.Http;
using PayU.Core;
using PayU.Exceptions;
using PayU.Models.Base;
using PayU.Models.Payments;

namespace PayU.Services
{
    public class PaymentsService
    {
        
        private string ApiLogin;
        private string ApiKey;
        private string Language;
        private bool TestMode;
        private string Endpoint;
        private object Headers;

        public PaymentsService(string apiLogin, string apiKey, string language, bool testMode)
        {
            ApiLogin = apiLogin ?? throw new ArgumentNullException(nameof(apiLogin));
            ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            Language = language;
            TestMode = testMode;
            Endpoint = ApiEndpoint.Payments(testMode);
            Headers = new
            {
                Accept = "application/json",
                Content_Type = "application/json"
            };
        }

        /// <summary>
        /// Get all the payment methods available for the merchant.
        /// </summary>
        /// <returns></returns>
        public async Task<AvailableMethods> GetPaymentMethods()
        {
            var body = new BaseRequest
            {
                Test = TestMode,
                Command = ApiCommand.GetPaymentMethods,
                Language = Language,
                Merchant = new Merchant
                {
                    ApiKey = ApiKey,
                    ApiLogin = ApiLogin
                }
            };

            AvailableMethods response;
            
            try
            {
                response = await Endpoint.WithHeaders(Headers).PostJsonAsync(body).ReceiveJson<AvailableMethods>();

                if (response.Code == ResponseCode.Success) return response;
                
                if (response.Error == "Invalid credentials")
                {
                    throw new InvalidAuthException("The provided credentials for the PayU API seem to be invalid.");
                }
            }
            catch (Exception e)
            {
                throw new UnexpectedTransactionException(
                    "An unexpected error occured while handling a GetPaymentMethods() transaction", e);
            }

            return response;

        }
        
    }
}