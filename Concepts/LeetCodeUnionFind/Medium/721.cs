using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeUnionFind.Medium
{
    public class _721
    {
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            Dictionary<string, string> owner = new Dictionary<string, string>();
            Dictionary<string, string> parents = new Dictionary<string, string>();
            Dictionary<string, SortedSet<string>> unions = new Dictionary<string, SortedSet<string>>();
            foreach (List<string> a in accounts)
            {
                for (int i = 1; i < a.Count; i++)
                {
                    parents[a[i]]= a[i];
                    owner[a[i]]= a[0];
                }
            }
            foreach (List<string> a in accounts)
            {
                string p = Find(a[1], parents);
                for (int i = 2; i < a.Count; i++)
                {
                    string key = Find(a[i], parents);
                    parents[key]= p;
                }
            }
            foreach (List<string> a in accounts)
            {
                string p = Find(a[1], parents);
                if (!unions.ContainsKey(p)) unions.Add(p, new SortedSet<string>());
                for (int i = 1; i < a.Count; i++)
                    unions[p].Add(a[i]);
            }

            List<IList<string>> res = new List<IList<string>>();
            foreach (string p in unions.Keys)
            {
                List<string> emails = new List<string>(unions[p]);
                
                emails.AddRange(unions[p]);
                emails.Insert(0, owner[p]);
                res.Add(emails);
            }
            return res;
        }
        private string Find(string s, Dictionary<string, string> p)
        {
            return p[s] == s ? s : Find(p[s], p);
        }


    }
}
