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
    public partial class AllMovies : System.Web.UI.Page
    {
        public int CurrentPage
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0; // default page index of 0
                else
                    return (int) o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }

        // Connection to Database with SQL Selection
        // SIGNES DB
        SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
        // AMANDAS DB
        //SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        string sqlsel = "SELECT * From Movies Left Join Genre On Movies.GenreID = Genre.ID ORDER BY Title asc";


        protected void Page_Load(object sender, EventArgs e)
        {
            // Call the ShowMovieData method to populate control.
            // Use method for showing the Movie data from Database
            ShowMovieData();
        }

        // Create method for our Movie data
        public void ShowMovieData()
        {
            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MovieList");
                dt = ds.Tables["MovieList"];

                // Populate the repeater control with the Items DataSet
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = ds.Tables[0].DefaultView;

                // Indicate that the data should be paged
                pds.AllowPaging = true;

                // Set the number of items you wish to display per page
                pds.PageSize = 30;

                // Set the PagedDataSource's current page
                pds.CurrentPageIndex = CurrentPage;

                LabelCurrentPage.Text = (CurrentPage + 1).ToString() + " of "
                + pds.PageCount.ToString();

                // Disable Prev or Next buttons if necessary
                ButtonPrev.Enabled = !pds.IsFirstPage;
                ButtonNext.Enabled = !pds.IsLastPage;

                // Binding the correct data from the PagedDataSource to the Repeater
                RepeaterAllMovies.DataSource = pds;
                RepeaterAllMovies.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();  // SqlDataAdapter closes connection by itself; but can fail in case of errors
            }
        }


        protected void ButtonPrev_Click(object sender, EventArgs e)
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            ShowMovieData();
        }


        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            ShowMovieData();
        }


    }
}