using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }
}