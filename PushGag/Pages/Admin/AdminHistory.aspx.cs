using PushGag.DAO;
using PushGag.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PushGag.Pages.Admin
{
    public partial class AdminHistory : System.Web.UI.Page {

        private EmployeeLogDAO employeeLogDAO;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Admin_ID"] != null) {
                employeeLogDAO = new EmployeeLogDAO();

                // Fill DataGrid
                int adminID = Int32.Parse(Session["Admin_ID"].ToString());
                List<ArticleDTO> articlesHistory = employeeLogDAO.GetAllArticles(adminID);

                if (articlesHistory.Count != 0) {
                    GridViewHistory.DataSource = articlesHistory;
                    GridViewHistory.DataBind();
                }
                else {
                    Testing.Text = "Your history is empty. Push it!";
                }
            } else {
                Response.Redirect("/admin");
            }
        }
    }
}