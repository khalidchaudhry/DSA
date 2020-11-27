using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashSet
{
    public class _1002
    {
        public IList<string> CommonChars(string[] A)
        {
            List<string> result = new List<string>();
            // creating 26 character array as strings made only from lowercase letters
            int[] minFreq = new int[26];
            // initiliaze array with max value as we are going to select min frequency later
            // if not initialized then if we encounter character with 1 frequency than it will be 
            // overridden by 0 as we are doing Math.Min
            Array.Fill(minFreq, int.MaxValue);

            for (int i = 0; i < A.Length; i++)
            {
                // this array will hold the frequency of characters appear in currently processing string
                int[] charFreq = new int[26];
                // Below loop will map character count  in currently processing string to array on specfic index
                // -a because we are mapping a to 0 index , b to 1 index etc
                for (int j = 0; j < A[i].Length; j++)
                {
                    ++charFreq[A[i][j] - 'a'];
                }

                // setting the minFrequency encounter so far. 
                for (int j = 0; j < 26; j++)
                {
                    minFreq[j] = Math.Min(charFreq[j], minFreq[j]);
                }
            }
            // loop through array and if count is greater than 0 than add them to result
            for (int i = 0; i < 26; i++)
            {
                while (minFreq[i] > 0)
                {
                    // adding  'a' to index to get ASCII code for character and then covert it to 
                    // character. 
                    // e.g. b maps to index 1 and adding 'a' it becomes 1+97=98
                    // When translates it  becomes b as its ascii code is 98
                    result.Add((Convert.ToChar(i + 'a')).ToString());
                    // reducing frequency by 1 to exclude character already processed. 
                    --minFreq[i];
                }
            }

            return result;
        }





    }
}
