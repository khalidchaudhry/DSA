using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class PrintSubsequencesString
    {
        static void printSubSeqRec(String str, int n,
                            int index, String curr)
        {
            // base case  
            if (index == n)
            {
                return;
            }
            Console.WriteLine(curr);
            for (int i = index + 1; i < n; i++)
            {
                curr += str[i];
                printSubSeqRec(str, n, i, curr);

                // backtracking  
                curr = curr.Substring(0, curr.Length - 1);
            }
        }

        // Generates power set in   
        // lexicographic order.  
        public static void PrintSubSeq(String str)
        {
            int index = -1;
            String curr = "";

            printSubSeqRec(str, str.Length, index, curr);
        }



    }
}
