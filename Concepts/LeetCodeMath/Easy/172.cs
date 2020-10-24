using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _172
    {

        /// <summary>
        /// https://www.youtube.com/watch?v=3Hdmv_Ym8PI
        /// https://www.youtube.com/watch?v=wkvVdggCSeo
        //! Basic intution: Occurance of trailing zeros= Occurances of 5's in number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TrailingZeroes(int n)
        {
            int trailingZerosCount = 0;
            while (n >= 5)
            {
                trailingZerosCount += n / 5;
                n = n / 5;
            }

            return trailingZerosCount;
        }


    }
}
