<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminUpload.aspx.cs" Inherits="PushGag.Pages.Admin.AdminUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h3>Welcome to the admin panel [employee name]</h3>

    <form id="formAdminUpload" runat="server">
        <asp:DropDownList ID="DropDownListCategorie" runat="server">

        </asp:DropDownList>
        <asp:TextBox ID="titleTextBox" placeholder="Title" runat="server"/>

        
    </form>

</asp:Content>
