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

            SavePosterDB();
            ///////////////////////////////////////////////



            // Retrieve strings from URL
            string movieid = Request.QueryString["Id"];
            //string movieposter = Request.QueryString["Poster"];
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
             
                cmd.Parameters.Add("@Title", SqlDbType.Text).Value = LabelTitle.Text;
                cmd.Parameters.Add("@Year", SqlDbType.Text).Value = LabelYear.Text;
                cmd.Parameters.Add("@Genre", SqlDbType.Text).Value = LabelGenre.Text;

                // Labels are assigned the values of the strings
                LabelTitle.Text = movietitle;
                LabelYear.Text = movieyear;
                LabelGenre.Text = moviegenre;


                /*if (cmd.Parameters.AddWithValue("@Poster", posterurl) == null)
                {
                    ImagePoster2.ImageUrl = posterurl;
                }
                else
                {
                    cmd.Parameters.Add("@Poster", SqlDbType.Text).Value = ImagePoster2.ImageUrl;
                }*/

                File.WriteAllText(Server.MapPath("~/Files/LatestResult.xml"), result);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);

                if (doc.SelectSingleNode("/root/@response").InnerText == "True")
                {
                    XmlNodeList nodelist = doc.SelectNodes("/root/movie");
                    foreach (XmlNode node in nodelist)
                    {
                        string movieposter = node.SelectSingleNode("@poster").InnerText;
                        ImagePoster2.ImageUrl = movieposter;                

                        /////////////////////////////////

                        LabelDirector.Text += " Director: " + nodelist[0].SelectSingleNode("@director").InnerText;
                        LabelActors.Text += " Actors: " + nodelist[0].SelectSingleNode("@actors").InnerText;
                        LabelRating.Text += " Rating: " + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
                        LabelDescription.Text = " Description: " + nodelist[0].SelectSingleNode("@plot").InnerText;
                    }
                }
                else
                {
                    LabelMessage.Text = "Movie not found";
                    //ImagePoster2.ImageUrl = "~/img/poster-placeholder.jpeg";
                    //  ImagePoster2.ImageUrl = Server.MapPath("~/img/poster-placeholder.jpeg");
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



        
        protected void SavePosterDB()
        {
            string movietitle = Request.QueryString["Title"];

            try
            {
                conn.Open();  //SqlDataAdapter opens connection by itself 

                string sqlsel = "Select * from Movies";
                da.SelectCommand = new SqlCommand(sqlsel, conn);
                da.Fill(ds, "movie");
                dt = ds.Tables["movie"];


                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Server.MapPath("~/Files/MoviePoster.xml"));

                if (xmlDoc.SelectSingleNode("/root/@response").InnerText == "True")
                {

                    XmlNodeList dataNodes = xmlDoc.SelectNodes("/root/movie");
                    foreach (XmlNode node in dataNodes)
                    {
                        string poster = node.SelectSingleNode("@poster").InnerText;
                        LabelMessage.Text = "Data from XML added to Database!";

                        string sqlupd = "UPDATE Movies SET Poster = @poster WHERE Title = 'movietitle'";

                        da.SelectCommand = new SqlCommand(sqlupd, conn);
                        da.SelectCommand.Parameters.Add("@poster", SqlDbType.Text).Value = poster;
                        da.SelectCommand.ExecuteNonQuery();

                        da.Update(ds, "movie");
                        ds.Clear();
                    }

                }
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
        


    }
}