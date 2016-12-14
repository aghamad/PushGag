<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PushGag.Pages.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Register - PushGag</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="col-md-8">
        <div class="alert alert-info">
            <strong>Hey!</strong> Sign up and pull!
        </div>
        <form id="formRegistration" runat="server">
            <div class="form-group">
                <label for="emailTextBox">Email</label>
                <asp:TextBox  ID="emailTextBox" class="form-control" placeholder="Email" runat="server" Width="50%" required autofocus/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Veillez entrer un email" ControlToValidate="emailTextBox">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Veillez entrer un email valide" ControlToValidate="emailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:Label ID="lblEmail" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="form-group">
                <label for="usernameTextBox">Username</label>
                <asp:TextBox ID="usernameTextBox" class="form-control" placeholder="Username" runat="server" Width="50%" required autofocus/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Veillez entrer un username" ControlToValidate="usernameTextBox">*</asp:RequiredFieldValidator>
                <asp:Label ID="lblUsername" runat="server" ForeColor="Red"></asp:Label>
            </div>
             <div class="form-group">
                <label for="passwordTextBox">Password</label>
                <asp:TextBox ID="passwordTextBox" class="form-control" placeholder="Password" runat="server" TextMode="Password" Width="50%" required autofocus/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Veillez entrer un mot de passe" ControlToValidate="passwordTextBox">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Minimum 8 characters et au moin 1 Alphabet, 1 chiffre et 1  character spetial" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&amp;])[A-Za-z\d$@$!%*#?&amp;]{8,}$" ControlToValidate="passwordTextBox">*</asp:RegularExpressionValidator>
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <asp:Button class="btn btn-warning" ID="SubmitButton" Text="Sign Up" runat="server" OnClick="Register_User" />
            <br />
            <asp:Label ID="lblUserPassW" runat="server" Text=""></asp:Label>
        </form>
    </div>
</asp:Content>
