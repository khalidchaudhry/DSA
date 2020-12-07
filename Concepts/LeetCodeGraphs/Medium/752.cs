using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _752
    {
        public static void _752Main()
        {
            _752 Main = new _752();
            string[] deadends = new string[] { "0201", "0101", "0102", "1212", "2002" };
            string target = "0202";

            var result = Main.OpenLock(deadends, target);
            Console.ReadLine();
        }
        /// <summary>
        ///// # <image url="http://gitlinux.net/img/media/15689514316224.jpg" scale="0.5" />   
        /// </summary>      
        public int OpenLock(string[] deadends, string target)
        {
            HashSet<(int w1, int w2, int w3, int w4)> visited = new HashSet<(int w1, int w2, int w3, int w4)>();
            //! Convert deadends to 4 sized tuple
            foreach (string deadend in deadends)
            {
                visited.Add((deadend[0] - '0', deadend[1] - '0', deadend[2] - '0', deadend[3] - '0'));
            }
            //! add tuple to visited
            if (visited.Contains((0, 0, 0, 0)))
                return -1;

            (int w1, int w2, int w3, int w4) trg = (target[0] - '0', target[1] - '0', target[2] - '0', target[3] - '0');

            Queue<(int w1, int w2, int w3, int w4)> queue = new Queue<(int w1, int w2, int w3, int w4)>();

            int level = 0;

            queue.Enqueue((0, 0, 0, 0));
            visited.Add((0, 0, 0, 0));

            while (queue.Count != 0)
            {
                int size = queue.Count;
                //! level order traversal as we need minimum total number of turns required to open the lock
                for (int i = 0; i < size; i++)
                {
                    (int w1, int w2, int w3, int w4) currLock = queue.Dequeue();

                    if (currLock.Equals(trg))
                    {
                        return level;
                    }
                    foreach ((int w1, int w2, int w3, int w4) in GetNextStates(currLock))
                    {
                        if (!visited.Contains((w1, w2, w3, w4)))
                        {
                            visited.Add((w1, w2, w3, w4));
                            queue.Enqueue((w1, w2, w3, w4));
                        }
                    }
                }

                level++;
            }

            return -1;
        }
        /// <summary>
        //! Clean version of the function is below 
        /// </summary>
        /// <returns></returns>
        private List<(int w1, int w2, int w3, int w4)> GetNextStates((int w1, int w2, int w3, int w4) currLock)
        {
            List<(int w1, int w2, int w3, int w4)> allStates = new List<(int w1, int w2, int w3, int w4)>();

            //!(10+n+1)%10 gives the next number in range 0-9. In case of 9 , it will give 0 
            //!(10+n-1)%10 gives the previous number in range 0-9. In case of 0 , it will give 9 

            int w1BackWord = (10 + currLock.w1 - 1) % 10;
            int w1Forward = (10 + currLock.w1 + 1) % 10;
            allStates.Add((w1BackWord, currLock.w2, currLock.w3, currLock.w4));
            allStates.Add((w1Forward, currLock.w2, currLock.w3, currLock.w4));

            int w2BackWord = (10 + currLock.w2 - 1) % 10;
            int w2Forward = (10 + currLock.w2 + 1) % 10;
            allStates.Add((currLock.w1, w2BackWord, currLock.w3, currLock.w4));
            allStates.Add((currLock.w1, w2Forward, currLock.w3, currLock.w4));

            int w3BackWord = (10 + currLock.w3 - 1) % 10;
            int w3Forward = (10 + currLock.w3 + 1) % 10;
            allStates.Add((currLock.w1, currLock.w2, w3BackWord, currLock.w4));
            allStates.Add((currLock.w1, currLock.w2, w3Forward, currLock.w4));

            int w4BackWord = (10 + currLock.w4 - 1) % 10;
            int w4Forward = (10 + currLock.w4 + 1) % 10;
            allStates.Add((currLock.w1, currLock.w2, currLock.w3, w4BackWord));
            allStates.Add((currLock.w1, currLock.w2, currLock.w3, w4Forward));

            return allStates;

        }       
    }
}