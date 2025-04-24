using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_FinalProject.Interfaces;
using MySqlConnector;

namespace CPRG211_Group1_FinalProject.Classes
{
    public class MenuDbAccessor : IDatabase
    {
        protected MySqlConnection connection;

        public MenuDbAccessor()
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
            string sql = @"CREATE TABLE IF NOT EXISTS menu (
                        ItemId VARCHAR(6) PRIMARY KEY,
                        ItemName VARCHAR(20) NOT NULL,
                        ItemType VARCHAR(20) NOT NULL,
                        Price VARCHAR(6) NOT NULL);";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
