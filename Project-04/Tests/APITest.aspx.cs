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
    public partial class APITest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn2 = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");
            SqlCommand cmd2 = null;
            SqlDataReader rdr2 = null;


            WebClient client = new WebClient();
            string result = "";
            string movieselection = TextBoxSearch.Text.Replace(' ', '+');

            result = client.DownloadString("http://www.omdbapi.com/?t=" + movieselection + "&r=xml&apikey=" + TokenClass.token);

            string sqlsel2 = "SELECT * Id, Title, Genre, Year, Poster FROM Movies WHERE Title LIKE (@title)";

                try
                {
                    conn2.Open();

                    cmd2 = new SqlCommand(sqlsel2, conn2);

                    rdr2 = cmd2.ExecuteReader();

                    RepeaterMovie.DataSource = rdr2;
                    RepeaterMovie.DataBind();

                }
                catch (Exception ex)
                {
                    //  LabelMessage.Text = ex.Message;
                }
                finally
                {
                    conn2.Close();
                }

            File.WriteAllText(Server.MapPath("~/Files/LatestResult.xml"), result);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);

            if (doc.SelectSingleNode("/root/@response").InnerText == "True")
            {
                XmlNodeList nodelist = doc.SelectNodes("/root/movie");
                foreach (XmlNode node in nodelist) 
                {
                   // string id = node.SelectSingleNode("@poster").InnerText;
                   // ImageDefault.ImageUrl = id;

                }

                
                LabelDirector.Text += " Director: " + nodelist[0].SelectSingleNode("@director").InnerText;
                LabelActors.Text += " Actors: " + nodelist[0].SelectSingleNode("@actors").InnerText;
                LabelRating.Text += " Rating: " + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
                LabelDescription.Text = " Description: " + nodelist[0].SelectSingleNode("@plot").InnerText;

            }

            else
            {
                LabelMessage.Text = "Movie not found";

                LabelResult.Text = "";
            } 

        }

    }
}