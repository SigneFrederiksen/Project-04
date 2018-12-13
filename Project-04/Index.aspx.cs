using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Net;

namespace Project_04
{
    public partial class Index : System.Web.UI.Page
    {
        // Connection to Database with SQL Selection
        // SIGNES DB
       // SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
        // AMANDAS DB
        SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqlsel = "SELECT top 6 COUNT(*) PopularMovies, Movies.ID, Movies.Title, Movies.Year, Genre.Genre, Movies.Poster " +
                        "FROM Views " +
                        "INNER JOIN Movies ON Views.MovieID = Movies.ID " +
                        "INNER JOIN Genre ON Movies.GenreID = Genre.ID " +
                        "GROUP BY Movies.ID, Movies.Title, Movies.Year, Genre.Genre, Movies.Poster " +
                        "ORDER BY PopularMovies desc";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Use method for showing the Movie data from Database
            ShowMovieData();

            string sourcefile = Server.MapPath("Files/Commercials.xml");
            string xslthtmlfile = Server.MapPath("Files/ToHTML.xslt");
            string destinationhtmlfile = Server.MapPath("Files/ToHTML.html");

            FileStream fshtml = new FileStream(destinationhtmlfile, FileMode.Create);
            XslCompiledTransform xcthtml = new XslCompiledTransform();
            xcthtml.Load(xslthtmlfile);
            xcthtml.Transform(sourcefile, null, fshtml);
            fshtml.Close();

            WebClient cl = new WebClient();
            Literal1.Text = cl.DownloadString(destinationhtmlfile);
        }

        // Create method for our Movie data
        public void ShowMovieData()
        {
            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();
                RepeaterPopularMovies.DataSource = rdr;
                RepeaterPopularMovies.DataBind();
            }
            catch (Exception ex)
            {
                //LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }

    }
}