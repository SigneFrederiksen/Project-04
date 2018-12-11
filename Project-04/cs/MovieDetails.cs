using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;

namespace Project_04.cs
{
    public class MovieDetails
    {

        public void SavePoster(string ImagePoster, string movie_id)
        {
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "SELECT * from Movies";
            string sqlupd = "UPDATE Movies set Movies.Poster = @poster_url Where Movies.ID = @movie_id";

            // SIGNES DB
            SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
            // AMANDAS DB
            //SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");

            conn.Open();

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);
                ds = new DataSet();
                da.Fill(ds, "MoviePoster");
                dt = ds.Tables["MoviePoster"];
                int requestid = Convert.ToInt32(movie_id);
                dt.Rows[requestid]["ID"] = movie_id;
                dt.Rows[requestid]["Poster"] = ImagePoster;
                SqlCommand cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@movie_id", SqlDbType.Int, 50, "ID");
                cmd.Parameters.Add("@poster_url", SqlDbType.Text, 255, "Poster");
                da.UpdateCommand = cmd;
                da.Update(ds, "MoviePoster");
            }
            catch (Exception ex)
            {
                // LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }

    }
}