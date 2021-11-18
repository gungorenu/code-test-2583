using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Implementations
{
    /// <summary>
    /// Implementation of Conversion service
    /// </summary>
    public class ConversionService : IConversionService
    {
        private readonly IExchangeRateService _exchangeService;
        private readonly IAccountService _accountService;

        public ConversionService(IExchangeRateService exchangeService, IAccountService accountService)
        {
            if (exchangeService == null)
                throw new ArgumentNullException(nameof(exchangeService));
            if (accountService == null)
                throw new ArgumentNullException(nameof(accountService));

            _exchangeService = exchangeService;
            _accountService = accountService;
        }

        /// <summary>
        /// Gets account with requested currency
        /// </summary>
        /// <param name="currency">Currency name</param>
        /// <returns>Account info</returns>
        public async Task<Account> GetConvertedAccount(string currency)
        {
            // I am not checking _exchangeService == null, no way of setting null
            var exchangeRate = await _exchangeService.GetExchangeRate();
            if (exchangeRate == null)
                throw new InvalidOperationException("Service Initialization failed");

            var currencyInfo = exchangeRate.Currencies.FirstOrDefault(f => f.Name == currency);
            if (currencyInfo == null)
                throw new ArgumentException("Currency not found");

            // I am not checking _accountService == null, no way of setting null
            var account = await _accountService.GetAccount();
            if (account == null)
                throw new InvalidOperationException("Account not found");

            // we need to update balance values because of currency difference
            if (currency != account.Currency)
            {
                UpdateBalanceDueToCurrencyChange(account, currencyInfo);
            }

            return account;
        }


        /// <summary>
        /// Updates balance on account info with modified currency
        /// </summary>
        /// <param name="account">Account info</param>
        /// <param name="currency">Currency info</param>
        private void UpdateBalanceDueToCurrencyChange(Account account, Currency currency)
        {
            // null checks are not necessary since there is only one function but best practice
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            if (currency == null)
                throw new ArgumentNullException(nameof(currency));

            // I do not get how this works but it is a multiplier rate I guess? not explained
            account.Currency = currency.Name;
            account.Balance = currency.ExchangeRate * account.Balance;
            if (account.Transactions != null)
            {
                foreach (var tran in account.Transactions)
                {
                    tran.Balance = currency.ExchangeRate * tran.Balance;
                }
            }
        }
    }
}
