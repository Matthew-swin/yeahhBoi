using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using models;

namespace Film.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        IConfiguration configuration;
        string connectionString;
        Actor actor1 = new Actor();
        Movie movie1 = new Movie();

        public FilmController(IConfiguration iconfig)
        {
            this.configuration = iconfig;
            try{
                this.stringBuilder.DataSource = "no.database.here.com";
                this.stringBuilder.InitialCatalog = "ls";
                this.stringBuilder.UserID = "Wally";
                this.stringBuilder.Password = "Where";
                this.connectionString = this.stringBuilder.ConnectionString;
            }
            catch (SqlException e) {
                Console.WriteLine(e.Message);
            }
            finally {
                
                this.stringBuilder.DataSource = this.configuration.GetSection("DbConnectionStrings").GetSection("Url").Value;
                this.stringBuilder.InitialCatalog = this.configuration.GetSection("DbConnectionStrings").GetSection("Database").Value;
                this.stringBuilder.UserID = this.configuration.GetSection("DbConnectionStrings").GetSection("User").Value;
                this.stringBuilder.Password = this.configuration.GetSection("DbConnectionStrings").GetSection("Password").Value;
                this.connectionString = this.stringBuilder.ConnectionString;
            }
            
        }

        [HttpGet("{test}")]
        public List<Actor> you(string test){
            string connectionStrang = "Server=tcp:oiyou.database.windows.net,1433;Initial Catalog=last;Persist Security Info=False;User ID=bigbob;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //yaya
            List<Actor> weewee = new List<Actor>();
            SqlConnection conn = new SqlConnection(connectionStrang);
            string queryString = $"Select * From Actor";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            string result = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result += reader[0] + " | " + reader[1] + reader[2] + "\n";

                    weewee.Add(
                        new Actor()
                        {
                            actorNo = (int)reader[0],
                            fullName = reader[1].ToString(),
                            firstName = reader[2].ToString(),
                            lastName = reader[3].ToString()
                        });
                }
            }
            return weewee;
        }

        [HttpGet("rtask1")]
        public List<Movie> ReadTask1(){
            string connectionStrang = "Server=tcp:oiyou.database.windows.net,1433;Initial Catalog=last;Persist Security Info=False;User ID=bigbob;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //yaya
            List<Movie> Movies = new List<Movie>();
            SqlConnection conn = new SqlConnection(connectionStrang);
            string queryString = $"Select * From Movie";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            string result = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result += reader[0] + " | " + reader[1] + reader[2] + reader[3] + "\n";

                    Movies.Add(
                        new Movie()
                        {
                            movieNo = (int)reader[0],
                            title = reader[1].ToString(),
                            relYear = (Int16)reader[2],
                            runTime = (Int16)reader[3]
                        });
                }
            }
            return Movies;
        }

        [HttpGet("rtask2")]
        public List<Movie> ReadTask2(){
            string connectionStrang = "Server=tcp:oiyou.database.windows.net,1433;Initial Catalog=last;Persist Security Info=False;User ID=bigbob;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //yaya
            List<Movie> Movies = new List<Movie>();
            SqlConnection conn = new SqlConnection(connectionStrang);
            string queryString = $"Select * From Movie Where Title like 'The%' or Title like 'the%'";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            string result = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result += reader[0] + " | " + reader[1] + reader[2] + reader[3] + "\n";

                    Movies.Add(
                        new Movie()
                        {
                            movieNo = (int)reader[0],
                            title = reader[1].ToString(),
                            relYear = (Int16)reader[2],
                            runTime = (Int16)reader[3]
                        });
                }
            }
            return Movies;
        }


        [HttpGet("rtask3")]
        public List<rt3> ReadTask3(){
            string connectionStrang = "Server=tcp:oiyou.database.windows.net,1433;Initial Catalog=last;Persist Security Info=False;User ID=bigbob;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //yaya
            List<rt3> Movies = new List<rt3>();
            SqlConnection conn = new SqlConnection(connectionStrang);
            string queryString = $"SELECT TITLE FROM MOVIE M LEFT JOIN CASTING C on C.MOVIENO = M.MOVIENO LEFT JOIN ACTOR A on C.ACTORNO = A.ACTORNO WHERE FULLNAME = 'Luke Wilson'";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            string result = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result += reader[0] + "\n";

                    Movies.Add(
                        new rt3()
                        {
                            title = reader[0].ToString(),
                        });
                }
            }
            return Movies;
        }

        [HttpGet("rtask4")]
        public int ReadTask4(){
            string connectionStrang = "Server=tcp:oiyou.database.windows.net,1433;Initial Catalog=last;Persist Security Info=False;User ID=bigbob;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //yaya
            List<Movie> Movies = new List<Movie>();
            SqlConnection conn = new SqlConnection(connectionStrang);
            string queryString = $"Select * From Movie";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            string result = "";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result += reader[0] + " | " + reader[1] + reader[2] + reader[3] + "\n";

                    Movies.Add(
                        new Movie()
                        {
                            movieNo = (int)reader[0],
                            title = reader[1].ToString(),
                            relYear = (Int16)reader[2],
                            runTime = (Int16)reader[3]
                        });
                }
            }
            int total = 0;
            foreach (var movie in Movies)
            {   
                total = total + (int)movie.runTime;
            }
            return total;
        }



    }
}