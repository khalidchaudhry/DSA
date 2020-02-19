using System;
using System.Collections.Generic;
using System.Text;

namespace BreadthFirstSearch.Easy
{
    class _690
    {

        public int GetImportance(List<Employee> employees, int id)
        {
            int importance = 0;
            Employee e = null;
            foreach (Employee employee in employees)
            {
                if (employee.id == id)
                {
                    importance += employee.importance;
                    e = employee;
                    break;
                }
            }
            foreach (int subordinate in e.subordinates)
            {
                importance += employees.Find(x => x.id == subordinate).importance;
            }

            return importance;
        }
    }

    class Employee
    {
        // It's the unique id of each node;
        // unique id of this employee
        public int id;
        // the importance value of this employee
        public int importance;
        // the id of direct subordinates
        public List<int> subordinates;
    }
}
