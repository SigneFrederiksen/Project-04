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

namespace Project_04
{
    public partial class SingleMovie : System.Web.UI.Page
    {
        //AMANDAS DB
       
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");
            SqlCommand cmd = null;

            string movieid = Request.QueryString["Id"];
            string movietitle = Request.QueryString["Title"];
            string movieyear = Request.QueryString["Year"];
            string moviegenre = Request.QueryString["Genre"];

            string sqlsel = "SELECT * From Movies Left Join Genre On Movies.GenreID = Genre.ID WHERE Id = 'movieid'";

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


        }
    }
}