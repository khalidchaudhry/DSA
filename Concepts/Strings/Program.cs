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

            //String S = "ADOBBECODEBANC";
            //string T = "ABBC";

            //MinimumWindowSubstring Minimum = new MinimumWindowSubstring();
            //var ans=Minimum.MinWindow0(S,T);

            //FindAllAnagrams All = new FindAllAnagrams();

            //var result=All.FindAnagrams("cbaebabacd", "abc");

            //FindSubstring substring = new FindSubstring();

            //string s = "barfoothefoobarman";
            //List<string> words = new List<string> { "foo", "bar" };

            //var ans=substring.SubstringWithAllConcatenateWords(s,words);

            LongestSubstringwithAtMostTwoDistinctCharacters longest = new LongestSubstringwithAtMostTwoDistinctCharacters();


            longest.LengthOfLongestSubstringTwoDistinct2("leeeeeeeetcooooooooode");

            Console.ReadLine();
        }


    }
}
