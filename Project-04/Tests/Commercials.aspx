<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commercials.aspx.cs" Inherits="Project_04.Commercials" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <asp:Xml ID="Xml1" runat="server" DocumentSource="~/Files/Commercials.xml" TransformSource="~/Files/Commercials.xslt"></asp:Xml>
            <br />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>


        </div>
    </form>
</body>
</html>
