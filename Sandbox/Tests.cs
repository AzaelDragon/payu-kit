using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using PayU;
using PayU.Core;
using PayU.Models.Base;
using PayU.Models.Base.Subcomponents;
using PayU.Models.Payments;

namespace Sandbox
{
    public class Tests
    {
        private string _sandboxLogin;
        private string _sandboxKey;
        private string _sandboxMerchantId;
        private bool _testMode;
        private string _language;
        private string _country;
        private string _currency;
        private string _accountID;
        private PayUKit _kit;
        private Address _address;
        private Buyer _buyer;
        private Payer _payer;
        private TransactionPrototype _proto;

        [SetUp]
        public void Setup()
        {
            _sandboxLogin = "pRRXKOl8ikMmt9u";
            _sandboxKey = "4Vj8eK4rloUd272L48hsrarnUA";
            _testMode = true;
            _language = "en";
            _country = "CO";
            _currency = "COP";
            _accountID = "512321";
            _sandboxMerchantId = "508029";

            _address = new Address
            {
                // City = "Medellin",
                Country = _country,
                // Phone = "7563126",
                // State = "Antioquia",
                // PostalCode = "000000",
                // Street1 = "Calle 100",
                // Street2 = "5555487"
            };

            _buyer = new Buyer
            {
                MerchantBuyerId = "1",
                FullName = "John Doe",
                EmailAddress = "john@email.com",
                ContactPhone = "7563126",
                DNINumber = "5415668464654",
                ShippingAddress = _address
            };

            _payer = new Payer
            {
                MerchantPayerId = "1",
                FullName = "John Doe",
                EmailAddress = "john@email.com",
                ContactPhone = "7563126",
                DNINumber = "5415668464654",
                BillingAddress = _address
            };
            
            _proto = new TransactionPrototype
            {
                Address = _address,
                Cookie = "pt1t38347bs6jc9ruv2ecpv7o2",
                Country = _country,
                Currency = _currency,
                Description = "A test transaction for colombia.",
                Value = 20000,
                ReferenceCode = "TTest-" + Guid.NewGuid(),
                UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:18.0) Gecko/20100101 Firefox/18.0",
                AccountID = _accountID,
                IPAddress = "127.0.0.1",
                DeviceSessionID = "vghs6tvkcle931686k1900o6e1",
                NotifyURL = "https://mytest.com"
            };


            _kit = new PayUKit(_sandboxLogin, _sandboxKey, _sandboxMerchantId, _testMode, _language);
        }

        [Test]
        public void Sign()
        {
            var signature = ApiUtil.HashSignature(_sandboxKey, _sandboxMerchantId, "TTest-3a1836d4-af32-4c39-bc6d-455632902c9fa", "6", "USD");
            Console.Write(signature);
        }
        
        [Test]
        public void Connectivity()
        {
            var pingResult = _kit.Payments.CheckConnectivity();
            Assert.AreEqual(true, pingResult);
        }

        [Test]
        public void PaymentMethods()
        {
            var methods = _kit.Payments.GetPaymentMethods();
            Console.Write(JsonConvert.SerializeObject(methods));
            Assert.AreEqual("SUCCESS", methods.Code);
        }
        
        [Test]
        public void BankList()
        {
            var bankList = _kit.Payments.GetAvailablePSEBanks();
            Assert.AreEqual(ResponseCode.Success, bankList.Code);
            Assert.AreNotEqual(0, bankList.Banks.Count);
        }

        [Test]
        public void CreditTransaction()
        {
            var card = new Card
            {
                Name = "APPROVED",
                Number = "4097440000000004",
                ExpirationDate = "2040/12",
                SecurityCode = 321
            };

            var tx = _kit.Payments.BuildCardTransaction(_proto, card, _buyer, _payer,
                TransactionType.AuthorizeAndCapture());

            var response = _kit.Payments.ExecuteTransaction(tx);

            Assert.AreEqual(ResponseCode.Success, response.Code);
        }

        [Test]
        public void PSETransaction()
        {
            var banks = _kit.Payments.GetAvailablePSEBanks().Banks;
            
            Assert.AreNotEqual(0, banks.Count);

            var tx = _kit.Payments.BuildPSETransaction(_proto, _buyer, _payer, "https://mytest.com/PSE",
                banks[5].PSECode, "CC", _payer.DNINumber);

            var response = _kit.Payments.ExecuteTransaction(tx);
            
            Assert.AreEqual(ResponseCode.Success, response.Code);
            Assert.NotNull(response.TransactionResponse.ExtraParameters.BankURL);
            Assert.AreEqual("PENDING_TRANSACTION_CONFIRMATION", response.TransactionResponse.ResponseCode);
        }
    }
}