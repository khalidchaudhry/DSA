using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            //int[] nums = new int[] { 4, 3, 6, 7, 0, 9, 2 };
            //var result=MaxNumber(nums, 0, int.MinValue);
            //Console.Write(result);
            //string s = "xyxx";

            //var result=IsPalindrome(s,0,s.Length-1);
            //Console.Write(result);
            //Console.ReadKey();

            int[] values = new int[] { 150, 300, 200 };
            int[] weight = new int[] { 1, 4, 3 };
            int capacity = 4;
            int result=KnapSack(values, weight, capacity);

            Console.Write(result);

            Console.Read();
        }

        public static int KnapSack(int[] values, int[] weight, int capacity)
        {
            int[,] result = new int[values.Length+1,capacity+1];

            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (i == 0 || j == 0)
                    {
                        result[i, j] = 0;
                    }
                    else if (weight[i - 1] > j)
                    {
                        result[i, j] = result[i - 1, j];
                    }
                    else
                    {
                                           //current item + remaining capacity ,     previous item 
                        result[i, j] = Math.Max(values[i-1]+result[i-1,j-weight[i-1]],result[i-1,j]);
                    }
                }

           
                       //  access the last element of the array. 
            return result[values.Length , capacity];


        }






        public static int MaxNumber(int[] nums, int index, int maxNumber)
        {
            if (index == nums.Length - 1)
            {
                maxNumber = Math.Max(nums[index], maxNumber);
                return maxNumber;
            }
            else
            {
                maxNumber = Math.Max(maxNumber, nums[index]);

                maxNumber = MaxNumber(nums, index + 1, maxNumber);
                return maxNumber;
            }

        }

        public static bool IsPalindrome(string s, int start, int end)
        {
            if (start >= end)
            {
                return true;
            }
            else
            {
                if (s[start] != s[end])
                {
                    return false;
                }

                return IsPalindrome(s, start + 1, end - 1);
            }

        }
    }
}
