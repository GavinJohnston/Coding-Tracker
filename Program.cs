using System;
using Microsoft.Data.Sqlite;

namespace codingTracker
{
    class Program
    {

        static string connectionString = @"Data Source=code-tracker.db";
        static void Main(string[] args)
        {
            using(var connection = new SqliteConnection(connectionString)) {
                connection.Open();
                
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS code_tracker (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        date TEXT,
                        duration INTEGER
                        )";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }

            GetUserInput.UserInput();
        }
    }
}
