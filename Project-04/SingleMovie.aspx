<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SingleMovie.aspx.cs" Inherits="Project_04.SingleMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container-fluid">
    <div class="row">
        <div class="col-xs-12">
          
        </div>
         <div class="col-xs-12">
          
        </div>
    </div>
</div>


    <div class="container-fluid">
        <div class="row">
                    <div class="col-6">
                        <asp:Image ID="ImagePoster" runat="server" ImageUrl="~/img/poster-placeholder.jpeg" CssClass="image-poster" /> 
                        <!-- <img src="<%# Eval("Poster") %>" alt="poster" class="image-poster" /> -->
                    </div>
                    <div class="col-6">
                        <asp:Repeater ID="RepeaterSingleMovie" runat="server">
                            <ItemTemplate>
                                <h3 class="heading-label"><asp:Label ID="LabelTitle" runat="server" Text="Label"><%# Eval("Title") %></asp:Label></h3>
                                <p class="p-small-bold"><asp:Label ID="LabelInfo" runat="server" Text="Label"><%# Eval("Genre") %>, <%# Eval("Year") %></asp:Label></p>
                                <p class=""><asp:Label ID="LabelDirector" runat="server"></asp:Label></p>
                                <p class=""><asp:Label ID="LabelActors" runat="server"></asp:Label></p>
                                <p class=""><asp:Label ID="LabelRating" runat="server"></asp:Label></p>
                                <p class=""><asp:Label ID="LabelDescription" runat="server"></asp:Label></p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>


            <!--<asp:Label ID="LabelMessage" runat="server" Text="No messages"></asp:Label>-->

        </div>
    </div>
</asp:Content>