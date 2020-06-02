using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _338
    {

        //https://www.youtube.com/watch?v=awxaRgUB4Kw
        public int[] CountBits0(int num)
        {
            int[] result = new int[num + 1];
            result[0] = 0;
            for (int i = 1; i <= num; i++)
            {
                int count = i % 2 == 0 ? 0 : 1;
                int index = i / 2;
                result[i] = result[index] + count;
            }

            return result;
        }


        public int[] CountBits(int num)
        {
            List<int> results = new List<int>();
            for (int i = 0; i <= num; i++)
            {
                Count1s(i, results);
            }

            return results.ToArray();

        }

        private void Count1s(int value, List<int> result)
        {
            BitArray b = new BitArray(new int[] { value });
            int count = 0;
            foreach (bool bit in b)
            {
                if (bit)
                {
                    ++count;
                }
            }

            result.Add(count);
        }






    }
}
