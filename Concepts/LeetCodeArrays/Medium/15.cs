using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _15
    {
        //https://www.youtube.com/watch?v=bixvM1-28us
        //https://www.youtube.com/watch?v=3u59zv-c7go
        public IList<IList<int>> ThreeSum0(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                //! to avoid duplicates 
                if (i != 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum < 0)
                    {
                        ++left;
                    }
                    else if (sum > 0)
                    {
                        --right;
                    }
                    else
                    {
                        List<int> triplet = new List<int>();
                        triplet.Add(nums[i]);                        
                        triplet.Add(nums[left]);
                        triplet.Add(nums[right]);

                        res.Add(triplet);

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

            return res;
        }





        //https://leetcode.com/problems/3sum/solution/
        public IList<IList<int>> ThreeSum1(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> res = new List<IList<int>>();
            //!If the current value is greater than zero, break from the loop.Remaining values cannot sum to zero as we have sorted an array
            for (int i = 0; i < nums.Length && nums[i] <= 0; ++i)
                //!nums[i - 1] != nums[i]=If the current value is the same as the one before, skip it as its duplicate
                //e.g. {-1,-1,0,1,2}
                if (i == 0 || nums[i - 1] != nums[i])
                    TwoSumII(nums, i, res);
            return res;
        }
        private void TwoSumII(int[] nums, int i, List<IList<int>> res)
        {
            int lo = i + 1, hi = nums.Length - 1;
            while (lo < hi)
            {
                int sum = nums[i] + nums[lo] + nums[hi];
                //! lo > i + 1 to avoid duplicates 
                if (sum < 0 || (lo > i + 1 && nums[lo] == nums[lo - 1]))
                    ++lo;
                //! hi < nums.Length - 1 to avoid duplicates
                else if (sum > 0 || (hi < nums.Length - 1 && nums[hi] == nums[hi + 1]))
                    --hi;
                else
                {
                    List<int> triplet = new List<int>();
                    triplet.Add(nums[i]);
                    triplet.Add(nums[lo++]);
                    triplet.Add(nums[hi--]);

                    res.Add(triplet);
                }
            }
        }


        /*
        Three pointer approach 
        First  pointer =start from beginning
        second pointer=First Pointer+1
        Third pointer=Start from right(end). why from right because we are working on array that is already sorted.
                      The pointer will point to current largest element that can be the part of tripplet. 
          
        Time complexity=O(n^2)  
         https://www.youtube.com/watch?v=jeim_j8VdiM
        */
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();

            // O(nlogn) complexity
            Array.Sort(nums);
            // -2 because we are asked to find tripplet 
            for (int i = 0; i < nums.Length - 2; i++)
            {

                //!To handle duplicate elements
                /*
                  { -1,-1,0,1,2}
                  {-1(index 0),0,1} willbe one triplet 
                   As answer cannot contain duplicate triplets processing below will create duplicate hence we can skip it
                  {-1(index 1),0,1}
                  */
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    // Happy case 
                    if (sum == 0)
                    {
                        List<int> triplet = new List<int>();
                        triplet.Add(nums[i]);
                        triplet.Add(nums[left]);
                        triplet.Add(nums[right]);

                        result.Add(triplet);

                        // To skip duplicates. 
                        // {-1,-1,0,0,1,1,1,2,2,3}
                        while (left < right && nums[left] == nums[left + 1])
                        {
                            ++left;
                        }
                        // To skip duplicates. 
                        // {-1,-1,0,0,1,1,1,2,2,3}
                        while (left < right && nums[right] == nums[right - 1])
                        {
                            --right;
                        }

                        ++left;
                        --right;
                    }
                    // the element we are going to find that results in 0 will be on left side hence decrementing 
                    else if (sum > 0)
                    {
                        --right;
                    }
                    else
                    {
                        ++left;
                    }
                }
            }
            return result;
        }
        public IList<IList<int>> ThreeSum3(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            HashSet<string> hs = new HashSet<string>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //a+b+c=0
                //b+c=-a
                // target=-a
                int target = -nums[i];
                dict.Clear();
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    int num = target - nums[j];
                    // Looking up based on the aray element
                    if (dict.ContainsKey(nums[j]))
                    {
                        int[] arr = new int[3];
                        // Below steps to ensure that we don't insert duplicate triplets
                        arr[0] = nums[i]; //a
                        arr[1] = nums[dict[nums[j]]]; //b 
                        arr[2] = nums[j]; //c
                        Array.Sort(arr);
                        string s = $"{arr[0]}{arr[1]}{arr[2]}";
                        if (!hs.Contains(s))
                        {
                            hs.Add(s);

                            List<int> record = new List<int>();
                            record.Add(arr[0]);
                            record.Add(arr[1]);
                            record.Add(arr[2]);
                            // adding the record to the final result set
                            result.Add(record);
                        }
                    }
                    else
                    {
                        // This check is very important in case if there are repeated elements in array
                        // like // [2,2,7,11,5] without it code will throw an error that element already exists

                        if (!dict.ContainsKey(num))
                        {
                            dict.Add(num, j);
                        }
                    }

                }

            }
            return result;
        }
        public IList<IList<int>> ThreeSum4(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums); //nlog(n)
            for (int i = 0; i < nums.Length - 2; i++)
            {
                /*
                To handle duplicate elements
                {-1,-1,-1,0,1,2}
                {-1(index 0),0,1} willbe one triplet 
                As answer cannot contain duplicate triplets processing below will create duplicate hence we can skip it
                {-1(index 1),0,1}
                */
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;                     //corner case {0,0,0,0}
                }
                // x+y+z=0
                // y+z=-x;

                TwoSum(result, nums, i + 1, -nums[i]);
            }
            return result;

        }
        private void TwoSum(List<IList<int>> result, int[] nums, int low, int target)
        {
            // Dictionary will store the difference between target and current array element of the iteration
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = low; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    List<int> lst = new List<int>();

                    lst.Add(-target);
                    lst.Add(nums[i]);
                    lst.Add(nums[map[nums[i]]]);
                    result.Add(lst);
                    while (i + 1 < nums.Length && nums[i] == nums[i + 1])
                    {
                        i++;             //corner case {0,0,0,0}
                    }
                }
                else
                {
                    int difference = target - nums[i];
                    if (map.ContainsKey(difference))
                    {
                        map[difference] = i;          //overriding index of the existing difference we have                                            
                    }
                    else
                    {
                        map.Add(difference, i);
                    }
                }
            }
        }
    }
}
