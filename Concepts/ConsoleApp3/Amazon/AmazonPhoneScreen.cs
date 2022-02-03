using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Amazon
{
    public class AmazonPhoneScreen
    {
        public static void Run()
        {
            List<(string name, int id, int reportsTo)> employeesInfo = new List<(string name, int id, int reportsTo)>();
            employeesInfo.Add(("Khalid", 1, 0));
            employeesInfo.Add(("Alex", 2, 1));
            employeesInfo.Add(("Brein", 3, 2));
            employeesInfo.Add(("Donald", 4, 1));
            employeesInfo.Add(("Hamid", 5, 10));
            employeesInfo.Add(("Jannnifer", 10, 3));

            Dictionary<int, Employee> graph = new Dictionary<int, Employee>();
            graph.Add(0,new Employee(0,string.Empty));
            foreach (var employee in employeesInfo)
            {
                graph.Add(employee.id, new Employee(employee.id, employee.name));
            }

            foreach (var employee in employeesInfo)
            {
                graph[employee.reportsTo].Subordinates.Add(employee.id);                               
            }

            DFS(graph, 1, "");
            Console.ReadLine();

        }
        private static void DFS(Dictionary<int, Employee> graph, int at, string indent)
        {
            string print = indent + graph[at].Name;
            Console.WriteLine(print);
            foreach (int neighborId in graph[at].Subordinates)
            {
                DFS(graph, neighborId, indent + ' ');
            }
        }

    }
    public class Employee
    {
        public int Id;
        public string Name;
        public List<int> Subordinates;
        public Employee(int id)
        {
            Id = id;
            Name = string.Empty;
            Subordinates = new List<int>();

        }
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
            Subordinates = new List<int>();
        }
    }

}
