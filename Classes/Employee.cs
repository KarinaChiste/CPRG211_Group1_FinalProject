using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_FinalProject.Exceptions;

namespace CPRG211_Group1_FinalProject.Classes
{
    public abstract class Employee
    {
        private string employeeId;
        private string employeeFirstName;
        private string employeeLastName;
        private string position;
        private string salary;
        private string startDate;
        private string hours;
        
        public string EmployeeId { get=> employeeId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Employee ID");
                }

                if (!int.TryParse(value, out int parsedId))
                {
                    throw new InvalidFormatException("EmployeeID must be a numeric value.");
                }

                if (parsedId < 0)
                {
                    throw new InvalidFormatException("Employee ID cannot be negative.");
                }

                if (value.Length != 6)
                {
                    throw new InvalidFormatException("Employee ID must be exactly 6 digits long.");
                }

                employeeId = value;
            }
        }
        public string EmployeeFirstName { get => employeeFirstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("First Name");
                }
                employeeFirstName = value;
            }
        }
        public string EmployeeLastName { get => employeeLastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Last Name");
                }
                employeeLastName = value;
            }
        }
        public string Position { get => position;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Position");
                }
                position = value;
            }
        }

        public string Salary { get => salary;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Salary");
                }
                salary = value;
            }
        }
        public string StartDate { get => startDate;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Start Date");
                }
                startDate = value;
            }
        }
        public string Hours { get => hours;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Hours");
                }
                hours = value;
            }
        }

        public string EmployeeType { get; set; }

        public Employee(string employeeId, string employeeFirstName, string employeeLastName, string position, string salary, string startDate, string hours, string employeeType)
        {
            EmployeeId = employeeId;
            EmployeeFirstName = employeeFirstName;
            EmployeeLastName = employeeLastName;
            Position = position;
            Salary = salary;
            StartDate = startDate;
            Hours = hours;
            EmployeeType = employeeType;
        }

        public override string ToString()
        {
            return $"{EmployeeId},{EmployeeFirstName},{EmployeeLastName},{Position},{Salary},{StartDate},{Hours},{EmployeeType}";
        }

        public abstract string GetStaffType();
       
    }
}
