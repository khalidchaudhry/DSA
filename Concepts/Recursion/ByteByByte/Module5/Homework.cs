using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module5
{
    public class Homework
    {

        /*
           Array of Arrays. Given a 2 dimensional array, find all of the different 1 dimensional arrays that you
           can make by selecting a single element from each array.            
        */
        public List<List<int>> ArrayOfArrays(int[][] arr)
        {
            List<List<int>> result = new List<List<int>>();
            ArrayOfArrays(arr, 0, new List<int>(), result);
            return result;
        }

        private void ArrayOfArrays(int[][] arr, int i, List<int> path, List<List<int>> result)
        {
            if (i == arr.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            foreach (int item in arr[i])
            {
                path.Add(item);
                ArrayOfArrays(arr, i + 1, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }
        /*
         Write a permutation function that guarantees that the results are in sorted order.
         */
        public List<List<int>> SortedPermutations(int[] arr)
        {
            List<List<int>> result = new List<List<int>>();
            Array.Sort(arr);
            SortedPermutations(arr, 0, new List<int>(), result);

            return result;
        }
        /*
             A teacher is trying to arrange a seating chart in their classroom. They have N students who will sit
            in a line. They also have a list of pairs of students who have to sit next to each other. Write a
            function to find all of the possible seating arrangements.
        */
        public List<List<int>> Arrangements(int N, Dictionary<int, int> pairs)
        {
            List<List<int>> result = new List<List<int>>();

            HashSet<int> items = new HashSet<int>();
            for (int i = 1; i <= N; i++)
            {
                items.Add(i);
            }
            Arrangements(items, new List<int>(), pairs, result);
            return result;
        }

        private void Arrangements(HashSet<int> items, List<int> path, Dictionary<int, int> pairs, List<List<int>> result)
        {
            if (items.Count == 0)
            {
                result.Add(new List<int>(path));
                return;
            }

            foreach (int item in new HashSet<int>(items))
            {
                items.Remove(item);
                path.Add(item);
                int j=0;
                bool exists = pairs.ContainsKey(item);
                if (exists)
                {
                    pairs.TryGetValue(item, out j);
                    items.Remove(j);
                    path.Add(j);
                }
                Arrangements(items, path, pairs, result);
                path.RemoveAt(path.Count - 1);
                items.Add(item);
                if (exists)
                {
                    items.Add(j);
                    path.RemoveAt(path.Count-1);
                }
            }
        }

        private void SortedPermutations(int[] arr, int i, List<int> path, List<List<int>> result)
        {
            if (i == arr.Length)
            {
                result.Add(new List<int>(path));
            }

            for (int j = i; j < arr.Length; j++)
            {
                Swap(arr, i, j);
                path.Add(arr[i]);
                SortedPermutations(arr, i + 1, path, result);
                path.RemoveAt(path.Count - 1);
                Swap(arr, i, j);
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
