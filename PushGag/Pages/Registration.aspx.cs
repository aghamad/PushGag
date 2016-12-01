using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using PushGag.DTO;
using PushGag.DAO;

namespace PushGag.Pages
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Register_User(object sender, EventArgs e) {
            //var usersAdd = new DAO.UsersDAO();
            Console.WriteLine("Ass");
            UsersDAO usersDAO = new UsersDAO();
            UserDTO userDTO = new UserDTO();
            userDTO.Username = usernameTextBox.Text;
            userDTO.Password = passwordTextBox.Text;
            userDTO.Email = emailTextBox.Text;
            usersDAO.Add(userDTO); 
        }
    }
}