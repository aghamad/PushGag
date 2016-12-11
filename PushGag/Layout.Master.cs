using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace PushGag
{
    public partial class Layout : System.Web.UI.MasterPage {
        
        protected void Page_Load(object sender, EventArgs e) {
       
            if (Session["user_name"] != null || Session["Admin_ID"] != null)  {
                login.Visible = false;
                signup.Visible = false;
            } else {
                logout.Visible = false;
            }
        }


        protected void Logout_Event(object sender, EventArgs e) {

            if (Session["Admin_ID"] != null) {
                Session.Remove("Admin_Username");
                Session.Remove("Admin_ID");
            } else {
                Session.Remove("user_name");
            }

            Session.RemoveAll();
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }
    }
}