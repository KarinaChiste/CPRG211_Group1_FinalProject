using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_FinalProject.Components.Pages;
//using static Android.Icu.Text.Transliterator;

namespace CPRG211_Group1_FinalProject.Classes
{
    class EmployeeManager
    {
        public static List<Employee> employees = new List<Employee>();

        //public static Employee emp = new KitchenStaff("123", "Bob", "Jones", "Chef", "500", "April 5 2024", "40", "Kitchen Staff");

        public static List<Employee> GetEmployees()
        {
            //employees.Add(emp);
            return employees;
        }
         public static  Employee CreateEmployee(string employeeId, string employeeFirstName, string employeeLastName, string position, string salary, string startDate, string hours, string employeeType)
        {
            Employee emp = null;
            if(employeeType == "Kitchen Staff")
            {
                emp = new KitchenStaff(employeeId, employeeFirstName, employeeLastName, position, salary, startDate, hours, employeeType);
                employees.Add(emp);
                //return emp;
            }
            else
            {
                emp = new FrontOfHouseStaff(employeeId, employeeFirstName, employeeLastName, position, salary, startDate, hours, employeeType);
                employees.Add(emp);
                //return emp;
            }

            EmployeeDbAccessor db = new EmployeeDbAccessor();
            db.AddEmployee(emp);
            return emp;
            //Employee employee = new Employee(employeeid, firstname, lastname, position, salary, startdate, hours);
            //EmployeeManager.employees.Add(employee);
        }
        
    }
}
