using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _811
    {
        //Time Complexity: O(N), 
        // where N is the length of cpdomains, and assuming the length of cpdomains[i] is fixed.
        //  there can be only 3 subdomains at the most, as mentioned in question.
        //Space Complexity: O(N) the space used in our count.

        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            List<string> result = new List<string>();
            foreach (string cpDomain in cpdomains)
            {
                // First element count, second element domain
                string[] countAndDomain = cpDomain.Split(" ");
                int count = int.Parse(countAndDomain[0]);
                string domain = countAndDomain[1];
                // First add given domain
                AddUpdateMap(map, domain, count);

                // Add subdomains                               
                while (true)
                {
                    int indexOf = domain.IndexOf('.');
                    if (indexOf == -1)
                    {
                        break;
                    }

                    string subDomain = domain.Substring(indexOf + 1);
                    AddUpdateMap(map, subDomain, count);
                    domain = subDomain;
                }
            }

            foreach (var item in map)
            {
                result.Add($"{item.Value} {item.Key}");
            }

            return result;
        }

        private void AddUpdateMap(Dictionary<string, int> map, string key, int value)
        {
            if (!map.ContainsKey(key))
            {
                map.Add(key, value);
            }
            else
            {
                map[key] += value;
            }
        }
    }
}
