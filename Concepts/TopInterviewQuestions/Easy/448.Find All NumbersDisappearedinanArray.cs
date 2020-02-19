using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _448
    {
        //https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/discuss/93007/Simple-Java-In-place-sort-solution
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            IList<int> disappearedNumbers = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //nums[i] != i + 1 -->
                //check that the number is not in the correct position (we are going to swap if not)
                //nums[nums[i] - 1]-->
                //check that the number with which we are going to swap is not the same as 
                // already have(avoid infinite loop)
                // nums[nums[i]-1] --Element we are going to swap is already at correct position . No need to swap
                while (nums[i] != i + 1 && nums[i] != nums[nums[i] - 1])
                {
                    int temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    disappearedNumbers.Add(i + 1);
                }
            }

            return disappearedNumbers;
        }

        public IList<int> FindDisappearedNumbers2(int[] nums)
        {
            IList<int> disappearedNumbers = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //Math.Abs needed . Otherwise it will not work
                int index = Math.Abs(nums[i]) - 1;
                //nums[index]=Math.Abs(nums[index]) * -1;

                if (nums[index] > 0)
                {
                    nums[index] = -nums[index];

                }   
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    disappearedNumbers.Add(i + 1);
                }
            }

            return disappearedNumbers;
        }




    }
}
