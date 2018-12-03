<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APITest.aspx.cs" Inherits="Project_04.APITest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Search" />
            <br />
            <br />
            <asp:Label ID="LabelMessage" runat="server"></asp:Label>
            <br />
            <br />

            <asp:Repeater ID="RepeaterMovie" runat="server">
                <ItemTemplate>
                 <p><%# Eval("Title") %></p>
                   <!-- <asp:Image ID="ImageDefault" runat="server" Height="311px" /> -->
                   <img src="Pictures/<%# Eval("Poster") %>" alt="pest" />
                   <p><%# Eval("Year") %></p>
                   <p><%# Eval("Genre") %></p>
                </ItemTemplate>
            </asp:Repeater>

            <asp:Label ID="LabelResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
