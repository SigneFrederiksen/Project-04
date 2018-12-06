<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AllMovies.aspx.cs" Inherits="Project_04.AllMovies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">

            <h2 class="col-md-12 heading-label">All movies</h2>

            <asp:Repeater ID="RepeaterAllMovies" runat="server">
                <ItemTemplate>
                    <div class="col-6 col-sm-6 col-md-4 col-lg-2 movie-list">
                    <
                        <asp:Image ID="ImagePoster" runat="server" ImageUrl="~/img/poster-placeholder.jpeg" CssClass="image-poster" /> 
                        <!-- <img src="<%# Eval("Poster") %>" alt="poster" class="image-poster" /> -->
                        <h3><%# Eval("Title") %></h3>
                        <p class="p-small-bold"><%# Eval("Genre") %>, <%# Eval("Year") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <!--<asp:Label ID="LabelMessage" runat="server" Text="No messages"></asp:Label>-->

        </div>
    </div>

</asp:Content>