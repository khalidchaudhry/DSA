using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Easy
{
    public class _690
    {
        public int getImportance(List<Employee> employees, int id)
        {
            Dictionary<int, Employee> map = new Dictionary<int, Employee>();
            foreach (Employee e in employees)
            {
                map.Add(e.id, e);
            }

            int importance = 0;
            Queue<Employee> queue = new Queue<Employee>();
            queue.Enqueue(map[id]);
            while (queue.Count != 0)
            {
                Employee curr = queue.Dequeue();
                importance += curr.importance;
                foreach (int subordinate in curr.subordinates)
                {
                    queue.Enqueue(map[subordinate]);
                }
            }

            return importance;
        }
    }

    public class Employee
    {
        public int id;
        public int importance;
        public IList<int> subordinates;
    }

}
