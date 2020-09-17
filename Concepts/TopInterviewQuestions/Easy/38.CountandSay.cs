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
            Count.CountAndSay0(5);
            Console.ReadLine();
        }
        /// <summary>
        //! Based on the previous row, we will calculate the new row. 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay0(int n)
        {
            //! We know first row, it will be one  1 as per question
            StringBuilder previousRow = new StringBuilder("1");

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
                        frequency = 1;
                    }
                }
                previousRow = currentRow;
            }

            return previousRow.ToString();
        } 


    public string CountAndSay1(int n)
    {
        List<int>[] result = new List<int>[n];

        for (int i = 0; i < n; ++i)
        {
            result[i] = new List<int>();
        }

        for (int i = 0; i < n; ++i)
        {
            if (i == 0)
            {
                result[i].Add(i);
                continue;
            }
            //get the previous row
            List<int> previousRow = result[i - 1];
            int j = 0;
            //previous row first element               
            int previousElement = previousRow[j];
            int frequency = 0;
            while (j < previousRow.Count)
            {
                int currentElement = previousRow[j];
                if (currentElement == previousElement)
                {
                    ++frequency;
                }
                else
                {
                    result[i].Add(frequency);
                    result[i].Add(previousElement);
                    frequency = 1;
                }

                previousElement = currentElement;
                ++j;
            }
            result[i].Add(frequency);
            result[i].Add(previousElement);
        }

        return string.Join("", result[n - 1]);
    }



    public string CountAndSay2(int n)
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
