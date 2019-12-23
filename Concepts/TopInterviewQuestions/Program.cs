using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopInterviewQuestions.Easy;

namespace TopInterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            //FizzBuzProblem fb = new FizzBuzProblem();
            //var result=fb.FizzBuzz(15);

            //foreach (var a in result)
            //{
            //    Console.WriteLine(a);
            //}


            // First unique string
            ///Console.WriteLine(FirstUniqueCharacterInString.FirstUniqCharApproach2("LLLtcode"));

            //Console.WriteLine(SumOfTwoIntegers.GetSum(5,7));

            // Array intersection
            /*
            IntersectionOfArray intersectionOfArray = new IntersectionOfArray();
            int[] num1 =new int[] { 1, 2, 2, 1 };
            int[] num2 = new int[] { 2, 2 };
            */
            //var result=intersectionOfArray.Intersect(num1,num2);
            //var result = intersectionOfArray.Union(num1,num2);

            //var result = intersectionOfArray.Intersect2(num1,num2);
            //foreach (var one in result)
            //{
            //    Console.Write(one);
            //}


            //Reverse string 
            //_5 reverseString = new _5();
            //Char[] ch = new char[] { 'h', 'e', 'l', 'l', 'o' };
            //reverseString.ReverseString(ch);
            //foreach (var item in ch)
            //{
            //    Console.Write(item);
            //}

            //IS Power of Three
            //_6 powerOfThree = new _6();
            //Console.Write(powerOfThree.IsPowerOfThree(-3));

            //_283 moveZeros = new _283();
            //int[] arr =new int[] { 0,0};
            //moveZeros.MoveZeros(arr);
            //foreach (var item in arr)
            //{
            //    Console.Write(item);
            //}

            //_286 missingNumber = new _286();
            //int[] nums = new int[] {3, 1, 0};
            //Console.Write($"Missing number:{missingNumber.MissingNumber2(nums)}");

            //_242 anagram = new _242();
            //Console.Write(anagram.IsAnagram("aacc", "ccac"));

            //Palindrome linked list
            
            //1->2->2->1
            LinkedList list = new LinkedList();
            //list.head = new ListNode(1);
            //list.head.next = new ListNode(2);
            //list.head.next.next = new ListNode(2);
            //list.head.next.next = new ListNode(1);
            
            //1->2
            list.head = new ListNode(1);
            list.head.next = new ListNode(2);
            //_234 palindrome = new _234();
            //Console.WriteLine(palindrome.IsPalindrome(list.head));

            _204 primesCount = new _204();

            Console.WriteLine(primesCount.CountPrimes(10));


            Console.Read();

        }
    }
}
