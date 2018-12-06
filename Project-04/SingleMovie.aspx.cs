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
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;

            WebClient client = new WebClient();
            string movietitle = Request.QueryString["Title"];
            string movieyear = Request.QueryString["Year"];
            string movieid = Request.QueryString["Id"];
           
            //SqlCommand cmd = null;
            //SqlDataReader rdr = null;

            string sqlsel = "SELECT * From Movies Left Join Genre On Movies.GenreID = Genre.ID WHERE Id = 'movieid'";

           // WebClient client = new WebClient();

            try
            {

                

                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "SingleMovie");

                dt = ds.Tables["SingleMovie"];

                RepeaterSingleMovie.DataSource = dt;
                RepeaterSingleMovie.DataBind();
            }

        }
    }
}