using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Classes
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string Position { get; set; }

        public double Salary { get; set; }
        public string StartDate { get; set; }
        public double Hours { get; set; }

        public Employee(string employeeId, string employeeFirstName, string employeeLastName, string position, double salary, string startDate, double hours)
        {
            EmployeeId = employeeId;
            EmployeeFirstName = employeeFirstName;
            EmployeeLastName = employeeLastName;
            Position = position;
            Salary = salary;
            StartDate = startDate;
            Hours = hours;
        }
    }
}
