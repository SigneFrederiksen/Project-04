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
    public partial class InsertAllMovies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            allmovies();
        }

        public void allmovies()
        {
            // AMANDAS DB
            SqlConnection conn = new SqlConnection(@"data source = LAPTOP-7ILGU10M; integrated security = true; database = MovieDB");

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
                        result = client.DownloadString("http://www.omdbapi.com/?t=" + rdr.GetString(1) + "&y=" + rdr.GetInt32(2) + "&apikey=" + TokenClass.token + "");
                        string[] seperatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
                        string[] mysplit = result.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries);
                        if (mysplit[1] != "False")
                        {
                            string imageposter = "";
                            for (int i = 0; i < mysplit.Length; i++)
                            {
                                if (mysplit[i] == "Poster")
                                {
                                    imageposter = mysplit[++i];
                                    if (imageposter == "N/A")
                                    {
                                        imageposter = "~/img/poster-placeholder.jpeg";
                                    }
                                    cs.MovieDetails movie = new cs.MovieDetails();
                                    string movie_id = Convert.ToString(rdr.GetInt32(0));
                                    movie.SavePoster(imageposter, movie_id);
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