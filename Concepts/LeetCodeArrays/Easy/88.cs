using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _88
    {


        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int resultIdx = nums1.Length - 1;
            int ptr1 = m - 1;
            int ptr2 = n - 1;
            while (ptr1 >= 0 || ptr2 >= 0)
            {
                bool chooseFromnums1 = ptr1 >= 0 && (ptr2 < 0 || nums1[ptr1] >= nums2[ptr2]);
                if (chooseFromnums1)
                {
                    nums1[resultIdx--] = nums1[ptr1--];
                }
                else
                {
                    nums1[resultIdx--] = nums2[ptr2--];
                }
            }
        }



        /// <summary>
        //! ONLY WORKS IF WE NEED TO RETURN THE MERGE LIST  
        /// </summary>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {

            int[] result = new int[m + n];
            int resultIdx = 0;
            int ptr1 = 0;
            int ptr2 = 0;
            while (ptr1 < m || ptr2 < n)
            {
                bool chooseFromnums1 = ptr1 < m && (ptr2 == n || nums1[ptr1] <= nums2[ptr2]);
                if (chooseFromnums1)
                {
                    result[resultIdx++] = nums1[ptr1++];
                }
                else
                {
                    result[resultIdx++] = nums2[ptr2++];
                }
            }
            //return result;

        }

    }
}
