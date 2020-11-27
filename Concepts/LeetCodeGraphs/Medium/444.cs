using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    class _444
    {

        public static void _444Main()
        {

            _444 Test = new _444();
            int[] orgs = new int[] { 4, 1, 5, 2, 6, 3 };
            List<IList<int>> seqs = new List<IList<int>>();            seqs.Add(new List<int> { 5, 2, 6, 3 });            seqs.Add(new List<int> { 4, 1, 5, 2 });


            var result = Test.SequenceReconstruction(orgs, seqs);

            Console.ReadLine();
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=Bqhf7zPMdaU
        /// </summary>
        /// <param name="org"></param>
        /// <param name="seqs"></param>
        /// <returns></returns>
        public bool SequenceReconstruction(int[] org, IList<IList<int>> seqs)
        {

            //! there may be duplicate edges between nodes hence we using hashset rather than List<int>
            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            Dictionary<int, int> inDegree = new Dictionary<int, int>();

            foreach (List<int> seq in seqs)
            {
                foreach (int digit in seq)
                {
                    if (!graph.ContainsKey(digit))
                        graph[digit] = new HashSet<int>();
                    if (!inDegree.ContainsKey(digit))
                        inDegree[digit] = 0;
                }
            }
            
            //[1]
            //[[1],[2,3],[3,2]]
            
            if (org.Length != graph.Count) return false;

            foreach (List<int> seq in seqs)
            {
                for (int i = 0; i < seq.Count - 1; ++i)
                {
                    int from = seq[i];
                    int to = seq[i + 1];
                    //! As there may be duplicate 
                    //!edges between nodes hence we are checking if its not already been added
                    if (!graph[from].Contains(to))
                    {
                        graph[from].Add(to);
                        ++inDegree[to];
                    }
                }
            }

            Queue<int> queue = new Queue<int>();
            foreach (var keyValue in inDegree)
            {
                if (keyValue.Value == 0)
                    queue.Enqueue(keyValue.Key);
            }
            List<int> ans = new List<int>();
            while (queue.Count != 0)
            {
                //! If initially queue count > zero i.e. two nodes have indegree of 0 we immediately returns   
                //! If at any point queue count is greater then zero than it means we have 
                //! multiple sequence exists and we can't create unique one
                if (queue.Count > 1)
                {
                    return false;
                }

                int curr = queue.Dequeue();
                ans.Add(curr);
                foreach (int neighbor in graph[curr])
                {
                    --inDegree[neighbor];
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            if (ans.Count != org.Length) return false;

            for (int i = 0; i < org.Length; ++i)
            {
                if (ans[i] != org[i]) return false;
            }
            return true;
        }
    }
}
