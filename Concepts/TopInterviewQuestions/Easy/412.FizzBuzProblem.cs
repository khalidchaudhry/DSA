using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions
{
    public class FizzBuzProblem
    {
        public IList<string> FizzBuzz(int n)
        {
            IList<string> lst = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                int modBy3 = i % 3;
                int modBy5 = i % 5;

                if (modBy3 == 0 && modBy5 == 0)
                {
                    lst.Add("FizzBuzz");
                }
                else if (modBy3 == 0)
                {
                    lst.Add("Fizz");
                }
                else if (modBy5 == 0)
                {
                    lst.Add("Buzz");
                }
                else
                {
                    lst.Add(i.ToString());
                }
            }
            return lst;
        }

    }
}
