 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _540
    {
        public int SingleNonDuplicate(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 1;

            while (l < r)
            {
                int mid = l + (r - l) / 2;

                bool isEven = (r - mid) % 2 == 0;
                
                if (nums[mid] == nums[mid - 1])
                {
                    if (isEven)
                    {
                        r = mid - 2;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                else if (nums[mid] == nums[mid + 1])
                {
                    if (isEven)
                    {
                        l = mid + 2;
                    }
                    else
                    {                        
                        r = mid - 1;
                    }
                }
                else
                    return nums[mid];
            }

            return nums[l];

        }

    }
}
