using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_FinalProject.Components.Pages;
using CPRG211_Group1_FinalProject.Exceptions;
//using static Android.Icu.Text.Transliterator;

namespace CPRG211_Group1_FinalProject.Classes
{
    //Creates employee objects
    class EmployeeManager
    {
        public static List<Employee> employees = new List<Employee>();

        

        public static List<Employee> GetEmployees()
        {
            
            return employees;
        }
        public static  Employee CreateEmployee(string employeeId, string employeeFirstName, string employeeLastName, string position, string salary, string startDate, string hours, string employeeType)
        {
            Employee emp = null;
            if(employeeType == "Kitchen Staff")
            {
                emp = new KitchenStaff(employeeId, employeeFirstName, employeeLastName, position, salary, startDate, hours, employeeType);
                employees.Add(emp);
               
            }
            else if (employeeType == "Front of House")
            {
                emp = new FrontOfHouseStaff(employeeId, employeeFirstName, employeeLastName, position, salary, startDate, hours, employeeType);
                employees.Add(emp);
                
            }
            else
            {
                throw new TypeNotSelectedException();
            }

                EmployeeDbAccessor db = new EmployeeDbAccessor();
            db.AddEmployee(emp);
            return emp;
            
        }
        
    }
}
