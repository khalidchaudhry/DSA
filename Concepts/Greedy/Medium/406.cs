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
            var sortbyHDescKAsc =people.OrderByDescending(h => h[0]).ThenBy(k => k[1]);

            foreach (int[] person in sortbyHDescKAsc)
            {
                ans.Insert(person[1],person);
                
            }

            return ans.ToArray();
        }


    }
}
