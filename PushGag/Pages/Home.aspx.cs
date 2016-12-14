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

        protected void Page_Load(object sender, EventArgs e) {

            articlesDAO = new ArticlesDAO();

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
                SiteContent.Controls.Add(new LiteralControl(ShowArticle(articleDTO)));
            }
            Button button = new Button();
            button.Click += new EventHandler(this.Pull_Click);
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


        protected void Pull_Click(object sender, EventArgs e)
        {
              
            Button button = sender as Button;
            button.Text = "izane";  
        }



        }
}