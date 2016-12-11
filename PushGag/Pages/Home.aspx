<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PushGag.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Home - PushGag</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="col-md-8">
        <div class="jumbotron">             
            <h3>Welcome to PushGag!</h3>
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <div runat="server" id="SiteContent">
            
        </div>
    </div>
</asp:Content>
