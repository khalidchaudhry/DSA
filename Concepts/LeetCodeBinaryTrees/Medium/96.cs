using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _96
    {
        /*
        
        G(n) = the summation from 1 to n of F(i, n)
        F(i,n): the number of unique BST, where the number i is served as the root of 
                BST (1 is less than or equal to i which is less than or equal to n)
        F(i, n) = G(i - 1) * G(n - i)
        */

        public int NumTrees(int input)
        {
            int[] G = new int[input + 1];
            G[0] = 1;
            G[1] = 1;
            // strting n from 2 because we already know values at index 0 and index 1
            for (int n = 2; n <= input; n++)
            {      // starting fron 1 because we need to go back to previous index.
                   // 0 will casue out of bound exception 
                for (int i = 1; i <= n; i++)
                {
                    // G(n) = the summation from 1 to n of F(i, n)
                    G[n]+= G[i - 1] * G[n - i];
                }
            }
            return G[input];
        }
    }
}
