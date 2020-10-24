using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    public class _311
    {
        public static void _311Main()
        {
            int[][] A = new int[2][]
            {
                new int[]{1,0,0 },
                new int[]{-1,0,3 },
            };

            int[][] B = new int[3][]
            {
                new int[]{7,0,0 },
                new int[]{0,0,0 },
                new int[]{0,0,1 },
            };
            //int[][] A = new int[1][]
            //{
            //    new int[]{1,-5},

            //};

            //int[][] B = new int[2][]
            //{
            //    new int[]{12 },
            //    new int[]{-1}             
            //};
            _311 SparseMultiplication = new _311();
            var ans = SparseMultiplication.Multiply1(A, B);
            Console.ReadLine();

        }
        /// <summary>
        /// https://leetcode.com/problems/sparse-matrix-multiplication/discuss/76154/Easiest-JAVA-solution
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[][] Multiply1(int[][] A, int[][] B)
        {
            //!Product of A.B matrix must have same number of rows as the first matrix and same number of columns as the second matrix
            int[][] AB = new int[A.Length][];

            int r1 = A.Length;
            int c1 = A[0].Length;
            int r2 = B.Length;
            int c2 = B[0].Length;

            for (int i = 0; i < AB.Length; ++i)
            {
                AB[i] = new int[c2];
            }

            //First create a map based on the first matrix
            //!Key will be the row and value will be the sequence of (column-number, value) pairs of the nonzero values in the row.
            Dictionary<int, List<(int Column, int Value)>> map = new Dictionary<int, List<(int Column, int Value)>>();
            for (int i = 0; i < r1; ++i)
            {
                for (int j = 0; j < c1; ++j)
                {
                    if (A[i][j] != 0)
                    {
                        if (map.ContainsKey(i))
                        {
                            map[i].Add((j, A[i][j]));
                        }
                        else
                        {
                            List<(int Column, int Value)> lst = new List<(int Column, int Value)>();
                            lst.Add((j, A[i][j]));
                            map.Add(i, lst);
                        }
                    }
                }
            }

            //Multiply map with B.
            for (int i = 0; i < r1; ++i)
            {
                if (map.ContainsKey(i))
                {
                    List<(int Column, int value)> lst = map[i];

                    foreach ((int ColumnA, int valueA) in lst)
                    {   // get col number from the list entry and multiply it with the respective row in
                        // second matrix
                        for (int j = 0; j < c2; ++j)
                        {
                            int valueB = B[ColumnA][j];
                            AB[i][j] += valueA * valueB;
                        }
                    }
                }
            }

            return AB;
        }


        /// <summary>
        /// https://www.java67.com/2016/10/how-to-multiply-two-matrices-in-java.html
        //! The number of columns of the first matrix must be equal to the number of rows of the second matrix.  
        //! The product matrix will have the same number of rows as the first matrix, and the same number of columns as the second matrix.
        //! Below  method does not consider that matrix is sparse 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[][] Multiply2(int[][] A, int[][] B)
        {
            //!Product of A.B matrix must have same number of rows as the first matrix and same number of columns as the second matrix
            int[][] AB = new int[A.Length][];

            int r1 = A.Length;
            int c1 = A[0].Length;
            int r2 = B.Length;
            int c2 = B[0].Length;

            for (int i = 0; i < AB.Length; ++i)
            {
                AB[i] = new int[c2];
            }


            for (int i = 0; i < r1; ++i)
            {
                for (int j = 0; j < c2; ++j)
                {

                    int result = 0;
                    for (int k = 0; k < c1; ++k)
                    {
                        result += A[i][k] * B[k][j];
                    }

                    AB[i][j] = result;


                }
            }

            return AB;
        }


    }
}
