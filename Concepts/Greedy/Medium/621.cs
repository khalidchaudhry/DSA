using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Greedy.Medium
{
    public class _621
    {

        public static void _621Main()
        {

            char[] tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' };
            int n = 2;
            _621 TotalSlots = new _621();
            var ans = TotalSlots.LeastInterval0(tasks, n);
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
            Dictionary<char, int> frequencyCount = new Dictionary<char, int>();
            GetFrequencyCount(tasks, frequencyCount);

            var sortedFrequencyCount = frequencyCount.OrderByDescending(x => x.Value);

            //! -1 because we don't need to wait after last task in context of  calculating for the idle slots
            int maxValue = sortedFrequencyCount.ElementAt(0).Value - 1;
            int idleSlots = maxValue * n;

            //! why starting at 1 and not 0 becuase index 0 contains most frequent task. We caculated our idle slots based on it . 
            //! Rest of the tasks will work reducing the idle slots 
            //!Index 1 and onwards contain task that we want to fill idle slotes
            for (int i = 1; i < sortedFrequencyCount.Count(); ++i)
            {
                //! Math.Min because what if we have more than 1 most frequency tasks. 
                //! That task count will not take all available idle slots as we have not calculated idle slots based on most frequent task count but mostFrequenctTaskCount-1
                //! We calculated our idle slots based on maxOccuringTask-1 hence 
                idleSlots -= Math.Min(maxValue, sortedFrequencyCount.ElementAt(i).Value);
            }

            return idleSlots > 0 ? idleSlots + tasks.Length : tasks.Length;

        }

        private void GetFrequencyCount(char[] tasks, Dictionary<char, int> frequencyCount)
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
