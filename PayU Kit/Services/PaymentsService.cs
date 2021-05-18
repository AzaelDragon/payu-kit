using System;
using System.Threading.Tasks;
using Flurl.Http;
using PayU.Core;
using PayU.Exceptions;
using PayU.Models.Base;
using PayU.Models.Base.Subcomponents;
using PayU.Models.Payments;

namespace PayU.Services
{
    public class PaymentsService
    {
        
        private readonly string _apiLogin;
        private readonly string _apiKey;
        private readonly string _language;
        private readonly bool _testMode;
        private readonly string _endpoint;
        private readonly object _headers;
        private readonly Merchant _merchant;

        public PaymentsService(string apiLogin, string apiKey, string language, bool testMode)
        {
            _apiLogin = apiLogin ?? throw new ArgumentNullException(nameof(apiLogin));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _language = language;
            _testMode = testMode;
            _endpoint = ApiEndpoint.Payments(testMode);
            _headers = new
            {
                Accept = "application/json",
                Content_Type = "application/json"
            };
            _merchant = new Merchant
            {
                ApiKey = _apiKey,
                ApiLogin = _apiLogin
            };
        }

        /// <summary>
        /// Get all the payment methods available for the merchant.
        /// </summary>
        /// <returns>An element with all the available payment methods for the merchant.
        /// See <seealso cref="AvailableMethods"/> for more information on the return information.
        /// </returns>
        /// <exception cref="InvalidAuthException">Thrown when the keys used to configure the Kit are invalid.</exception>
        /// <exception cref="UnexpectedTransactionException">Thrown when an unexpected processing error occurs.</exception>
        public async Task<AvailableMethods> GetPaymentMethods()
        {
            var body = new BaseRequest
            {
                Test = _testMode,
                Command = ApiCommand.GetPaymentMethods,
                Language = _language,
                Merchant = _merchant
            };

            AvailableMethods response;
            
            try
            {
                response = await _endpoint.WithHeaders(_headers).PostJsonAsync(body).ReceiveJson<AvailableMethods>();

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

        /// <summary>
        /// A connectivity check through the doPing method to verify the connectivity to PayU's services.
        /// </summary>
        /// <returns>True if there is connectivity, False if there isn't.</returns>
        /// <exception cref="InvalidAuthException">Thrown when the keys used to configure the Kit are invalid.</exception>
        /// <exception cref="UnexpectedTransactionException">Thrown when an unexpected processing error occurs.</exception>
        public async Task<bool> CheckConnectivity()
        {
            var body = new BaseRequest
            {
                Test = _testMode,
                Command = ApiCommand.Ping,
                Language = _language,
                Merchant = _merchant
            };

            BaseResponse response;

            try
            {
                response = await _endpoint.WithHeaders(_headers).PostJsonAsync(body).ReceiveJson<BaseResponse>();

                if (response.Code == ResponseCode.Success) return true;

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

            return false;
        }

        /// <summary>
        /// Finds all the available banks for transfer operations.
        /// </summary>
        /// <param name="paymentCountry">The country from where to find the banks in.</param>
        /// <param name="paymentMethod">The payment method that must be supported by said banks.</param>
        /// <returns>An object with all available banks for transfer. See <see cref="Bank"/> for more information.</returns>
        /// <exception cref="InvalidAuthException">Thrown when the keys used to configure the Kit are invalid.</exception>
        /// <exception cref="UnexpectedTransactionException">Thrown when an unexpected processing error occurs.</exception>
        public async Task<AvailableBanks> GetAvailableBanks(string paymentCountry, string paymentMethod)
        {
            var body = new AvailableBanksRequest
            {
                Command = ApiCommand.GetBanks,
                Language = _language,
                Merchant = _merchant,
                Test = _testMode,
                BankList = new BankListInformation
                {
                    PaymentCountry = paymentCountry,
                    PaymentMethod = paymentMethod
                }
            };

            AvailableBanks response;

            try
            {
                response = await _endpoint.WithHeaders(_headers).PostJsonAsync(body).ReceiveJson<AvailableBanks>();

                if (response.Error == "Invalid credentials")
                {
                    throw new InvalidAuthException("The provided credentials for the PayU API seem to be invalid.");
                }
            } catch (Exception e)
            {
                throw new UnexpectedTransactionException(
                    "An unexpected error occured while handling a GetPaymentMethods() transaction", e);
            }

            return response;
        }

        /// <summary>
        /// Finds all the available banks for PSE transfer operations.
        /// </summary>
        /// <returns>An object with all available banks for transfer. See <see cref="Bank"/> for more information.</returns>
        public async Task<AvailableBanks> GetAvailablePSEBanks()
        {
            return await GetAvailableBanks("CO", "PSE");
        }
        
    }
}