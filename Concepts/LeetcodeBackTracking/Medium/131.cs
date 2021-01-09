using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _131
    {

       

        //  # <image url="$(SolutionDir)\Images\131.jpg"  scale="0.4"/>

        public IList<IList<string>> Partition(string s)
        {
            List<IList<string>> result = new List<IList<string>>();
            Partition(s, 0, new List<string>(), result);
            return result;
        }
        private void Partition(string s, int start, List<string> path, List<IList<string>> result)
        {
            if (start == s.Length)
            {
                result.Add(new List<string>(path));
                return;
            }

            for (int i = start; i < s.Length; ++i)
            {
                if (!IsPalindrome(s, start, i))
                    continue;

                path.Add(s.Substring(start, i - start + 1));
                Partition(s, i + 1, path, result);
                path.RemoveAt(path.Count - 1);
            }

        }
        private bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                    return false;

                ++start;
                --end;
            }

            return true;
        }



    }
}
