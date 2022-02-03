using System;
using System.Collections.Generic;
using System.Globalization;
using ConsoleTableExt;
using Microsoft.Data.Sqlite;
public class AccessDB {
    
    static string connectionString = @"Data Source=code-tracker.db";
        public static void NewRecord(string userDate, TimeSpan userDuration) {

         using (var connection = new SqliteConnection(connectionString)) {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = 
            $"INSERT INTO code_tracker(date, duration) VALUES('{userDate}', {userDuration.Ticks})";
            tableCmd.ExecuteNonQuery();
               connection.Close();
            }
        Console.WriteLine("Progress Saved!");
    }
    public static void ViewRecords() {
        Console.Clear();

        using (var connection = new SqliteConnection(connectionString)) {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = 
                    $"SELECT * FROM code_tracker ";

                List<CodeTrack> tabledata = new();

                SqliteDataReader reader = tableCmd.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        tabledata.Add(
                            new CodeTrack {
                                Id = reader.GetInt32(0),
                                Date = reader.GetString(1),
                                duration = TimeSpan.FromSeconds(reader.GetDouble(2))
                            }); ;
                    }
                } else {
                    Console.WriteLine("No rows found");
                }

                connection.Close();

            ConsoleTableBuilder
            .From(tabledata)
            .ExportAndWriteLine();

    }
}

public class CodeTrack {
        public int Id {get; set; }
        public string Date {get; set; }
        public TimeSpan duration {get; set; }
    }
}