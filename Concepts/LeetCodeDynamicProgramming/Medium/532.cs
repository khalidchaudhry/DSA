using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _532
    {

        public static void _532Main()
        {

            _532 CheckSubArraySum = new _532();
            int[] nums = new int[] { 0, 0 };
            int k = 0;
            var ans = CheckSubArraySum.CheckSubarraySum1(nums, k);

            Console.ReadLine();

        }


        /// <summary>
        //! Brute force solution
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CheckSubarraySum0(int[] nums, int k)
        {

            int sum = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                sum += nums[i];
                if (k != 0)
                {
                    sum = sum % k;
                }
                if (map.ContainsKey(sum))
                {
                    if (i - map[sum] > 1)
                    {
                        return true;
                    }
                }
                else
                {
                    map[sum] = i;
                }


            }

            return false;
        }

        /// <summary>
        //! Brute force solution
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CheckSubarraySum1(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                int sum = nums[i];

                for (int j = i + 1; j < nums.Length; ++j)
                {
                    sum += nums[j];
                    if (sum == 0 && k == 0) return true;
                    if (k != 0 && sum % k == 0) return true;
                }
            }

            return false;
        }


    }
}
