using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAndIntervals
{
    public class MinimumPlatforms
    {
        public static void MinimumPlatformsMain()
        {

            int[] arr = new int[] { 900, 940, 950, 1100, 1500, 1800 };
            int[] dep = new int[] { 910, 1200, 1120, 1130, 1900, 2000 };
            int n = arr.Length;

            MinimumPlatforms test = new MinimumPlatforms();
            int result = test.FindPlatform0(arr, dep, n);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public int FindPlatform0(int[] arr, int[] dep, int n)
        {
            SortedDictionary<int, int> timeCount = new SortedDictionary<int, int>();

            for (int i = 0; i < n; ++i)
            {
                int arrival = arr[i];
                int departure = dep[i];
                if (!timeCount.ContainsKey(arrival))
                {
                    timeCount.Add(arrival, 0);
                }
                ++timeCount[arrival];

                if (!timeCount.ContainsKey(departure))
                {
                    timeCount.Add(departure, 0);
                }
                --timeCount[departure];
            }

            int minPlatforms = 0;
            int sum = 0;
            foreach (var keyValue in timeCount)
            {
                sum += keyValue.Value;
                minPlatforms = Math.Max(sum,minPlatforms);
            }
            return minPlatforms;
        }


        public int FindPlatform(int[] arr, int[] dep, int n)
        {
            List<(int arr, int dep)> arrivalDeparture = new List<(int arr, int dep)>();

            for (int i = 0; i < n; ++i)
            {
                arrivalDeparture.Add((arr[i], dep[i]));
            }
            arrivalDeparture = arrivalDeparture.OrderBy(x => x.arr).ToList();

            PQ<int> pq = new PQ<int>();
            foreach ((int start, int end) in arrivalDeparture)
            {
                if (pq.Size > 0 && start > pq.Peek())
                {
                    pq.Poll();
                    pq.Add(end);
                }
                else
                {
                    pq.Add(end);
                }
            }
            return pq.Size;
        }
    }
}


