﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminUpload.aspx.cs" Inherits="PushGag.Pages.Admin.AdminUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Upload - PushGag</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <form id="formAdminUpload" class="form-group" runat="server">
        <asp:ScriptManager ID="ScriptManagerUpload" runat="server"></asp:ScriptManager>
    <div class="col-md-8">
        <div class="alert alert-info">
            <strong>Info!</strong> Upload article.
        </div>
        <label>Titre</label>
        <asp:TextBox ID="titleTextBox" class="form-control" placeholder="Title" runat="server" Width="70%" required autofocus/>
        <br />

        <label>Catégorie</label>
        <asp:DropDownList ID="DropDownListCategorie" multiple class="form-control p-t-2" runat="server" Width="70%" required autofocus>
        </asp:DropDownList>
        <br />

        <label>Type de format</label>
        <ul class="nav type-section">
            <li class="nav-item"><a class="nav-link" id="text">Text</a></li>
            <li class="nav-item"><a class="nav-link" id="video">Video</a></li>
            <li class="nav-item"><a class="nav-link" id="image">Image</a></li>
        </ul>
        <br />

        <div class="typeText">
            <label>Text:</label> <asp:RegularExpressionValidator ID="RegularExpressionValidatorText" runat="server" ErrorMessage="Veuillez entrer 8 caractère ou plus" ControlToValidate="textTextBox" ForeColor="Red" ValidationExpression="^.{8,150}$"></asp:RegularExpressionValidator>
            <asp:TextBox ID="textTextBox" class="form-control texto" OnClick="clearImageField();" TextMode="multiline" Columns="50" Rows="5" placeholder="Enter a joke or a riddle or ...." runat="server"/>
        </div>

        <div class="typeVideo">
            <label>Video:</label> <asp:RegularExpressionValidator ID="RegularExpressionValidatorYoutube" runat="server" ErrorMessage="Veuillez entrer un link YouTube valide" ControlToValidate="videoTextBox" ForeColor="Red" ValidationExpression="(?:https?:\/\/)?(?:www\.)?youtu\.?be(?:\.com)?\/?.*(?:watch|embed)?(?:.*v=|v\/|\/)([\w\-_]+)\&?"></asp:RegularExpressionValidator>
            <asp:TextBox ID="videoTextBox" class="form-control input-video" OnClick="clearTextoField();" rows="1" placeholder="Enter a valid embed YouTube link" runat="server"/>
        </div>

        <div class="typeImage">
            <label>Image:</label>     
            <label class="btn btn-default btn-file">
            <asp:FileUpload ID="FileUploadImage" runat="server" />
            </label>
        </div>
        <br />
        <asp:Button ID="ButtonUpload" class="btn btn-success" runat="server" OnClick="Upload_Data" Text="Push" />
        <br />
        <asp:Label ID="AdminLabel" runat="server" Text="Push it hard"></asp:Label>
    </div>
    </form> 
    <div class="col-md-4">
        <ul class="nav nav-pills nav-stacked">
            <li class="active"><a href="/admin">Push</a></li>
            <li><a href="/admin/profile">Profile</a></li>
            <li><a href="/admin/history">History</a></li>
        </ul>
    </div>
    <script>  
         function clearImageField(){
             $(".input-video").val("");
         };

         function clearTextoField() {
             $(".texto").val("");
         };
    </script>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="OtherJavascript" runat="server">
    <script type="text/javascript" src="Scripts/PushGag/adminUpload.js"></script>
</asp:Content>

