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
        //need for numActors method
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

                this.stringBuilder.DataSource = "oiyou.database.windows.net";
                this.stringBuilder.InitialCatalog = "last";
                this.stringBuilder.UserID = "bigbob";
                this.stringBuilder.Password = "Password1234";
                this.connectionString = this.stringBuilder.ConnectionString;
            }

        }
        public void setConnectionString(){
            this.stringBuilder.DataSource = "oiyou.database.windows.net";
                this.stringBuilder.InitialCatalog = "last";
                this.stringBuilder.UserID = "bigbob";
                this.stringBuilder.Password = "Password1234";
                this.connectionString = this.stringBuilder.ConnectionString;
        }
        //end of SQL stuff

        //methods to test
        //adding parameter title for numactors to make it easier for testing
        public int NumActor(string title)
        {
            this.title = title;
            SqlConnection conn = new SqlConnection(connectionString);
            string queryString = $"Select count(ACTORNO) FROM CASTING C LEFT JOIN MOVIE M ON M.MOVIENO = C.MOVIENO WHERE M.TITLE = '{this.title}'";
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

        public int GetAge(string title)
        {
            this.title = title;
            DateTime currentDateTime = DateTime.Today;
            int curr = Convert.ToInt32(currentDateTime.Year);      
            SqlConnection conn = new SqlConnection(connectionString);
            string queryString = $"Select Relyear From Movie where Title = '{this.title}'";
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
            return poop = curr - (int)this.relYear;
        }
    }
}