using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    /// <summary>
    /// https://www.youtube.com/watch?time_continue=614&v=IPWmrjE1_MU
    /// </summary>
    public class ArrayPermutations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            NextPermutationHelper(nums, 0, result);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="results"></param>
        private void NextPermutationHelper(int[] nums, int start, List<List<int>> results)
        {
            if (start >= nums.Length)
            {
                results.Add(new List<int>(nums));
            }
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    //swap 
                    Swap(nums, start, i);
                    NextPermutationHelper(nums, start + 1, results);
                    //undo the swap
                    Swap(nums, start, i);
                }

            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }


    }
}
