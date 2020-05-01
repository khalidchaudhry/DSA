using PracticingRecursionInJava.Integers;
using System;
using System.Collections.Generic;

namespace PracticingRecursionInJava
{
    class Program
    {
        static void Main(string[] args)
        {
            //_1 PrintHello = new _1();
            //PrintHello.PrintHelloNTimes(1);

            //_2 Print1toN = new _2();
            //Print1toN.Print1ToN(5);

            //_3 PrintNto1 = new _3();
            //PrintNto1.PrintNto1(5);

            //_4 Power1 = new _4();

            //Console.WriteLine(Power1.Power1(5,0));

            //_5 NumberOfDigits = new _5();

            //Console.WriteLine(NumberOfDigits.NumberOfDigits(123456));
            //_6 NContainsK = new _6();

            //Console.WriteLine(NContainsK.NContainsK(10,9));

            //_9 GCD = new _7();

            //Console.WriteLine(GCD.GCD(15,10));

            //_15 InvFacSum = new _15();
            //Console.Write(InvFacSum.InvFacSum(5));
            //_20 ReverseInteger = new _20();

            //ReverseInteger.ReverseInteger(10);


            //_21 Palindrome = new _21();
            //long number = 123;

            //_7 NumberOfDigits = new _7();
            //int numberOfDigits = NumberOfDigits.NumberOfDigits(number);


            //Console.WriteLine(Palindrome.IsPalindrome(number, 4));

            //_22 Binomial = new _22();

            //Console.WriteLine(Binomial.Binomial(4,2));

            //_23 DecimalToBinary = new _23();

            //DecimalToBinary.Convert(10);

            //_28 PrinCommas = new _28();

            //long number = 10000;
            //PrinCommas.PrintCommas(number);

            //_29 PrintA = new _29();

            //PrintA.PrintAExpTimes(4);

            //_31 Print = new _31();

            //Print.PrintTriangle(5);

            //_32 Print = new _32();

            //Print.PrintTriangle(5);

            //_34 Permutation = new _34();

            //var result=Permutation.Permutation2(2);

            //_35 PowerSet = new _35();

            //var result=PowerSet.PowerSet(3);
            //int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            //var PrintArray = new Arrays._1();
            //PrintArray.PrintArray(arr,0);

            //int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            //var PrintArrayInReverseOrder = new Arrays._2();
            //PrintArrayInReverseOrder.PrintArrayInReverseOrder(arr, arr.Length-1);

            //int[] arr = new int[5] { 1, 2, 3, 4, 5 };

            //var BinarySearch = new Arrays._22();
            //BinarySearch.BinarySearch(arr,0,arr.Length-1,2);

            //Arrays._23 TernarySearch = new Arrays._23();

            //int[] arr = new int[] {9,7,12,1,3 };
            //Array.Sort(arr);

            //var result=TernarySearch.TernarySearch(arr, 3,0, arr.Length);

            //Arrays._24 CountStringItems = new Arrays._24();
            //string item = "abc";
            //string[] arr = new string[] {"abc","def","ghi","abc","xyz" };
            //int size = 4;
            //var result=CountStringItems.CountStringItem(item,arr,size);
                       
            LinkedList.LinkedList linkedList = new LinkedList.LinkedList();
            linkedList.head = new LinkedList.ListNode(1);
            linkedList.head.next = new LinkedList.ListNode(2);
            linkedList.head.next.next = new LinkedList.ListNode(2);
            linkedList.head.next.next.next = new LinkedList.ListNode(2);
            linkedList.head.next.next.next.next = new LinkedList.ListNode(2);


            //Console.WriteLine("Printing Linked list in order");
            //LinkedList._1 LinkedListTraverse = new LinkedList._1();
            //LinkedListTraverse.Traverse(linkedList.head);

            //Console.WriteLine();
            //Console.WriteLine("Printing Linked list in reverse");
            //LinkedList._2 LinkedListTraverseReverse = new LinkedList._2();
            //LinkedListTraverseReverse.TraverseReverse(linkedList.head);

            //Console.WriteLine();
            //Console.WriteLine("Count nodes in the linked list");
            //LinkedList._3 CountNodees = new LinkedList._3();
            //var ans=CountNodees.CountNodes(linkedList.head);
            //Console.WriteLine(ans);

            //LinkedList._4 Count = new LinkedList._4();

            //var ans=Count.CountItems(linkedList.head,2);

            //LinkedList._5 ItemInList = new LinkedList._5();

            //Console.WriteLine(ItemInList.ItemInList(linkedList.head,2));


            //LinkedList._7 PointToItem = new LinkedList._7();

            //var ans=PointToItem.PointToItem(linkedList.head,2);

            //LinkedList._8 PointToLastItem = new PracticingRecursionInJava.LinkedList._8();

            //var ans=PointToLastItem.PointToLastItem(linkedList.head,1);

            //LinkedList._9 NthNode = new LinkedList._9();
            //var result=NthNode.Return_N_Node2(linkedList.head, 5);

            LinkedList._10 Sum = new LinkedList._10();

            var ans=Sum.Sum(linkedList.head);



            Console.ReadLine();
        }
    }
}
