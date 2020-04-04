using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Easy
{
    public class _1042
    {
        public int[] GardenNoAdj(int N, int[][] paths)

        {
            int[] answer = new int[N];
            int[] flowerTypes = new int[4] { 1, 2, 3, 4 };
            // map will contain garden(garden id)  and its neighboring gardens
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < paths.Length; i++)
            {
                // only two entries in the gardens array as one edge can connect at max 2 garden
                int[] gardens = new int[2] { paths[i][0], paths[i][1] };

                // One  edge can connect at max 2 garden hence loop iterates 2 times only
                for (int k = 0; k < 2; k++)
                {
                    // garden does not exist in map. Adding garden and its neighbour(first one)
                    if (!map.ContainsKey(gardens[0]))
                    {
                        List<int> lst = new List<int>();
                        lst.Add(gardens[1]);
                        map.Add(gardens[0], lst);
                    }
                    else
                    {
                        // garden already exists in map. Adding neighbour to it
                        map[gardens[0]].Add(gardens[1]);
                    }
                    // swaping as its bidirectional graph and so that above code does not need to change.
                    // edge between 1 and 2 means that there is also edge between 2 to 1 
                    Swap(gardens);
                }
            }
            // iterating entries in map and assign them flower types
            foreach (var record in map)
            {
                HashSet<int> hs = new HashSet<int>();
                // Adding flower type to hashset already assigned to neighbour(s)
                // so that we assign garden different flower type than its neighbours 
                foreach (var one in record.Value)
                {
                    if (answer[one - 1] != 0)
                    {
                        hs.Add(answer[one - 1]);
                    }
                }
                // Purpose of below loop is to assign flower type to garden that is not assign to any of its neighbours  
                int choosenFlowerType = 0;
                for (int i = 0; i < flowerTypes.Length; i++)
                {
                    if (!hs.Contains(flowerTypes[i]))
                    {
                        choosenFlowerType = flowerTypes[i];
                        break;
                    }
                }
                // assigning flower type to the garden
                answer[record.Key - 1] = choosenFlowerType;
            }

            // If answer array entries still contains zero it means some gardens are not conencted by paths and 
            // we need to assign any(because they are not connected) flower types to them 
            // Below i am choosing flowerType 1 to them
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == 0) // only those gardens that don't have flower type assigned to them 
                {
                    // it does not matter what flower type we are assigning to them. 
                    answer[i] = flowerTypes[0];
                }
            }

            return answer;
        }

        private void Swap(int[] gardens)
        {
            int temp = gardens[0];
            gardens[0] = gardens[1];
            gardens[1] = temp;
        }
    }
}
