using System;
using PayU.Services;

namespace PayU
{
    public class PayUKit
    {
        public PaymentsService Payments;
        
        public PayUKit(string apiLogin, string apiKey, bool testMode, string language)
        {
            Payments = new PaymentsService(apiLogin, apiKey, language, testMode);
        }
    }
}