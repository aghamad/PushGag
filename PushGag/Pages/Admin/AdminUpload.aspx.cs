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

    }
}