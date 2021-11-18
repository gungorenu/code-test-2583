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
            if (transactions == null)
                throw new ArgumentNullException(nameof(transactions));

            // if has no transaction or only one then I return null values
            if( transactions.Count < 1)
                return (null, null, 0);

            // there was no requirement about performance so I use regular iterations

            // stores indexes, starts from 0, we are looking for ranges, we do not need to know balance for algorithm but it shall check it very step
            Tuple<int, int> highestRange = new Tuple<int, int>(0, 0);
            // assumption: if there is no increment in balance then the start and end indexes shall be same
            // we do not check dates but indexes, we can get dates easily from transaction info

            // algorithm :
            // - start with first transaction
            // - day by day check balance changes, if?
            // - - balance increased? then extend the highest balance range end index (first index is set already)
            // - - balance decreased? store it if it is higher than previous finding. reset the balance range start and end indexes
            // - - balance not changed? works same as incremented case (technically it did not decrease)

            // not sure but maybe rquires to be sorted by date? maybe unnecessary
            transactions.Sort((a, b) => a.Date.CompareTo(b.Date));

            int start =0, end = 0;
            decimal balance = transactions[0].Balance;
            for ( int i =1; i < transactions.Count; i++)
            {
                // increasing
                if ( transactions[i].Balance >= balance)
                {
                    balance = transactions[i].Balance; // for next day comparison
                    end = i;

                    // end of list came? then we should make our check if for higher range found, to avoid double implementation we do not continue and let negative case handle same code
                    if( i != transactions.Count -1)
                        continue; // negative case is more code so I move forward instead of if-else
                }
                
                // decrease found (note that start and end can be same and shall yield to 0 change) 
                decimal highestChange = transactions[end].Balance - transactions[start].Balance;
                decimal storedHighestChange = transactions[highestRange.Item2].Balance - transactions[highestRange.Item1].Balance;

                // we have a higher change found, so replace
                if( highestChange > storedHighestChange)
                {
                    highestRange = new Tuple<int, int>(start, end);
                }

                // reset
                start = end = i; 
                balance = transactions[i].Balance;
            }

            // at this point we have highest range pointed by "highestRange" variable

            if( highestRange.Item1 == highestRange.Item2) // equal means no range, all decrease in balance
                return (null, null, 0);

            // this means we have a range, get dates and balance
            return (
                transactions[highestRange.Item1].Date,
                transactions[highestRange.Item2].Date,
                transactions[highestRange.Item2].Balance - transactions[highestRange.Item1].Balance
                );
        }
    }
}
