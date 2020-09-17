using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _1011
    {

        public static void _1011Main()
        {
            int[] weights = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int D = 5;
            _1011 MinCapacity = new _1011();
            var ans=MinCapacity.ShipWithinDays(weights,D);

            Console.ReadLine();
        }

        public int ShipWithinDays(int[] weights, int D)
        {
            int left = GetMaxWeight(weights);
            int right = GetSum(weights);
            while (left < right)
            {
                int mid = left + ((right - left) / 2);

                if (IsAboveD(weights, mid, D))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        private bool IsAboveD(int[] weights, int mid, int D)
        {
            //! days=1 as we need atleast 1 day to ship whatever the weight given to us
            int days = 1;
            int sum = 0;
            for (int i = 0; i < weights.Length; ++i)
            {
                sum += weights[i];
                if (sum > mid)
                {
                    ++days;
                    //! reseting sum to current weight
                    sum = weights[i];
                }
                //! This conidtion is for the last day as above condition will not 
                //! increment the days count
                //! or you can set days to 1 as we need at least one day to ship the weight given to us
                //if (i == weights.Length - 1)
                //{
                //    ++days;
                //}
                if (days > D)
                {
                    return true;
                }
            }

            return false;
        }

        private int GetSum(int[] weights)
        {
            int sum = 0;
            for (int i = 0; i < weights.Length; ++i)
            {
                sum += weights[i];
            }
            return sum;
        }

        private int GetMaxWeight(int[] weights)
        {
            int maxWeight = weights[0];
            for (int i = 1; i < weights.Length; ++i)
            {
                maxWeight = Math.Max(maxWeight,weights[i]);
            }

            return maxWeight;
        }
    }
}
