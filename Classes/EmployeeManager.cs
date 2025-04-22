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
        public static Employee emp = new KitchenStaff("123", "Bob", "Jones", "Chef", "500", "April 5 2024", "40");
        public static void addDemoEmployee()
        {
            employees.Add(emp);
        }

        public static List<Employee> GetEmployees()
        {
            return employees;
        }
        public static string CreateEmployee(string employeeId, string employeeFirstName, string employeeLastName, string position, string salary, string startDate, string hours, string employeeType)
        {
            foreach (Employee emp in employees)
            {
                if (emp.EmployeeId == employeeId)
                {
                    return "Employee with this ID Already exists!";
                }
            }
            if (employeeType == "KitchenStaff")
            {
                Employee emp = new KitchenStaff(employeeId, employeeFirstName, employeeLastName, position, salary, startDate, hours);
                employees.Add(emp);
            }
            else
            {
                Employee emp = new FrontOfHouseStaff(employeeId, employeeFirstName, employeeLastName, position, salary, startDate, hours);
                employees.Add(emp);
            }
            return "Employee Created!";
            //Employee employee = new Employee(employeeid, firstname, lastname, position, salary, startdate, hours);
            //EmployeeManager.employees.Add(employee);
        }
        public static void EditEmployee(string employeeId, string edFName, string edLName, string edPosition, string edSalary, string edStartDate, string edHours)
        {
            Employee edited = null;

            foreach (Employee emp in employees)
            {
                if (emp.EmployeeId == employeeId)
                {
                    edited = emp;
                    break;
                }
            }
            if (edited != null)
            {
                if(!string.IsNullOrEmpty(edFName))
                {
                    edited.EmployeeFirstName = edFName;
                }
                if(!string.IsNullOrEmpty(edLName))
                {
                    edited.EmployeeLastName = edLName;
                }
                if(!string.IsNullOrEmpty(edPosition))
                {
                    edited.Position = edPosition;
                }
                if(!string.IsNullOrEmpty(edSalary))
                {
                    edited.Salary = edSalary;
                }
                if(!string.IsNullOrEmpty(edStartDate))
                {
                    edited.StartDate = edStartDate;
                }
                if(!string.IsNullOrEmpty(edHours))
                {
                    edited.Hours = edHours;
                }
            }
        }

        public static void RemoveEmployee(string employeeId)
        {
            Employee removed = null;

            foreach (Employee emp in employees)
            {
                if (emp.EmployeeId == employeeId)
                {
                    removed = emp;
                    break;
                }
            }
            if (removed != null)
            {
                employees.Remove(removed);
            }
        }
    }
}
