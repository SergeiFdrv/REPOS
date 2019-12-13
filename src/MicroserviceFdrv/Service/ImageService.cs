using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace MicroserviceFdrv.Service
{
    public class ImageService
    {
        public void SaveImageToDb(string base64, string fname, string fpath)
        {
            string md = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MicroserviceApp";
            if (!Directory.Exists(md))
            {
                Directory.CreateDirectory(md);
            }
            if (!Directory.Exists(md + "\\Images"))
            {
                Directory.CreateDirectory(md + "\\Images");
            }
            File.WriteAllBytes(md + "\\Images\\" + fname + ".jpg", Convert.FromBase64String(base64));
            SqlConnection connection = new SqlConnection(Startup.CS);
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT images VALUES (@fname, @fpath)", connection);
            command.Parameters.AddWithValue("@fname", fname);
            command.Parameters.AddWithValue("@fpath", fpath);
            command.ExecuteNonQuery();
        }

        public string LoadImage(int id)
        {
            SqlConnection connection = new SqlConnection(Startup.CS);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT fpath FROM images WHERE id = @imageid", connection);
            command.Parameters.AddWithValue("@imageid", id);
            try { return Convert.ToBase64String(File.ReadAllBytes(command.ExecuteScalar().ToString())); }
            catch { return string.Empty; }
        }

        public void DeleteImage(int id)
        {
            SqlConnection connection = new SqlConnection(Startup.CS);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT fpath FROM images WHERE id = @imageid", connection);
            command.Parameters.AddWithValue("@imageid", id);
            string file;
            try { file = command.ExecuteScalar().ToString(); }
            catch { return; }
            command.CommandText = "SELECT COUNT(id) FROM noteimages WHERE imageid = @imageid";
            if ((int)command.ExecuteScalar() == 0)
            {
                command.CommandText = "DELETE FROM images WHERE fpath = @path";
                command.ExecuteNonQuery();
            }
        }
    }
}
