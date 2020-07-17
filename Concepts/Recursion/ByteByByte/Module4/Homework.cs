using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module4
{
    public class Homework
    {
        /*
         Question #1
         Implement the 01 Knapsack problem by building up the result rather than using a passed  variable.
         As a reminder, here is the definition of the problem:
         Given a list of items with values and weights, as well as a max weight, find the maximum
         value you can generate from items, where the sum of the weights is less than or equal to the max.
        */
        public List<Item> KnapsackBuiltUp(Item[] items, int totalWeight)
        {

            return KnapsackBuiltUp(items, 0, totalWeight, 0, new List<Item>());

        }
        /*
           Question#3
           Making Change. Given an integer representing a given amount of change, write a function to
           compute the minimum number of coins required to make that amount of change. You can
           assume that there is always a 1¢ coin. 
        */
        /*************************************/
        //! Time complexity=branching_factor^recursion_depth * work_per_recrsive_call
        //! branching_factor=2
        //! recursion_depth=amt
        //! work_per_recursive_call=n
        //! O(c)= where c is number of valid combinations we have
        //! Time complexity=O(2^amt)*O(n)+O(c)
        //! Space complexity=recursion_depth*space_per_recursive_call
        //! space_per_recursive_call=O(1) since we are not saving any extra stuff 
        //! Space complexity=O(amt)
        /*************************************/

        public int MakingChange(int[] coins, int amt)
        {
            int minCoinsNeeded = int.MaxValue;
            List<List<int>> result = new List<List<int>>();
            MakingChange(coins, 0, amt, new List<int>(), result);

            for (int i = 0; i < result.Count; i++)
            {
                minCoinsNeeded = Math.Min(minCoinsNeeded, result[i].Count);
            }

            return minCoinsNeeded;

        }
        /*
         Question#3
         Making Change. Given an integer representing a given amount of change, write a function to
         compute the minimum number of coins required to make that amount of change. You can
         assume that there is always a 1¢ coin. 
         */
        /*************************************/
        //! Time complexity=branching_factor^recursion_depth * work_per_recrsive_call
        //! branching_factor=2
        //! recursion_depth=amt
        //! work_per_recursive_call=O(1)        
        //! Time complexity=O(2^amt)
        //! Space complexity=recursion_depth*space_per_recursive_call
        //! space_per_recursive_call=O(1) since we are not saving any extra stuff 
        //! Space complexity=O(amt)
        /*************************************/
        public int MakingChange2(int[] coins, int amt)
        {
            ResultWrapper resultWrapper = new ResultWrapper();
            resultWrapper.Result = int.MaxValue;
            MakingChange2(coins, 0, amt, new List<int>(), resultWrapper);
            return resultWrapper.Result;
        }

        private void MakingChange(int[] coins, int i, int amt, List<int> path, List<List<int>> result)
        {
            if (amt < 0) return;
            if (amt == 0)
            {
                result.Add(new List<int>(path));
                return;
            }
            if (i == coins.Length) return;

            path.Add(coins[i]);
            MakingChange(coins, i, amt - coins[i], path, result);
            path.RemoveAt(path.Count - 1);
            MakingChange(coins, i + 1, amt, path, result);
        }  

        private void MakingChange2(int[] coins, int i, int amt, List<int> path, ResultWrapper resultWrapper)
        {
            if (amt < 0) return;
            if (amt == 0)
            {
                resultWrapper.Result = Math.Min(resultWrapper.Result, path.Count);
                return;
            }
            if (i == coins.Length) return;

            path.Add(coins[i]);
            MakingChange2(coins, i, amt - coins[i], path, resultWrapper);
            path.RemoveAt(path.Count - 1);
            MakingChange2(coins, i + 1, amt, path, resultWrapper);
        }

        private List<Item> KnapsackBuiltUp(Item[] items, int i, int totalWeight, int currentWeight, List<Item> path)
        {
            List<Item> result = new List<Item>();

            if (currentWeight > totalWeight)
            {
                return result;
            }

            if (i == items.Length)
            {
                if (ItemsValue(result) < ItemsValue(path))
                {
                    result = new List<Item>(path);
                }

                return result;
            }
            //!Include
            path.Add(items[i]);
            List<Item> include = KnapsackBuiltUp(items, i + 1, totalWeight, currentWeight + items[i].weight, path);
            path.RemoveAt(path.Count - 1);

            //! exclude
            List<Item> exclude = KnapsackBuiltUp(items, i + 1, totalWeight, currentWeight, path);


            return ItemsValue(include) > ItemsValue(exclude) ? include : exclude;
        }

        private static int ItemsValue(List<Item> l)
        {
            int sum = 0;
            foreach (Item i in l)
                sum += i.value;

            return sum;
        }

        public class ResultWrapper
        {
            public int Result { get; set; }
        }
    }
}
