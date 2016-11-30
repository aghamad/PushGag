using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace PushGag.Pages
{
    public partial class Registration : System.Web.UI.Page
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e){
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();
                Response.Write("OKOKOKOKO");
            }
        }

        protected void Register_User(object sender, EventArgs e){

        }
    }
}