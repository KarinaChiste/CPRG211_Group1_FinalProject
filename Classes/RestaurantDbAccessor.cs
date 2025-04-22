using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
//using static Android.Net.Wifi.WifiEnterpriseConfig;


namespace CPRG211_Group1_FinalProject.Classes
{
    public class RestaurantDbAccessor
    {
        protected MySqlConnection connection;

        public RestaurantDbAccessor()
        {
            string dbHost = "localhost";
            string dbUser = "root";
            string dbPassword = "password";

            var builder = new MySqlConnectionStringBuilder
            {
                Server = dbHost,
                UserID = dbUser,
                Password = dbPassword,
                Database = "restaurant",
            };

            connection = new MySqlConnection(builder.ConnectionString);
        }

        public void InitializeDatabase()
        {
            connection.Open();
            string sql = @"CREATE TABLE IF NOT EXISTS staff (
                        EmployeeId VARCHAR(6) PRIMARY KEY,
                        FirstName VARCHAR(20) NOT NULL,
                        LastName VARCHAR(20) NOT NULL,
                        Position VARCHAR(30) NOT NULL,
                        Salary VARCHAR(10) NOT NULL,
                        StartDate VARCHAR(20) NOT NULL,
                        Hours VARCHAR(5) NOT NULL,
                        EmployeeType VARCHAR(40) NOT NULL);";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();            

            connection.Close();

        }

        public void AddEmployee(Employee employee)
        {
            connection.Open();
            string insertsql = $"Insert into staff(EmployeeId, FirstName, LastName, Position, Salary, StartDate, Hours, EmployeeType) values ('{employee.EmployeeId}', '{employee.EmployeeFirstName}', '{employee.EmployeeLastName}', '{employee.Position}', '{employee.Salary}','{employee.StartDate}', '{employee.Hours}', '{employee.EmployeeType}');";
            MySqlCommand insertCommand = new MySqlCommand(insertsql, connection);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public List<Employee> GetEmployees()
        {
            Employee newEmployee;
            List<Employee> employeeList = new List<Employee>();
            connection.Open();
            string sql = $"Select * from staff;";
            MySqlCommand command = new MySqlCommand( sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string first = reader.GetString(1);
                string last = reader.GetString(2);
                string position = reader.GetString(3);
                string salary = reader.GetString(4);
                string start = reader.GetString(5);
                string hours = reader.GetString(6);
                string employeeType = reader.GetString(7);


                //Employee newEmployee = EmployeeManager.CreateEmployee(id, first, last, position, salary, start, hours, employeeType);
                if (employeeType == "Kitchen Staff")
                {
                    newEmployee = new KitchenStaff(id, first, last, position, salary, start, hours, employeeType);
                    
                }
                else
                {
                    newEmployee = new FrontOfHouseStaff(id, first, last, position, salary, start, hours, employeeType);
                    
                }
                employeeList.Add(newEmployee);
            }
            connection.Close();
            return employeeList;
        }

        public Employee GetEmployee(string employeeId)
        {
            Employee selectedEmployee = null;
            connection.Open();
            string sql = $"Select * from staff where EmployeeId = '{employeeId}'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string first = reader.GetString(1);
                string last = reader.GetString(2);
                string position = reader.GetString(3);
                string salary = reader.GetString(4);
                string start = reader.GetString(5);
                string hours = reader.GetString(6);
                string employeeType = reader.GetString(7);


               selectedEmployee = EmployeeManager.CreateEmployee(id, first, last, position, salary, start, hours, employeeType);
            
            }
            connection.Close();
            return selectedEmployee;

        }

        public void RemoveEmployee(string employeeId)
        {
            connection.Open();
            string sql = $"delete from staff where employeeid = '{employeeId}'";
            MySqlCommand command = new MySqlCommand( sql, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
    }
}
