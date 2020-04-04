using PracticingRecursionInJava.Integers;
using System;

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

            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            var PrintArrayInReverseOrder = new Arrays._2();
            PrintArrayInReverseOrder.PrintArrayInReverseOrder(arr, arr.Length-1);

            Console.ReadLine();
        }
    }
}
