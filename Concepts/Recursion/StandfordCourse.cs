using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    public class StandfordCourse
    {
        public void PrintAllBinary(int digits)
        {
            PrintAllBinary(digits, new StringBuilder());

        }

        private void PrintAllBinary(int digits, StringBuilder path)
        {
            if (digits == 0)
            {
                Console.WriteLine(path.ToString());
                return;
            }

            for (int i = 0; i < 2; ++i)
            {
                path.Append(i);
                PrintAllBinary(digits - 1, path);
                --path.Length;
            }
        }
    }
}
