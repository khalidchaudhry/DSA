using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {

            SortedInsert si = new SortedInsert();
            Stack<int> stk = new Stack<int>();
            stk.Push(0);
            stk.Push(3);
            stk.Push(4);
            stk.Push(7);

            si.SortedInsertWithRecursion(stk,1);

            foreach (var one in stk)
            {
                Console.WriteLine(one);
            }

            Console.ReadLine();
           
        }
    }
}
