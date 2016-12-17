<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="PushGag.Pages.Admin.AdminProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
     <div class="col-md-8">
        <div class="alert alert-info">
            <strong>Info!</strong> Want to push it? Check out your exclusive Push page.
        </div>
        <form id="formLogin" runat="server">
            <asp:ScriptManager ID="ScriptManagerProfil" runat="server"></asp:ScriptManager>
            <div class="form-group">
                <label for="UsernameTextBox">Username</label>
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-user" aria-hidden="true"></i></span>
                    <asp:TextBox  ID="UsernameTextBox" class="form-control" placeholder="Username" runat="server" Width="50%" disabled/>
                </div>
            </div>

            <div class="form-group">
                <label for="PasswordTextBox">Password</label>
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-cog" aria-hidden="true"></i></span>
                    <asp:TextBox ID="PasswordTextBox" class="form-control" placeholder="Password" runat="server" Width="50%" TextMode="Password" required autofocus/>
                </div>
            </div>

            <div class="form-group">
                <label for="PasswordTextBox2">Password</label>
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-cog" aria-hidden="true"></i></span>
                    <asp:TextBox ID="PasswordTextBox2" class="form-control" placeholder="Password" runat="server" Width="50%" TextMode="Password" required autofocus/> 
                    <asp:CompareValidator ID="CompareValidatorPassword" style="margin                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               :2%;" runat="server" ErrorMessage="Password do not match" ControlToCompare="PasswordTextBox" ControlToValidate="PasswordTextBox2"></asp:CompareValidator>
                </div>
            </div>
            
            <br />
            <asp:Button class="btn btn-success" ID="SubmitButton" Text="Edit" runat="server" Width="10%" OnClick="Edit_Admin" />
            <br />
            <br />
            <asp:Label ID="LabelResult" runat="server" Text=""></asp:Label>
        </form>
    </div>
    <div class="col-md-4">
        <ul class="nav nav-pills nav-stacked">
            <li><a href="/admin">Push</a></li>
            <li class="active"><a href="/admin/profile">Profile</a></li>
            <li><a href="/admin/history">History</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OtherJavascript" runat="server">
</asp:Content>
