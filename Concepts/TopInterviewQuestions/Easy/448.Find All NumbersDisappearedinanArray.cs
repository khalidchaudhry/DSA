using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _448
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            IList<int> disappearedNumbers = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                while (i+1 != nums[i] && nums[nums[i]-1]!=nums[i])
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
                    disappearedNumbers.Add(i+1);
                }
            }

            return disappearedNumbers;
        }

        public IList<int> FindDisappearedNumbers2(int[] nums)
        {
            IList<int> disappearedNumbers = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                //nums[index]=Math.Abs(nums[index]) * -1;

                if (nums[index] > 0)
                {
                    nums[index] = -nums[index];

                }
            }
                for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >0)
                {
                    disappearedNumbers.Add(i+1);
                }
            }

            return disappearedNumbers;
        }




    }
}
