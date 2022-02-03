using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _189
    {

        //https://www.youtube.com/watch?v=BHr381Guz3Y
        
        public void Rotate(int[] nums, int k)
        {

            int n = nums.Length;

            int[] aux = new int[n];
            for (int i = 0; i < n; i++)
            {
                int idx = (i + k) % n;
                aux[idx] = nums[i];
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
            //! importan condition
            if (k > nums.Length)
            {
                k = k - nums.Length;
            }

            ReverseArray(nums, 0, nums.Length - 1);
            //! reversing first k elements. Why k-1 because array is zero based index and k-1 are actually k elements 
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
    }
}
