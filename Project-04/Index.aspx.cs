﻿using System;
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
        SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = Amanda");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqlsel = "SELECT * FROM MovieCategories";

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