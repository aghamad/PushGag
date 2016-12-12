<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminHistory.aspx.cs" Inherits="PushGag.Pages.Admin.AdminHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="col-md-8">
        <div class="alert alert-info">
            <strong>Info!</strong> Everything you have pushed.
        </div>
        <form id="formGrid" runat="server">
            <asp:GridView ID="GridViewHistory" class="table table-hover table-striped bg-success" GridLines="None"  runat="server">
         
            </asp:GridView>
        </form>
        <asp:Label ID="Testing" runat="server" Text=""></asp:Label>
    </div>
    <div class="col-md-4">
        <ul class="nav nav-pills nav-stacked">
            <li><a href="/admin">Go back</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OtherJavascript" runat="server">
</asp:Content>
