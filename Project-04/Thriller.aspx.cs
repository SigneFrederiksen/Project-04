using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace Project_04
{
    public partial class Thriller : System.Web.UI.Page
    {
        // Connection to Database with SQL Selection
        // SIGNES DB
        // SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
        // AMANDAS DB
        SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqlsel = "SELECT * From Movies Left Join Genre On Movies.GenreID = Genre.ID WHERE Genre LIKE '%thriller%' ORDER BY Title asc";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Use method for showing the Movie data from Database
            ShowMovieData();
        }

        // Create method for our Movie data
        public void ShowMovieData()
        {
            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();
                RepeaterThriller.DataSource = rdr;
                RepeaterThriller.DataBind();
            }
            catch (Exception ex)
            {
                //  LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}