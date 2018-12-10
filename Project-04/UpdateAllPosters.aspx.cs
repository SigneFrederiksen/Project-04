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
    public partial class UpdateAllPosters : System.Web.UI.Page
    {
        // SIGNES DB
        //SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
        // AMANDAS DB
        SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        SqlCommandBuilder cb = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            ds = new DataSet();
            dt = null;
            cb = new SqlCommandBuilder(da);

            UpdateRepeater();

        }

        // Method - UpdateRepeater
        public void UpdateRepeater()
        {

            try
            {
                // conn.Open();  SqlDataAdapter opens connection by itself

                string sqlsel = "Select * from Movies";

                da.SelectCommand = new SqlCommand(sqlsel, conn);
                da.Fill(ds, "movie");
                dt = ds.Tables["movie"];

                RepeaterMovies.DataSource = dt;
                RepeaterMovies.DataBind();

            }
            catch (Exception ex)
            {
                LabelMessages.Text = ex.Message;
            }
            finally
            {
                conn.Close();  // SqlDataAdapter closes connection by itself; but can fail in case of errors
            }

        } // Method - UpdateRepeater : END

        
    }
}