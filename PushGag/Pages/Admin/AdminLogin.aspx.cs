using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushGag.DAO;
using PushGag.DTO;

namespace PushGag.Pages.Admin
{
    public partial class AdminLogin : System.Web.UI.Page {

        private EmployeeDAO employeDAO;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Admin_ID"] != null) {
                // What are you doing here? .. 
                Response.Redirect("/admin");
            }
            employeDAO = new EmployeeDAO();
        }

        protected void Login_User(object sender, EventArgs e) {

            EmployeeDTO employeeDTO = employeDAO.Get(PasswordTextBox.Text, UsernameTextBox.Text);
            if (employeeDTO != null) {
                LabelResult.Text = "Hey, " + employeeDTO.Username;
                Session["Admin_Username"] = employeeDTO.Username;
                Session["Admin_ID"] = employeeDTO.ID;
                Response.Redirect("/admin");
            } else {
                LabelResult.Text = "Username ou mot de passe Incorrect.";
            }
  
        }
    }
}