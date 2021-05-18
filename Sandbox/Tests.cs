using System.Threading.Tasks;
using NUnit.Framework;
using PayU;

namespace Sandbox
{
    public class Tests
    {
        private string _sandboxLogin;
        private string _sandboxKey;
        private bool _testMode;
        private string _language;
        private PayUKit _kit;
        
        [SetUp]
        public void Setup()
        {
            _sandboxLogin = "pRRXKOl8ikMmt9u";
            _sandboxKey = "4Vj8eK4rloUd272L48hsrarnUA";
            _testMode = true;
            _language = "en";

            _kit = new PayUKit(_sandboxLogin, _sandboxKey, _testMode, _language);
        }

        [Test]
        public void Connectivity()
        {
            var pingResult = _kit.Payments.CheckConnectivity().Result;
            Assert.AreEqual(true, pingResult);
        }
    }
}