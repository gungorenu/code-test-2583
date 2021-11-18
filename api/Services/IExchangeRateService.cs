﻿using System.Threading.Tasks;
using api.Models;

namespace api.Services
{
    public interface IExchangeRateService
    {
        Task<ExchangeRate> GetExchangeRate();
    }
}