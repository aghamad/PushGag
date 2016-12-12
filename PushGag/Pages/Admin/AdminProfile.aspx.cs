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
    public partial class AdminProfile : System.Web.UI.Page {

        EmployeeDTO employeeDTO;
        EmployeeDAO employeeDAO;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Admin_ID"] != null) {
                employeeDAO = new EmployeeDAO();
                // Test: LabelResult.Text = Session["Admin_ID"].ToString();
                employeeDTO = employeeDAO.Read(Int32.Parse(Session["Admin_ID"].ToString()));
                UsernameTextBox.Text = employeeDTO.Username;
            } else {
                Response.Redirect("/admin");
            }
        }

        protected void Edit_Admin(object sender, EventArgs e) {
            if (PasswordTextBox.Text != null) {
                employeeDTO.Password = PasswordTextBox.Text;
                employeeDAO.Update(employeeDTO);
                LabelResult.Text = "Password Updated!";
            }
        }

    }
}