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

            List<ArticleDTO> articlesList = articlesDAO.GetAll();
            foreach (ArticleDTO articleDTO in articlesList) {
                SiteContent.Controls.Add(new LiteralControl(ShowArticle(articleDTO)));
            }
                    

        }

        private string ShowArticle(ArticleDTO articleDTO) {
            string articleHTML = "";
            if (articleDTO.Type == EnumType.picture) {
                articleHTML = "<div class='well well-lg'>"
                                + "<div class='.text-muted'><h2>" + articleDTO.Title + "</h2></div>"
                                + "<img class='img-responsive' width='620' src='" + articleDTO.Data + "'>"
                                + "</div>";
            } else if (articleDTO.Type == EnumType.text) {
                articleHTML = "<div class='well well-lg'>"
                                + "<div class='.text-muted'><h2>" + articleDTO.Title + "</h2></div>"
                                + "<p class='m-l-5'>" + articleDTO.Data + "</p>"
                                + "</div>";
            } else if (articleDTO.Type == EnumType.video) {
                articleHTML = "<div class='well well-lg'>"
                                + "<div class='.text-muted m-l-5'><h2>" + articleDTO.Title + "</h2></div>"
                                + "<div class='embed-responsive embed-responsive-16by9'>"
                                + "<iframe class='embed-responsive-item' src='" + articleDTO.Data + "'></iframe>"
                                + "</div>"
                                + "</div>";
            }
            return articleHTML;
        }

    }
}