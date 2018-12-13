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


            <div class="col-md-12 movie-pagination"> 
                <asp:button id="ButtonPrev" runat="server" text=" << " OnClick="ButtonPrev_Click" CssClass="button-pagination"></asp:button>     

                <asp:label id="LabelCurrentPage" runat="server" CssClass="label-pagination"></asp:label>

                <asp:button id="ButtonNext" runat="server" text=" >> " OnClick="ButtonNext_Click" CssClass="button-pagination"></asp:button>
            </div>

            <!--<asp:Label ID="LabelMessage" runat="server" Text="No messages"></asp:Label>-->

        </div>
    </div>

</asp:Content>