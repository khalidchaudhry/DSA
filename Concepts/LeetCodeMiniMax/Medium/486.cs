using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMiniMax.Medium
{
    public class _486
    {
        public bool PredictTheWinner(int[] nums)
        {

            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }

            Dictionary<(int left, int right), int> memo = new Dictionary<(int left, int right), int>();


            int player1 = PredictTheWinner(nums, 0, nums.Length - 1, memo);
            int player2 = sum - player1;
            return player1 >= player2;
        }

        private int PredictTheWinner(int[] nums, int left, int right, Dictionary<(int left, int right), int> memo)
        {
            if (left < 0 || right < 0 || left > right)
                return 0;

            if (memo.ContainsKey((left, right)))
                return memo[(left, right)];          

            //![a,b,c,d,e]
            //!PredictTheWinner[a,b,c,d,e]=max(
            //!                        a+Min(PredictTheWinner([c,d,e]),PredictTheWinner([b,c,d]),
            //!                        e+Min(PredictTheWinner([b,c,d]),PredictTheWinner([a,b,c]),

            int max = Math.Max(nums[left] + Math.Min(PredictTheWinner(nums, left + 2, right, memo),
                                                      PredictTheWinner(nums, left + 1, right - 1, memo)),
                               nums[right] + Math.Min(PredictTheWinner(nums, left + 1, right - 1, memo),
                                                       PredictTheWinner(nums, left, right - 2, memo)));

            memo[(left,right)] = max;

            return memo[(left, right)];
        }


    }
}
