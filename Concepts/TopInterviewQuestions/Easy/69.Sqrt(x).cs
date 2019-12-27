using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _69
    {
        public int MySqrt(int x)
        {
            long start = 0;

            long end = x;

            while(start<end)
            {
                long mid = (start + end) / 2;

                if (mid * mid == x)
                    return (int)mid;
                else if ((mid * mid) < x)
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }
            }

            if (end * end == x)
            {
                return (int)end;
            }
            return (int)start;


        }

    }
}
