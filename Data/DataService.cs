using CoreWebApplication1.Services;
using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace CoreWebApplication1.Data
{
    public class DataService
    {
        private readonly string connectionString;
        public DataService(string? connectionString = null) 
        {
            this.connectionString = Path.GetFullPath( "snoozeService.db");
            if (connectionString != null)
            {
                this.connectionString = connectionString.ToLower();
            }
        }

        public void InsertSnoozeMassage(string message, DateTime dateTime)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={connectionString}"))
                {
                    connection.Open();
                    SqliteCommand command = connection.CreateCommand();
                    command.CommandText = @"INSERT INTO snoozedMassages
                                        VALUES (
                                        @massage,
                                        @date,
                                        '0'
                                        );";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqliteParameter("@massage", message));
                    command.Parameters.Add(new SqliteParameter("@date", dateTime));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw(new Exception("Fail to connect the DB or to insert new row", ex));
            }
            
        }

        public List<string> GetMessagesToSend()
        {
            List<string> messages = new List<string>();

            try
            {
                using (var connection = new SqliteConnection($"Data Source={connectionString}"))
                {
                    SqliteCommand command = connection.CreateCommand();
                    command.CommandText = @"SELECT message
                                            FROM snoozedMassages
                                            WHERE NOT isSent AND dateToResend <= DATE();";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqliteDataReader datareader = command.ExecuteReader();
                    while (datareader.Read())
                    {
                        messages.Add(datareader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (new Exception("Fail to connect the DB or to insert new row", ex));
            }


            return messages;
        }

        public List<string> UpdateMessages()
        {
            List<string> messages = new List<string>();

            try
            {
                using (var connection = new SqliteConnection($"Data Source={connectionString}"))
                {
                    SqliteCommand command = connection.CreateCommand();
                    command.CommandText = @"UPDATE snoozedMassages
                                            SET isSent = 1
                                            WHERE NOT isSent AND dateToResend <= DATE();";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw (new Exception("Fail to connect the DB or to insert new row", ex));
            }


            return messages;
        }
    }
}
