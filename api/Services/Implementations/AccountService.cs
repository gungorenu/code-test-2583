using api.Models;
using System;
using System.Threading.Tasks;

namespace api.Services.Implementations
{
    /// <summary>
    /// Account service implementation
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IWebClient _webClient;

        public AccountService(IWebClient webClient)
        {
            if (webClient == null)
                throw new ArgumentNullException(nameof(webClient));

            _webClient = webClient;
        }

        /// <summary>
        /// Gets account info
        /// </summary>
        /// <returns>Account info</returns>
        public async Task<Account> GetAccount()
        {
            // I am not caching results, not asked
            return await _webClient.GetAccountAsync();
        }
    }
}
