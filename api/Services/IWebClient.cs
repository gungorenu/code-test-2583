using api.Models;
using System.Threading.Tasks;

namespace api.Services
{
    /// <summary>
    /// Simple interface for web stuff, can be completely moved elsewhere (inside services) but for code test I kept it separate
    /// </summary>
    public interface IWebClient
    {
        /// <summary>
        /// Gets account info from designated web source
        /// </summary>
        /// <returns>Account info</returns>
        Task<Account> GetAccountAsync();

        /// <summary>
        /// Gets exchange rate into from designated web source
        /// </summary>
        /// <returns>Exchange rate info</returns>
        Task<ExchangeRate> GetExchangeRateAsync();
    }
}
