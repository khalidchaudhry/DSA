using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recursion.ByteByByte.Module5
{
    public class PermutationWithDuplicates
    {
        //!Using sequence comparer
        public HashSet<List<int>> PermutationsWithSequenceComparer(int[] items)
        {
            HashSet<List<int>> result = new HashSet<List<int>>(new SequenceComparer<int>());
            PermutationsWithSwap(items, 0, new List<int>(), result);

            return result;
        }
        public List<List<int>> PermutationsWithHashMap(int[] items)
        {
            List<List<int>> result = new List<List<int>>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < items.Length; i++)
            {
                if (map.ContainsKey(items[i]))
                {
                    ++map[items[i]];
                }
                else
                {
                    map.Add(items[i], 1);
                }
            }
            Permutations(map, new List<int>(), result);
            return result;

        }

        //https://leetcode.com/problems/permutations-ii/discuss/18648/Share-my-Java-code-with-detailed-explanantion
        public List<List<int>> PermutationsWithoutHashMap(int[] items)
        {
            List<List<int>> result = new List<List<int>>();
            PermutationsWithoutHashMap(items, 0, new List<int>(), result);

            return result;

        }

        private void Permutations(Dictionary<int, int> map,
                                  List<int> path,
                                  List<List<int>> result
                                 )
        {
            if (map.Count == 0)
            {
                result.Add(new List<int>(path));
                return;
            }

            foreach (var item in new HashSet<int>(map.Keys))
            {
                int count = map[item];
                if (count == 1)
                {
                    map.Remove(item);
                }
                else
                {
                    map[item] = count - 1;
                }

                path.Add(item);
                Permutations(map, path, result);
                if (map.ContainsKey(item))
                {
                    map[item] = count;
                }
                else
                {
                    map.Add(item, count);
                }

                path.RemoveAt(path.Count - 1);
            }
        }

        private void PermutationsWithoutHashMap(int[] items,
                                  int i,
                                  List<int> path,
                                  List<List<int>> result
                                 )
        {
            if (i == items.Length)
            {
                result.Add(new List<int>(path));
                return;
            }
            HashSet<int> appeared = new HashSet<int>();

            for (int j = i; j < items.Length; ++j)
            {
                if (appeared.Add(items[j]))
                {

                    Swap(items, i, j);
                    path.Add(items[i]);
                    PermutationsWithoutHashMap(items, i + 1, path, result);
                    path.RemoveAt(path.Count - 1);
                    Swap(items, i, j);
                }
            }
        }

        private void PermutationsWithSwap(int[] items,
                                          int i,
                                          List<int> path,
                                          HashSet<List<int>> result)
        {
            if (i == items.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int j = i; j < items.Length; j++)
            {
                Swap(items, i, j);
                path.Add(items[i]);
                PermutationsWithSwap(items, i + 1, path, result);
                path.RemoveAt(path.Count - 1);
                Swap(items, i, j);
            }
        }
        private void Swap(int[] items, int i, int j)
        {
            int temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

    }

    class SequenceComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> seq1, IEnumerable<T> seq2)
        {
            return seq1.SequenceEqual(seq2);
        }

        public int GetHashCode(IEnumerable<T> seq)
        {
            int hash = 1234567;
            foreach (T elem in seq)
                hash = hash * 37 + elem.GetHashCode();
            return hash;
        }
    }

}
