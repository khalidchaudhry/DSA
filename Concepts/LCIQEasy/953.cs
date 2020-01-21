using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCIQEasy
{
    class _953
    {

        public bool IsAlienSorted(string[] words, string order)
        {
            Dictionary<Char, int> aphabetsOrder = new Dictionary<char, int>();

            for (int i = 0; i < order.Length; i++)
            {
                aphabetsOrder.Add(order[i],i);
            }

            bool alienSorted = true;
            for (int i = 0; i < words.Length-1; i++)
            {
                alienSorted = true;
                string word1 = words[i];
                string word2 = words[i+1];
                int j = 0, k = 0,common=0;
                while (j < word1.Length && k < word2.Length)
                {
                    if (aphabetsOrder[word1[j]] < aphabetsOrder[word2[k]])
                    {
                        break;
                    }

                    if (aphabetsOrder[word1[j]] > aphabetsOrder[word2[k]])
                    {
                        alienSorted = false;
                        break;
                    }
                    else
                    {
                        ++common;
                    }

                    if (word1.Length > common)
                    {
                        alienSorted = false;
                    }
                    ++j;
                    ++k;
                }

                if (!alienSorted)
                {
                    break;
                }
            }


            return alienSorted;

        }

    }
}
