using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer.cs
{
    class NumberOccurances
    {

        public int DuplicateNumberOccurrances(int[] arr, int target)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            int[] result = new int[] { -1, -1 };

            DuplicateNumberOccurances(arr, lo, hi, target, true, result);

            if (result[0] != -1)
            {
                 lo = 0;
                hi = arr.Length - 1;
                DuplicateNumberOccurances(arr, lo, hi, target, false, result);
            }
            else
            {
                return -1;
            }

            return result[1] - result[0] + 1;
        }

        private void DuplicateNumberOccurances(int[] arr, int lo, int hi, int target, bool loRange, int[] result)
        {
            if (lo > hi) return;
            int mid = lo + ((hi - lo) / 2);

            if (arr[mid] == target)
            {
                if (loRange)
                {
                    result[0] = mid;
                    DuplicateNumberOccurances(arr, lo, mid - 1, target, loRange, result);
                }
                else
                {
                    result[1] = mid;
                    DuplicateNumberOccurances(arr, mid + 1, hi, target, loRange, result);
                }
            }
            else if (arr[mid] > target)
            {
                DuplicateNumberOccurances(arr, lo, mid - 1, target, loRange, result);
            }
            else
            {
                DuplicateNumberOccurances(arr, mid + 1, hi, target, loRange, result);
            }
        }
    }
}
