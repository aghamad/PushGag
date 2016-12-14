<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="PushGag.Pages.Articles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

        <div runat="server" id="SiteContent">
            
        </div>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManagerArticle" runat="server"></asp:ScriptManager>
    <div class='well well-lg' style='background: #e7e7e7;'>
        <div class="input-group">
        <asp:TextBox runat="server" class="form-control" ID="commentTxt" ></asp:TextBox>
            <div class="input-group-btn">
             <asp:Button class='btn btn-default btn- lg' ID="Button1" runat="server" Text="Comment" OnClick="Button1_Click" />
            </div>
       </div>
    </div>
        </form>
    
    <div runat="server" id="CommentsContent">       
    </div>
   
</asp:Content>

       
        
    