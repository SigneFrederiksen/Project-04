﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

namespace Project_04
{
    public partial class Master : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.AbsolutePath.EndsWith("AllMovies.aspx"))
            {
                lnkAll.Attributes["class"] = "active";
                mlnkAll.Attributes["class"] = "active";
            }
            if (Request.Url.AbsolutePath.EndsWith("Action.aspx"))
            {
                lnkAct.Attributes["class"] = "active";
                mlnkAct.Attributes["class"] = "active";
            }
            if (Request.Url.AbsolutePath.EndsWith("Animation.aspx"))
            {
                lnkAni.Attributes["class"] = "active";
                mlnkAni.Attributes["class"] = "active";
            }
            if (Request.Url.AbsolutePath.EndsWith("Thriller.aspx"))
            {
                lnkThr.Attributes["class"] = "active";
                mlnkThr.Attributes["class"] = "active";
            }
            if (Request.Url.AbsolutePath.EndsWith("ScienceFiction.aspx"))
            {
                lnkSci.Attributes["class"] = "active";
                mlnkSci.Attributes["class"] = "active";
            }

        }

        // Button Search
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {

            // Saves the input from TextBoxSearchBar,
            // so that the we can use the data input on another page.
            string SearchResult = TextBoxSearchBar.Text;
            string Url;

            // We then rederect the user to SearchPage,
            // where we will display the search result that the user typed in.
            Url = "SearchPage.aspx?Search=" + SearchResult;
            Response.Redirect(Url);

        }

        // Button Search Mobile
        protected void ButtonSearchMobile_Click(object sender, EventArgs e)
        {
            // Saves the input from TextBoxSearchBar,
            // so that the we can use the data input on another page.
            string SearchResult = TextBoxSearchBarMobile.Text;
            string Url;

            // We then rederect the user to SearchPage,
            // where we will display the search result that the user typed in.
            Url = "SearchPage.aspx?Search=" + SearchResult;
            Response.Redirect(Url);
        }
    }
}