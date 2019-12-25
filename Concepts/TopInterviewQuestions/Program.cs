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
            // LinkedList list = new LinkedList();
            //list.head = new ListNode(1);
            //list.head.next = new ListNode(2);
            //list.head.next.next = new ListNode(2);
            //list.head.next.next = new ListNode(1);

            //1->2
            //list.head = new ListNode(1);
            //list.head.next = new ListNode(2);
            //_234 palindrome = new _234();
            //Console.WriteLine(palindrome.IsPalindrome(list.head));

            //_204 primesCount = new _204();

            //Console.WriteLine(primesCount.CountPrimes(10));

            //_202 happyNumber = new _202();
            //Console.Write(happyNumber.IsHappy(19));

            // _198 RObHouse = new _198();
            // int[] nums = new int[] { 2, 7, 9, 3, 1 };
            // Console.Write(RObHouse.Rob(nums));
            //_191 hammingWeight = new _191();

            //Console.Write(hammingWeight.HammingWeight(11));
            //_190 reverseBits = new _190();
            //Console.Write(reverseBits.reverseBits(0));

            //_189 rotateArray = new _189();
            //int[] nums = new int[] { -1, -100, 3, 99 };
            //rotateArray.Rotate2(nums,5);

            //foreach (var item in nums)
            //{
            //    Console.Write(item);
            //}

            //_172 TrailingZeros = new _172();

            //Console.Write(TrailingZeros.TrailingZeroes(30));

            //_171 number = new _171();
            //Console.Write(number.TitleToNumber("ZY"));
            //int[] nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            //_169 MajorityElement = new _169();
            //Console.Write(MajorityElement.MajorityElement2(nums));
            /*
            _160 linkedList = new _160();

            //intersectionNode
            ListNode intersectionNode = new ListNode(2);

            //0->9->1->2->4
             LinkedList listA = new LinkedList();
            listA.head = new ListNode(0);
            listA.head.next = new ListNode(9);
            listA.head.next.next = new ListNode(1);
            listA.head.next.next.next = intersectionNode;
            listA.head.next.next.next.next = new ListNode(4);

            //3->2->4
            LinkedList listB = new LinkedList();
            listB.head = new ListNode(3);
            listB.head.next = intersectionNode;
            listB.head.next.next = new ListNode(4);
 

            //linkedList.getIntersectionNode(listA.head,listB.head);
            */
            //["MinStack","push","push","push","getMin","pop","getMin"]
            //[[],[0],[1],[0],[],[],[]]

            /*
            MinStack minStack = new MinStack();
            //minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(1);
            minStack.Push(0);
            minStack.GetMin(); 
            minStack.Pop();
            minStack.Top(); 
            minStack.GetMin(); 
            */

            //_141 DetectCycle = new _141();
            //0->9->1->9
            //ListNode cycleNode = new ListNode(9);
            //LinkedList listA = new LinkedList();
            //listA.head = new ListNode(0);
            //listA.head.next = cycleNode;
            //listA.head.next.next = new ListNode(1);
            //listA.head.next.next.next = cycleNode;

            //0-->null
            //LinkedList listA = new LinkedList();
            //SlistA.head = new ListNode(0);
            //Console.Write(DetectCycle.HasCycle2(listA.head));

            //_136 SingleNumber = new _136();
            //int[] nums = new int[] { 4, 1, 2, 1, 2 };
            //Console.Write(SingleNumber.SingleNumber(nums));

            //_125 Palindrome = new _125();
            //string s = "A man, a plan, a canal: Panama";
            //Console.Write(Palindrome.IsPalindrome2(s));

            // _121 MaxProfit = new _121();
            //int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            //int[] prices = new int[] { 7, 6, 4, 3, 1 } ;
            //int[] prices = new int[] { 1, 2 };
            //int[] prices = new int[] { 2,4,1};
            //Console.Write(MaxProfit.MaxProfit(prices));

            _53 KadanesAlgorithm = new _53();
            int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Console.Write(KadanesAlgorithm.MaxSubArray(nums));

            Console.Read();

        }
    }
}
