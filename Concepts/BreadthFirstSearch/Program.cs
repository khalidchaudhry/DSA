using BreadthFirstSearch.Easy;
using System;
using System.Collections.Generic;

namespace BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // [[1, 5, [2, 3]], [2, 3, []], [3, 3, []]], 1
            Employee e = new Employee();
            e.id = 1;
            e.importance = 5;
            e.subordinates = new List<int> { 2, 3 };

            Employee e2 = new Employee();
            e2.id = 2;
            e2.importance = 3;
            e2.subordinates = new List<int> { };

            Employee e3 = new Employee();
            e3.id = 3;
            e3.importance = 3;
            e3.subordinates = new List<int> { };

            List<Employee> employees = new List<Employee>();

            employees.Add(e);
            employees.Add(e2);
            employees.Add(e3);

            _690 EmployeeImportance = new _690();

            Console.WriteLine(EmployeeImportance.GetImportance(employees,1));


            Console.ReadLine();
        }
    }
}
