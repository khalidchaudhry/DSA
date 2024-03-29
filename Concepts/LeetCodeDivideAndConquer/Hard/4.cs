﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Hard
{
    class _4
    {
        //! Time=O(log(Min(m,n))
        //! Space=O(1)
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            
            int[] big = nums1.Length > nums2.Length ? nums1 : nums2;
            int[] small = nums1.Length > nums2.Length ? nums2 : nums1;

            int m = big.Length;
            int n = small.Length;

            int partitionSize = (m + n) / 2;  //! x/2
            int lo = 0;
            int hi = n; 
            while (lo <= hi)
            {
                //! Find the pivot point in small array 
                //! We choose small array for partitioning because cut will always be deterministic 
                int mid = lo + ((hi - lo) / 2); //! index for small 

                //! Any pivot point in small array has a corresponding point on large array 
                //! that divides the total number of elments into two 
                int bigArrayIdx = partitionSize - mid; //! index for big 

                //! Find the indexes

                int smallLeft = mid == 0 ? int.MinValue : small[mid - 1];
                int bigLeft = bigArrayIdx == 0 ? int.MinValue : big[bigArrayIdx - 1];


                //! Right side will contain 1 more element  hence i is not i+1
                int smallRight = mid == n ? int.MaxValue : small[mid];              
                //! Right side will contain 1 more element  hence j is not j+1
                int bigRight = bigArrayIdx == m ? int.MaxValue : big[bigArrayIdx];

                //!If the partion is correct
                if (bigRight >= smallLeft && smallRight >= bigLeft)
                {
                    if ((m + n) % 2 == 1)
                    {
                        return Math.Min(bigRight, smallRight);
                    }
                    else
                    {
                        return (Math.Max(bigLeft, smallLeft) + Math.Min(bigRight, smallRight)) / (double)2;
                    }
                }
                //!Determine the direction where we need to go  
                else if (smallLeft > bigRight)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return 0;

        }


        /// <summary>
        //! O(m+n) space 
        //! O(m+n) time
        /// </summary>
        public double FindMedianSortedArrays1(int[] nums1, int[] nums2)
        {           

            int m = nums1.Length;
            int n = nums2.Length;
            int[] result = new int[m + n];
            int nums1Ptr = 0;
            int nums2Ptr = 0;

            int idx = 0;
            while (nums1Ptr < m || nums2Ptr < n)
            {
                bool chooseFromn1 = nums1Ptr < m && (nums2Ptr == n || nums1[nums1Ptr] <= nums2[nums2Ptr]);
                if (chooseFromn1)
                {
                    result[idx++] = nums1[nums1Ptr++];
                }
                else
                {
                    result[idx++] = nums2[nums2Ptr++];
                }
            }

            if ((m + n) % 2 == 1)
            {
                return result[(m + n) / 2];
            }
            else
            {
                int idx1 = (m + n) / 2;

                return ((double)result[idx1 - 1] + result[idx1]) / 2;
            }

        }

    }
}
