using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushGag.DTO;
using PushGag.DAO;

namespace PushGag.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Login_User(object sender, EventArgs e) {


            UsersDAO usersDAO = new UsersDAO();
            int countUserPassw = usersDAO.doesUserMdpExist(passwordTextBox.Text, usernameTextBox.Text);
            //int countUsers = usersDAO.doesUserExist(usernameTextBox.Text);

            if (countUserPassw == 0)
            {
                lblUserPassW.Text = "Username ou mot de passe Incorrect.";
 
            }
            else
            {
                lblUserPassW.Text = "connection ok";
                Session["user_name"] = usernameTextBox.Text;
                Response.Redirect("/");
            }
        }
    }
}