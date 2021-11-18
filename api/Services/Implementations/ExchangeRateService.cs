using api.Models;
using System;
using System.Threading.Tasks;

namespace api.Services.Implementations
{
    /// <summary>
    /// Exchange rate service implementation
    /// </summary>
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IWebClient _webClient;

        public ExchangeRateService(IWebClient webClient)
        {
            if (webClient == null)
                throw new ArgumentNullException(nameof(webClient));

            _webClient = webClient;
        }

        /// <summary>
        /// Gets exchange rate info
        /// </summary>
        /// <returns>Exchange rate values back</returns>
        public async Task<ExchangeRate> GetExchangeRate()
        {
            // I am not caching results, not asked
            return await _webClient.GetExchangeRateAsync();
        }
    }
}
