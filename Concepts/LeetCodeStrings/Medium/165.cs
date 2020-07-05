using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _165
    {
        /// <summary>
        /// https://leetcode.com/problems/compare-version-numbers/solution/
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public int CompareVersion(string version1, string version2)
        {

            string[] nums1 = version1.Split(".");

            string[] nums2 = version2.Split(".");

            int n1 = nums1.Length;
            int n2 = nums2.Length;

            // Compare versions 
            for (int i = 0; i < Math.Max(nums1.Length, nums2.Length); i++)
            {
                int i1 = i < n1 ? int.Parse(nums1[i]) : 0;
                int i2 = i < n2 ? int.Parse(nums2[i]) : 0;
                if (i1 != i2)
                {
                    return i1 > i2 ? 1 : -1;
                }               
            }

            return 0;
        }

      
    }
}
