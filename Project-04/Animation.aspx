<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Animation.aspx.cs" Inherits="Project_04.Animation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">

            <h2 class="col-md-12 heading-label">Animation</h2>

            <asp:Repeater ID="RepeaterAnimation" runat="server">
                <ItemTemplate>
                    <div class="col-6 col-sm-6 col-md-4 col-lg-2 movie-list">
                        <asp:Image ID="ImagePoster" runat="server" ImageUrl="~/img/poster-placeholder.jpeg" CssClass="image-poster" />
                        <h3><%# Eval("Title") %></h3>
                        <p class="p-small-bold"><%# Eval("Genre") %>, <%# Eval("Year") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <!--<asp:Label ID="LabelMessage" runat="server" Text="No messages"></asp:Label>-->

        </div>
    </div>

</asp:Content>