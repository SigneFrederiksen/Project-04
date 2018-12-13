using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Drawing;

namespace Project_04.Tests
{
    public partial class ComTest : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string destinationfile = Server.MapPath("~/Files/CommercialsTransformed.xml");

            DataSet ds = new DataSet();
            ds.ReadXml(destinationfile);
            DataTable dt = ds.Tables[0];

            int viewcounter = 0;
            int randomCommercial = (new Random()).Next(0, dt.Rows.Count);

            viewcounter = viewcounter + Convert.ToInt32(ds.Tables[0].Rows[randomCommercial][3]) + 1;

            dt.Rows[randomCommercial][3] = viewcounter;

            LabelCompany.Text = Convert.ToString(dt.Rows[randomCommercial][0]);
            ImageCommercial.ImageUrl = "~/img/" + Convert.ToString(dt.Rows[randomCommercial][1]);

            ds.WriteXml(Server.MapPath("~/Files/CommercialsTransformed.xml"));

        }
     
    }
}