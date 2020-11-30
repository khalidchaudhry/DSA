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
            var ans = MinCapacity.ShipWithinDays0(weights, D);

            Console.ReadLine();
        }
        /// <summary>
        //! Based on the template from Roger 
        /// </summary>
        public int ShipWithinDays0(int[] weights, int D)
        {
            int lo = Max(weights) - 1;//making it invalid 
            int hi = Sum(weights);
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (OK(weights, mid, D))
                {
                    hi = mid;
                }
                else
                    lo = mid;
            }

            return hi;
        }
        //!FFFF'T'TTTTT
        //! Can we ship within D days using the provided capacity? 
        private bool OK(int[] weights, int capacity, int D)
        {
            int days = 1;
            int sum = 0;
            //!calculating the number of days for the given capacity
            for (int i = 0; i < weights.Length; ++i)
            {
                sum += weights[i];
                if (sum > capacity)
                {
                    ++days;
                    //! reseting sum to current weight
                    //! We can't break the weights hence we are assigning current weight to sum
                    //! if we are allowed to break the weights than we could have less weights 
                    sum = weights[i];
                }
            }

            return days <= D;
        }

        public int ShipWithinDays(int[] weights, int D)
        {
            int left = Max(weights);
            int right = Sum(weights);
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

        private int Max(int[] weight)
        {
            int max = weight[0];
            for (int i = 0; i < weight.Length; ++i)
            {
                max = Math.Max(max, weight[i]);
            }
            return max;
        }

        private int Sum(int[] weight)
        {
            int sum = 0;
            for (int i = 0; i < weight.Length; ++i)
            {
                sum += weight[i];
            }

            return sum;
        }

    }
}
