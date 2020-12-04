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


        public FilmController(IConfiguration iconfig)
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

        [HttpGet("{test}")]
        public List<Actor> you(string test)
        {
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
                            givenName = reader[2].ToString(),
                            surname = reader[3].ToString()
                        });
                }
            }
            return weewee;
        }

        [HttpGet("rtask1")]
        public List<Movie> ReadTask1()
        {
            //for da test
            //string connectionStrang = "Server=tcp:oiyou.database.windows.net,1433;Initial Catalog=last;Persist Security Info=False;User ID=bigbob;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            List<Movie> Movies = new List<Movie>();
            SqlConnection conn = new SqlConnection(connectionString);
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
        public List<Movie> ReadTask2()
        {
            List<Movie> Movies = new List<Movie>();
            SqlConnection conn = new SqlConnection(connectionString);
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
        public List<rt3> ReadTask3()
        {
            List<rt3> Movies = new List<rt3>();
            SqlConnection conn = new SqlConnection(connectionString);
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
        public int ReadTask4()
        {
            List<Movie> Movies = new List<Movie>();
            SqlConnection conn = new SqlConnection(connectionString);
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
                    reader.Close();
                }
            }
            int total = 0;
            foreach (var movie in Movies)
            {
                total = total + (int)movie.runTime;
            }
            return total;
        }

        [HttpPut("{title}/{movieRuntime}")]
        public string upDateTask1(string title, int movieRuntime)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string queryString = $"Update Movie Set RUNTIME = {movieRuntime} Where Title like '%{title}%'";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader()) { }
            }
            catch (System.Exception se)
            {

                return $"Cannot Update Movie with Title {title}: " + se.Message;
            }
            return $" Success! Updated Movie with Title {title}: \n {cmd.CommandText}";
        }

        [HttpPut("poop/{NewActorName}/{ActorFirstName}/{ActorCurrentSurname}")]
        public string upDateTask2(string NewActorName, string ActorFirstName, string ActorCurrentSurname)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string queryString = $"UPDATE ACTOR SET SURNAME = '{NewActorName}', FULLNAME = '{ActorFirstName} {NewActorName}'  WHERE GIVENNAME = '{ActorFirstName}' AND SURNAME = '{ActorCurrentSurname}'";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader()) { }
                conn.Close();
            }
            catch (System.Exception se)

            {

                return $"Cannot Update Actor {ActorFirstName} {ActorCurrentSurname}: " + se.Message;
            }
            return $" Success! Updated Actor {ActorFirstName} {ActorCurrentSurname} to {ActorFirstName} {NewActorName} : \n {cmd.CommandText}";
        }

        [HttpPost("createTask1")]
        public string createTask1(Movie p)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string queryString = $"INSERT INTO MOVIE (MOVIENO, TITLE, RELYEAR, RUNTIME) VALUES ('{p.movieNo}','{p.title}','{p.relYear}','{p.runTime}')";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader()) { }
                conn.Close();
            }
            catch (System.Exception se)

            {

                return $"Cannot add the new movie {p.title}: " + se.Message;
            }
            return $" Success! have added the new movie {p.title}: \n {cmd.CommandText}";
        }

        [HttpPost("createTask2")]
        public string createTask2(Actor p)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string queryString = $"INSERT INTO ACTOR (ACTORNO, FULLNAME, GIVENNAME, SURNAME) VALUES ({p.actorNo}, '{p.givenName}', '{p.surname}', '{p.fullName}')";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader()) { }
                conn.Close();
            }
            catch (System.Exception se)

            {

                return $"I Cannot add the new Actor {p.fullName}: \n {se.Message}";
            }
            return $" Success! I have added the new Actor {p.fullName}: \n {cmd.CommandText}";
        }

        [HttpPost("createTask3")]
        public string createTask3(ct3 what)
        {
            //setting up object to get castid (from user input). 
            //from below queries the actorno and movie no
            cast bob = new cast();
            bob.castId = what.castID;
            SqlConnection conn = new SqlConnection(connectionString);
            //get actor no----------------------
            string ActorString =
                $"SELECT ACTORNO FROM ACTOR WHERE FULLNAME = '{what.actorName}' ";

            SqlCommand cmd = new SqlCommand(ActorString, conn);
            conn.Open();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        bob.actorNo = (int)reader[0];
                    }
                }
                conn.Close();
            }
            catch (System.Exception se)

            {

                return $"I cannot add the actor {what.actorName}: {se.Message}";

            }
            //got actor no----------------------
            //get movie no----------------------
            string MovieString =
                $"SELECT MOVIENO FROM MOVIE WHERE TITLE = '{what.movieTitle}'";

            cmd = new SqlCommand(MovieString, conn);
            conn.Open();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        bob.movieNo = (int)reader[0];
                    }
                }
                conn.Close();
            }
            catch (System.Exception se)

            {

                return $"I cannot add the movie {what.movieTitle}: " + se.Message;

            }
            //got movie no----------------------
            //insert into cast----------------------
            string theInserter = $"INSERT INTO CASTING (CASTID, ACTORNO, MOVIENO) VALUES ({bob.castId},{bob.actorNo}, {bob.movieNo})";
            cmd = new SqlCommand(theInserter, conn);
            conn.Open();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) { }

                }
                conn.Close();
            }
            catch (System.Exception se)

            {

                return $"I cannot add the {what.actorName} to the cast: " + se.Message;
            }
            return $"Success! I have add {what.actorName} to the cast of {what.movieTitle}: \n {cmd.CommandText}";
        }


    }
}