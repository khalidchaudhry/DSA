using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _171
    {
        /// <summary>
        //! Intuituon is converting base-26 number system to base-10 number system.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int TitleToNumber(string s)
        {
            double result = 0;
            int power = 0;
            for (int i = s.Length - 1; i >= 0; --i)
            {

                int number = s[i];
                //! Adding 1 will convert it into 1--26 number system
                //! Another way to think is there is no 0 in our int system as it starts with one
                ++number;
                result = result + (int)((number - 'A') * Math.Pow(26, power++));
            }
            return (int)result;

        }


    }
}
