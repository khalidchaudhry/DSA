using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer.cs
{
    public class FloorAndCeiling
    {
        //https://www.techiedelight.com/find-floor-ceil-number-sorted-array/
        public int[] FloorAndCeil(int[] arr, int number)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            //! First array element represents floor and second represents ceiling
            int[] result = new int[] { -1, -1 };
            FloorAndCeil(arr, lo, hi, number, true, result);
            return result;
        }

        private void FloorAndCeil(int[] arr, int lo, int hi, int number, bool floor, int[] result)
        {
            if (lo > hi)
            {
                return;
            }
            int mid = lo + ((hi - lo) / 2);

            if (arr[mid] == number)
            {
                result[0] = arr[mid];
                result[1] = arr[mid];
                return;
            }
            else if (arr[mid] > number) //! if mid element is greater than number than it will be ceiling
            {
                //Ceiling
                result[1] = arr[mid];
                FloorAndCeil(arr, lo, mid - 1, number, floor, result);
            }
            else //! if mid element is less  than number than it will be floor
            {
                //Floor
                result[0] = arr[mid];
                FloorAndCeil(arr, mid + 1, hi, number, floor, result);
            }
        }
    }
}
