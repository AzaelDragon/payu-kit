using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using PayU.Core;
using PayU.Exceptions;
using PayU.Models.Base;
using PayU.Models.Base.Subcomponents;
using PayU.Models.Payments;
using TransactionPrototype = PayU.Models.Payments.TransactionPrototype;

namespace PayU.Services
{
    public class PaymentsService
    {
        
        private readonly string _apiLogin;
        private readonly string _apiKey;
        private readonly string _language;
        private readonly bool _testMode;
        private readonly string _endpoint;
        private readonly string _merchantID;
        private readonly object _headers;
        private readonly Merchant _merchant;

        public PaymentsService(string apiLogin, string apiKey, string merchantID, string language, bool testMode)
        {
            _apiLogin = apiLogin ?? throw new ArgumentNullException(nameof(apiLogin));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _language = language;
            _testMode = testMode;
            _endpoint = ApiEndpoint.Payments(testMode);
            _merchantID = merchantID;
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
        public AvailableMethods GetPaymentMethods()
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
                response = _endpoint.WithHeaders(_headers).PostJsonAsync(body).ReceiveJson<AvailableMethods>().Result;

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
        public bool CheckConnectivity()
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
                response = _endpoint.WithHeaders(_headers).PostJsonAsync(body).ReceiveJson<BaseResponse>().Result;

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
        private AvailableBanks GetAvailableBanks(string paymentCountry, string paymentMethod)
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
                response = _endpoint.WithHeaders(_headers).PostJsonAsync(body).ReceiveJson<AvailableBanks>().Result;

                if (response.Error == "Invalid credentials")
                {
                    throw new InvalidAuthException("The provided credentials for the PayU API seem to be invalid.");
                }
            } catch (Exception e)
            {
                throw new UnexpectedTransactionException(
                    "An unexpected error occured while handling a GetAvailableBanks() transaction", e);
            }

            return response;
        }

        /// <summary>
        /// Finds all the available banks for PSE transfer operations.
        /// </summary>
        /// <returns>An object with all available banks for transfer. See <see cref="Bank"/> for more information.</returns>
        /// <exception cref="InvalidAuthException">Thrown when the keys used to configure the Kit are invalid.</exception>
        /// <exception cref="UnexpectedTransactionException">Thrown when an unexpected processing error occurs.</exception>
        public AvailableBanks GetAvailablePSEBanks()
        {
            return GetAvailableBanks("CO", "PSE");
        }

        
        /// <summary>
        /// Create a transactional object for PSE debit transactions.
        /// </summary>
        /// <param name="proto">Contains all the information required to build a transaction.</param>
        /// <param name="buyer">The buyer for the transaction.</param>
        /// <param name="payer">The payer for the transaction. Can be the same as the buyer.</param>
        /// <param name="responseURL">The URL to send the user to when the PSE flow ends.</param>
        /// <param name="targetBank">The financial institution redirection to send the user to. <see cref="GetAvailablePSEBanks"/>.</param>
        /// <param name="docType">The Colombian-issued DNI type of the user who will perform the payment..</param>
        /// <param name="document">The Colombian-issued DNI of the user who will perform the payment.</param>
        /// <returns></returns>
        public Transaction BuildPSETransaction(TransactionPrototype proto, Buyer buyer, Payer payer, string responseURL, string targetBank, string docType, string document)
        {
            var baseTx = BuildBaseTransaction(proto, buyer, payer, TransactionType.AuthorizeAndCapture(), true);
            docType = docType.ToUpper();

            var userType = docType == "NIT" ? "J" : "N";

            baseTx.PaymentMethod = "PSE";
            baseTx.PaymentCountry = "CO";
            
            baseTx.ExtraParameters = new RequestExtraParameters
            {
                InstallmentsNumber = null,
                ResponseURL = responseURL,
                UserIP = proto.IPAddress,
                FinancialInstitutionCode = targetBank,
                UserType = userType,
                DocumentType = docType,
                UserDNI = document
            };

            return baseTx;
        }

        /// <summary>
        /// Create a transactional object for credit or debit cards with the prototype specified.
        /// </summary>
        /// <param name="proto">Contains all the information required to build a transaction.</param>
        /// <param name="card">The card to charge or capture in the process.</param>
        /// <param name="buyer">The buyer for the transaction.</param>
        /// <param name="payer">The payer for the transaction. Can be the same as the buyer.</param>
        /// <param name="transactionType">Whether the transaction should be authorized or charged.</param>
        /// <param name="installments">How many installments to divide the purchase in. Default is 1.</param>
        /// <param name="isDebitTransaction">Whether the transaction should be determined as debit. Default is false.</param>
        /// <param name="dontUseCVV">Whether PayU should be instructed to not use the CVV. Requires previous authorization. Default is false.</param>
        /// <returns>A prepared transactional object to be used with <see cref="ExecuteTransaction"/>.</returns>
        public Transaction BuildCardTransaction(TransactionPrototype proto, Card card, Buyer buyer, Payer payer, TransactionType transactionType,
            int installments = 1, bool isDebitTransaction = false, bool dontUseCVV = false )
        {
            var franchise = card.FranchiseCode(isDebitTransaction);

            var baseTx = BuildBaseTransaction(proto, buyer, payer, transactionType);

            if (isDebitTransaction)
            {
                baseTx.DebitCard = card;
                installments = 1;
            }
            else
            {
                baseTx.CreditCard = card.ToCreditCard(dontUseCVV);
            }

            baseTx.PaymentMethod = franchise;
            baseTx.ExtraParameters = new RequestExtraParameters
            {
                InstallmentsNumber = installments
            };

            return baseTx;
        }

