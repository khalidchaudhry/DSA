using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recursion.ByteByByte.Module4
{
    public class Knapsack
    {
        public int KnapsackV1(Item[] items, int totalWeight)
        {
            List<List<Item>> results = new List<List<Item>>();
            //! Passed variable approach
            KnapsackV1(items, 0, totalWeight, results, new List<Item>());

            List<Item> maxList = new List<Item>();
            int max = int.MinValue;

            foreach (List<Item> l in results)
            {
                int weight = 0;
                int value = 0;

                foreach (Item item in l)
                {
                    weight += item.weight;
                    value += item.value;
                }

                if (weight <= totalWeight && value > max)
                {
                    maxList = l;
                    max = value;
                }
            }
            return max;
        }
        public int KnapsackV2(Item[] items, int totalWeight)
        {
            List<List<Item>> results = new List<List<Item>>();
            //! Passed variable approach
            KnapsackV2(items, 0, totalWeight, 0, results, new List<Item>());

            List<Item> maxList = new List<Item>();
            int max = int.MinValue;

            foreach (List<Item> l in results)
            {
                int weight = 0;
                int value = 0;

                foreach (Item item in l)
                {
                    weight += item.weight;
                    value += item.value;
                }

                if (weight <= totalWeight && value > max)
                {
                    maxList = l;
                    max = value;
                }
            }
            return max;
        }
        public int KnapsackV3(Item[] items, int totalWeight)
        {
            List<List<Item>> results = new List<List<Item>>();
            results.Add(new List<Item>());
            //! Passed variable approach
            KnapsackV3(items, 0, totalWeight, 0, results, new List<Item>());

            int sum = results[0].Sum(x => x.value);
            return sum;
        }
        public int KnapsackV4(Item[] items, int totalWeight)
        {
            Result result = new Result();
            result.result = new List<Item>();
            //! Passed variable approach
            KnapsackV4(items, 0, totalWeight, 0, result, new List<Item>(), 0);

            return result.value;
        }
        private void KnapsackV4(Item[] items, int i, int totalWeight, int currentWeight, Result result, List<Item> path, int currentValue)
        {
            if (currentWeight > totalWeight) return;
            if (i == items.Length)
            {
                if (currentValue > result.value)
                {
                    result.result = new List<Item>(path);
                    result.value = currentValue;
                }
                return;
            }
            //! exclude current item
            KnapsackV4(items, i + 1, totalWeight, currentWeight, result, path, currentValue);
            //! include current item
            path.Add(items[i]);
            KnapsackV4(items, i + 1, totalWeight, currentWeight, result, path, currentValue + items[i].value);
            path.RemoveAt(path.Count - 1);
        }
        private void KnapsackV3(Item[] items, int i, int totalWeight, int currentWeight, List<List<Item>> results, List<Item> path)
        {
            if (currentWeight > totalWeight)
                return;
            if (i == items.Length)
            {
                if (ItemsValue(results[0]) < ItemsValue(path))
                {
                    results[0] = new List<Item>(path);
                }
                return;
            }

            //exclude current item
            KnapsackV2(items, i + 1, totalWeight, currentWeight, results, path);

            //include current item
            path.Add(items[i]);
            KnapsackV2(items, i + 1, totalWeight, currentWeight + items[i].weight, results, path);
            path.RemoveAt(path.Count - 1);

        }
        private static int ItemsValue(List<Item> l)
        {
            int sum = 0;
            foreach (Item i in l)
                sum += i.value;

            return sum;
        }
        private void KnapsackV2(Item[] items, int i, int totalWeight, int currentWeight, List<List<Item>> results, List<Item> path)
        {
            if (currentWeight > totalWeight)
                return;
            if (i == items.Length)
            {
                results.Add(new List<Item>());
                return;
            }

            //exclude current item
            KnapsackV2(items, i + 1, totalWeight, currentWeight, results, path);

            //include current item
            path.Add(items[i]);
            KnapsackV2(items, i + 1, totalWeight, currentWeight + items[i].weight, results, path);
            path.RemoveAt(path.Count - 1);
        }
        private void KnapsackV1(Item[] items, int i, int totalWeight, List<List<Item>> results, List<Item> path)
        {
            if (i == items.Length)
            {
                results.Add(new List<Item>());
                return;
            }

            //exclude current item
            KnapsackV1(items, i + 1, totalWeight, results, path);

            //include current item
            path.Add(items[i]);
            KnapsackV1(items, i + 1, totalWeight, results, path);
            path.RemoveAt(path.Count - 1);
        }
    }

    public class Item
    {
        public int weight;
        public int value;
        public Item(int weight,int value)
        {
            this.weight = weight;
            this.value = value;
        }
    }
    public class Result
    {
        public List<Item> result;
        public int value;
    }
}
