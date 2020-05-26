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

            _215 KthLargestElement = new _215();
            int[] nums = new int[] { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            KthLargestElement.FindKthLargest(nums,k);



            Console.ReadLine();
        }
    }
}
