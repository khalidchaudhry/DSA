using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    //https://www.youtube.com/watch?v=bixvM1-28us
    //! Same pattern for 2 sum/3sum. 
    //! Its just matter  of how many inner for loops we need 
    public class _18
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> res = new List<IList<int>>();

            Array.Sort(nums);

            //!nums.Lenght-3 because we need to add 4 numbers to become equal to target sum 
            for (int i = 0; i < nums.Length - 3; i++)
            {
                //! to avoid duplicates 
                if (i != 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    //! to avoid duplicates   
                    //! j != i + 1=For input [0,0,0,0] without it , it will skip it but we need to add it in our result set. 
                    if (j != i + 1 && nums[j] == nums[j - 1])
                    {
                        continue;
                    }

                    int left = j + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];

                        if (sum < target)
                        {
                            ++left;
                        }
                        else if (sum > target)
                        {
                            --right;
                        }
                        else
                        {
                            List<int> quadruplet = new List<int>();
                            quadruplet.Add(nums[i]);
                            quadruplet.Add(nums[j]);
                            quadruplet.Add(nums[left]);
                            quadruplet.Add(nums[right]);

                            res.Add(quadruplet);

                            ++left;
                            --right;
                            //! To skip duplicates
                            while (left < right && nums[left] == nums[left - 1])
                            {
                                ++left;
                            }
                            //! To skip duplicates
                            while (left < right && nums[right] == nums[right + 1])
                            {
                                --right;
                            }
                        }
                    }
                }
            }

            return res;
        }


    }
}
