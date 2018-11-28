﻿<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project_04.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    


    <asp:Label ID="LabelHeadingPopular" runat="server" Text="Popular Movies"></asp:Label>
    <br />
    

 
    <asp:Repeater ID="RepeaterPopularMovies" runat="server">
        <ItemTemplate>
            <img src="img/<%# Eval("Poster") %>" alt="Movie poster" />
                <p><%# Eval("Title") %></p>
                <p>Year: <%# Eval("Year") %></p>
                <p><%# Eval("Description") %></p>
                <p>Actors: <%# Eval("Actors") %></p>
                <p>Child rating: <%# Eval("ChildRating") %></p>
        </ItemTemplate>
    </asp:Repeater>


    
    <asp:Label ID="LabelMessage" runat="server" Text="No messages"></asp:Label>


    
    <br />
    <br />
    
</asp:Content>