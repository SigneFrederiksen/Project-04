<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetPostersOMDB.aspx.cs" Inherits="Project_04.GetPostersOMDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get Posters From OMDB</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                        <asp:Label ID="LabelFieldtype" runat="server" Font-Bold="True" Text="Select file type to use"></asp:Label>
            <br />
            <br />
            <asp:RadioButton ID="RadioButtonXML" runat="server" GroupName="FileType" Text="XML" Checked="True" />
            <br />
            <br />
            <asp:Label ID="LabelIDorString" runat="server" Font-Bold="True" Text="Select ID for known movie or movie name"></asp:Label>
            <br />
            <br />
            <asp:RadioButton ID="RadioButtonName" runat="server" Checked="True" GroupName="NameorID" OnCheckedChanged="RadioButtonName_CheckedChanged" Text="Name" />
                        &nbsp;<br />
            <br />
            <br />
            <asp:TextBox ID="TextBoxInput" runat="server" Width="500px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelInput" runat="server" Text="Search input"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonFind" runat="server" OnClick="ButtonFind_Click" Text="Find Movie" />
            <br />
            <br />
            <asp:Label ID="LabelMessages" runat="server" Font-Bold="True" Text="Message"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelResult" runat="server" Text="Result"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Image ID="ImagePoster" runat="server" ImageUrl="~/img/poster-placeholder.jpeg" Width="200px" />
            <br />
            <br />
            <br />
            <asp:Button ID="ButtonReadXMLToDB" runat="server" OnClick="ButtonReadXMLToDB_Click" Text="Read XML to Database" />
            <br />
            <br />
            <asp:Repeater ID="RepeaterMovies" runat="server">
                <HeaderTemplate>
                    <table class="mytable">
                        <tr>
                            <td class="myheader">ID</td>
                            <td class="myheader">Title</td>
                            <td class="myheader">Year</td>
                            <td class="myheader">GenreID</td>
                            <td class="myheader">Poster</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="myitem"><%# Eval("ID") %></td>
                        <td class="myitem"><%# Eval("Title") %></td>
                        <td class="myitem"><%# Eval("Year") %></td>
                        <td class="myitem"><%# Eval("GenreID") %></td>
                        <td class="myitem"><%# Eval("Poster") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
