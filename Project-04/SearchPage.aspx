<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="Project_04.SearchPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="container-fluid">      
        <div class="row">

            <h2 class="col-md-12 search-h2"><asp:Label ID="LabelHeading" runat="server"></asp:Label></h2>

            <asp:Repeater ID="RepeaterSearchMovies" runat="server">
                <ItemTemplate>
                    <div class="col-6 col-sm-6 col-md-4 col-lg-2 movie-list">
                        <a href="SingleMovie.aspx?poster=<%# Eval("Poster") %>&title=<%# Eval("Title") %>&id=<%# Eval("Id") %>&year=<%# Eval("Year") %>&genre=<%# Eval("Genre") %>">
                            <img src="<%# Eval("Poster") %>" alt="poster" class="image-poster" />
                             <div class="image-text">
                            <h3><%# Eval("Title") %></h3>
                            <p class="p-small-bold"><%# Eval("Genre") %>, <%# Eval("Year") %></p>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <p class="col-md-12 not-found"><asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label></p>

        </div>
    </div>

</asp:Content>
