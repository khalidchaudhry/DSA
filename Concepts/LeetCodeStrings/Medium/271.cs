using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class Codec
    {
        public static void CodecMain()
        {
            Codec codec = new Codec();
            List<string> strs = new List<string>();
            strs.Add("Hello");
            strs.Add("World");
            var encode = codec.encode(strs);

            var ans = codec.decode(encode);
            foreach (string s in ans)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }

        // Encodes a list of strings to a single string.
        public string encode(IList<string> strs)
        {
            char strdelimiter = (char)256;
            StringBuilder sb = new StringBuilder();
            foreach (string s in strs)
            {
                sb.Append(s);
                sb.Append(strdelimiter);
            }

            return sb.ToString();
        }

        // Decodes a single string to a list of strings.
        public IList<string> decode(string s)
        {
            IList<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == 256)
                {
                    result.Add(sb.ToString());
                    sb = new StringBuilder();
                }
                else
                {
                    sb.Append(s[i]);
                }
            }

            return result;
        }
    }

}
