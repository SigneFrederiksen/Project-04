<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetPosters.aspx.cs" Inherits="Project_04.GetPosters" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get Psters From OMDb</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelFieldtype" runat="server" Font-Bold="True" Text="Select file type to use"></asp:Label>
            <br />
            <br />
            <asp:RadioButton ID="RadioButtonJSON" runat="server" Checked="True" GroupName="FileType" Text="JSON" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="RadioButtonXML" runat="server" GroupName="FileType" Text="XML" />
            <br />
            <br />
            <asp:Label ID="LabelIDorString" runat="server" Font-Bold="True" Text="Select ID for known movie or movie name"></asp:Label>
            <br />
            <br />
            <asp:RadioButton ID="RadioButtonName" runat="server" Checked="True" GroupName="NameorID" OnCheckedChanged="RadioButtonName_CheckedChanged" Text="Name" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="RadioButtonID" runat="server" GroupName="NameorID" OnCheckedChanged="RadioButtonID_CheckedChanged" Text="ID (Select known movie from list)" />
            <br />
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
            <asp:Image ID="ImagePoster" runat="server" />
            <br />
            <br />
            <br />
            <asp:Label ID="LabelHeading" runat="server" Text="XML and DB"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Message"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="ButtonReadXML" runat="server" Text="Read XML to DB" OnClick="ButtonReadXML_Click" />
        </div>
    </form>
</body>
</html>
