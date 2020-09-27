using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRandom.Medium._398
{
    public class _398
    {
        public static void _398Main()
        {
            int[] nums = new int[] { 1 };
            Solution sol = new Solution(nums);
            var ans = sol.Pick(1);
            Console.ReadLine();
        }



    }

    /// <summary>
    // https://www.youtube.com/watch?v=oyewBKxHYGU
    /// </summary>
    public class Solution
    {
        Dictionary<int, Node> map;
        public Solution(int[] nums)
        {
            map = new Dictionary<int, Node>();

            for (int i = 0; i < nums.Length; ++i)
            {
                if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]].Indexes.Add(i);
                }
                else
                {
                    Node n = new Node();
                    n.Indexes.Add(i);
                    map[nums[i]] = n;
                }
            }
        }

        public int Pick(int target)
        {
            //if (map[target].Start >= map[target].Indexes.Count)
            //{
            //    map[target].Start = 0;
            //}
            ////!Incrementing it for next call
            ////map[target].CurrentIndex++;
            //return map[target].Indexes[map[target].Start++];
            //
            return map[target].GetRoundRobin();
        }
    }

    public class Node
    {
        public List<int> Indexes { set; get; }

        public int Start;

        Random rand;
        public Node()
        {
            Indexes = new List<int>();
            rand = new Random();
        }

        public int GetRoundRobin()
        {    //!round robin
            if (Start >= Indexes.Count)
            {
                Start = 0;
            }

            int ret = Indexes[Start++];

            return ret;
        }
        public int GetRandom()
        {
            if (Start >= Indexes.Count)
            {
                Start = 0;
            }
            int idx = rand.Next(Start, Indexes.Count);
            int ret = Indexes[idx];
            Indexes[idx] = Indexes[Start];
            Indexes[Start++] = ret;            
            return ret;
        }
    }
}
