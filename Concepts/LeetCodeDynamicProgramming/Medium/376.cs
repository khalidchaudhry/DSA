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

            int longest = 0;
            Dictionary<int, (int ud, int du)> map = new Dictionary<int, (int ud, int du)>();
            for (int i = 0; i < nums.Length; ++i)
            {
                int curr = nums[i];
                //! Setting it with 1 as we have atleast 1 for maxUpToDown and maxDownToUp
                int maxUpToDown = 1;
                int maxDownToUp = 1;
                foreach (var keyValue in map)
                {   
                    //! You are comming from small value to bigger value hence update DownToUp but extend up to down of previous value
                    if (keyValue.Key < curr)
                    {
                        maxDownToUp = Math.Max(maxDownToUp, 1 + keyValue.Value.ud);
                    }
                    //! You are comming from big value to small value hence update UpToDown  but extend down to up of previous value 
                    else if (keyValue.Key > curr)
                    {
                        maxUpToDown = Math.Max(maxUpToDown, 1 + keyValue.Value.du);
                    }
                    //! if value is same as encountered before get the max of maxUpToDown and maxDownToUp
                    else
                    {
                        maxUpToDown = Math.Max(maxUpToDown, keyValue.Value.ud);
                        maxDownToUp = Math.Max(maxDownToUp, keyValue.Value.du);
                    }
                }
                map[curr] = (maxUpToDown, maxDownToUp);
                longest = Math.Max(longest, Math.Max(map[curr].ud, map[curr].du));
            }

            return longest;


        }





    }
}
