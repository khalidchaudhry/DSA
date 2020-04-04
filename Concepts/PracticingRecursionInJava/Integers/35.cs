using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    public class _35
    {
        public List<string> PowerSet(int n)
        {
            List<string> result, oldResult;
            string current;

            result = new List<string>();
            if (n == 0)
            {
                result.Add("0");
            }
            else
            {
                oldResult = PowerSet(n-1);
                foreach (string oldCurrent in oldResult)
                {
                    result.Add(oldCurrent);
                }
                foreach (string oldCurrent in oldResult)
                {
                    if (oldCurrent != "0")
                    {
                        result.Add($"{oldCurrent},{n}");
                    }
                    else
                    {
                        result.Add($"{n}");
                    }
                }
            }
            return result;
        }

    }
}
