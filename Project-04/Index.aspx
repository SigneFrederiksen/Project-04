<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project_04.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">      
        <div class="row">
    
        <div class="col-md-12">
            <asp:Label ID="LabelTrailer" runat="server" Text=""></asp:Label>
            <asp:Label ID="LabelTrailerName" runat="server" Text=""></asp:Label>
        </div>

        <h2 class="col-md-12 heading-label">Our Top Movies</h2>
 
        <asp:Repeater ID="RepeaterPopularMovies" runat="server">
            <ItemTemplate>
                <div class="col-6 col-sm-6 col-md-4 col-lg-2 movie-list">
                    <a href="SingleMovie.aspx?poster=<%# Eval("Poster") %>&title=<%# Eval("Title") %>&id=<%# Eval("Id") %>&year=<%# Eval("Year") %>&genre=<%# Eval("Genre") %>">
                        <img src="<%# Eval("Poster") %>" alt="poster" class="image-poster" />
                        <!--<asp:Image ID="ImagePoster" runat="server" ImageUrl="~/img/poster-placeholder.jpeg" CssClass="image-poster" />-->
                       <div class="image-text">
                        <h3><%# Eval("Title") %></h3>   
                        <p class="p-small-bold"><%# Eval("Genre") %>, <%# Eval("Year") %></p>
                        </div> 
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>

            <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>

        </div>
    </div>

    <div class="container-fluid">
        <div class="row">   
            <div class="col-xs-12 col-md-12">
                <div class="commercial">
                <a id="Webpage" runat="server" href="#">
                <h4 ><asp:Label ID="LabelCompany" runat="server" Text="Label"></asp:Label></h4>
                <div id="imgcom"></div>
                </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
