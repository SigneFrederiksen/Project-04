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
    public partial class GetPosters : System.Web.UI.Page
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

            try
            {
                // conn.Open();  SqlDataAdapter opens connection by itself

                string sqlsel = "Select Poster from Movies";

                da.SelectCommand = new SqlCommand(sqlsel, conn);
                da.Fill(ds, "movie");
                dt = ds.Tables["movie"];

                //RepeaterCat.DataSource = dt;
                //RepeaterCat.DataBind();

            }
            catch (Exception ex)
            {
                LabelMessages.Text = ex.Message;
            }
            finally
            {
                conn.Close();  // SqlDataAdapter closes connection by itself; but can fail in case of errors
            }


            if (!Page.IsPostBack)
            {
                RadioButtonID.AutoPostBack = true;
                RadioButtonName.AutoPostBack = true;
            }

        }


        // Button Find
        protected void ButtonFind_Click(object sender, EventArgs e)
        {

            WebClient client = new WebClient();
            string result = "";

            if (RadioButtonID.Checked)
            {
                if (RadioButtonJSON.Checked)
                {
                    result = client.DownloadString("http://www.omdbapi.com/?i=" + TextBoxInput.Text + "&apikey=" + TokenClass.token);
                }
                else
                {
                    result = client.DownloadString("http://www.omdbapi.com/?i=" + TextBoxInput.Text + "&r=xml&apikey=" + TokenClass.token);
                }
            }
            else
            {
                // substitute " " with "+"
                string myselection = TextBoxInput.Text.Replace(' ', '+');

                if (RadioButtonJSON.Checked)
                {
                    result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&apikey=" + TokenClass.token);
                }
                else
                {
                    result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&r=xml&apikey=" + TokenClass.token);
                }
            }

            if (RadioButtonJSON.Checked)
            {
                File.WriteAllText(Server.MapPath("~/Files/MoviePoster.json"), result);

                // A simple example - Treat json as a string
                string[] separatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
                string[] mysplit = result.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);

                if (mysplit[1] != "False")
                {
                    LabelMessages.Text = "Movie found!";

                    for (int i = 0; i < mysplit.Length; i++)
                    {
                        if (mysplit[i] == "Poster")
                        {
                            ImagePoster.ImageUrl = mysplit[++i];
                            break;
                        }
                    }
                    LabelResult.Text = "Ratings : ";
                    for (int i = 0; i < mysplit.Length; i++)
                    {
                        if (mysplit[i] == "Ratings")
                        {
                            while (mysplit[++i] == "Source")
                            {
                                if (mysplit[i - 1] != "Ratings") LabelResult.Text += "; ";
                                LabelResult.Text += mysplit[i + 3] + " from " + mysplit[i + 1];
                                i = i + 3;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    LabelMessages.Text = "Movie not found!";
                    //ImagePoster.ImageUrl = "~/MyFiles/ext-bg.jpg";
                    LabelResult.Text = "Result";
                }
            }
            else
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
                    //ImagePoster.ImageUrl = "~/MyFiles/ext-bg.jpg";
                    LabelResult.Text = "Result";
                }
            }

        }


        // Radio Button Name
        protected void RadioButtonName_CheckedChanged(object sender, EventArgs e)
        {
            
            TextBoxInput.Text = "";
            //ImagePoster.ImageUrl = "~/MyFiles/ext-bg.jpg";
            LabelMessages.Text = "Message";
            LabelResult.Text = "Result";
        }

        // Radio Button ID
        protected void RadioButtonID_CheckedChanged(object sender, EventArgs e)
        {
            
            TextBoxInput.Text = "";
            //ImagePoster.ImageUrl = "~/MyFiles/ext-bg.jpg";
            LabelMessages.Text = "Message";
            LabelResult.Text = "Result";
        }




        // Button Read XML To DB
        protected void ButtonReadXML_Click(object sender, EventArgs e)
        {

            ds.ReadXml(Server.MapPath("~/Files/MoviePoster.xml"));
            LabelMessages.Text = "Data from XML added to Database!";

            // There can be duplicate ID's in the ds
            // The updated DB is ok.
            // Autonumbering will change the ID's
            // Without autonumbering : 1. Merge 2 ds, 2. List ID's and search for duplicates
            da.Update(ds, "movie");

            ds.Clear();

        } // Button Read XML To DB : END

    }
}