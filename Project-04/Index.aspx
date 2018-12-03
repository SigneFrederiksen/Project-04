<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project_04.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">      
        <div class="row">
    
        <h2 class="col-md-12 heading-label">Our Top Movies</h2>
 
        <asp:Repeater ID="RepeaterPopularMovies" runat="server">
            <ItemTemplate>
                <div class="col-xs-2 col-sm-2 col-md-4 col-lg-2 movie-list">
                    <asp:Image ID="ImagePoster" runat="server" ImageUrl="~/img/poster-placeholder.jpeg" CssClass="image-poster" />
                    <h3><%# Eval("Title") %></h3>   
                    <p class="p-small-bold"><%# Eval("Genre") %>, <%# Eval("Year") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        </div>
    </div>

    <div class="container-fluid">
        <div class="row">   
            <div class="col-xs-12 col-md-12">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>
