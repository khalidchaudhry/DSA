using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashSet
{
    class _575
    {
        public int DistributeCandies(int[] candies)
        {
            HashSet<int> hs = new HashSet<int>();
            //int candiesCount = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < candies.Length; i++)
            {
                if (map.ContainsKey(candies[i]))
                {
                    ++map[candies[i]];
                }
                else
                {
                    map.Add(candies[i], 1);
                }
            }
            var ordered = map.OrderBy(x => x.Value);

            bool oddFlag = false;
            int midval = candies.Length / 2;
            int result = 0;
            foreach (var keyValue in ordered)
            {

                if (keyValue.Value % 2 == 0)
                {
                    //result+=keyValue.Value / 2;
                    result += keyValue.Value / 2;
                    if (!hs.Contains(keyValue.Key))
                    {
                        hs.Add(keyValue.Key);
                    }
                }
                else
                {
                    if (oddFlag)
                    {
                        oddFlag = false;
                        // continue;
                    }
                    result += keyValue.Value == 1 ? 1 : keyValue.Value % 2;
                    if (result > midval)
                    {
                        //  continue;
                    }
                    if (!hs.Contains(keyValue.Key))
                    {
                        hs.Add(keyValue.Key);
                        // oddFlag = true;

                    }
                }


            }
            return hs.Count;
        }

        public int DistributeCandies2(int[] candies)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var  candy in  candies)
            {
                set.Add(candy);
            }
            return Math.Min(set.Count, candies.Length / 2);
        }
    }
}
