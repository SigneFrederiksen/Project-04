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

            // Save the transformed xml file in an variable
            string destinationfile = Server.MapPath("~/Files/CommercialsTransformed.xml");

            // Create a new dataset/table and reading the xml file
            DataSet ds = new DataSet();
            ds.ReadXml(destinationfile);
            DataTable dt = ds.Tables[0];

            // using the "Random" method to randomize the commercials
            int viewcounter = 0;
            int randomCommercial = (new Random()).Next(0, dt.Rows.Count);

            // viewcounter is now assigned the value of the current value of the viewcounter + 
            viewcounter = viewcounter + Convert.ToInt32(ds.Tables[0].Rows[randomCommercial][3]) + 1;

            dt.Rows[randomCommercial][3] = viewcounter;

            // insert the values from the xml to the different elements
            LabelCompany.Text = Convert.ToString(dt.Rows[randomCommercial][0]);
            Webpage.HRef = "http://" + Convert.ToString(dt.Rows[randomCommercial][2]);
           // ImageCommercial.ImageUrl = "~/img/" + Convert.ToString(dt.Rows[randomCommercial][1]);

            // updating the transformed xml each time a new view has occurred
            ds.WriteXml(Server.MapPath("~/Files/CommercialsTransformed.xml"));

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