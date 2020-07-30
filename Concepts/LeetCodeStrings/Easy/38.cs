using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStrings.Easy
{
    public class _38
    {
        public static void _38Main()
        {
            _38 Count = new _38();
            var ans = Count.CountAndSay0(10);
            Console.ReadLine();
        }

        /// <summary>
        //! Basic idea is to calculate new row based on the previous row
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay0(int n)
        {

            StringBuilder previousRow = new StringBuilder("1");
            //! Starting with 1 as we already have one row already 
            for (int i = 1; i < n; ++i)
            {
                StringBuilder currentRow = new StringBuilder();

                for (int j = 0, frequency = 1; j < previousRow.Length; ++j)
                {
                    if (j + 1 < previousRow.Length && previousRow[j] == previousRow[j + 1])
                    {
                        ++frequency;
                    }
                    else
                    {
                        currentRow.Append(frequency);
                        currentRow.Append(previousRow[j]);
                        //! resetting the frequency
                        frequency = 1;
                    }
                }
                //! Making current row as previous row
                previousRow = currentRow;
            }

            return previousRow.ToString();
        }
        public string CountAndSay1(int n)
        {
            StringBuilder[] result = new StringBuilder[n];

            for (int i = 0; i < n; ++i)
            {
                result[i] = new StringBuilder();
            }

            for (int i = 0; i < n; ++i)
            {
                if (i == 0)
                {
                    result[i].Append('1');
                    continue;
                }
                //!get the previous row
                StringBuilder previousRow = result[i - 1];
                int j = 0;
                //!previous row first element               
                char previousElement = previousRow[j];
                int frequency = 0;
                while (j < previousRow.Length)
                {
                    char currentElement = previousRow[j];
                    if (currentElement == previousElement)
                    {
                        ++frequency;
                    }
                    else
                    {
                        result[i].Append(frequency);
                        result[i].Append(previousElement);
                        frequency = 1;
                    }

                    previousElement = currentElement;
                    ++j;
                }
                result[i].Append(frequency);
                result[i].Append(previousElement);
            }

            return result[n - 1].ToString();
        }
    
        public string CountAndSay(int n)
        {

            if (n == 1)
            {
                return "1";
            }

            StringBuilder result = new StringBuilder("1");

            for (int i = 2; i <= n; i++)
            {
                StringBuilder sb = new StringBuilder();

                for (int j = 0, count = 1; j < result.Length; j++)
                {
                    if (j + 1 < result.Length && result[j] == result[j + 1])
                    {
                        ++count;
                    }
                    else
                    {
                        sb.Append(count);
                        sb.Append(result[j]);
                        count = 1;
                    }
                }
                result = sb;
            }

            return result.ToString();
        }


    }
}
