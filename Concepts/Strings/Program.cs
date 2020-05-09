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
            //var result=stringPermutations.StringPermutations("abc");
            //foreach (var one in result)
            //{
            //    Console.WriteLine(one);            
            //}

            //String str = "dedededca";
            ////PrintSubsequencesString.PrintSubSeq(str);
            ////Console.WriteLine(SortCharactersInString.SortCharacters(str));
            //AllSubStrings.AllSubstrings("abc");

            String S = "ADOBECODEBANC";
            string T = "ABC";

            MinimumWindowSubstring Minimum = new MinimumWindowSubstring();
            var ans=Minimum.MinWindow(S,T);


            Console.ReadLine();
        }


    }
}
