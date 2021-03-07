using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Medium
{
    class _241
    {
        public IList<int> DiffWaysToCompute(string input)
        {

            return DiffWaysToCompute(input, 0, input.Length - 1);

        }
        /// <summary>
        //! Same as 95
        //! Recursion With memoization 
        //! Time Complexity=O(n^5) = (n^2 states) * work per recursive call(n^3)
        //! Space Complexity=O(n)(recursion depth) + 2^n(storing result) +O(n^2) for memo
        /// <summary>
        public IList<int> DiffWaysToCompute0(string input)
        {
            Dictionary<(int, int), List<int>> memo = new Dictionary<(int, int), List<int>>();
            return DiffWaysToCompute0(input, 0, input.Length - 1, memo);

        }
        private List<int> DiffWaysToCompute0(string input, int s, int e, Dictionary<(int, int), List<int>> memo)  //! n^2 function states
        {
            int operand;
            if (int.TryParse(input.Substring(s, e - s + 1), out operand))
            {
                return new List<int>() { operand };
            }

            if (memo.ContainsKey((s, e)))
            {
                return memo[(s, e)];
            }

            List<int> result = new List<int>();
            for (int i = s; i <= e; ++i)  //!O(n)
            {
                if (IsOperator(input[i]))
                {
                    List<int> left = DiffWaysToCompute0(input, s, i - 1, memo);
                    List<int> right = DiffWaysToCompute0(input, i + 1, e, memo);
                    Combinations(input[i], left, right, result);  //! O(n^2)
                }
            }

            memo[(s, e)] = result;
            return memo[(s, e)];
        }



        //! Recursion(brute force)
        //! Time Complexity= 2^n (catalan split) * n^3
        //! Space Complexity=O(n)+2^n ==0(n) for recursion depth and 2^n for storing result
        private List<int> DiffWaysToCompute(string input, int s, int e)
        {
            int operand;
            if (int.TryParse(input.Substring(s, e - s + 1), out operand))
            {
                return new List<int>() { operand };
            }

            List<int> result = new List<int>();
            for (int i = s; i <= e; ++i)  //!O(n)
            {
                if (IsOperator(input[i]))
                {
                    List<int> left = DiffWaysToCompute(input, s, i - 1);
                    List<int> right = DiffWaysToCompute(input, i + 1, e);
                    Combinations(input[i], left, right, result); //!O(n^2)
                }
            }

            return result;
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*';
        }

        private void Combinations(char oper, List<int> left, List<int> right, List<int> result)
        {
            foreach (int l in left)
            {
                foreach (int r in right)
                {
                    if (oper == '+')
                    {
                        result.Add(l + r);
                    }
                    else if (oper == '-')
                    {
                        result.Add(l - r);
                    }
                    else if (oper == '*')
                    {
                        result.Add(l * r);
                    }
                }
            }
        }


    }
}
