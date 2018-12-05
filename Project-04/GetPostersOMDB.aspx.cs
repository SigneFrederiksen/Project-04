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
    public partial class GetPostersOMDB : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
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


        // Button Find
        protected void ButtonFind_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string result = "";

            if (RadioButtonName.Checked)
            {
                // substitute " " with "+"
                string myselection = TextBoxInput.Text.Replace(' ', '+');

                if (RadioButtonXML.Checked)
                {
                    result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&r=xml&apikey=" + TokenClass.token);
                }
                else
                {
                    result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&r=xml&apikey=" + TokenClass.token);
                }
            }

            if (RadioButtonXML.Checked)
            {
                File.WriteAllText(Server.MapPath("~/Files/MoviePoster.xml"), result);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);

                if (doc.SelectSingleNode("/root/@response").InnerText == "True")
                {
                    XmlNodeList nodelist = doc.SelectNodes("/root/movie");
                    foreach (XmlNode node in nodelist)
                    {
                        string id = node.SelectSingleNode("@poster").InnerText;
                        ImagePoster.ImageUrl = id;
                    }
                    LabelResult.Text = "Rating" + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
                    LabelResult.Text += " from " + nodelist[0].SelectSingleNode("@imdbVotes").InnerText;
                }
                else
                {
                    LabelMessages.Text = "Movie not found!";
                    ImagePoster.ImageUrl = "~/img/poster-placeholder.jpeg";
                    LabelResult.Text = "Result";
                }
            }
        }


        // Radio Button Name
        protected void RadioButtonName_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxInput.Text = "";
            ImagePoster.ImageUrl = "~/img/poster-placeholder.jpeg";
            LabelMessages.Text = "Message";
            LabelResult.Text = "Result";
        }


        // Read XML to Database
        protected void ButtonReadXMLToDB_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();  //SqlDataAdapter opens connection by itself 

                ds.ReadXml(Server.MapPath("~/Files/MoviePoster.xml"));
                LabelMessages.Text = "Data from XML added to Database!";

                string sqlsel = "UPDATE Movies SET Poster = @poster WHERE Title = '" + TextBoxInput.Text + "'";

                da.SelectCommand = new SqlCommand(sqlsel, conn);

                da.SelectCommand.Parameters.Add("@poster", SqlDbType.Text);
                da.SelectCommand.ExecuteNonQuery();

                da.Update(ds, "movie");

                ds.Clear();
                UpdateRepeater();

                /*da.Fill(ds, "movie");
                dt = ds.Tables["movie"];

                RepeaterMovies.DataSource = dt;
                RepeaterMovies.DataBind();*/

            }
            catch (Exception ex)
            {
                LabelMessages.Text = ex.Message;
            }
            finally
            {
                conn.Close();  // SqlDataAdapter closes connection by itself; but can fail in case of errors
            }

            /*ds.ReadXml(Server.MapPath("~/Files/MoviePoster.xml"));
            LabelMessages.Text = "Data from XML added to Database!";

            da.Update(ds, "movie");

            ds.Clear();
            UpdateRepeater();
            */
        }
    }
}