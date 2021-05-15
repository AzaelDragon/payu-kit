using System;
using System.Security.Cryptography;
using System.Text;

namespace PayU.Core
{
    public class ApiUtil
    {
        
        /// <summary>
        /// Calculates the hashed signature for a particular transaction through the SHA512 algorithm.
        /// </summary>
        /// <param name="apiKey"> The application's API key.</param>
        /// <param name="merchantId">The merchant's ID.</param>
        /// <param name="referenceCode">The reference code to be used by the transaction.</param>
        /// <param name="amount">The amount to charge for the transaction.</param>
        /// <param name="currency">The money used to process the transaction.</param>
        /// <returns></returns>
        public static string HashSignature(string apiKey, string merchantId, string referenceCode, double amount,
            string currency)
        {
            var stringBase = apiKey + '~' + merchantId + '~' + referenceCode + '~' + amount + '~' + currency;
            var baseData = Encoding.UTF8.GetBytes(stringBase);

            using (SHA256 hasher = new SHA256Managed())
            {
                var computedHash = hasher.ComputeHash(baseData);
                return BitConverter.ToString(computedHash).Replace("-", "");
            }
        }
    }
}