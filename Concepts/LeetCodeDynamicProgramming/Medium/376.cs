using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _376
    {

        //! Same pattern as Leetcode 300 
        public int WiggleMaxLength(int[] nums)
        {
            
            Dictionary<int, (int down, int up)> map = new Dictionary<int, (int down, int up)>();
            int longest = 1;
            foreach (int num in nums)
            {

                int maxUp = 1;
                int maxDown = 1;
                foreach (var keyValue in map)
                {
                    int prev = keyValue.Key;
                    (int prevDown, int prevUp) = keyValue.Value;
                    if (prev < num)
                    {
                        maxUp = Math.Max(maxUp, prevDown + 1);
                    }
                    else if (prev > num)
                    {
                        maxDown = Math.Max(maxDown, prevUp + 1);
                    }
                    else
                    {
                        maxUp = Math.Max(maxUp, prevUp);
                        maxDown = Math.Max(maxDown, prevDown);
                    }
                }
                map[num] = (maxDown, maxUp);

                longest = Math.Max(longest, Math.Max(maxUp, maxDown));
            }
            return longest;


        }





    }
}
