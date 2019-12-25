using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _189
    {
        //[1,2,3]
        //and k = 1

        //[5,6,7,1,2,3,4]
        public void Rotate(int[] nums, int k)
        {
            int[] aux = new int[nums.Length];

            //from where to start copying the array
            //nums.Length - k

            for (int i = nums.Length - k, j = 0; i < nums.Length; i++, j++)
            {
                aux[j] = nums[i];
            }

            for (int i = k, j = 0; i < nums.Length; i++, j++)
            {
                aux[i] = nums[j];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = aux[i];
            }
        }
        public void Rotate2(int[] nums, int k)
        {
            if (nums.Length == 1 || k == 0)
                return;

            if (k > nums.Length)
            {
                k = k - nums.Length;
            }

            ReverseArray(nums, 0, nums.Length - 1);
            ReverseArray(nums, 0, k - 1);
            ReverseArray(nums, k, nums.Length - 1);
        }

        private void ReverseArray(int[] nums, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                int temp = nums[startIndex];
                nums[startIndex] = nums[endIndex];
                nums[endIndex] = temp;
                ++startIndex;
                --endIndex;
            }
        }
        public void Rotate3(int[] nums, int k)
        {
            for (int i = 0; i < k; i++)
            {

                // take out the last element
                int temp = nums[nums.Length - 1];
                for (int j = nums.Length - 1; j > 0; j--)
                {
                    // shift array elements towards right by one place
                    nums[j] = nums[j - 1];
                }
                nums[0] = temp;
            }

        }

    }
}
