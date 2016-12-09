using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace PushGag
{
    //string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString;
    public partial class Layout : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_name"] != null)
            {
                login.Visible = false;
                signup.Visible = false;
                //ButtonReplaceId.Visible = false;


            }
            else
            {
                logout.Visible = false;

            }
        }

        protected void MyFuncion_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('okokok')", true);
            Session.Remove("user_name");
            Session.RemoveAll();
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

        }
    }
}