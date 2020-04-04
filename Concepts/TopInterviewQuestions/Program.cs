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

            _198 RObHouse = new _198();
            int[] nums = new int[] { 3, 1, 2, 5, 4, 2 };
            Console.Write(RObHouse.Rob(nums));

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
            //minStack.Push(0);
            minStack.Push(1);
            minStack.Push(0);
            minStack.GetMin(); 
            //minStack.Pop();
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

            //_53 KadanesAlgorithm = new _53();
            ///int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //Console.Write(KadanesAlgorithm.MaxSubArray(nums));


            //_7 ReverseInteger = new _7();
            //Console.Write(ReverseInteger.Reverse2(-120));

            //_1 twoSum = new _1();
            //int[] nums = new int[] { 2, 7, 11, 15 };
            //int target = 9;
            //var result=twoSum.TwoSum(nums,9);

            //foreach (var item in result)
            //{
            //    Console.Write(item);
            //}

            //_88 MergeArray = new _88();
            //int[] nums1 = new int[] {2,0};
            //int[] nums2 = new int[] { 1 };
            //MergeArray.Merge(nums1,1,nums2,1);

            //_26 Duplicates = new _26();
            //int[] nums = new int[] { 1, 1, 2 };
            //Duplicates.RemoveDuplicates(nums);

            //_20 Parenthesis = new _20();

            //Console.Write(Parenthesis.IsValid("(])"));


            //_14 longestCommonPrefix = new _14();
            //string[] strs = new string[] {"flower", "flow", "flight" };

            //string[] strs = new string[] { "dog", "racecar", "car" };

            //Console.Write(longestCommonPrefix.LongestCommonPrefix(strs));

            //_21 MergeTwoLists = new _21();
            //0->9->1->2->4
            //LinkedList listA = new LinkedList();
            //listA.head = new ListNode(1);
            //listA.head.next = new ListNode(2);
            //listA.head.next.next = new ListNode(3);
            //listA.head.next.next.next = new ListNode(4);

            //1->3->4
            //LinkedList listB = new LinkedList();
            //listB.head = new ListNode(1);
            //listB.head.next = new ListNode(3);
            //listB.head.next.next = new ListNode(4);

            //MergeTwoLists.MergeTwoLists2(listA.head, listB.head);

            //_66 PlusOne = new _66();
            //PlusOne.PlusOne();

            //_108 ArrayToBST = new _108();
            //int[] arr = new int[] { -10, -3, 0, 5, 9 };
            //var result=ArrayToBST.SortedArrayToBST(arr);

            //_28 Strstr = new _28();

            //Console.Write(Strstr.StrStr("mississippi", "issip"));
            //_118 PascalTriangle = new _118();
            //PascalTriangle.Generate(5);
            //_101 SymmetricTree = new _101();

            /*
                1
               / \
              2   2
             / \ / \
            3  4 4  3
            */

            //var t = new TreeNode(1);

            //t.left = new TreeNode(2);
            //t.left.left = new TreeNode(3);
            //t.left.right = new TreeNode(4);


            //t.right = new TreeNode(2);
            //t.right.left = new TreeNode(4);
            //t.right.right = new TreeNode(3);

            //SymmetricTree.IsSymmetric(t);            

            //_13 romanToInteger = new _13();

            //Console.Write(romanToInteger.RomanToInt("MCMXCIV"));

            //_38 CountAndSay = new _38();
            //Console.Write(CountAndSay.CountAndSay(6));

            //_70 ClimbingStairs = new _70();

            //Console.Write(ClimbingStairs.ClimbStairs(44));

            //_122 Profit = new _122();
            //int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            //int[] prices = new int[] { 1,2,3,4,5 };
            //Console.Write(Profit.MaxProfit(prices));

            /*
           _226 InvertBinaryTree = new _226();

            /*
                1
               / \
              2   2
             / \ / \
            3  4 5  9
            */
            /*
            var t = new TreeNode(1);

            t.left = new TreeNode(2);
            t.left.left = new TreeNode(3);
            t.left.right = new TreeNode(4);


            t.right = new TreeNode(2);
            t.right.left = new TreeNode(5);
            t.right.right = new TreeNode(9);

            InvertBinaryTree.InvertTree(t);
            */
            //int[] nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1};
            //_448 _448 = new _448();
            //_448.FindDisappearedNumbers2(nums);





            /*
               1
              / \
             3   2
            / 
            5
            */


            //var t = new TreeNode(1);

            ///t.left = new TreeNode(3);
            //t.left.left = new TreeNode(5);

            //t.right = new TreeNode(2);

            /*
                2
               / \
              1   3
              \    \
               4    5
             
             */
            //var t2 = new TreeNode(2);

            //t2.left = new TreeNode(1);
            //t2.left.right = new TreeNode(4);

            //t2.right = new TreeNode(3);
            //t2.right.right = new TreeNode(7);



            //_617 MergeTrees =new _617();
            //var treeNode=MergeTrees.MergeTrees(t,t2);

            /*
                    1
                   / \
                  2   3
                 / \     
                4   5
           */


            //_543 TreeDiameter = new _543();


            //var t = new TreeNode(1);

            //t.left = new TreeNode(2);
            //t.left.left = new TreeNode(4);
            //t.left.right = new TreeNode(5);

            //t.right = new TreeNode(3);

            //Console.Write(TreeDiameter.DiameterOfBinaryTree(t));

            /*
                  1
                 / \
                2   3
               / \     
              4   5
             
            
         */

            //var t = new TreeNode(7);

            ////t.left = new TreeNode(2);
            ////t.left.left = new TreeNode(4);
            ////t.left.right = new TreeNode(5);

            ////t.right = new TreeNode(3);

            //_437 pathSum = new _437();

            //pathSum.PathSum(t, 7);


            Console.Read();

        }
    }
}
