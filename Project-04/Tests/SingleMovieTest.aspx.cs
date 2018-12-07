using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;

namespace Project_04.Tests
{
    public partial class SingleMovieTest : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
        SqlCommand cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            string movieid = Request.QueryString["ID"];
            string movietitle = Request.QueryString["Title"];
            string movieyear = Request.QueryString["Year"];
            string moviegenre = Request.QueryString["Genre"];

            string sqlsel = "SELECT * From Movies Left Join Genre On Movies.GenreID = Genre.ID WHERE ID = 'movieid'";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);

                cmd.Parameters.Add("@Title", SqlDbType.Text).Value = LabelTitle.Text;
                cmd.Parameters.Add("@Year", SqlDbType.Text).Value = LabelYear.Text;
                cmd.Parameters.Add("@Genre", SqlDbType.Text).Value = LabelGenre.Text;

                LabelTitle.Text = movietitle;
                LabelYear.Text = movieyear;
                LabelGenre.Text = moviegenre;
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }


            // Activates the ViewCount method.
            ViewCount();

        }


        // Adds a timestamp of the selected movie to the database table Views. 
        // Used to finding the most popular movies and for analytics.
        public void ViewCount()
        {

            string movieid = Request.QueryString["ID"];
            DateTime dateTimeVariable = DateTime.Now;

            string sqlupd = "INSERT INTO Views VALUES (@Datetime, @movieid)";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.AddWithValue("@Datetime", dateTimeVariable);
                cmd.Parameters.AddWithValue("@movieid", movieid);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }

    }
}