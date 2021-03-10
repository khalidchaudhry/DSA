using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeUnionFind.Medium
{
    public class _737
    {
        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, IList<IList<string>> pairs)
        {

            int n1 = words1.Length;
            int n2 = words2.Length;
            if (n1 != n2) return false;

            UF uf = new UF(pairs.Count * 2);

            Dictionary<string, int> map = new Dictionary<string, int>();

            int idx = 0;
            foreach (List<string> pair in pairs)
            {
                foreach (string word in pair)
                {
                    if (!map.ContainsKey(word))
                    {
                        map.Add(word, idx++);
                    }
                }
                uf.Union(map[pair[0]], map[pair[1]]);
            }

            for (int i = 0; i < n1; ++i)
            {
                string w1 = words1[i];
                string w2 = words2[i];
                if (w1 == w2)
                {
                    continue;
                }

                if (!map.ContainsKey(w1) || !map.ContainsKey(w2))
                {
                    return false;
                }
                int w1Index = map[w1];
                int w2Index = map[w2];
                int u = uf.FindSet(w1Index);
                int v = uf.FindSet(w2Index);
                if (u != v)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
