<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="PushGag.Pages.Admin.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="formLogIn" runat="server">
    <asp:TextBox ID="UsernameTextBox" placeholder="Username" runat="server"/>
    </br>
    <asp:TextBox ID="PasswordTextBox" placeholder="Password" runat="server" TextMode="Password"/>
    <br />
    <asp:Label ID="LabelResult" runat="server"></asp:Label>
    </br>
    <asp:Button class="btn-success" ID="SubmitButton" Text="Sign in" runat="server" OnClick="Login_User" />
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OtherJavascript" runat="server">
</asp:Content>
