using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace MicroserviceFdrv.Controllers
{
    public class PCController : Controller
    {
        public string ConnectionString { get; set; }

        public PCController()
        {
            ConnectionString = string.Empty;//TODO: добавить строку подлюкчения из appsetting
        }

        [Route("getpc")]
        public IActionResult Get()
        {
            List<PC> PCs = new List<PC>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM pc", connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    PCs.Add(new PC
                    {
                        Model = (short)dataReader["model"],
                        Speed = (short)dataReader["speed"],
                        Ram = (short)dataReader["ram"],
                        Hd = (short)dataReader["hd"],
                        Rd = dataReader["rd"].ToString(),
                        Price = (int)dataReader["price"]
                    });
                }
                dataReader.Close();
            }
            return Json(PCs);
        }

        [Route("savepc")]
        public IActionResult Add(short model, short speed, short ram, short hd, string rd, int price)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT pc VALUES (@model, @speed, @ram, @hd, @rd, @price)", connection);
                    command.Parameters.AddWithValue("@model", model);
                    command.Parameters.AddWithValue("@speed", speed);
                    command.Parameters.AddWithValue("@ram", ram);
                    command.Parameters.AddWithValue("@hd", hd);
                    command.Parameters.AddWithValue("@rd", rd.Length < 10 ? rd : rd.Substring(0, 10));
                    command.Parameters.AddWithValue("@price", price);
                    command.ExecuteNonQuery();
                }
                return Ok("Ok");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        } // https://localhost:44366/savepc?model=1100&speed=1000&ram=128&hd=100&rd=16xDVD&price=5000
    }
}