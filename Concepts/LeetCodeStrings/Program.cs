using LeetCodeStrings.Medium;
using System;

namespace LeetCodeStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "11";
            //string b = "11";
            //_67 AddBinary = new _67();
            //string answer=AddBinary.AddBinary2(a, b);


            //_1108 IPAddress = new _1108();
            //Console.WriteLine(IPAddress.DefangIPaddr2("255.100.50.0"));

            /**************929.Unique Email Addresses***********************/

            //_929 email = new _929();
            //string[] emails = new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" };
            ////string[] emails = new string[] { "testemail@leetcode.com", "testemail1@leetcode.com", "testemail+david@lee.tcode.com" };
            //email.NumUniqueEmails2(emails);

            /******************804.Unique Morse Code Words*************************/

            //string[] words = new string[] { "gin", "zen", "gig", "msg" };
            //_804 Unique = new _804();

            //Unique.UniqueMorseRepresentations(words);

            /******************657.Robot Return to Origin*******************/

            //_657 Robot = new _657();
            //Robot.JudgeCircle("LL");

            /*****************557.Reverse Words in a String III**************/
            //_557 reverseWords = new _557();

            //Console.WriteLine(reverseWords.ReverseWords2("Let's take LeetCode contest"));

            //415.Add Strings

            //_415 AddStrings = new _415();

            //Console.WriteLine(AddStrings.AddStrings("0","0"));


            /*****************709.To Lower Case*****************************/
            //_709 ToLower = new _709();
            //Console.WriteLine(ToLower.ToLowerCase("al&phaBET"));

            /*****************383.Ransom Note*****************************/
            //_383 RansomNote = new _383();
            //string ransomNote = "fffbfgffff";
            //string magazine = "effjfggbffjdgbjjhhdegh";
            //var result = RansomNote.CanConstruct2(ransomNote, magazine);

            /*****************345.Reverse Vowels of a String*****************************/
            //_345 ReverseVowels = new _345();
            //string s = "aA";
            //Console.WriteLine(ReverseVowels.ReverseVowels(s));

            //_541 ReverseString = new _541();
            //string s = "abcdefg";
            //int k = 2;
            //Console.WriteLine(ReverseString.ReverseStr(s,k));


            //_13 romanToInteger = new _13();

            //romanToInteger.RomanToInt("IX");

            //string s = "PAYPALISHIRING";

            //_6 zigZagConversion = new _6();

            //Console.WriteLine(zigZagConversion.Convert(s,3));

            //_3 longestSubstring = new _3();
            //string s = "dvdf";
            //Console.Write(longestSubstring.LengthOfLongestSubstring0(s));

            //_937 ReorderLogs = new _937();
            //string[] logs = new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };
            //ReorderLogs.ReorderLogFiles2(logs);

            //string s = "aba";

            //_5 LongestPalindrome = new _5();

            //var result = LongestPalindrome.LongestPalindrome0(s);

            //_12 IntegerToRoman = new _12();

            //var result=IntegerToRoman.IntToRoman(101);

            //_22 GenerateParenthesis = new _22();

            //var result=GenerateParenthesis.GenerateParenthesis(2);

            //_151 Reverse = new _151();
            //string s = "a good   example";

            //var result=Reverse.ReverseWords(s);

            ////_17 LetterCombinations = new _17();
            //var result=LetterCombinations.LetterCombinations2("23");

            //_49 GroupAnagrams = new _49();
            //string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            //GroupAnagrams.GroupAnagrams(strs);

            //_43 Multiplier = new _43();

            //string nums1 = "9133";
            //string nums2 = "0";
            //var result=Multiplier.Multiply0(nums1,nums2);


            //_8 Atoi = new _8();
            //string str = "-5-";
            //var result=Atoi.MyAtoi1(str);

            //_609 Duplicate = new _609();
            ////string[] paths = new string[]
            ////{
            ////    "root/a 1.txt(abcd) 2.txt(efgh)",
            ////    "root/c 3.txt(abcd)",
            ////    "root/c/d 4.txt(efgh)",
            ////    "root 4.txt(efgh)"
            ////};
            //string[] paths = new string[]
            //{
            //    "root/a 1.txt(abcd) 2.txt(efsfgh)",
            //    "root/c 3.txt(abdfcd)",
            //    "root/c/d 4.txt(efggdfh)"
            //};

            //Duplicate.FindDuplicate(paths);

            //_91 DecodeWays = new _91();

            //DecodeWays.NumDecodings("226");

            //_93 RestoreIpAddress = new _93();

            //RestoreIpAddress.RestoreIpAddresses("25525511135");

            string s = "/a//b////c/d//././/..";

            _71 SimplifyPath = new _71();

            var ans=SimplifyPath.SimplifyPath(s);



            Console.ReadLine();
        }
    }
}
