using LeetCodeDivideAndConquer.Medium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer
{
    class Program
    {
        static void Main(string[] args)
        {

            //_215 KthLargestElement = new _215();
            //int[] nums = new int[] { 2, 1 };
            //int k = 1;
            //KthLargestElement.FindKthLargest0(nums, k);

            _240 Search = new _240();

            int[,] matrix = new int[,]
            {
                {1,4,7,11,15 },
                {2,5,8,12,19 },
                {3,6,9,16,22 },
                {10,13,14,7,24 },
                {18,21,23,26,30 }
            };

             Search.SearchMatrix(matrix,5);


            Console.ReadLine();
        }
    }
}
