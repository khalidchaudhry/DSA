using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeStrings.Easy
{
    class _345
    {
        public string ReverseVowels(string s)
        {
            char[] charArray = s.ToCharArray();
            int i = 0;
            int j = charArray.Length - 1;
            //char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            while (i < j)
            {
                if (
                    i < j &&
                    //!vowels.Contains(charArray[i])
                    charArray[i] != 'a' &&
                    charArray[i] != 'A' &&
                    charArray[i] != 'e' &&
                    charArray[i] != 'E' &&
                    charArray[i] != 'i' &&
                    charArray[i] != 'I' &&
                    charArray[i] != 'o' &&
                    charArray[i] != 'O' &&
                    charArray[i] != 'u' &&
                    charArray[i] != 'U'
                    )
                {
                    ++i;
                }
                else if (
                         i < j &&
                        //!vowels.Contains(charArray[j])
                        charArray[j] != 'a' &&
                        charArray[j] != 'A' &&
                        charArray[j] != 'e' &&
                        charArray[j] != 'E' &&
                        charArray[j] != 'i' &&
                        charArray[j] != 'I' &&
                        charArray[j] != 'o' &&
                        charArray[j] != 'O' &&
                        charArray[j] != 'u' &&
                        charArray[j] != 'U'
                        )
                {
                    --j;
                }
                else
                {
                    Swap(charArray, i, j);
                    ++i;
                    --j;
                }
            }

            return new string(charArray);
        }

        private void Swap(char[] array, int i, int j)
        {
            char temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
