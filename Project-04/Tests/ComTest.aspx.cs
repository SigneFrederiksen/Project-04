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
using System.Net;
using System.Drawing;

namespace Project_04.Tests
{
    public partial class ComTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            // If the XML uses a namespace, the XSLT must refer to this namespace
            string sourcefile = Server.MapPath("~/Files/Commercials.xml");
            string xsltfile = Server.MapPath("~/Files/ToXML.xslt");
           // string xslthtmlfile = Server.MapPath("~/Files/ToHTML.xslt");
            string destinationfile = Server.MapPath("~/Files/CommercialsTransformed.xml");
            //string destinationhtmlfile = Server.MapPath("~/Files/ToHTML.html");

            FileStream fs = new FileStream(destinationfile, FileMode.Create);
            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load(xsltfile);
            xct.Transform(sourcefile, null, fs);
            fs.Close();

            DataSet ds = new DataSet();
            ds.ReadXml(destinationfile);
            DataTable dt = ds.Tables[0];
           // dt.Rows[0][3] = 1;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            //XmlDocument doc = new XmlDocument();

           // WebClient client = new WebClient();
           // XmlNodeList nodelist = .SelectNodes("/Commercials/Commercial");

            //  LabelWebpage.Text = " Description: " + nodelist[0].SelectSingleNode("@plot").InnerText;
           // LabelCompany.Text = nodelist[0].SelectSingleNode("Company").InnerText;



            //   FileStream fshtml = new FileStream(destinationhtmlfile, FileMode.Create);
            //  XslCompiledTransform xcthtml = new XslCompiledTransform();
            //  xcthtml.Load(xslthtmlfile);
            //  xcthtml.Transform(sourcefile, null, fshtml);
            // fshtml.Close();


            //   Literal1.Text = cl.DownloadString(destinationhtmlfile);
        }
    }
}