using LeetCodeStrings.Easy;
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

            _541 ReverseString = new _541();
            string s = "abcdefg";
            int k = 2;
            Console.WriteLine(ReverseString.ReverseStr(s,k));

            Console.ReadLine();
        }
    }
}
