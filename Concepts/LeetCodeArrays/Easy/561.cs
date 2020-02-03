using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _561
    {
        public int ArrayPairSum(int[] nums)
        {
            int sum = 0;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; i += 2)
            {
                // No need to use Math.Min. First element will always be minimum.
                sum += Math.Min(nums[i], nums[i + 1]);
            }

            return sum;
        }

        public int ArrayPairSum2(int[] nums)
        {
            int[] arr = new int[20001];
            int lim = 10000;
            foreach (int num in  nums)
                arr[num + lim]++;
            int d = 0, sum = 0;
            for (int i = -10000; i <= 10000; i++)
            {
                sum += (arr[i + lim] + 1 - d) / 2 * i;
                d = (2 + arr[i + lim] - d) % 2;
            }


            return sum;
        }

        public int ArrayPairSum3(int[] nums)
        {
            //All the integers in the array will be in the range of [-10,000, 10,000].
            // so total elements in count array will be 
            //10,000(negative numbers)+10,000(positive numbers)+1(for zero)=20,001

            int[] hash = new int[20001];
            foreach (int ele in nums)
            {
                //-10000 to -1 array elements values maps to array index from 0 to 9999
                // 0 array element maps to array index 10000 
                // 1 to 10000 array elements maps to array index from 10001 to 20000
                hash[ele+10000]++;
            }
            int sum = 0;
            int p = 0;
            for (int i = 0; i < 20001; i++)
            {
                //if 0 than means no corresponding element exists in provided array
                if (hash[i] == 0) continue;
                //If not 0 than it means value exists in provided array
                while (hash[i] != 0)
                {
                    // We will take the first element encountered as !=0 for sum
                    // Afterwords skip next element
                    //
                    if (p % 2 == 0)
                    {
                        sum += (i-1000);
                    }
                    p++;
                    hash[i]--;
                }
            }
            return sum;
        }
    }
}
