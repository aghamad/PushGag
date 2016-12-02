using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushGag.DTO;

namespace PushGag.Pages.Admin
{
    public partial class AdminUpload : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e) {
            // Load le ListBox avec nos categories 
            foreach (EnumCategorie categorie in Enum.GetValues(typeof(EnumCategorie))) {
                ListItem item = new ListItem(categorie.ToString());
                DropDownListCategorie.Items.Add(item);
            }

        }

        protected void Upload_Data(object sender, EventArgs e) {
            string title = titleTextBox.Text;
            // EnumCategorie categorie = DropDownListCategorie.SelectedValue;
            if (String.IsNullOrEmpty(textTextBox.Text)) {
                // Cela veut dire que le admin veux upload un text 
            } else if (String.IsNullOrEmpty(videoTextBox.Text)) {
                // video 
            } else  {
                // image // check if browse is not null
                // upload to cloudinary if validation passes through
            }
        }


    }
}