using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _96
    {


        /// <summary>
        //! Recursion with memoization
        //!Time Complexity: O(n^2)==> Our possible recursive function states are n and we are performing n units of work in each recursive call hence total time complexity=O(n^2)
        /// </summary>
        public int NumTrees0(int n)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return NumTrees(n, memo);
        }

        private int NumTrees(int n, Dictionary<int, int> memo)
        {
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            int numTrees = 0;
            for (int i = 1; i <= n; ++i)
            {
                int left = NumTrees(i - 1, memo);
                int right = NumTrees(n - i, memo);
                numTrees += left * right;
            }
            memo[n] = numTrees;
            return memo[n];
        }
        /// <summary>
        //! Recursion brute force 
        //! O(2^n)
        /// </summary>
        public int NumTrees1(int n)
        {
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;

            int numTrees = 0;
            for (int i = 1; i <= n; ++i)
            {
                int left = NumTrees1(i - 1);
                int right = NumTrees1(n - i);
                numTrees += left * right;
            }
            return numTrees;
        }

        /*
        Timecomplexity : O(n^2)
        Spece complexity: O(n^2)

        G(n) = the summation from 1 to n of F(i, n)
        F(i,n): the number of unique BST, where the number i is served as the root of 
                BST (1 is less than or equal to i which is less than or equal to n)
        F(i, n) = G(i - 1) * G(n - i)
        */

        public int NumTrees(int input)
        {
            int[] T = new int[input + 1];
            //! for tree with null node , there is one unique BST.  
            T[0] = 1;
            T[1] = 1;
            // strting n from 2 because we already know values at index 0 and index 1
            for (int i = 2; i <= input; i++)
            {      
                for (int j = 0; j < i; j++)
                {
                    // G(n) = the summation from 1 to n of F(i, n)
                    //! left subtree possibilities * right subtree possibilities 
                    //! Catalan product
                    /*
                            [1,2,3,4,5]
                            |                          
                            
                            When 1 is the root =T[0]*T[4] because there is no element on left and 4 elements on right side
                            When 2 is the root =T[1]*T[3] because there is 1 element on left and 3 elements on right side
                            When 1 is the root =T[2]*T[2] because there is 2 element on left and 2 elements on right side
                            When 1 is the root =T[3]*T[1] because there is 3 element on left and 1 elements on right side
                            When 1 is the root =T[4]      because there is 4 element on left and 0 elements on right side
                          
                            For i=5
                            T[5]=T[0]*T[4]+ //when j=0
                                 T[1]*T[3]+ //when j=1
                                 T[2]*T[2]+ //when j=2
                                 T[3]*T[1]+ //when j=3
                                 T[4]      // when j=4                                        
                      */
                    //! T[i] represents the total possiblities for i nodes e.g. i=2 we have two possibilities
                    //! T[j] represents the total possiblities we have on left side of i and right side of i.    
                    T[i] += T[j] * T[i - j - 1];
                }
            }
            return T[input];
        }
    }
}
