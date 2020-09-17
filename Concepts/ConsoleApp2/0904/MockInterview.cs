using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2._0904
{
    public class MockInterview
    {
        public static void MockInterviewMain()
        {

            int[] nums = new int[] { 1, 1, 1, 0 };

            MockInterview Jumps = new MockInterview();

            Jumps.CanJump(nums);

        }
        public bool CanJump(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return true;
            int i = 0;

            while (i < n)
            {
                int maxJump = nums[i];

                //if (maxJump >= n - 1)
                //    return true;


                if (maxJump < n)
                {
                    int maxValueIndex = MaxValueIndex(nums, i + 1, maxJump);
                    i = maxValueIndex;
                    continue;
                }
                else if (maxJump >= n - 1)
                {
                    return true;
                }

                else if (maxJump == 0)
                    return false;

                ++i;
            }

            return false;
        }

        private int MaxValueIndex(int[] nums, int startIndex, int maxJump)
        {
            int maxValue = nums[startIndex];
            int maxValueIndex = startIndex;

            for (int i = startIndex + 1; i <= maxJump; ++i)
            {
                if (nums[i] >= maxValue)
                {
                    maxValue = nums[i];
                    maxValueIndex = i;
                }

            }

            return maxValueIndex;
        }
    }
}
