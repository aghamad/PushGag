using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushGag.DTO;
using PushGag.DAO;

namespace PushGag.Pages.Admin
{
    public partial class AdminUpload : System.Web.UI.Page
    {
        private ArticlesDAO articlesDAO;

        protected void Page_Load(object sender, EventArgs e) {
            // Load le ListBox avec nos categories 
            articlesDAO = new ArticlesDAO();

            /*
            foreach (String categorie in articlesDAO.GetAllCategorieValues()) {
                ListItem item = new ListItem(categorie);
                DropDownListCategorie.Items.Add(item);
            }
            */

            foreach (EnumCategorie categorie in Enum.GetValues(typeof(EnumCategorie))) {
                ListItem item = new ListItem(categorie.ToString());
                DropDownListCategorie.Items.Add(item);
            }
           

        }

        protected void Upload_Data(object sender, EventArgs e) {
            string title = titleTextBox.Text;
            string categorie = DropDownListCategorie.SelectedValue;
            string data = "";
            EnumType type = EnumType.text;

            if (!String.IsNullOrEmpty(textTextBox.Text)) {
                type = EnumType.text;
                data = textTextBox.Text;
            } else if (!String.IsNullOrEmpty(videoTextBox.Text)) {
                type = EnumType.video;
                data = videoTextBox.Text;
            } else  {
                type = EnumType.picture;
                // upload to cloudinary if validation passes through
            }

            ArticleDTO articleDTO = new ArticleDTO();
            articleDTO.Title = title;
            articleDTO.Categorie = ArticleDTO.ParseEnum<EnumCategorie>(categorie);
            articleDTO.Data = data;
            articleDTO.Type = type;

            AdminLabel.Text = articleDTO.ToString();
        }


    }
}