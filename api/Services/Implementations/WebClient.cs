using api.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace api.Services.Implementations
{
    /// <summary>
    /// Simple class to get stuff from web, good foc mocking stuff
    /// </summary>
    public class WebClient : IWebClient
    {
        private readonly string _accountUri;
        private readonly string _exchangeRateUri;
        private readonly string _host;

        public WebClient(IConfiguration conf)
        {
            if (conf == null)
                throw new ArgumentNullException(nameof(conf));

            _accountUri = conf.GetSection("WebStuff").GetSection("Account").Value;
            _exchangeRateUri = conf.GetSection("WebStuff").GetSection("ExchangeRate").Value;
            _host = conf.GetSection("WebStuff").GetSection("Base").Value;
        }

        /// <summary>
        /// Gets account info from designated web source
        /// </summary>
        /// <returns>Account info</returns>
        public async Task<Account> GetAccountAsync()
        {
            return await GetFromWebAsync<Account>(_accountUri);
        }

        /// <summary>
        /// Gets exchange rate into from designated web source
        /// </summary>
        /// <returns>Exchange rate info</returns>
        public async Task<ExchangeRate> GetExchangeRateAsync()
        {
            return await GetFromWebAsync<ExchangeRate>(_exchangeRateUri);
        }

        private async Task<T> GetFromWebAsync<T>(string uri)
        {
            var client = new RestClient(new Uri(_host));
            var request = new RestRequest(uri, Method.GET);

            var response = await client.ExecuteAsync<T>(request);
            return response.Data;
        }
    }
}
