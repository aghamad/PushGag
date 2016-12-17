using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushGag.DTO;
using PushGag.DAO;
using System.Web.UI.HtmlControls;

namespace PushGag
{
    public partial class Home : System.Web.UI.Page {


        private ArticlesDAO articlesDAO;
        private UsersLogDAO usersLogDAO;

        protected void Page_Load(object sender, EventArgs e) {

            articlesDAO = new ArticlesDAO();
            usersLogDAO = new UsersLogDAO();

            if (Session["user_name"] != null) {
                Label1.Text =   "Session Created with success "+ Session["user_name"].ToString(); ;
            }
            else {

                Label1.Text = "Session was NOT Created";
            }

            List<ArticleDTO> articlesList = null;

            if (Request.QueryString["filter"] != null) {
                string categorie = Request.QueryString["filter"];
                Label1.Text = "FIltering by " + (EnumCategorie) int.Parse(categorie);
                articlesList = articlesDAO.GetAllByCategory(categorie);
            } else {
                articlesList = articlesDAO.GetAll();
            }

            foreach (ArticleDTO articleDTO in articlesList) {
                Button ButtonPull = new Button();
                ButtonPull.Text = "Pull";
                ButtonPull.ID = articleDTO.ArticleID.ToString();
                ButtonPull.ControlStyle.CssClass = "btn btn-warning";
                ButtonPull.Click += new EventHandler(Pull_Click);
                SiteContent.Controls.Add(ButtonPull);
                //SiteContent.Controls.Add(new LiteralControl(ShowArticle(articleDTO)));

                Button ButtonComment = new Button();
                ButtonComment.Text = "Comment";
                ButtonComment.ID = articleDTO.ArticleID.ToString()+ "00";
                ButtonComment.ControlStyle.CssClass = "btn btn-warning";
                ButtonComment.Click += new EventHandler(Comment_Click);
                SiteContent.Controls.Add(ButtonComment);
                SiteContent.Controls.Add(new LiteralControl(ShowArticle(articleDTO)));
            }
        }

        private string ShowArticle(ArticleDTO articleDTO) {
            string articleHTML = "";
            if (articleDTO.Type == EnumType.picture) {
                articleHTML = "<div class='well well-lg' style='background: #5bc0de;'>"
                                + "<h3>" + articleDTO.Title + "</h3>"
                                + "<img class='img-responsive' src='" + articleDTO.Data + "'>";
            } else if (articleDTO.Type == EnumType.text) {
                articleHTML = "<div class='well well-lg' style='background: #818a91;'>"
                                + "<h3>" + articleDTO.Title + "</h3>"
                                + "<p class='m-l-5'>" + articleDTO.Data + "</p>";                         
            } else if (articleDTO.Type == EnumType.video) {
                articleHTML = "<div class='well well-lg' style='background: #f0ad4e;' Autopostback=false >"
                                + "<h3>" + articleDTO.Title + "</h3>"
                                + "<div class='embed-responsive embed-responsive-16by9'>"
                                + "<iframe class='embed-responsive-item' src='" + articleDTO.Data + "'></iframe>"
                                + "</div>";
            }
            // Date
            articleHTML += "<p>" + articleDTO.DatePublished.ToString("dd-MM-yyyy") + "</p>";
            // Button push with Ajax
            // Add thumbs up 
            
            // Close the well
            articleHTML += "</div>";
            return articleHTML;
        }


        protected void Pull_Click(object sender, EventArgs e)  {
            if (Session["user_name"] != null) {
                Button buttonClicked = sender as Button;
                int articleID = int.Parse(buttonClicked.ID);

                // Test
                LabelTest.Text = "Clicked on article " + articleID;

                UsersLogDTO logDTO = new UsersLogDTO();
                logDTO.UserID = int.Parse(Session["User_ID"].ToString());
                logDTO.ArticleID = articleID;
                usersLogDAO.AddPull(logDTO);
            } else {
                // Login!!
                Response.Redirect("/login");
            }
        }

        protected void Comment_Click(object sender, EventArgs e) {
            Button buttonClicked = sender as Button;
            int articleID = int.Parse(buttonClicked.ID);
            LabelTest.Text = "Clicked on article " + articleID;
            //UsersLogDTO logDTO = new UsersLogDTO();
            string myId = articleID.ToString();
            myId = myId.Remove(myId.Length - 2);
            Response.Redirect("/Pages/Articles.aspx?filter="+ myId);
        }

    }
}