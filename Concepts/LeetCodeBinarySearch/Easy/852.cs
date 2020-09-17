using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Easy
{
    public class _852
    {
        public int PeakIndexInMountainArray(int[] A)
        {
            int lo = 0;
            int hi = A.Length - 1;

            while (lo < hi)
            {
                //! comparing element with its neighbours 
                int mid = lo + ((hi - lo) / 2);

                if (A[mid] > A[mid + 1] && A[mid] < A[mid - 1])
                {
                    return mid;
                }
                else if (A[mid] < A[mid - 1])
                {
                    //! because mid can contribute in determining the peak hence no mid-1
                    hi = mid;
                }
                else
                {
                    //! because mid can contribute in determining the peak hence no mid-1
                    lo = mid;
                }
            }

            return -1;

        }


    }
}
