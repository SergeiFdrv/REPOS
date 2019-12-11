using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace MicroserviceFdrv.Controllers
{
    public class NoteController : Controller
    {
        private readonly string connectionString = @"Data Source=KONDR-244\MSSQLSERVER01; Initial Catalog=Computers; Integrated Security=true";
        [Route("addnote")]
        public IActionResult Add(string title = "", string text = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT notes VALUES (@title, @text, @now)", connection);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@text", text);
                command.Parameters.AddWithValue("@now", DateTime.Now);
                try { command.ExecuteNonQuery(); }
                catch (Exception e) { return Ok(e.Message); }
            }
            return Ok("Ok");
        }

        [Route("editnote")]
        public IActionResult Edit(int id, string title = null, string text = null)
        {
            if (title == null && text == null) return Ok("No changes ordered");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE TABLE notes SET " + title == null ? (text == null ? "" : "notetext = @text") : ("title = @title" + text == null ? "" : ", notetext = @text") + " WHERE id = @id", connection);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@text", text);
                command.Parameters.AddWithValue("@id", id);
                try { command.ExecuteNonQuery(); }
                catch (Exception e) { return Ok(e.Message); }
            }
            return Ok("Ok");
        }

        [Route("delnote")]
        public IActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM notes WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                try { command.ExecuteNonQuery(); }
                catch (Exception e) { return Ok(e.Message); }
            }
            return Ok("Ok");
        }
    }
}