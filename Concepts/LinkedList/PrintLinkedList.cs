using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class PrintLinkedList
    {
        public static void PrintInReverse(Node n)
        {
            if (n == null)
                return;
            PrintInReverse(n.next);
            Console.Write($"{n.data} ");
        }


    }
}
