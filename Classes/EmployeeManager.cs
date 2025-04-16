using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_FinalProject.Components.Pages;

namespace CPRG211_Group1_FinalProject.Classes
{
    class EmployeeManager
    {
        public static List<Employee> employees = new List<Employee>();

        public static Employee emp = new Employee("123", "Bob", "Jones", "Chef", "500", "April 5 2024", "40");

        public static List<Employee> GetEmployees()
        {
            employees.Add(emp);
            return employees;
        }
    }
}
