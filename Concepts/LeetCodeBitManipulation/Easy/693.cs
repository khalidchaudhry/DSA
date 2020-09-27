using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Easy
{
    public class _693
    {
        public bool HasAlternatingBits(int n)
        {

            int curr = n % 2;

            n = n / 2;

            while (n != 0)
            {
                if (n % 2 == curr) return false;

                curr = n % 2;

                n = n / 2;
            }

            return true;
        }

        public bool HasAlternatingBits2(int n)
        {
            int base2 = 2;
            string binaryString = Convert.ToString(n, base2);

            for (int i = 0; i < binaryString.Length - 1; ++i)
            {
                if (binaryString[i] == binaryString[i + 1])
                {
                    return false;
                }
            }

            return true;

        }
    }
}
