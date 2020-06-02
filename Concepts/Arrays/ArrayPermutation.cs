using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class ArrayPermutation
    {
        public List<int[]> ListPermutations(int[] a)
        {
            List<int[]> results = new List<int[]>();
            ListPermutations(a, 0, results);
            return results;
        }

        private void ListPermutations(int[] a, int start, List<int[]> result)
        {
            if (start >= a.Length)
            {                
                result.Add((int[])a.Clone());
            }
            else
            {
                for (int i = start; i < a.Length; i++)
                {
                    Swap(a, start, i);
                    ListPermutations(a, start + 1, result);
                    Swap(a, start, i);
                }
            }
        }

        private void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

    }
}
