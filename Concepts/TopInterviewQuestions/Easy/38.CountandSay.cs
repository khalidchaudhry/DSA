using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _38
    {
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
                
                for (int j = 0,count=1; j < result.Length; j++)
                {
                    if (j + 1 < result.Length && result[j] == result[j + 1])
                    {
                        ++count;
                    }
                    else
                    {
                        sb.Append(count);
                        sb.Append(result[j]);
                        count=1;
                    }
                }
                result = sb;
            }

            return result.ToString();
        }


    }
}
