<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="PushGag.Pages.Admin.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="col-md-8">
        <div class="alert alert-danger">
            <strong>Watch Out!</strong> Admin Login Only.
        </div>
        <div class="alert alert-info">
            <strong>Info!</strong> Want to be admin? Send us an email.
        </div>
        <form id="formLogin" runat="server">
            <div class="form-group">
                <label for="UsernameTextBox">Username</label>
                <asp:TextBox  ID="UsernameTextBox" class="form-control" placeholder="Enter Username" runat="server" Width="50%" required autofocus/>
            </div>
            <div class="form-group">
                <label for="PasswordTextBox">Password</label>
                <asp:TextBox ID="PasswordTextBox" class="form-control" placeholder="Password" runat="server" Width="50%" TextMode="Password" required autofocus/>
            </div>
            <asp:Button class="btn btn-success" ID="SubmitButton" Text="Sign in" runat="server" OnClick="Login_User" />
            <br />
            <asp:Label ID="LabelResult" runat="server" Text=""></asp:Label>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OtherJavascript" runat="server">
</asp:Content>
