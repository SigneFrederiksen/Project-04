<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="Project_04.SearchPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
 
    <asp:Repeater ID="RepeaterSearchMovies" runat="server">
        <ItemTemplate>
            <p><%# Eval("Title") %></p>
            <p>Year: <%# Eval("Year") %></p>
            <p><%# Eval("Genre") %></p>
        </ItemTemplate>
    </asp:Repeater>

  
    <asp:Label ID="LabelMessage" runat="server" Text="No messages"></asp:Label>

    
    <br />
    <br />
    
</asp:Content>
