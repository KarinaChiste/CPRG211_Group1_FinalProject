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

        public string Salary { get; set; }
        public string StartDate { get; set; }
        public string Hours { get; set; }

        public Employee(string employeeId, string employeeFirstName, string employeeLastName, string position, string salary, string startDate, string hours)
        {
            EmployeeId = employeeId;
            EmployeeFirstName = employeeFirstName;
            EmployeeLastName = employeeLastName;
            Position = position;
            Salary = salary;
            StartDate = startDate;
            Hours = hours;
        }

        public override string ToString()
        {
            return $"{EmployeeId},{EmployeeFirstName},{EmployeeLastName},{Position},{Salary},{StartDate},{Hours}";
        }
    }
}
