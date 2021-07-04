using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _935
    {
        Dictionary<int, List<int>> _numTargets = new Dictionary<int, List<int>>();
        int _mod = (int)1e9 + 7;
        public int KnightDialer(int n)
        {

            Dictionary<(int, int), long> memo = new Dictionary<(int, int), long>();
            Initialize();
            long ans = 0;
            for (int i = 0; i <= 9; ++i)
            {
                ans = (ans + KnightDialer(i, 0, n - 1, memo)) % _mod;
            }
            return (int)ans;
        }

        private long KnightDialer(int start, int jumps, int target, Dictionary<(int, int), long> memo)
        {
            if (jumps == target)
                return 1;
            if (memo.ContainsKey((start, jumps)))
            {
                return memo[(start, jumps)];
            }
            long total = 0;
            foreach (int dest in _numTargets[start])
            {
                total = (total + KnightDialer(dest, jumps + 1, target, memo) % _mod) % _mod;
            }
            return memo[(start, jumps)] = total;
        }

        private void Initialize()
        {
            _numTargets.Add(0, new List<int>() { 4, 6 });
            _numTargets.Add(1, new List<int>() { 6, 8 });
            _numTargets.Add(2, new List<int>() { 7, 9 });
            _numTargets.Add(3, new List<int>() { 4, 8 });
            _numTargets.Add(4, new List<int>() { 0, 3, 9 });
            _numTargets.Add(5, new List<int>());
            _numTargets.Add(6, new List<int>() { 0, 1, 7 });
            _numTargets.Add(7, new List<int>() { 2, 6 });
            _numTargets.Add(8, new List<int>() { 1, 3 });
            _numTargets.Add(9, new List<int>() { 2, 4 });
        }


    }
}
