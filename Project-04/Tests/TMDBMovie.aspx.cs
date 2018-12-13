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

namespace Project_04.Tests
{
    public partial class TMDBMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string result = "";
            //string id = "920";
            string name = "Cars";



            //result = client.DownloadString("https://api.themoviedb.org/3/movie/" + id + "/videos?api_key=" + TokenClass.TMDBtoken + "&append_to_response=videos");
            result = client.DownloadString("https://api.themoviedb.org/3/search/movie?api_key=" + TokenClass.TMDBtoken + "&query=" + name);

            File.WriteAllText(Server.MapPath("~/Files/TMDB.json"), result);

            // A simple example - Treat json as a string
            string[] separatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
            string[] mysplit = result.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);

            if (mysplit[1] != "False")
            {
                LabelMessage.Text = "Movie found!";

              /*  for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "title")
                    {
                        string movietrailer = mysplit[++i];
                        LabelVideo.Text = movietrailer;
                        //LabelVideo.Text = "<iframe width='1200' height='315' src='https://www.youtube.com/embed/" + movietrailer + "'></iframe>";
                        break;
                    }
                }
                */  

                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "results")
                    {
                        while (mysplit[++i] == "title")
                        {
                            if (mysplit[i - 1] != "results") LabelVideo.Text += "; ";
                            LabelResult.Text += mysplit[i + 3] + " from " + mysplit[i + 1];
                           i = i + 3;
                        }
                        break;
                    }
                }


            }
            else
            {
                LabelMessage.Text = "Movie not found!";
                LabelResult.Text = "Result";
            }
        }
    }
}

