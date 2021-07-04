using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAndIntervals.GeekForGeeks
{
    public class FractionalKnapsackQueries
    {
        public static void FractionalKnapsackQueriesMain()
        {
            int[][] arr = new int[][]
            {
              new int[]{1,2},
              new int[]{1,3 },
              new int[]{3,7}
            };

            int[] queries = new int[] { 1, 2, 3, 4, 5 };
            FractionalKnapsackQueries test = new FractionalKnapsackQueries();
            var result = test.Queries(arr, queries);
            Console.ReadLine();
        }


        public double[] Queries(int[][] arr, int[] queries)
        {
            int n = queries.Length;
            double[] result = new double[n];
            //arr[0]==Weight
            //arr[1]==Value/TotalPrice
            var comparer = Comparer<int[]>.Create((x, y) =>
            {
                return ((double)y[1] / y[0]).CompareTo((double)x[1] / x[0]);
            });

            Array.Sort(arr, comparer);
            int idx = 0;
            foreach (int query in queries)
            {
                double profit = 0;
                int givenCapacity = query;
                foreach (int[] item in arr)
                {
                    int currItemWeight = item[0];
                    int currItemValue = item[1];
                    if (givenCapacity >= currItemWeight)
                    {
                        profit += currItemValue;
                        givenCapacity -= currItemWeight;
                    }
                    else
                    {
                        profit += ((double)givenCapacity / currItemWeight) *currItemValue;                        
                        break;
                    }
                }
                result[idx++] = profit;
            }
            return result;
        }



    }
}
