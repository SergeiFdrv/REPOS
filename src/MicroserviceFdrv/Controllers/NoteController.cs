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
        [Route("addnote")]
        public IActionResult Add(string title, string text)
        {
            if(string.IsNullOrEmpty(title) || string.IsNullOrEmpty(text))
            {
                return null;
            }

            using (SqlConnection connection = new SqlConnection(Startup.CS))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT notes VALUES (@title, @text, @now)", connection);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@text", text);
                command.Parameters.AddWithValue("@now", DateTime.Now);
                try { command.ExecuteNonQuery(); }
                catch (Exception e) { return Ok(e.Message); }
            }
            return Ok(title + " added");
        }

        [Route("editnote")]
        public IActionResult Edit(int id, string title, string text)
        {
            bool notitle = string.IsNullOrEmpty(title), notext = string.IsNullOrEmpty(text);
            if (notitle && notext || id == 0)
            {
                return Ok("Could not edit note");
            }
            using (SqlConnection connection = new SqlConnection(Startup.CS))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE notes SET " + (notitle ? (notext ? "" : "notetext = @text") : ("title = @title" + (notext ? "" : ", notetext = @text"))) + " WHERE id = @id", connection);
                if (!notitle) command.Parameters.AddWithValue("@title", title);
                if (!notext) command.Parameters.AddWithValue("@text", text);
                command.Parameters.AddWithValue("@id", id);
                try { command.ExecuteNonQuery(); }
                catch (Exception e) { return Ok(e.Message); }
            }
            return Ok($"note {id} changes submitted");
        }

        [Route("delnote")]
        public IActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Startup.CS))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM notes WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                try { command.ExecuteNonQuery(); }
                catch (Exception e) { return Ok(e.Message); }
            }
            return Ok($"note {id} deleted");
        }
    }
}