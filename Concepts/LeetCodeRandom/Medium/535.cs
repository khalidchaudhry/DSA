using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRandom.Medium
{
    class _535
    {
    }


    /// <summary>
    ///https://leetcode.com/problems/encode-and-decode-tinyurl/solution/ 
    /// </summary>
    public class Codec
    {
        Dictionary<string, string> map = new Dictionary<string, string>();
        public string encode(string longUrl)
        {
            string key = GetRand();
            while (map.ContainsKey(key))
            {
                key = GetRand();
            }
            map.Add(key, longUrl);
            return key;

        }

        public string decode(string shortUrl)
        {
            return map[shortUrl];
        }

        private static string GetRand()
        {
            string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                sb.Append(alphabet[rand.Next(62)]);
            }
            return sb.ToString();
        }
    }
}
