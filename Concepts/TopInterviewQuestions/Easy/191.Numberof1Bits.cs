using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _191
    {
        public int HammingWeight(uint n)

        {
            //Stack<uint> stk =new Stack<uint>();
            int count=0;
            while (n != 0)
            {
                uint remainder=n % 2;
                if (remainder == 1)
                    ++count;

                n = n / 2;
            }
            return count;

            //     while (stk.Count != 0)
            //     {
            //         if (stk.Pop() == 1)
            //         {
            //             ++count;
            //}

            //     }
        }

    }
}
