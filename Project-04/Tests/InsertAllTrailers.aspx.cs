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
    public partial class InsertAllTrailers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            allTrailers();
        }

        public void allTrailers()
        {
            // SIGNES DB
            SqlConnection conn = new SqlConnection(@"data source = DESKTOP-VKU3EK5; integrated security = true; database = MovieDB");
            // AMANDAS DB
            //SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");
            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                string sqlcheck = "SELECT * From Movies";
                SqlCommand cmd = new SqlCommand(sqlcheck, conn);
                using (rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string result = "";
                        WebClient client = new WebClient();
                        //result = client.DownloadString("http://www.omdbapi.com/?t=" + rdr.GetString(1) + "&y=" + rdr.GetInt32(2) + "&apikey=" + TokenClass.token + "");
                        //result = client.DownloadString("https://api.themoviedb.org/3/search?api_key=" + TokenClass.TMDBtoken + "&query=" + rdr.GetString(1) + "");
                        //result = client.DownloadString("https://api.themoviedb.org/3/search/movie?api_key=" + TokenClass.TMDBtoken + "&append_to_response=videos&query=Jack+Reacher");

                        result = client.DownloadString("https://api.themoviedb.org/3/search/movie?api_key=" + TokenClass.TMDBtoken + "&query=" + rdr.GetString(1) + "");

                        string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
                        string[] mysplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);

                        if (mysplit[1] != "False")
                        {
                            string trailerID = "";
                            for (int i = 0; i < mysplit.Length; i++)
                            {
                                if (mysplit[i] == "id")
                                {
                                    trailerID = mysplit[++i];
                                    /*if (imageposter == "N/A")
                                    {
                                        imageposter = "~/img/poster-placeholder.jpeg";
                                    }*/
                                    cs.TrailerDetails trailer = new cs.TrailerDetails();
                                    string movie_id = Convert.ToString(rdr.GetInt32(0));
                                    trailer.SaveTrailerID(trailerID, movie_id);
                                    break;
                                }
                            }
                        }
                    }
                    testlabel.Text = rdr.GetInt32(0).ToString();
                }
            }
            catch (Exception ex)
            {
                testlabel.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }

    }
}