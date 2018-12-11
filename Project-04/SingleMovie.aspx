<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SingleMovie.aspx.cs" Inherits="Project_04.SingleMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container-fluid">
    <div class="row">
        <div class="col-xs-12">
            <asp:Button ID="ButtonBack" runat="server" Text="Go Back" OnClick="ButtonBack_Click" />
        </div>
         <div class="col-xs-12">
          
        </div>
    </div>
</div>


    <div class="container-fluid">
        <div class="row">
                    <div class="col-6">
                      <!--  <asp:Image ID="ImagePoster" runat="server" ImageUrl="~/img/poster-placeholder.jpeg" CssClass="image-poster" /> -->
                        <asp:Image ID="ImagePoster2" runat="server" CssClass="image-poster" /> 
                        <!-- <img src="<%# Eval("Poster") %>" alt="poster" class="image-poster" /> -->
                    </div>
                    <div class="col-6">
                          <div class="movie-details">
                                <h3 class="heading-label"><asp:Label ID="LabelTitle" runat="server" Text="Label"><%# Eval("Title") %></asp:Label></h3>
                                <p class="p-small-bold"><asp:Label ID="LabelYear" runat="server" Text="Label"> <%# Eval("Year") %></asp:Label></p>
                                <p class="p-small-bold"><asp:Label ID="LabelGenre" runat="server" Text="Label"><%# Eval("Genre") %></asp:Label></p>
                                <p class=""><asp:Label ID="LabelDirector" runat="server"></asp:Label></p>
                                <p class=""><asp:Label ID="LabelActors" runat="server"></asp:Label></p>
                                <p class=""><asp:Label ID="LabelRating" runat="server"></asp:Label></p>
                                <p class=""><asp:Label ID="LabelDescription" runat="server"></asp:Label></p>
                          </div>
                    </div>


            <asp:Label ID="LabelMessage" runat="server"></asp:Label> 

        </div>
    </div>
</asp:Content>