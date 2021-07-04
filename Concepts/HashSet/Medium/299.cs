using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _299
    {

        /// <summary>
        //https://www.youtube.com/watch?v=gbLfuCGUh4A 
        /// </summary>
        public string GetHint(string secret, string guess)
        {

            Dictionary<char, int> map = new Dictionary<char, int>();
            List<char> unknowns = new List<char>();
            int bullsCount = 0;
            int cowsCount = 0;

            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i].Equals(guess[i]))
                {
                    ++bullsCount;
                }
                else
                {
                    unknowns.Add(guess[i]);
                    if (map.ContainsKey(secret[i]))
                    {
                        ++map[secret[i]];
                    }
                    else
                    {
                        map.Add(secret[i], 1);
                    }
                }
            }

            foreach (char unknown in unknowns)
            {
                if (map.ContainsKey(unknown))
                {
                    if (map[unknown] > 0)
                    {
                        ++cowsCount;
                        --map[unknown];
                    }
                }
            }

            return $"{bullsCount}A{cowsCount}B";
        }
       
        public String GetHint2(String secret, String guess)
        {
            int bulls = 0;
            int[] nums1 = new int[10];
            int[] nums2 = new int[10];
            for (int i = 0; i < secret.Length; i++)
            {
                char s = secret[i];
                char g = guess[i];
                if (s == g)
                {
                    bulls++;
                }
                else
                {
                    // subtracting 0 as char will than come as number from 0 to 9 
                    nums1[s - '0']++;
                    nums2[g - '0']++;
                }
            }
            int cows = 0;
            for (int i = 0; i < 10; i++)
            {
                // Math.Min because common element is which appears least
                //! minimum because we are looking for intersection here. 
                cows += Math.Min(nums1[i], nums2[i]);
            }
            String res = bulls + "A" + cows + "B";
            return res;
        }

        public String GetHint3(String secret, String guess)
        {
            int bulls = 0;
            int cows = 0;
            int[] numbers = new int[10];
            for (int i = 0; i < secret.Length; i++)
            {
                int s = (int)char.GetNumericValue(secret[i]);
                int g = (int)char.GetNumericValue(guess[i]);
                if (s == g) bulls++;
                else
                {
                    if (numbers[s] < 0) cows++;
                    if (numbers[g] > 0) cows++;
                    numbers[s]++;
                    numbers[g]--;
                }
            }
            return bulls + "A" + cows + "B";
        }
    }
}
