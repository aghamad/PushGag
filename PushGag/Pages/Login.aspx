<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PushGag.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login - PushGag</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="col-md-8">
        <div class="alert alert-info">
            <strong>Hey!</strong> PushUser, how are you doing today?
        </div>
        <form id="formLogIn" runat="server">
            <div class="form-group">
                <label for="usernameTextBox">Username</label>
                <asp:TextBox  ID="usernameTextBox" class="form-control" placeholder="Username" runat="server" Width="50%" required autofocus/>
            </div>
            <div class="form-group">
                <label for="passwordTextBox">Password</label>
                <asp:TextBox ID="passwordTextBox" class="form-control" placeholder="Password" runat="server" Width="50%" TextMode="Password" required autofocus/>
            </div>
            <asp:Button class="btn btn-success" ID="SubmitButton" Text="Sign in" runat="server" OnClick="Login_User" />
            <br />
            <asp:Label ID="lblUserPassW" runat="server" Text=""></asp:Label>
        </form>
    </div>
</asp:Content>
