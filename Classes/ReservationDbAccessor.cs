using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_FinalProject.Interfaces;
using MySqlConnector;

namespace CPRG211_Group1_FinalProject.Classes
{
    public class ReservationDbAccessor : IDatabase
    {
        protected MySqlConnection connection;

        public ReservationDbAccessor()
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
            string sql = @"CREATE TABLE IF NOT EXISTS reservations (
                        ReservationId VARCHAR(6) PRIMARY KEY,
                        ReservationName VARCHAR(20) NOT NULL,
                        NumOfPeople VARCHAR(2) NOT NULL,
                        Date VARCHAR(20) NOT NULL,
                        Time VARCHAR(10) NOT NULL);";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
