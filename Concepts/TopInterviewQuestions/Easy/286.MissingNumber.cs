using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _286
    {
        public int MissingNumber(int[] nums)
        {

            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i <nums.Length; i++)
            {
                hs.Add(nums[i]);
            }

            for (int i = 0; i <= nums.Length; i++)
            {
                if (!hs.Contains(i))
                {
                    return i;
                }
            }
            return -1;
        }
        //using xor 
        // a number XOR itself will become 0, any number XOR with 0 will stay unchanged.
        // So if every number from 1...n XOR with itself except the missing number, the result will be the missing number.
        public int MissingNumber2(int[] nums)
        {
            int res = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                res ^= i;
                res ^= nums[i];
            }

            return res;
        }
    }
}
