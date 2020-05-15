using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[] arr = new int[4] { 4,5,2,25};
            //NGE.PrintNGE(arr);

            //int[] arr = new int[] { 1, 5, 9, 10, 15, 20 };
            //int[] arr1 = new int[] { 2, 3, 8, 13 };

            //Merge m = new Merge();

            //m.merge(arr,arr1);

            ///*******************************************************/
            ///******************************************************/

            //PermutationsInPlace p = new PermutationsInPlace();
            //char[] A = new char[] { 'a', 'b', 'c', 'd', 'e' };
            //int[] P = new int[] { 4, 0, 1, 2, 3 };
            //p.Permute(A, P);

            //Console.WriteLine(string.Join(",", A));

            //int[,] matrix = new int[,]
            //{
            //    {1, 2, 3, 4},
            //    {5, 6, 7, 8},
            //    {9, 10, 11, 12},
            //    {13, 14, 15, 16}

            //};

            //    char[][] matrix = new char[3][]
            //{
            //        new char[]{'A', 'B', 'C','E'},
            //        new char[]{'S', 'F', 'C','S'},
            //        new char[]{'A', 'D', 'E', 'F'}
            //};
            //    BFSOn2DArray BFSOn2DArray = new BFSOn2DArray();
            //    BFSOn2DArray.BFS2(matrix);

            // Matrix rollout 
            //int[][] matrix = new int[3][]
            //{
            //    new int[]{1, 2, 3},
            //    new int[]{4, 5, 6},
            //    new int[]{7, 8, 9},
            //    ///new int[]{13, 14, 15}
            //};

            //int[][] matrix = new int[3][]
            //{
            //   new int[]{1, 2, 3, 4 },
            //   new int[]{5, 6, 7, 8 },
            //   new int[]{9, 10, 11, 12}
            //    ///new int[]{13, 14, 15}
            //};


            //MatrixRollOut Spiral = new MatrixRollOut();

            //var result = Spiral.MatricRollOut(matrix);

            //char[][] matrix = new char[4][] {
            //    new char[]{'S', '0', '1', '1'},
            //    new char[]{'1', '1', '0', '1'},
            //    new char[]{'0', '1', '1', '1'},
            //    new char[]{'1', '0', 'D', '1'}
            //};


            char[][] matrix = new char[4][] {
                new char[]{'S', '0', '1', 'D'},
                new char[]{'1', '0', '1', '0'},
                new char[]{'1', '0', '1', '0'},
                new char[]{'1', '1', '1', '0'}
            };


            var result = ShortestPathin2DArray.PathExists(matrix);



            Console.ReadLine();
        }
    }
}
