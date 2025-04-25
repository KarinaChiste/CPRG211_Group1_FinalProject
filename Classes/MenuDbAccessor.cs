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

        public void AddMenuItem(MenuItem item)
        {
            if (item == null)
                throw new ArgumentNullException("All fields must be filled.");

            connection.Open();
            string insertsql = $"Insert into menu(ItemId, ItemName, ItemType, Price) values ('{item.ItemId}', '{item.ItemName}', '{item.ItemType}', '{item.Price}');";
            MySqlCommand insertCommand = new MySqlCommand(insertsql, connection);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public List<MenuItem> GetMenuItems(string idcriteria = null, string namecriteria = null, string typecriteria = null)
        {
            MenuItem newItem = null;
            string sql = string.Empty;
            List<MenuItem> itemList = new List<MenuItem>();
            connection.Open();
            if (idcriteria != null)
            {
                if (namecriteria != null)
                {
                    if (typecriteria != null)
                    {
                        sql = $"Select * from menu where ItemId = '{idcriteria}' and ItemName = '{namecriteria}' and ItemType = '{typecriteria}';";
                    }
                    else
                    {
                        sql = $"Select * from menu where ItemId = '{idcriteria}' and ItemName = '{namecriteria}';";
                    }
                }
                else if (typecriteria != null)
                {
                    sql = $"Select * from menu where ItemId = '{idcriteria}' and ItemType = '{typecriteria}';";
                }
                else
                {
                    sql = $"Select * from menu where ItemId = '{idcriteria}';";
                }
            }
            else if (namecriteria != null)
            {
                if (typecriteria != null)
                {
                    sql = $"Select * from menu where ItemName = '{namecriteria}' and ItemType = '{typecriteria}';";
                }
                else
                {
                    sql = $"Select * from menu where ItemName = '{namecriteria}';";
                }
            }
            else if (typecriteria != null)
            {
                sql = $"Select * from menu where ItemType = '{typecriteria}';";
            }
            
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                string price = reader.GetString(3);
                
                
                if (type == "Appetizer")
                {
                    newItem = new AppetizerType(id, name, type, price);

                }
                else if(type == "Dessert")
                {
                    newItem = new DessertType(id, name, type, price);

                }
                else if (type == "Drink")
                {
                    newItem = new DrinkType(id, name, type, price);
                }
                else if(type == "Main")
                {
                    newItem = new MainType(id, name, type, price);
                }
                else
                {
                    throw new InvalidOperationException($"Unknown menu item type: {type}");
                }
                itemList.Add(newItem);
            }
            connection.Close();
            return itemList;
        }

        public MenuItem GetMenuItem(string itemId)
        {
            MenuItem selectedItem = null;
            connection.Open();
            string sql = $"Select * from menu where ItemId = '{itemId}'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                string price = reader.GetString(3);

                if (type == "Appetizer")
                {
                    selectedItem = new AppetizerType(id, name, type, price);

                }
                else if (type == "Dessert")
                {
                    selectedItem = new DessertType(id, name, type, price);

                }
                else if (type == "Drink")
                {
                    selectedItem = new DrinkType(id, name, type, price);
                }
                else if (type == "Main")
                {
                    selectedItem = new MainType(id, name, type, price);
                }
                else
                {
                    throw new InvalidOperationException($"Unknown menu item type: {type}");
                }

            }
            connection.Close();
            return selectedItem;
        }

        public void RemoveMenuItem(string itemId)
        {
            connection.Open();
            string sql = $"DELETE FROM menu WHERE ItemId = '{itemId}'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
    }
}
