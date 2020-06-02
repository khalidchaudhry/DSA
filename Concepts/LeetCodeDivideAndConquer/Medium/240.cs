using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Medium
{
    public class _240
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            bool result = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if(IsValueExist(matrix,i,target))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private bool IsValueExist(int[,] arr,int row,int target)
        {

            bool result = false;
            int low = 0;

            int high = arr.GetLength(1)-1;

            while (low <= high)
            {
                int midPoint = low + ((high - low) / 2);

                int value = arr[row, midPoint];
                if (value == target)
                {
                    return true;
                }
                else if (value > target)
                {
                    high = midPoint - 1;
                }
                else
                {
                    low = midPoint + 1;
                }

            }

            return result;
        }


    }
}
