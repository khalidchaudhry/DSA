using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class NGE
    {
        public static void PrintNGE(int[] arr)
        {
            int i = 0;
            Stack<int> s = new Stack<int>();

            int poppedElement, current;

            /* push the first element to stack */
            s.Push(arr[0]);

            // iterate for rest of the elements 
            for (i = 1; i < arr.Length; i++)
            {
                current = arr[i];
                while (s.Count > 0 && current > s.Peek())
                {
                    poppedElement = s.Pop();
                    Console.WriteLine(poppedElement + " --> " + current);

                }
                s.Push(current);
            }
            /* After iterating over the loop, the remaining 
            elements in stack do not have the next greater 
            element, so print -1 for them */
            while (s.Count != 0)
            {
                poppedElement = s.Pop();
                current = -1;
                Console.WriteLine(poppedElement + " -- " + current);
            }
        }
    }
}
