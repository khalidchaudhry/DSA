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

            int[] arr = new int[] { 1, 5, 9, 10, 15, 20 };
            int[] arr1 = new int[] { 2, 3, 8, 13 };

            Merge m = new Merge();

            m.merge(arr,arr1);

           

            Console.ReadLine();
        }
    }
}
