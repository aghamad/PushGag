<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PushGag.Pages.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Register - PushGag</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="formRegistration" runat="server">
        <asp:TextBox ID="emailTextBox" placeholder="Email" runat="server"/>
        <asp:TextBox ID="usernameTextBox" placeholder="Username" runat="server"/>
        <asp:TextBox ID="passwordTextBox" placeholder="Password" runat="server"/>
        <asp:Button class="btn-success" ID="SubmitButton" Text="Sign Up" runat="server" OnCLick="Register_User"/>
    </form>
</asp:Content>
