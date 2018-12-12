<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SingleMovie.aspx.cs" Inherits="Project_04.SingleMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container-fluid">
    <div class="row">
        <div class="col-xs-12">
            <asp:Button ID="ButtonBack" runat="server" Text="<< Go back" OnClick="ButtonBack_Click" CssClass="button-back" />
        </div>
         <div class="col-xs-12">
          
        </div>
    </div>
</div>


    <div class="container-fluid">
        <div class="row">
                    <div class="col-6">
                      <!--  <asp:Image ID="ImagePoster" runat="server" ImageUrl="~/img/poster-placeholder.jpeg" CssClass="image-poster" /> -->
                        <asp:Image ID="ImagePoster2" runat="server" CssClass="image-info" /> 
                        <!-- <img src="<%# Eval("Poster") %>" alt="poster" class="image-poster" /> -->
                    </div>
                    <div class="col-6">
                          <div class="single-details">
                                <h3 class="heading-label"><asp:Label ID="LabelTitle" runat="server" Text="Label"><%# Eval("Title") %></asp:Label></h3>
                                <p class="p-undertitle dot"><asp:Label ID="LabelYear" runat="server" Text="Label"> <%# Eval("Year") %></asp:Label></p>
                                <asp:Label ID="LabelDot1" runat="server" Text="Label"><span class="dot" role="presentation" aria-hidden="true"> · </span></asp:Label>
                                <p class="p-undertitle dot"><asp:Label ID="LabelRuntime" runat="server"></asp:Label></p>
                                <asp:Label ID="LabelDot2" runat="server" Text="Label"><span class="dot" role="presentation" aria-hidden="true"> · </span></asp:Label>
                                <p class="p-undertitle dot"><asp:Label ID="LabelGenre" runat="server" Text="Label"><%# Eval("Genre") %></asp:Label></p>
                                <asp:Label ID="LabelDot3" runat="server" Text="Label"><span class="dot" role="presentation" aria-hidden="true"> · </span></asp:Label>
                                <p class="p-undertitle"><asp:Label ID="LabelRated" runat="server"></asp:Label></p>
                                <!-- Label Message -->
                                <p class="no-movie"><asp:Label ID="LabelMessage" runat="server"></asp:Label> </p>
                                <p class=""><asp:Label ID="LabelDescription" runat="server"></asp:Label></p>
                                <div class="more-info">
                                <p><asp:Label ID="LabelSpanActors" runat="server" Text="Label" CssClass="span-info">Actors</asp:Label><asp:Label ID="LabelActors" runat="server" CssClass="label-info"></asp:Label></p>
                                <p><asp:Label ID="LabelSpanDirector" runat="server" Text="Label" CssClass="span-info">Director</asp:Label><asp:Label ID="LabelDirector" runat="server" CssClass="label-info"></asp:Label></p>
                                <p><asp:Label ID="LabelSpanLanguage" runat="server" Text="Label" CssClass="span-info">Language</asp:Label><asp:Label ID="LabelLanguage" runat="server" CssClass="label-info"></asp:Label></p>
                                <p><asp:Label ID="LabelSpanCountry" runat="server" Text="Label" CssClass="span-info">Country</asp:Label><asp:Label ID="LabelCountry" runat="server" CssClass="label-info"></asp:Label></p>
                                <p><asp:Label ID="LabelSpanAwards" runat="server" Text="Label" CssClass="span-info">Awards</asp:Label><asp:Label ID="LabelAwards" runat="server" CssClass="label-info"></asp:Label></p>
                                <p><asp:Label ID="LabelSpanRating" runat="server" Text="Label" CssClass="span-info">Rating</asp:Label><asp:Label ID="LabelRating" runat="server" CssClass="label-info"></asp:Label></p>
                                </div>
                          </div>
                    </div>
        </div>
    </div>
</asp:Content>