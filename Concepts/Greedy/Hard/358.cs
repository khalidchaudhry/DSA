using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Hard
{
    public class _358
    {
        public string RearrangeString(string s, int k)
        {

            if (k == 0)
                return s;
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!freqMap.ContainsKey(c))
                {
                    freqMap.Add(c, 0);
                }
                ++freqMap[c];
            }

            var comparer = Comparer<Data>.Create((x, y) =>
            {
                if (x.Freq == y.Freq)
                {
                    return x.Char.CompareTo(y.Char);
                }
                return y.Freq.CompareTo(x.Freq);
            });

            PQ<Data> pq = new PQ<Data>(comparer);
            foreach (var keyValue in freqMap)
            {
                pq.Add(new Data(keyValue.Key, keyValue.Value));
            }
            int leftOver = s.Length;
            StringBuilder result = new StringBuilder();
            while (pq.Size > 0)
            {
                PQ<Data> temp = new PQ<Data>(comparer);

                int itrs = Math.Min(leftOver, k);
                for (int i = 0; i < itrs; ++i)
                {
                    //! We need to place itrs elements however if pq is empty we can't place them. 
                    if (pq.Size == 0)
                        return string.Empty;

                    Data curr = pq.Poll();
                    result.Append(curr.Char);
                    --curr.Freq;
                    --leftOver;
                    if (curr.Freq > 0)
                    {
                        temp.Add(new Data(curr.Char, curr.Freq));
                    }
                }
                while (temp.Size > 0)
                {
                    Data curr = temp.Poll();
                    pq.Add(new Data(curr.Char, curr.Freq));
                }
            }
            return result.ToString();
        }
    }
    public class Data
    {
        public char Char;
        public int Freq;
        public Data(char c, int freq)
        {
            Char = c;
            Freq = freq;
        }
    }
}


