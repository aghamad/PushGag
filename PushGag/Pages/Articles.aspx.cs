using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushGag.DAO;
using PushGag.DTO;
using System.Web.UI.HtmlControls;

namespace PushGag.Pages
{
    public partial class Articles : System.Web.UI.Page
    {
        private ArticlesDAO articlesDAO;

        protected void Page_Load(object sender, EventArgs e)
        {
            articlesDAO = new ArticlesDAO();
            List<ArticleDTO> articlesList = null;
            List<CommentsDTO> commentsList = null;
            string categorie = Request.QueryString["filter"];
            string id = Request.QueryString["filter"];
            //Label1.Text = "FIltering by " + (EnumCategorie)int.Parse(categorie);
            articlesList = articlesDAO.GetAllById(id);
            commentsList = articlesDAO.GetComments(id);

            foreach (ArticleDTO articleDTO in articlesList)
            {
                SiteContent.Controls.Add(new LiteralControl(ShowArticle(articleDTO)));
                
            }

            foreach (CommentsDTO commentsDTO in commentsList)
            {
                CommentsContent.Controls.Add(new LiteralControl(ShowComments(commentsDTO)));
            }

        }
        private string ShowArticle(ArticleDTO articleDTO)
        {
            string articleHTML = "";
            if (articleDTO.Type == EnumType.picture)
            {
                articleHTML = "<div class='well well-lg' style='background: #5bc0de;'>"
                                + "<h3>" + articleDTO.Title + "</h3>"
                                + "<img class='img-responsive' src='" + articleDTO.Data + "'>";
            }
            else if (articleDTO.Type == EnumType.text)
            {
                articleHTML = "<div class='well well-lg' style='background: #818a91;'>"
                                + "<h3>" + articleDTO.Title + "</h3>"
                                + "<p class='m-l-5'>" + articleDTO.Data + "</p>";
            }
            else if (articleDTO.Type == EnumType.video)
            {
                articleHTML = "<div class='well well-lg' style='background: #f0ad4e;'>"
                                + "<h3>" + articleDTO.Title + "</h3>"
                                + "<div class='embed-responsive embed-responsive-16by9'>"
                                + "<iframe class='embed-responsive-item' src='" + articleDTO.Data + "'></iframe>"
                                + "</div>";
            }
            // Date
            articleHTML += "<p>" + articleDTO.DatePublished.ToString("dd-MM-yyyy") + "</p>";
            // Close the well
            // Button push with Ajax
            articleHTML += "<asp:UpdatePanel ID='UpdatePanel1' runat='server'>";
            articleHTML += "<ContentTemplate>";
            articleHTML += "<asp:Button ID='button' type='button' OnClick='Pull_Click' class='btn btn-default btn- lg'>Pull</asp:button>";
            articleHTML += "</ContentTemplate>";
            articleHTML += "</asp:UpdatePanel>";
            articleHTML += "</div>";
            // Add thumbs up 
            return articleHTML;
        }

        private string ShowComments(CommentsDTO commentsDTO)
        {
            string commentHTML = "";

            commentHTML = "<li class='list-group-item'><b>"+commentsDTO.Username+"</b>&nbsp;&nbsp;" + commentsDTO.Comment +"</li>";

            return commentHTML;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["user_name"] != null)
            {
                int idArticle = Int32.Parse(Request.QueryString["filter"]);
                string username = Session["user_name"].ToString();
                articlesDAO = new ArticlesDAO();
                articlesDAO.AddComment(idArticle, username, commentTxt.Text);
                Response.Redirect(Request.RawUrl);
            }
            else {
                Response.Redirect("Login.aspx");
            }
        }
    }
}