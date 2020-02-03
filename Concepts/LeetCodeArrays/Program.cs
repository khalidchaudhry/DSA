using LeetCodeArrays.Easy;
using System;

namespace LeetCodeArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            /****************1.Two Sum****************************************/
            //int[] nums = new int[] 
            //{230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789542 };

            //int target = 542;

            //_1 TwoSum = new _1();

            //TwoSum.TwoSum(nums, target);

            /****************53.Maximum Subarray****************************************/
            //_53 MaximumSubArraySum = new _53();
            //int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            //MaximumSubArraySum.MaxSubArray(nums);

            /******121.Best Time to Buy and Sell Stock**************************/

            //_121 BestTimeToBuy = new _121();
            //int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            //BestTimeToBuy.MaxProfit(prices);

            /**************561.Array Partition I**********************************/
            //int[] nums = new int[] { 1, 4, 3, 2 };
            //_561 ArrayPartition = new _561();
            //ArrayPartition.ArrayPairSum3(nums);

            /**************27.Remove Element**********************************/
            //int[] nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            //_27 RemoveElement = new _27();
            //RemoveElement.RemoveElement(nums,2);

            /*************219.Contains Duplicate II*****************************/
            //int[] nums = new int[] { 1, 2, 3, 1, 2, 3 };

            //int k = 2;
            //_219 Duplicates = new _219();

            //Duplicates.ContainsNearbyDuplicate(nums,k);

            /*************167.Two Sum II -Input array is sorted*********************/
            int[] numbers = new int[] { 2, 7, 11, 15 };
            int target = 9;
            _167 TwoSum = new _167();

            TwoSum.TwoSum(numbers,9);


            Console.ReadLine();
        }
    }
}
