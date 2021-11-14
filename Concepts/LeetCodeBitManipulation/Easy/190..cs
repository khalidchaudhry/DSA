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

            uint ans = 0;
            //! in unsigned integer msb represents value and not symbol(+ or -)
            for (int i = 0; i <= 31; ++i)
            {
                //! Right shift by 1 to make spave for new bit 
                ans = ans << 1;
                //! Extracting the ith bit from the number 
                uint temp = (n >> i) & 1;
                //! if the bit is set than we will simply set the least significant bit of the answer
                if (temp == 1)
                {
                    ++ans;
                }
            }
            return ans;
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
