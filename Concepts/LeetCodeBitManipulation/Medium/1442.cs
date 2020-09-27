using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Medium
{
    public class _1442
    {
        public static void _1442Main()
        {
            int[] arr = new int[] { 1, 1, 1, 1 };

            _1442 CountTriplets = new _1442();
            var ans = CountTriplets.CountTriplets(arr);

            Console.ReadLine();
        }
        /// <summary>
        // !Brute Force
        /// https://www.youtube.com/watch?v=0dAZTDykGbs
        // ! XOR is both associative and commutative 
        //! a^(b^c)=(a^b)^c  --commutative 
        //! if a^b=c then a^c=b and b^c=a   ---associative
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>

        public int CountTriplets(int[] arr)
        {
            int count = 0;
            //! arr.Length-1 because triplets must include 2 numbers in an array
            for (int i = 0; i < arr.Length-1; ++i)
            {
                int xor = 0;
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    xor = xor ^ arr[j];
                    //! case where a^b=c
                    if (arr[i] == xor)
                        //! Number of triplets depends upon  length since there are  different combination possible
                        //! e.g. 1=1^1^1 have different possiblites like 1^1^1=1 , 1^1=1^1
                        //! triplet count is equal to the length of the subarray
                        count += (j - i);
                }
            }

            return count;

        }


    }
}
