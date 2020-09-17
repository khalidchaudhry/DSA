using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _96
    {
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
            T[0] = 1;
            T[1] = 1;
            // strting n from 2 because we already know values at index 0 and index 1
            for (int i = 2; i <= input; i++)
            {      // starting fron 1 because we need to go back to previous index.
                   // 0 will casue out of bound exception 
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
                    T[i] += T[j] * T[i - j - 1];
                }
            }
            return T[input];
        }
    }
}
