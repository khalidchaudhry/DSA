using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Hard
{
    public class _269
    {

        public static void _269Main()
        {


        }

        //https://www.youtube.com/watch?v=LA0X_N-dEsg
        public string AlienOrder(string[] words)
        {
            int[] inDegree = new int[26];
            Dictionary<char, List<char>> graph = BuildGraph(inDegree, words);
            Queue<char> queue = new Queue<char>();
            StringBuilder sb = new StringBuilder();

            foreach (var keyValue in graph)
            {
                char c = keyValue.Key;
                if (inDegree[c - 'a'] == 0)
                {
                    sb.Append(c);
                    queue.Enqueue(keyValue.Key);
                }
            }

            while (queue.Count != 0)
            {
                char curr = queue.Dequeue();
                foreach (char neighbor in graph[curr])
                {
                    --inDegree[neighbor - 'a'];

                    if (inDegree[neighbor - 'a'] == 0)
                    {
                        sb.Append(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return sb.Length == graph.Count ? sb.ToString() : string.Empty;
        }

        private Dictionary<char, List<char>> BuildGraph(int[] inDegree, string[] words)
        {
            //! here in this problem , graph is build in different way. For every word , we will make entry in the graph
            Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
            foreach (string word in words)
            {
                foreach (char c in word)
                {
                    if (!graph.ContainsKey(c))
                    {
                        graph[c] = new List<char>();
                    }
                }
            }

            for (int i = 0; i < words.Length - 1; ++i)
            {
                string word1 = words[i];
                string word2 = words[i + 1];
                //!["abc","ab"]
                //! Check that word2 is not a prefix of word1.In that case its not possible to do anything. Simply returns 
                if (word1.Length > word2.Length && word1.StartsWith(word2))
                {
                    return new Dictionary<char, List<char>>();

                }
                int len = Math.Min(word1.Length, word2.Length);
                int j = 0;
                while (j < len)
                {
                    if (word1[j] != word2[j])
                    {
                        graph[word1[j]].Add(word2[j]);

                        ++inDegree[word2[j] - 'a'];

                        break;
                    }

                    ++j;
                }
            }

            return graph;
        }
    }
}
