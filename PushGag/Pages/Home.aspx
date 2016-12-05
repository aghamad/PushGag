<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PushGag.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Home - PushGag</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="form1" runat="server">
        <h3 class="display-5">Welcome to PushGag!<asp:Label ID="Label1" runat="server"></asp:Label>
        </h3>
    </form>
</asp:Content>
