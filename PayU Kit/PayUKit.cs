using PayU.Services;

namespace PayU
{
    public class PayUKit
    {
        public PaymentsService Payments;
        
        public PayUKit(string apiLogin, string apiKey, string merchantId, bool testMode, string language)
        {
            Payments = new PaymentsService(apiLogin, apiKey, merchantId, language, testMode);
        }
    }
}