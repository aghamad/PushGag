<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminUpload.aspx.cs" Inherits="PushGag.Pages.Admin.AdminUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Upload - PushGag</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="row">
        <form id="formAdminUpload" class="form-group" runat="server">
        <div class="col-md-6">

            <label>Titre</label>
            <asp:TextBox ID="titleTextBox" class="form-control" placeholder="Title" runat="server" required autofocus/>
            <br />

            <label>Catégorie</label>
            <asp:DropDownList ID="DropDownListCategorie" multiple class="form-control p-t-2" runat="server" required autofocus>
            </asp:DropDownList>
            <br />

            <label>Type de format</label>
            <ul class="nav type-section">
                <li class="nav-item"><a class="nav-link" href="#" id="text">Text</a></li>
                <li class="nav-item"><a class="nav-link" href="#" id="video">Video</a></li>
                <li class="nav-item"><a class="nav-link" href="#" id="image">Image</a></li>
            </ul>
            <br />

            <div class="typeText">
                <label>Text:</label>
                <asp:TextBox ID="textTextBox" class="form-control" rows="5" placeholder="Enter a joke or a riddle or ...." runat="server"/>
            </div>

            <div class="typeVideo">
                <label>Video:</label>
                <asp:TextBox ID="videoTextBox" class="form-control" rows="1" placeholder="Enter a YouTube link" runat="server"/>
            </div>

             <div class="typeImage">
                <label>Image:</label>     
                <label class="btn btn-default btn-file">
                Browse <input type="file" style="display: none;" />
                </label>
            </div>
            <br />
            <asp:Button ID="ButtonUpload" class="btn btn-success" runat="server" OnCLick="Upload_Data" Text="Push" />
        </div>
        </form>
    </div>
    <asp:Label ID="AdminLabel" runat="server" Text="Label"></asp:Label>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="OtherJavascript" runat="server">
    <script type="text/javascript" src="Scripts/PushGag/adminUpload.js"></script>
</asp:Content>

