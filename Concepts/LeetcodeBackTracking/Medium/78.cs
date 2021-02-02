using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeBackTracking.Medium
{
    public class _78
    {


        public static void _78Main()
        {
            int[] nums = new int[] { 1, 2, 3 };

            int target = 3;

            var test = new _78();
            List<IList<int>> result = new List<IList<int>>();

            test.Subset3(nums, 0, target, new List<int>(), result);

            Console.ReadLine();

        }



        /// <summary>
        //  # <image url="$(SolutionDir)\Images\78.jpg" scale="0.4"/>


        //  # <image url="$(SolutionDir)\Images\78(0).png"  scale="0.5"/>
        //  https://www.youtube.com/watch?v=MsHFNGltIxw
        /// https://leetcode.com/problems/combination-sum/discuss/16502/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
        //! Takeaway1: In subset , every node is having  the result,in permutation, the leaf nodes are having the result 
        //! Takeaway2: We can only choose number after it as subset can't have duplicates
        /// </summary>

        public IList<IList<int>> Subsets0(int[] nums)
        {

            List<IList<int>> powerSet = new List<IList<int>>();
            Subset0(nums, 0, new List<int>(), powerSet);
            return powerSet;
        }

        private void Subset0(int[] nums, int start, List<int> path, List<IList<int>> powerSet)
        {
            powerSet.Add(new List<int>(path));

            //!i+1 => Once we choose number on a postion, we will not choose the same number for that position again. 
            //! 
            for (int i = start; i < nums.Length; ++i)
            {
                path.Add(nums[i]); //choose
                //! i + 1=> we can only start the call afterwords.                 
                Subset0(nums, i + 1, path, powerSet);//explore 
                path.RemoveAt(path.Count - 1);//unchoose 
            }
        }
        //! Based on Sams byte by byte course
        //! https://youtu.be/MsHFNGltIxw?t=374
        // # <image url="$(SolutionDir)\Images\78.png"  scale="0.5"/>
        public IList<IList<int>> Subsets1(int[] nums)
        {

            List<IList<int>> powerSet = new List<IList<int>>();
            Subset1(nums, 0, new List<int>(), powerSet);
            return powerSet;
        }

        private void Subset1(int[] nums, int i, List<int> path, List<IList<int>> powerSet)
        {
            if (i == nums.Length)
            {
                // new List<int> to add new path
                powerSet.Add(new List<int>(path));
                return;
            }

            //! not  choose the current number(we are not adding the number to path)
            Subset1(nums, i + 1, path, powerSet);
            //! choose the current number(we are adding the number to the path)
            path.Add(nums[i]);
            Subset1(nums, i + 1, path, powerSet);
            //! unchoose the current number
            path.RemoveAt(path.Count - 1);

        }

   
        /// <summary>
        //! Below code can be potiential followup for subset problem when they ask for the subsets equal to the target.  
        /// </summary>
        private void Subset2(int[] nums, int i, int target, List<int> path, List<IList<int>> powerSet)
        {
            if (target == 0)
            {
                powerSet.Add(new List<int>(path));
                return;
            }

            if (target < 0 || i == nums.Length)
                return;

            //! not choose the current number(we are not adding the number to path)
            Subset2(nums, i + 1, target, path, powerSet);
            //! choose the current number(we are adding the number to the path)
            path.Add(nums[i]);
            Subset2(nums, i + 1, target - nums[i], path, powerSet);
            //! unchoose the current number
            path.RemoveAt(path.Count - 1);

        }
        /// <summary>
        //! Below code can be potiential followup for subset problem when they ask for the subsets equal to the target.  
        /// </summary>
        private void Subset3(int[] nums, int index, int target, List<int> path, List<IList<int>> powerSet)
        {
            if (target == 0)
            {
                powerSet.Add(new List<int>(path));
                return;
            }

            if (target < 0 || index == nums.Length)
                return;

            for (int i = index; i < nums.Length; ++i)
            {
                path.Add(nums[i]);
                Subset3(nums, i + 1, target - nums[i], path, powerSet);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
