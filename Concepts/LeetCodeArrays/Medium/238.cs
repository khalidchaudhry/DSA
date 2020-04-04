using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _238
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];
            // The left and right arrays as described in the algorithm
            int[] L = new int[nums.Length];
            int[] R = new int[nums.Length];
            // L[i] contains the product of all the elements to the left
            // Note: for the element at index '0', there are no elements to the left,
            // so L[0] would be 1
            L[0] = 1;
            for (int i = 1; i < L.Length; ++i)
            {
                // L[i - 1] already contains the product of elements to the left of 'i - 1'
                // Simply multiplying it with nums[i - 1] would give the product of all
                // elements to the left of index 'i'
                L[i] = L[i - 1] * nums[i - 1];
            }
            // R[i] contains the product of all the elements to the right
            // Note: for the element at index 'length - 1', there are no elements to the right,
            // so the R[length - 1] would be 1
            R[R.Length - 1] = 1;
            for (int i = R.Length - 2; i >= 0; --i)
            {
                // R[i + 1] already contains the product of elements to the right of 'i + 1'
                // Simply multiplying it with nums[i + 1] would give the product of all
                // elements to the right of index 'i'
                R[i] = R[i + 1] * nums[i + 1];
            }

            for (int i = 0; i < result.Length; i++)
            {
                // For the first element, R[i] would be product except self
                // For the last element of the array, product except self would be L[i]
                // Else, multiple product of all elements to the left and to the right
                result[i] = L[i] * R[i];
            }

            return result;
        }

        public int[] ProductExceptSelf2(int[] nums)
        {
            // Final answer array to be returned
            int[] result = new int[nums.Length];
            // answer[i] contains the product of all the elements to the left
            // Note: for the element at index '0', there are no elements to the left,
            // so the answer[0] would be 1
            result[0] = 1;
            for (int i = 1; i < nums.Length; ++i)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }
            // R contains the product of all the elements to the right
            // Note: for the element at index 'length - 1', there are no elements to the right,
            // so the R would be 1
            int R = 1;
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                // For the index 'i', R would contain the 
                // product of all elements to the right. We update R accordingly
                result[i] = result[i] * R;
                R = R * nums[i];
            }

            return result;
        }

    }
}
