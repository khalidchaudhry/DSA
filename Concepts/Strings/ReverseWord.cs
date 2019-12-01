using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Strings
{
    class ReverseWord
    {
        public void ReverseWordInString()
        {
            var stringArrays = Regex.Split("This is a string", @"\s");
            stringArrays.ToList().ForEach(x => Console.WriteLine(x));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < stringArrays.Count(); i++)
            {
                var strArray = stringArrays[i].ToCharArray();
                int j = 0, k = strArray.Length - 1;
                while (j < k)
                {
                    var temp = strArray[j];
                    strArray[j] = strArray[k];
                    strArray[k] = temp;

                    ++j;
                    --k;
                }
                sb.Append(strArray);
                if (i != stringArrays.Length - 1)
                {
                    sb.Append(" ");
                }
            }
            Console.WriteLine(sb.ToString());

        }
        public void ReverseWordInString2()
        {
            var stringArray = "This is a string".ToCharArray();

            StringBuilder sb = new StringBuilder();
            var stack = new Stack<char>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (stringArray[i] == ' ')
                {
                    while (stack.Count > 0)
                    {
                        sb.Append(stack.Pop());
                    }
                    sb.Append(" ");
                }
                else
                {
                    stack.Push(stringArray[i]);
                }
            }

            Console.WriteLine(sb.ToString());

        }

    }
}
