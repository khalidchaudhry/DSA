using System;
using System.Collections;
using System.Collections.Generic;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            ByteByByteExamples b = new ByteByByteExamples();
            //var arr = new int[5] {1,2,3,4,5 };
            //b.CountEvenBuiltUp(arr);

            //insert item at the bottom of the stack
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);

            b.InsertItemAtStackBottom(s);

            foreach (var one in s)
            {
                Console.WriteLine($"{one} ");
            }
            Console.ReadLine();
        }
    }
}
