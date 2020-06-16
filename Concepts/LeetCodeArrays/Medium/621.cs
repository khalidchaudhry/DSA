using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _621
    {

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
        public int LeastInterval(char[] tasks, int n)
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
            // For example for input AAABB there will be 4 idle tasks if we don't consider B
            int idleSlots = max_val * n;

            for (int i = 24; i >= 0; i--)
            {
                idleSlots -= Math.Min(charMap[i],max_val);
            }

            //if we could not fill up all the idle slots with the tasks. 
            //idleSlots > 0 we still have idle slots then least interval will be idleSlot+tasks else just tasks
            return idleSlots > 0 ? idleSlots + tasks.Length : tasks.Length;
        }


    }
}
