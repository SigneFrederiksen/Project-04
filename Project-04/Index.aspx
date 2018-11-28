<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project_04.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    


    <asp:Label ID="LabelHeadingPopular" runat="server" Text="Popular Movies"></asp:Label>
    <br />
    


    <asp:Repeater ID="RepeaterPopularMovies" runat="server">
        <ItemTemplate>
            <p><%# Eval("Title") %></p>
            <p><%# Eval("Genre") %></p>
            <p>Year: <%# Eval("Year") %></p>
        </ItemTemplate>
    </asp:Repeater>


    
    <asp:Label ID="LabelMessage" runat="server" Text="No messages"></asp:Label>


    
    <br />
    <br />
    
</asp:Content>
