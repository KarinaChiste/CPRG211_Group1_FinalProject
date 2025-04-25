using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_FinalProject.Interfaces;
using MySqlConnector;

namespace CPRG211_Group1_FinalProject.Classes
{
    //Connects reservations to the database
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
                        GroupSize VARCHAR(2) NOT NULL,
                        Date VARCHAR(20) NOT NULL,
                        Time VARCHAR(10) NOT NULL);";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void AddReservation(Reservation reservation)
        {
            connection.Open();
            string insertsql = $"Insert into reservations(ReservationId, ReservationName, GroupSize, Date, Time) values ('{reservation.ReservationId}', '{reservation.Name}', '{reservation.GroupSize}', '{reservation.Date}', '{reservation.Time}');";
            MySqlCommand insertCommand = new MySqlCommand(insertsql, connection);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public List<Reservation> GetReservations(string idcriteria = null, string namecriteria = null, string timecriteria = null)
        {
            Reservation newReservation;
            string sql = string.Empty;
            List<Reservation> reservationList = new List<Reservation>();
            connection.Open();
            if (idcriteria != null)
            {
                if (namecriteria != null)
                {
                    if (timecriteria != null)
                    {
                        sql = $"Select * from reservations where ReservationId = '{idcriteria}' and ReservationName = '{namecriteria}' and Time = '{timecriteria}';";
                    }
                    else
                    {
                        sql = $"Select * from reservations where ReservationId = '{idcriteria}' and ReservationName = '{namecriteria}';"; ;
                    }
                }
                else if (timecriteria != null)
                {
                    sql = $"Select * from reservations where ReservationId = '{idcriteria}' and Time = '{timecriteria}';";
                }
                else
                {
                    sql = $"Select * from reservations where ReservationId = '{idcriteria}';";
                }
            }
            else if (namecriteria != null)
            {
                if (timecriteria != null)
                {
                    sql = $"Select * from reservations where ReservationName = '{namecriteria}' and Time = '{timecriteria}';";
                }
                else
                {
                    sql = $"Select * from reservations where ReservationName = '{namecriteria}' ;";
                }
            }
            else if (timecriteria != null)
            {
                sql = $"Select * from reservations where Time = '{timecriteria}';";
            }

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string name = reader.GetString(1);
                string size = reader.GetString(2);
                string date = reader.GetString(3);
                string time = reader.GetString(4);




                newReservation = new Reservation(id, name, size, date, time);
                reservationList.Add(newReservation);
            }
            connection.Close();
            return reservationList;
        }

        public Reservation GetReservation(string reservationId)
        {
            Reservation selectedReservation = null;
            connection.Open();
            string sql = $"Select * from reservations where ReservationId = '{reservationId}'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string name = reader.GetString(1);
                string size = reader.GetString(2);
                string date = reader.GetString(3);
                string time = reader.GetString(4);




                selectedReservation = new Reservation(id, name, size, date, time);

            }
            connection.Close();
            return selectedReservation;
        }

        public void RemoveReservation(string reservationId)
        {
            connection.Open();
            string sql = $"delete from reservations where ReservationId = '{reservationId}'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
    }
}
