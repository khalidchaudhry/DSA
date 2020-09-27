using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Easy
{
    class _190
    {

        //https://www.youtube.com/watch?v=ZW7st_pN05w
        public uint reverseBits2(uint n)
        {

            uint result = 0;
            for (int i = 1; i <= 32; ++i)
            {
                // left shift result to make space for new number 
                result = result << 1;
                //! if last bit of number is 1 than add 1 to the result
                if ((n & 1) == 1)
                    ++result;
                //! right shift number to drop-off as we have already processed it 
                n = n >> 1;
            }

            return result;


        }
        public uint reverseBits3(uint n)
        {
            Stack<uint> stk = new Stack<uint>();
            while (n != 0)
            {
                uint remainder = n % 2;
                stk.Push(remainder);

                n = n / 2;
            }
            //Since its 32 bit unsigned integer
            while (stk.Count != 32)
            {
                stk.Push(0);
            }

            int i = 0;
            uint result = 0;
            while (stk.Count != 0)
            {
                result += stk.Pop() * ((uint)Math.Pow(2, i));
                ++i;
            }

            return result;
        }

    }
}
