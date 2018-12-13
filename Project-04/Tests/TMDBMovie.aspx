<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TMDBMovie.aspx.cs" Inherits="Project_04.Tests.TMDBMovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelMessage" runat="server" Text="No messages"></asp:Label>
            <br />

            <asp:Label ID="LabelVideo" runat="server"></asp:Label>
            <br />

            <asp:Label ID="LabelName" runat="server"></asp:Label>
            <br />

            <asp:Label ID="LabelResult" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
