using api.Models;
using System;
using System.Collections.Generic;

namespace api.Services.Implementations
{
    /// <summary>
    /// Transaction service implementation
    /// </summary>
    public class TransactionService : ITransactionService
    {
        /// <summary>
        /// Searches for highest positive balance change from one date to another
        /// </summary>
        /// <param name="transactions">Transaction list</param>
        /// <returns>the dates and balance change back</returns>
        public (DateTime? start, DateTime? end, decimal highestBalanceChange) GetHighestPositiveBalanceChange(List<Transaction> transactions)
        {
            return (null, null, 0);
        }
    }
}
