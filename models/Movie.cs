using System;
using System.Collections.Generic;
// using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace models
{
    public class Movie
    {
        public int movieNo { get; set; }
        public string title { get; set; }
        public Int16 relYear { get; set; }
        public Int16 runTime { get; set; }
        
        
        //use dis in controller
        public DateTime currentDateTime = DateTime.Now;

        // SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        // IConfiguration configuration;
        // string connectionString;

        //     public int NumActors(string movieName){
        //     List<Movie> Movies = new List<Movie>();
        //     SqlConnection conn = new SqlConnection(connectionString);
        //     string queryString = $"Select * From Movie";
        //     SqlCommand cmd = new SqlCommand(queryString, conn);
        //     conn.Open();
        //     string result = "";
        //     using (SqlDataReader reader = cmd.ExecuteReader())
        //     {
        //         while (reader.Read())
        //         {
        //             result += reader[0] + " | " + reader[1] + reader[2] + reader[3] + "\n";

        //             Movies.Add(
        //                 new Movie()
        //                 {
        //                     movieNo = (int)reader[0],
        //                     title = reader[1].ToString(),
        //                     relYear = (Int16)reader[2],
        //                     runTime = (Int16)reader[3]
        //                 });
        //                 reader.Close();
        //         }
        //     }
        //     int total = 0;
        //     foreach (var movie in Movies)
        //     {   
        //         total = total + (int)movie.runTime;
        //     }
        //     return total;
        // }
    }
}