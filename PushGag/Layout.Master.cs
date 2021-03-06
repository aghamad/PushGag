﻿using System;
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
            AdminLink.Visible = false;

            if (Session["user_name"] != null || Session["Admin_ID"] != null)  {
                login.Visible = false;
                signup.Visible = false;
            } else {
                logout.Visible = false;
            }

            if (Session["Admin_ID"] != null){
                AdminLink.Visible = true;
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
            //Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            Response.Redirect(Request.RawUrl);
        }

        protected void Go_Admin_Event(object sender, EventArgs e) {
            Response.Redirect("/admin");
        }
    }
}