<%@ Page Language="C#"  MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="Project_04.Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">

            <h2 class="col-md-12 heading-label">Action</h2>

            <asp:Repeater ID="RepeaterAction" runat="server">
                <ItemTemplate>
                    <div class="col-6 col-sm-6 col-md-4 col-lg-2 movie-list">
                        <a href="SingleMovie.aspx?title=<%# Eval("Title") %>&id=<%# Eval("Id") %>&year=<%# Eval("Year") %>&genre=<%# Eval("Genre") %>">
                      <!--  <a href="SingleMovie.aspx?poster&=<%# Eval("Poster") %>title=<%# Eval("Title") %>&id=<%# Eval("Id") %>&year=<%# Eval("Year") %>&genre=<%# Eval("Genre") %>"> -->
                     <asp:Image ID="ImagePoster" runat="server" ImageUrl="~/img/poster-placeholder.jpeg" CssClass="image-poster" />
                       <!--  <img src="<%# Eval("Poster") %>" alt="poster" class="image-poster" /> -->
                        <h3><%# Eval("Title") %></h3>
                        <p class="p-small-bold"><%# Eval("Genre") %>, <%# Eval("Year") %></p>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <!--<asp:Label ID="LabelMessage" runat="server" Text="No messages"></asp:Label>-->

        </div>
    </div>

</asp:Content>