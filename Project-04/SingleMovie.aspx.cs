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
        
        // SIGNES DB
        //SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
        // AMANDAS DB
        SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");
        SqlCommand cmd = null;


        protected void Page_Load(object sender, EventArgs e)
        {

            // Activates the ViewCount method.
            ViewCount();
            ///////////////////////////////////////////////



            // Retrieve strings from URL
            string movieid = Request.QueryString["Id"];
            string movieposter = Request.QueryString["Poster"];
            string movietitle = Request.QueryString["Title"];
            string movieyear = Request.QueryString["Year"];
            string moviegenre = Request.QueryString["Genre"];

            // Selects all from movies where DB id is the same as the string "movieid"
            string sqlsel = "SELECT * From Movies Left Join Genre On Movies.GenreID = Genre.ID WHERE Id = 'movieid'";

            // OMDB API Set-Up
            WebClient client = new WebClient();
            string result = "";
            //string movieselection = movietitle.Replace(' ', '+');
            //.Replace(' ', '+')

            result = client.DownloadString("http://www.omdbapi.com/?t=" + movietitle + "&r=xml&apikey=" + TokenClass.token);

            //string posterdefault = Server.MapPath("~/img/poster-placeholder.jpeg");
            //string posterurl = "";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);

                // Adds database parameters to matching labels

                cmd.Parameters.Add("@Poster", SqlDbType.Text).Value = ImagePoster2.ImageUrl;
                cmd.Parameters.Add("@Title", SqlDbType.Text).Value = LabelTitle.Text;
                cmd.Parameters.Add("@Year", SqlDbType.Text).Value = LabelYear.Text;
                cmd.Parameters.Add("@Genre", SqlDbType.Text).Value = LabelGenre.Text;

                // Labels are assigned the values of the strings
                ImagePoster2.ImageUrl = movieposter;
                LabelTitle.Text = movietitle;
                LabelYear.Text = movieyear;
                LabelGenre.Text = moviegenre;

                if (movieposter == "")
                {
                    ImagePoster2.ImageUrl = "~/img/poster-placeholder.jpeg";
                }
                else
                {
                    cmd.Parameters.Add("@Poster", SqlDbType.Text).Value = ImagePoster2.ImageUrl;
                }

                File.WriteAllText(Server.MapPath("~/Files/LatestResult.xml"), result);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);

                if (doc.SelectSingleNode("/root/@response").InnerText == "True")
                {
                    XmlNodeList nodelist = doc.SelectNodes("/root/movie");
                    foreach (XmlNode node in nodelist)
                    {
                        //string saveposter = node.SelectSingleNode("@poster").InnerText;
                        //ImagePoster2.ImageUrl = movieposter;    

                        /////////////////////////////////

                        LabelRuntime.Text += nodelist[0].SelectSingleNode("@runtime").InnerText;
                        LabelRated.Text += nodelist[0].SelectSingleNode("@rated").InnerText;
                        LabelDescription.Text = nodelist[0].SelectSingleNode("@plot").InnerText;
                        LabelActors.Text += nodelist[0].SelectSingleNode("@actors").InnerText;
                        LabelDirector.Text += nodelist[0].SelectSingleNode("@director").InnerText;
                        LabelLanguage.Text += nodelist[0].SelectSingleNode("@language").InnerText;
                        LabelCountry.Text += nodelist[0].SelectSingleNode("@country").InnerText;
                        LabelAwards.Text += nodelist[0].SelectSingleNode("@awards").InnerText;
                    }
                }
                else
                {
                    LabelMessage.Text = "(No movie info available)";
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


        // Adds a timestamp of the selected movie to the database table Views. 
        // Used to finding the most popular movies and for analytics.
        public void ViewCount()
        {
            string movieid = Request.QueryString["Id"];
            DateTime dateTimeVariable = DateTime.Now;

            string sqlupd = "INSERT INTO Views VALUES (@Datetime, @movieid)";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.AddWithValue("@Datetime", dateTimeVariable);
                cmd.Parameters.AddWithValue("@movieid", movieid);

                cmd.ExecuteNonQuery();

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