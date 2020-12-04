using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace models
{
    public class Movie
    {
        public int movieNo { get; set; }
        public string title { get; set; }
        public Int16 relYear { get; set; }
        public Int16 runTime { get; set; }
        //
        public int methodBitch;
        // SQL interfaces and objects
        IConfiguration configuration;
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        string connectionString;
        
        public Movie(){}
        public Movie(IConfiguration iconfig)
        {
            
            
            this.configuration = iconfig;
            try
            {
                this.stringBuilder.DataSource = "no.database.here.com";
                this.stringBuilder.InitialCatalog = "ls";
                this.stringBuilder.UserID = "Wally";
                this.stringBuilder.Password = "Where";
                this.connectionString = this.stringBuilder.ConnectionString;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

                this.stringBuilder.DataSource = this.configuration.GetSection("DbConnectionStrings").GetSection("Url").Value;
                this.stringBuilder.InitialCatalog = this.configuration.GetSection("DbConnectionStrings").GetSection("Database").Value;
                this.stringBuilder.UserID = this.configuration.GetSection("DbConnectionStrings").GetSection("User").Value;
                this.stringBuilder.Password = this.configuration.GetSection("DbConnectionStrings").GetSection("Password").Value;
                this.connectionString = this.stringBuilder.ConnectionString;
            }

        }
        //end of SQL stuff

        //methods to test
        public int NumActor()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string queryString = $"Select count(ACTORNO) FROM CASTING C LEFT JOIN MOVIE M ON M.MOVIENO = C.MOVIENO WHERE M.TITLE = {this.title}";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    this.methodBitch = (int)reader[0];         
                }
            }

            return methodBitch;
        }

        public int GetAge()
        {
            DateTime currentDateTime = DateTime.Now;
            currentDateTime.ToString("yyyy");
            int currdate = Convert.ToInt32(currentDateTime);

            SqlConnection conn = new SqlConnection(connectionString);
            string queryString = $"Select Relyear From Movie where Title = {this.title}";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    this.relYear = (Int16)reader[0];
                }
            }
            int poop;
            return poop = currdate - (int)this.relYear;
        }
    }
}