        /// <summary>
        /// Constructs a base transactional structure, universal for payments.
        /// </summary>
        /// <param name="proto">Contains all the information required to build a transaction.</param>
        /// <param name="buyer">The buyer for the transaction.</param>
        /// <param name="payer">The payer for the transaction. Can be the same as the buyer.</param>
        /// <param name="transactionType">Whether the transaction should be authorized or charged.</param>
        /// <returns></returns>
        private Transaction BuildBaseTransaction(TransactionPrototype proto, Buyer buyer, Payer payer,
            TransactionType transactionType, bool useIntValues = false)
        {

            var tax = 0.0;
            var taxBase = 0.0;
            proto.Country = proto.Country.ToUpper();
            proto.Currency = proto.Currency.ToUpper();
            
            if (proto.Country == "CO")
            {
                tax = proto.Value * 0.19;
                taxBase = proto.Value - tax;
            }

            

            var valValue = useIntValues ? Convert.ToInt32(proto.Value).ToString() : proto.Value.ToString(CultureInfo.InvariantCulture);
            var valTax = useIntValues ? Convert.ToInt32(tax).ToString() : tax.ToString(CultureInfo.InvariantCulture);
            var valTaxBase = useIntValues ? Convert.ToInt32(Convert.ToInt32(valValue) - Convert.ToInt32(valTax)).ToString() : taxBase.ToString(CultureInfo.InvariantCulture);
            
            var signature = ApiUtil.HashSignature(_apiKey, _merchantID, proto.ReferenceCode, valValue, proto.Currency);
            
            var additionalValues = new AdditionalValues
            {
                Value = AdditionalValues.TransactionValue(valValue, proto.Currency),
                Tax = AdditionalValues.TaxValue(valTax, proto.Currency),
                TaxBase = AdditionalValues.TaxReturnBase(valTaxBase, proto.Currency)
            };

            var order = new Order
            {
                Buyer = buyer,
                Description = proto.Description,
                Language = _language,
                Signature = signature,
                AccountId = proto.AccountID,
                AdditionalValues = additionalValues,
                ReferenceCode = proto.ReferenceCode,
                ShippingAddress = proto.Address,
                NotifyURL = proto.NotifyURL
            };
            
            var tx = new Transaction
            {
                Order = order,
                Payer = payer,
                Cookie = proto.Cookie,
                PaymentCountry = proto.Country,
                Type = transactionType.Value,
                UserAgent = proto.UserAgent,
                IPAddress = proto.IPAddress,
                DeviceSessionID = proto.DeviceSessionID,
            };

            if (proto.ThreeDomainSecure != null)
            {
                tx.ThreeDomainSecure = proto.ThreeDomainSecure;
            }

            return tx;
        }
        
        /// <summary>
        /// Processes a  transaction with the PayU API.
        /// </summary>
        /// <param name="transaction">The constructed transaction to process.</param>
        /// <returns>A <see cref="PaymentTransaction"/> object containing PayU's response for the transaction.</returns>
        /// <exception cref="InvalidAuthException">Thrown when the keys used to configure the Kit are invalid.</exception>
        /// <exception cref="UnexpectedTransactionException">Thrown when an unexpected processing error occurs.</exception>
        public PaymentTransaction ExecuteTransaction(Transaction transaction)
        {
            var body = new PaymentTransactionRequest
            {
                Command = ApiCommand.SubmitTransaction,
                Language = _language,
                Merchant = _merchant,
                Test = _testMode,
                Transaction = transaction
            };

            if (_testMode)
            {
                Console.Write("\nATTEMPT TRANSACTION, BODY =\n");
                Console.Write(JsonConvert.SerializeObject(body, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }));
                Console.Write("\n");
            }

            PaymentTransaction response;

            try
            {
                response = _endpoint.ConfigureRequest(settings =>
                {
                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ObjectCreationHandling = ObjectCreationHandling.Replace
                    };
                    settings.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
                }).WithHeaders(_headers).PostJsonAsync(body).ReceiveJson<PaymentTransaction>().Result;
                
                if (_testMode)
                {
                    Console.Write("\nATTEMPT TRANSACTION, RESPONSE =\n");
                    Console.Write(JsonConvert.SerializeObject(response, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }));
                    Console.Write("\n");
                }
                
                if (response.Error == "Invalid credentials")
                {
                    throw new InvalidAuthException("The provided credentials for the PayU API seem to be invalid.");
                }
            } catch (Exception e)
            {
                throw new UnexpectedTransactionException(
                    "An unexpected error occured while handling a GetAvailableBanks() transaction", e);
            }

            return response;
        }
        
    }
}