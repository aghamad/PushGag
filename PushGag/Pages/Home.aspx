<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PushGag.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Home - PushGag</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="col-md-8">
        <div class="jumbotron">             
            <h3>Welcome to PushGag!</h3>
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <form runat="server">
            <asp:ScriptManager ID="ScriptManagerPull" runat="server"></asp:ScriptManager>
            <!-- Ajax -->
            <asp:UpdatePanel ID="UpdatePanelPull" runat="server">
                <ContentTemplate>
                    <asp:Label ID="LabelTest" runat="server" Text="Clicked on article: "></asp:Label>
                    <div runat="server" id="SiteContent">

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel> 
            <!-- /Ajax -->   
       </form>
    </div>
    <div class="col-md-4">
        <div class="alert alert-info">
            <strong>Info!</strong> Please Sign Up!
        </div>
    </div>
</asp:Content>
