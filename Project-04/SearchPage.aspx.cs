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
    public partial class SearchPage : System.Web.UI.Page
    {
        // Creates a string, that will store our Search value
        string RetrievedSearchValue;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Store the Search value
            RetrievedSearchValue = Request.QueryString["Search"];

            // Connection to Database with SQL Selection
            // SIGNES DB
           // SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
            // AMANDAS DB
            SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            //string sqlsel = "SELECT * From Movies Left Join Genre On Movies.GenreID = Genre.ID WHERE Title Like '%" + TextBoxSearchBar.Text.Trim() + "%'";
            string sqlsel = "SELECT * From Movies Left Join Genre On Movies.GenreID = Genre.ID WHERE Title Like '%" + RetrievedSearchValue + "%'";


            try
            {
                // conn.Open();  SqlDataAdapter opens connection by itself

                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MovieSearchList");
                dt = ds.Tables["MovieSearchList"];

                RepeaterSearchMovies.DataSource = dt;
                RepeaterSearchMovies.DataBind();

                LabelHeading.Text = "You searched for: " + RetrievedSearchValue;

                // If there is no result matching the search input
                if (ds.Tables[0].Rows.Count == 0)
                {
                    LabelMessage.Text = "Movie not found. Try to search on another title.";
                }

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

        protected void RepeaterSearchMovies_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

    }
}