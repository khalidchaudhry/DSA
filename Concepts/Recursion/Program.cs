using System;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            ByteByByteExamples b = new ByteByByteExamples();
            var arr = new int[5] {1,2,3,4,5 };
            b.CountEvenBuiltUp(arr);

        }
    }
}
