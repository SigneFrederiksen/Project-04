<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComTest.aspx.cs" Inherits="Project_04.Tests.ComTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Xml ID="Xml1" runat="server" DocumentSource="~/Files/Commercials.xml" TransformSource="~/Files/ToXML.xslt"></asp:Xml>

            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />

            <asp:Label ID="LabelWebpage" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <h3><asp:Label ID="LabelCompany" runat="server" Text="Label"></asp:Label></h3>  
            <br />
            <br />
            <asp:Image ID="ImageLogo" runat="server" />
            <br />

            <br />

        </div>
    </form>
</body>
</html>
