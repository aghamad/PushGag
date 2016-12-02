<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PushGag.Pages.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Register - PushGag</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="formRegistration" runat="server">
        <asp:TextBox ID="emailTextBox" placeholder="Email" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Veillez entrer un email" ControlToValidate="emailTextBox">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Veillez entrer un email valide" ControlToValidate="emailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <asp:Label ID="lblEmail" runat="server" ForeColor="Red"></asp:Label>
</br>
        <asp:TextBox ID="usernameTextBox" placeholder="Username" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Veillez entrer un username" ControlToValidate="usernameTextBox">*</asp:RequiredFieldValidator>
        <asp:Label ID="lblUsername" runat="server" ForeColor="Red"></asp:Label>
</br>
        <asp:TextBox ID="passwordTextBox" placeholder="Password" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Veillez entrer un mot de passe" ControlToValidate="passwordTextBox">*</asp:RequiredFieldValidator></br>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Button class="btn-success" ID="SubmitButton" Text="Sign Up" runat="server" OnCLick="Register_User"/>
    </form>
</asp:Content>
