<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PushGag.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login - PushGag</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="formLogIn" runat="server">
        <asp:TextBox ID="usernameTextBox" placeholder="Username" runat="server"/></br>
        <asp:TextBox ID="passwordTextBox" placeholder="Password" runat="server" TextMode="Password"/>
        <br />
        <asp:Label ID="lblUserPassW" runat="server"></asp:Label>
        </br>
        <asp:Button class="btn-success" ID="SubmitButton" Text="Sign in" runat="server" OnClick="Login_User" />
    </form>
</asp:Content>
