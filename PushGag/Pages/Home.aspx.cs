using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushGag.DTO;
using PushGag.DAO;

namespace PushGag
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] != null)
            {
                Label1.Text =   "Session Created with success "+ Session["user_name"].ToString(); ;

            }
            else {

                Label1.Text = "Session was NOT Created";
            }

            ArticlesDAO articlesDAO = new ArticlesDAO();
            
            
            // foreach (var item in articleDTO)
            // {
            //    this.Controls.Add(new LiteralControl("<div style='color: gray; height: 20px; width: 300px;'> fefg" + it.Title + " </div>"));
            //}
            List<ArticleDTO> articlelist = articlesDAO.GetAll();
            foreach (ArticleDTO myArticle in articlesDAO.GetAll())
            {
                this.Controls.Add(new LiteralControl("<table class='table' style='height: 367px; width: 638px;'><tbody><tr style='height: 20px;'><td style='width: 66px; height: 20px;'>&nbsp;</td><td class='panel - heading' style='height: 20px; width: 504px;'>" + myArticle.Title + "</td><td style='width: 67px; height: 20px;'>&nbsp;</td></tr><tr style='height: 372px;'><td style='width: 66px; height: 372px;'>&nbsp;</td><td style='width: 504px; height: 372px;'><img style='width:100%; height:auto;' src='" + myArticle.Data + "'></td><td style='width: 67px; height: 372px;'>&nbsp;</td></tr><tr style='height: 48px;'><td style='width: 66px; height: 48px;'>&nbsp;</td><td style='width: 504px; height: 48px;'>" + myArticle.DatePublished + "</td><td style='width: 67px; height: 48px;'>&nbsp;</td></tr></tbody></table> "));
            }
                    

        }
    }
}