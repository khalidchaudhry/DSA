using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    public class CoinChange
    {
        /// <summary>
        /// https://www.byte-by-byte.com/12-recursion-questions/
        //!Brute Force approach 
        //!Getting minimum of 
        //  Minimum(
        // Change(32-25)
        // Change(32-10)
        // Change(32-5)
        // Change(32-1)
        //)
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>

        public int Change(int[] coins, int amount)
        {
            //! base case
            if (amount == 0)
                return 0;
            //! minimum number of coins cannot be greater than the amount
            int min = amount;
            //! going through for loop and find minimum value for all of the possible coins 
            foreach (int coin in coins)
            {
                //! change we are making is possible with the given coin system 
                if (amount - coin >= 0)
                {
                    int c = Change(coins, amount - coin);
                    //! c+1 because we removed the coin by calling the change function hence added 1
                    if (min > c + 1)
                    {
                        min = c + 1;
                    }
                }
            }

            return min;

        }

        public int CoinsChange(int[] coins, int amount)
        {
            Array.Sort(coins);
            int coinsNeeded = 0;
            int i = coins.Length - 1;

            while (amount > 0)
            {
                if (amount >= coins[i])
                {
                    ++coinsNeeded;
                    amount = amount - coins[i];
                }
                else
                {
                    --i;
                }
            }

            return coinsNeeded;

        }


    }
}
