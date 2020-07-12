using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module4
{
    class CombinationsCount
    {
        /// <summary>
        //! Time complexity=O(2^n) since we have brancing factor of 2 and depth of our tree is n
        //! Space complexity=O(n) because its just the height of our recursion 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountCombinations(int[] n)
        {
            return CountCombinations(n, 0);
        }

        private int CountCombinations(int[] n, int i)
        {
            if (i == n.Length)
            {
                return 1;
            }
            //! For every item we have two choices. Either we include the item or exclude the item            
            int include = CountCombinations(n, i + 1);
            int exclude = CountCombinations(n, i + 1);

            return include + exclude;

        }
    }
}
