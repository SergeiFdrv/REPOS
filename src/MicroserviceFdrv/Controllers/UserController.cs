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
        public string ConnectionString { get; set; }

        public UserController()
        {
            ConnectionString = string.Empty;//TODO: добавить строку подлюкчения из appsetting
        }

        [Route("login")]
        public IActionResult Login(string username, string passwd = "")
        {
            using (SqlConnection connection = new SqlConnection(Startup.CS))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT id FROM users WHERE username = @username AND passwd = @password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", passwd);
                try
                {
                    int id = (int)command.ExecuteScalar();
                    command.CommandText = "INSERT sessionlog VALUES (@id, @now, 1)";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@now", DateTime.Now);
                    command.ExecuteNonQuery();
                }
                catch { return Ok("User not found"); }
            }
            return Ok("sup, " + username);
        }

        [Route("logout")]
        public IActionResult Logout(int id)
        {
            using (SqlConnection connection = new SqlConnection(Startup.CS))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT sessionlog VALUES (@id, @now, 0)", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@now", DateTime.Now);
                try { command.ExecuteNonQuery(); }
                catch (Exception e) { return Ok(e.Message); }
            }
            return Ok($"bye, user {id}");
        }

        [Route("register")]
        public IActionResult Register(string username, string passwd = "")
        {
            using (SqlConnection connection = new SqlConnection(Startup.CS))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT users VALUES (@name, @pwd)", connection);
                command.Parameters.AddWithValue("@name", username);
                command.Parameters.AddWithValue("@pwd", passwd);
                try { command.ExecuteNonQuery(); }
                catch (Exception e) { return Ok(e.Message); }
            }
            return Ok("welcome, " + username);
        }
    }
}