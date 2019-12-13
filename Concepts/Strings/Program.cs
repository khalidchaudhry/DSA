using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            //RabinKarpSearch rks = new RabinKarpSearch();
            //Console.WriteLine(rks.PatternSearch("TusharRoy".ToCharArray(), "sharRoy".ToCharArray()));
            //var stringPermutations = new StringPermutation();
            //var result=stringPermutations.StringPermutations("ABCD");
            //foreach (var one in result)
            //{
            //    Console.WriteLine(one);            
            //}

            String str = "ca";
            PrintSubsequencesString.PrintSubSeq(str);
            Console.ReadLine();
        }


    }
}
