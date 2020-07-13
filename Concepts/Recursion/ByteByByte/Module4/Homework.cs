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
    }
}
