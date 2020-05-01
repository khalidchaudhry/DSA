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

            PermutationsInPlace p = new PermutationsInPlace();
            char[] A = new char[] { 'a', 'b', 'c', 'd', 'e' };
            int[] P = new int[] { 4, 0, 1, 2, 3 };
            p.Permute(A, P);

            Console.WriteLine(string.Join(",", A));

            Console.ReadLine();
        }
    }
}
