using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMiniMax.Medium
{
    public class _877
    {


        public bool StoneGames(int[] piles)
        {
            int sum = 0;
            foreach (int pile in piles)
            {
                sum += pile;
            }

            Dictionary<(int left, int right), int> memo = new Dictionary<(int left, int right), int>();

            int alex = BestScore(piles, 0, piles.Length - 1, memo);
            int lee = sum - alex;
            return alex > lee;

        }

        private int BestScore(int[] piles, int left, int right, Dictionary<(int left, int right), int> memo)
        {
            if (left < 0 || right < 0 || left > right)
                return 0;

            if (memo.ContainsKey((left, right)))
                return memo[(left, right)];

            //![a,b,c,d,e]
            //!BestScore[a,b,c,d,e]=max(
            //!                        a+Min( BestScore([c,d,e]), If user 2 picks up b       
            //!                               BestScore([b,c,d]), If user 2 picks up e
            //!                        e+Min( BestScore([b,c,d]),  if user 2 picks up a
            //!                               BestScore([a,b,c]),  if user 2 picks up d

            int max = Math.Max(piles[left] + Math.Min(BestScore(piles, left + 2, right, memo),
                                                      BestScore(piles, left + 1, right - 1, memo)),
                               piles[right] + Math.Min(BestScore(piles, left + 1, right - 1, memo),
                                                       BestScore(piles, left, right - 2, memo)));

            memo[(left, right)] = max;

            return memo[(left, right)];
        }

        /// <summary>
        /// https://leetcode.com/problems/stone-game/discuss/154610/DP-or-Just-return-true
        /// </summary>
        /// <param name="piles"></param>
        /// <returns></returns>
        public bool StoneGame1(int[] piles)
        {
            return true;
        }




    }
}
