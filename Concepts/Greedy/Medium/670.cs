using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Greedy.Medium
{

    /// <summary>
    /// 
    /// </summary>
    public class _670
    {

        public static void _670Main()
        {

            _670 MaximumSwaps = new _670();

            var ans = MaximumSwaps.MaximumSwap3(98368);

            Console.ReadLine();

        }

        public int MaximumSwap3(int num)
        {

            List<int> digits = new List<int>();
            while (num != 0)
            {
                digits.Add(num % 10);
                num = num / 10;
            }
            digits.Reverse();
            int n = digits.Count;
            int[] suffix = new int[n];
            for (int i = n - 1; i >= 0; --i)
            {
                if (i == n - 1 || digits[i] > digits[suffix[i + 1]])
                    suffix[i] = i;
                else
                    suffix[i] = suffix[i + 1];
            }

            foreach (int digit in suffix)
            {
                Console.WriteLine(digit);
            }

            for (int i = 0; i < n; ++i)
            {
                if (digits[suffix[i]] > digits[i])
                {
                    int temp = digits[i];
                    digits[i] = digits[suffix[i]];
                    digits[suffix[i]] = temp;
                    break;
                }
            }
            int result = 0;

            //! we are starting from 0 index to recreate original number
            foreach (int digit in digits)
            {

                result = result * 10 + digit;
            }
            return result;
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=pDyh9VOMWgI
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MaximumSwap0(int num)
        {
            char[] digits = num.ToString().ToCharArray();
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < digits.Length; ++i)
            {
                int digit = digits[i] - '0';
                if (map.ContainsKey(digits[i]))
                {
                    map[digit] = i;
                }
                else
                {
                    map[digit] = i;
                }
            }

            for (int i = 0; i < digits.Length; ++i)
            {
                char digit = digits[i];
                for (int j = 9; j > digit - '0'; --j)
                {

                    if (map.ContainsKey(j) && map[j] > i)
                    {
                        int index = map[j];
                        char temp = digits[i];
                        digits[i] = digits[index];
                        digits[index] = temp;
                        return int.Parse(new string(digits));
                    }
                }
            }
            return num;
        }


        ///https://leetcode.com/problems/maximum-swap/solution/           
        public int MaximumSwap1(int num)
        {
            char[] digits = num.ToString().ToCharArray();
            int[] indexes = GetIndexes(digits);
            for (int i = 0; i < digits.Length; ++i)
            {
                for (int j = 9; j > digits[i] - '0'; --j)
                {
                    if (indexes[j] > i)
                    {
                        char temp = digits[i];
                        digits[i] = digits[indexes[j]];
                        digits[indexes[j]] = temp;
                        return int.Parse(new string(digits));
                    }
                }
            }
            return num;
        }

        private int[] GetIndexes(char[] digits)
        {
            int[] indexes = new int[10];
            for (int i = 0; i < digits.Length; ++i)
            {
                indexes[digits[i] - '0'] = i;

            }
            return indexes;
        }

        public int MaximumSwap(int num)
        {
            int divisor = 10;
            int divident = num;
            List<int> digits = new List<int>();
            while (divident != 0)
            {
                int remainder = divident % divisor;
                digits.Add(remainder);
                divident = divident / divisor;
            }
            bool isSwapped = false;
            int digitsCount = digits.Count;

            for (int i = digitsCount - 1; i > 0; --i)
            {
                int j = i - 1;
                while (j >= 0)
                {
                    if (digits[j] > digits[i])
                    {
                        int temp = digits[j];
                        digits[j] = digits[i];
                        digits[i] = temp;
                        isSwapped = true;
                        break;
                    }
                    --j;
                }
                if (isSwapped)
                {
                    break;
                }
            }
            int ans = 0;
            int multiplier = 0;
            if (isSwapped)
            {
                for (int i = 0; i < digitsCount; ++i)
                {
                    ans += digits[i] * (int)Math.Pow(10, multiplier++);
                }
                return ans;
            }
            else
            {
                return num;
            }
        }
    }
}
