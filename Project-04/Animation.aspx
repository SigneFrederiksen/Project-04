<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Animation.aspx.cs" Inherits="Project_04.Animation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
    <div class="row">
        <div class="col-xs-12">

            <h2>Animation</h2>

            <asp:Repeater ID="RepeaterAnimation" runat="server">
                <ItemTemplate>
                    <div class="moviedisplay">
                        <h3><%# Eval("Title") %></h3>
                        <p>Year: <%# Eval("Year") %></p>
                        <img class="moviepic" src="<%# Eval("Poster") %>" alt="movie" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:Label ID="LabelMessage" runat="server" Text="No messages"></asp:Label>
        </div>
    </div>
</div>

</asp:Content>