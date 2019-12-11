using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace MicroserviceFdrv.Controllers
{
    public class UserController : Controller
    {
        private readonly string connectionString = @"Data Source=KONDR-244\MSSQLSERVER01; Initial Catalog=Computers; Integrated Security=true";
        [Route("login")]
        public IActionResult Login(string username, string passwd = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT id FROM users WHERE username = @username AND passwd = @password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", passwd);
                try { int id = (int)command.ExecuteScalar(); }
                catch { return Ok("User not found"); }
            }
            return Ok("Ok");
        }

        [Route("register")]
        public IActionResult Register(string username, string passwd = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT users VALUES (@name, @pwd)", connection);
                command.Parameters.AddWithValue("@name", username);
                command.Parameters.AddWithValue("@pwd", passwd);
                try { int id = (int)command.ExecuteScalar(); }
                catch { return Ok("User not found"); }
            }
            return Ok("Ok");
        }
    }
}