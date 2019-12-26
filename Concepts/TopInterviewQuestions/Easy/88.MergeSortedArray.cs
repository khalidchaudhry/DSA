using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _88
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = 0, j = 0, k = 0;
            int[] result = new int[n + m];
            while (i < m && j < n)
            {
                if (nums1[i] < nums2[j])
                {
                    result[k] = nums1[i];
                    ++i;
                    ++k;
                }
                else if (nums1[i] > nums2[j])
                {
                    result[k] = nums2[j];
                    ++j;
                    ++k;

                }
                else
                {
                    result[k] = nums1[i];
                    ++k;
                    result[k] = nums2[j];
                    ++k;
                    ++i;
                    ++j;
                }
            }

            while (i < m)
            {
                result[k] = nums1[i];
                ++i;
                ++k;
            }

            while (j < n)
            {
                result[k] = nums2[j];
                ++j;
                ++k;
            }

            for (int r = 0; r < result.Length; r++)
            {
                nums1[r] = result[r];
            }
        }

        void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums1[j])
                    nums1[k--] = nums1[i--];
                else
                    nums1[k--] = nums2[j--];
            }
            while (j >= 0)
                nums1[k--] = nums1[j--];
        }
    }
}
