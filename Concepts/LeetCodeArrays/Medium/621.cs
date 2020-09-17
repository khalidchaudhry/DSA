using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LeetCodeArrays.Medium
{
    public class _621
    {

        public static void _621Main()
        {

            char[] tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' };
            int n = 2;
            _621 TotalSlots = new _621();
            var ans=TotalSlots.LeastInterval1(tasks,n);
            Console.ReadLine();
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=eGf-26OTI-A
        /// https://www.youtube.com/watch?v=I9Tq7R2Z2ys
        //!intuition 
        /***************************************/
        //!Solve the task with largest repitition first than solve other task and come back to the largest task again
        /***************************************/
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastInterval0(char[] tasks, int n)
        {

            int[] charMap = new int[26];

            foreach (char c in tasks)
            {
                charMap[c - 'A']++;
            }

            //!Why sorting?  because doing first the task that occurs most frequently will 
            //! give us optimum way to complete the tasks 
            //!sorting does not ruin time complexity as we are sorting 26 characters 
            //! We are soritng because we want to get the maximum value from array and 
            //! sorting will help as we can grab last element from it and it will be the maximum
            // ! After sorting we will no longer get the frequency of chars in array but frequency of tasks 
            Array.Sort(charMap);

            //! -1 because we don't need to wait for very last task. 
            int max_val = charMap[25] - 1;

            //! Fill everything except the maximum accuring task with idle 
            // For example for input AAABB with cool down period=2 there will be 4 idle tasks if we don't consider B
            int idleSlots = max_val * n;

            for (int i = 24; i >= 0; i--)
            {
                //!AAABBB
                //!AAABB
                //If f_B == f_max, then it could take (f_max - 1) cooling idle slots, and one slot at the end, which is not an idle slot: AB -- AB -- AB.
                //If f_B<f_max, then it could take f_B cooling idle slots: AB-- A--(cooling)-- A.
                //To uniform these two cases, we take min(f_max - 1, f_B).
                idleSlots -= Math.Min(charMap[i], max_val);
            }

            //if we could not fill up all the idle slots with the tasks. 
            //idleSlots > 0 we still have idle slots then least interval will be idleSlot+tasks else just tasks
            return idleSlots > 0 ? idleSlots + tasks.Length : tasks.Length;
        }

        public int LeastInterval1(char[] tasks, int n)
        {
            Dictionary<int, int> frequencyCount = new Dictionary<int, int>();
            GetFrequencyCount(tasks, frequencyCount);

            frequencyCount.OrderByDescending(x => x.Value);

            //! -1 because we don't need to wait after last task
            int idleSlots = frequencyCount.ElementAt(0).Value - 1 * n;
            //! why 1 and 0 becuase index 0 contains most frequent task. We caculated our idle slots based on it . 
            //!Index 1 and onwards contain task that we want to fill idle slotes
            for (int i = 1; i < frequencyCount.Count; ++i)
            {
                idleSlots -= frequencyCount.ElementAt(i).Value;
            }

            return idleSlots > 0 ? idleSlots + tasks.Length : tasks.Length;

        }

        private void GetFrequencyCount(char[] tasks, Dictionary<int, int> frequencyCount)
        {
            for (int i = 0; i < tasks.Length; ++i)
            {
                if (frequencyCount.ContainsKey(tasks[i]))
                {
                    frequencyCount[tasks[i]]++;
                }
                else
                {
                    frequencyCount[tasks[i]] = 1;
                }
            }
        }
    }
}
