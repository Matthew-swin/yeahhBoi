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
            this.stringBuilder.DataSource = this.configuration.GetSection("DbConnectionStrings").GetSection("Url").Value;
            this.stringBuilder.InitialCatalog = this.configuration.GetSection("DbConnectionStrings").GetSection("Database").Value;
            this.stringBuilder.UserID = this.configuration.GetSection("DbConnectionStrings").GetSection("User").Value;
            this.stringBuilder.Password = this.configuration.GetSection("DbConnectionStrings").GetSection("Password").Value;
            this.connectionString = this.stringBuilder.ConnectionString;
        }

        [HttpGet("{test}")]
        public string you(string test){
            string connectionStrang = "Server=tcp:oiyou.database.windows.net,1433;Initial Catalog=last;Persist Security Info=False;User ID=bigbob;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //yaya
            SqlConnection conn = new SqlConnection(connectionStrang);
            string queryString = $"Select * From Actor";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader()){}

            }
            catch (System.Exception se)
            {
                
                return $"Cannot Update user with id {test}: " + se.Message;
            }
            return $" Success! Update customer id {test}: \n {cmd.CommandText}";
        }

    }
}