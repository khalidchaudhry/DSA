using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _935
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        int mod = (int)1e9 + 7;
        public int KnightDialer(int n)
        {

            Dictionary<(int, int), long> memo = new Dictionary<(int, int), long>();
            Initialize();
            long ans = 0;
            for (int i = 0; i <= 9; ++i)
            {
                ans = (ans + KnightDialer(i, n - 1, memo)) % mod;
            }
            return (int)ans;
        }

        private long KnightDialer(int start, int jumps, Dictionary<(int, int), long> memo)
        {

            
            if (jumps == 0)
            {
                return 1;
            }

            if (start == 5)
            {
                return 0;
            }

            if (memo.ContainsKey((start, jumps)))
            {
                return memo[(start, jumps)];
            }

            long total = 0;
            foreach (int neighbor in map[start])
            {
                total = (total + (KnightDialer(neighbor, jumps - 1, memo)) % mod) % mod;
            }

            return memo[(start, jumps)] = total;
        }

        private void Initialize()
        {
            map.Add(0, new List<int>() { 4, 6 });
            map.Add(1, new List<int>() { 6, 8 });
            map.Add(2, new List<int>() { 7, 9 });
            map.Add(3, new List<int>() { 4, 8 });
            map.Add(4, new List<int>() { 0, 3, 9 });
            map.Add(5, new List<int>());
            map.Add(6, new List<int>() { 0, 1, 7 });
            map.Add(7, new List<int>() { 2, 6 });
            map.Add(8, new List<int>() { 1, 3 });
            map.Add(9, new List<int>() { 2, 4 });
        }


    }
}
