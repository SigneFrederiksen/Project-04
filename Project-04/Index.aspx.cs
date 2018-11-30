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
    public partial class Index : System.Web.UI.Page
    {
        // Connection to Database with SQL Selection
        SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        //string sqlsel = "SELECT top 8 * From Movies Left Join Genre On Movies.GenreID = Genre.ID";
        string sqlsel = "SELECT top 8 COUNT(*) PopularMovies, Movies.ID, Movies.Title, Movies.Year, Genre.Genre " +
                        "FROM Views " +
                        "INNER JOIN Movies ON Views.MovieID = Movies.ID " +
                        "INNER JOIN Genre ON Movies.GenreID = Genre.ID " +
                        "GROUP BY Movies.ID, Movies.Title, Movies.Year, Genre.Genre " +
                        "ORDER BY PopularMovies desc";

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
                RepeaterPopularMovies.DataSource = rdr;
                RepeaterPopularMovies.DataBind();
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