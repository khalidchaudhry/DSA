using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _1215
    {
        /// <summary>
        //! Based on idea in Kuai's class 
        /// # <image url="$(SolutionDir)\Images\1215.png"  scale="0.6"/>
        /// </summary>
        public IList<int> CountSteppingNumbers(int low, int high)
        {
            List<int> result = new List<int>();
            //! 0 does not have any left child and right child already considered when we queue numbers from 1......9 
            if (low == 0)
            {
                result.Add(0);
            }

            Queue<long> queue = new Queue<long>();
            InitializeQueue(queue);
            while (queue.Count != 0)
            {
                long current = queue.Dequeue();
                if (current >= low && current <= high)
                {
                    result.Add((int)current);
                }

                long lastDigit = current % 10;
                List<long> possibilities = new List<long>() { lastDigit - 1, lastDigit + 1 };
                foreach (int possibility in possibilities)
                {
                    //! current < high not current<=high as there is no value being added if current =high
                    //! e.g if current=10 and high=10 then there is no point adding as the value going to add will be > 10
                    
                    //! possibility >= 0 && possibility < 10 because in case 10 we don't want to add 10*10+(0-1)=99 since its  adjacent digits 
                    //! don't have an absolute difference of exactly 1. 
                    if (possibility >= 0 && possibility < 10 && current < high)
                    {
                        queue.Enqueue(current * 10 + possibility);
                    }
                }

            }
            //! WE don't need sorting here since we are already adding number occuring first(lastDigit - 1) in queue
            //result.Sort();
            return result;

        }
        private void InitializeQueue(Queue<long> queue)
        {
            for (long i = 1; i <= 9; ++i)
            {
                queue.Enqueue(i);
            }
        }

        //! Brute force
        public IList<int> CountSteppingNumbers2(int low, int high)
        {
            List<int> result = new List<int>();
            for (int i = low; i <= high; ++i)
            {
                if (i <= 10)
                {
                    result.Add(i);
                }
                else
                {
                    if (IsSteppingNumber(i))
                    {
                        result.Add(i);
                    }
                }
            }

            return result;
        }

        private bool IsSteppingNumber(int number)
        {
            int lastDigit = int.MaxValue;
            while (number != 0)
            {
                int remainder = number % 10;
                int quotient = number / 10;
                if (lastDigit != int.MaxValue)
                {
                    if (Math.Abs(remainder - lastDigit) != 1)
                    {
                        return false;
                    }
                }
                lastDigit = remainder;
                number = quotient;
            }

            return true;
        }



    }
}
