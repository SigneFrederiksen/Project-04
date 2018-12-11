<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateAllPosters.aspx.cs" Inherits="Project_04.UpdateAllPosters" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="RepeaterMovies" runat="server">
            </asp:Repeater>
            <br />
            <br />

            <asp:Button ID="ButtonReadPosters" runat="server" Text="Read poster urls to DB" Font-Italic="False" />

            <br />
            <br />

            <asp:Label ID="LabelMessages" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
