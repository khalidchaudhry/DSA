using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Easy
{
    public class _690
    {
        int importance = 0;
        public int GetImportance(IList<Employee> employees, int id)
        {

            Dictionary<int, Employee> graph = new Dictionary<int, Employee>();

            foreach (Employee employee in employees)
            {
                graph.Add(employee.id, employee);
            }
            //! visited resultset not needed here  
            //! because employee can't have someone listed as subordinate for him  &&
            //! same person listed as subordinate for its suborrdinate  hence we don't need visited array.
            //! in other words there is only unidirectonal relation among employee or there is no cycle
            //HashSet<int> visited = new HashSet<int>();
            //DFS(graph, visited, id);
            DFS(graph, id);
            return importance;
        }

        private void DFS(Dictionary<int, Employee> graph, int id)
        {
            importance += graph[id].importance;
            IList<int> neighbors = graph[id].subordinates;

            foreach (int neighbor in neighbors)
            {
                DFS(graph,  neighbor);
            }
        }
    }
    //!Given in leetcode
    public class Employee
    {
        public int id;
        public int importance;
        public IList<int> subordinates;
    }
}
