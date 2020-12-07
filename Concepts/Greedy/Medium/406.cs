using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Greedy.Medium
{
    public class _406
    {
        public static void _406Main()
        {

            _406 Reconstruct = new _406();
            int[][] people = new int[6][]
                {
                new int[]{7, 0 },
                new int []{4,4 },
                new int[]{7, 1 } ,
                new int[]{5, 0 } ,
                new int[]{6, 1 },
                new int[]{5, 2 }
                };

            var ans = Reconstruct.ReconstructQueue(people);

            Console.ReadLine();


        }
        public int[][] ReconstructQueue(int[][] people)
        {
            List<int[]> ans = new List<int[]>();

            //for (int i = 0; i < people.Length; i++)
            //{
            //    ans.Add(new int[2]);
            //}
            //(7,0) (7,1) (6,1) (5,0,) (5,2) (4,4) 
            var sortbyHDescKAsc = people.OrderByDescending(h => h[0]).ThenBy(k => k[1]);

            foreach (int[] person in sortbyHDescKAsc)
            {
                ans.Insert(person[1], person);

            }
            return ans.ToArray();
        }
        public int[][] ReconstructQueue1(int[][] people)
        {
            Sort(people);
            List<int[]> result = new List<int[]>();

            foreach (int[] person in people)
            {
                result.Insert(person[1],person);
            }

            return result.ToArray();
        }

        private void Sort(int[][] people)
        {
            Comparer<int[]> comparer = Comparer<int[]>.Create((x, y) =>
            {
                //! if person of same height , sort them based on k ascending
                if (x[0] == y[0])
                {
                    return x[1].CompareTo(y[1]);
                }
                //! else sort based on height descending 
                return y[0].CompareTo(x[0]);
            }
        );

            Array.Sort(people, comparer);
        }
    }
}
