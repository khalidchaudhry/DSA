using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _190
    {
        public uint reverseBits(uint n)
        {
            Stack<uint> stk = new Stack<uint>();
            while (n != 0)
            {
                uint remainder = n % 2;
                stk.Push(remainder);

                 n = n / 2;
            }
            //Since its 32 bit signed integer
            while (stk.Count != 32)
            {
                stk.Push(0);
            }

            int i = 0;
            uint result = 0;
            while (stk.Count != 0)
            {
                result+=stk.Pop()*((uint)Math.Pow(2,i));
                ++i;
            }

            return result;
        }

    }
}
