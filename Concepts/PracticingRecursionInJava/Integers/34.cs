using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    public class _34
    {

        public List<string> Permutation(int n)
        {
            if (n == 0)
            {
                return new List<string>() { };
            }
            if (n == 1)
            {
                return new List<string>() { "1" };
            }

            List<string> lst = new List<string>();
            lst = Permutation(n - 1);
            lst.Add($"{n}");
            return lst;
        }
        public List<string> Permutation2(int n)
        {
            List<string> result = new List<string>();
            List<string> oldResult = new List<string>();
            string current;

            if (n == 1)
            {
                result.Add("1");
                return result;
            }
            else
            {
                oldResult = Permutation2(n - 1);

                foreach (string oldCurrent in oldResult)
                {
                    result.Add(n + oldCurrent);
                    for (int j = 0; j < n - 1; j++)

                    {
                        current = oldCurrent.MySubString(0,j+1)+ n + oldCurrent.MySubString(j + 1, n - 1);
                        result.Add(current);
                    }
                }
                return result;
            }
        }
    }
    public static partial class MyExtensions
    {
        public static string MySubString(this string s, int start, int end)
        {
            return s.Substring(start, end - start);
        }
    }
}
