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
    public class TrailerDetails
    {
        public void SaveTrailerID(string tmdbTrailerID, string movie_id)
        {
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "SELECT * from Movies";
            string sqlupd = "UPDATE Movies set Movies.Trailer = @trailer_id Where Movies.ID = @movie_id";

            // SIGNES DB
            //SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
            // AMANDAS DB
            SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");

            conn.Open();

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);
                ds = new DataSet();
                da.Fill(ds, "MovieTrailer");
                dt = ds.Tables["MovieTrailer"];
                int requestid = Convert.ToInt32(movie_id);
                dt.Rows[requestid]["ID"] = movie_id;
                dt.Rows[requestid]["Trailer"] = tmdbTrailerID;
                SqlCommand cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@movie_id", SqlDbType.Int, 50, "ID");
                cmd.Parameters.Add("@trailer_id", SqlDbType.Text, 50, "Trailer");
                da.UpdateCommand = cmd;
                da.Update(ds, "MovieTrailer");

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