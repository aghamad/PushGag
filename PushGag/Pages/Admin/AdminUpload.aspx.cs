using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushGag.DTO;
using PushGag.DAO;
using PushGag.Util;
using CloudinaryDotNet;
using System.Web.Configuration;
using CloudinaryDotNet.Actions;
using System.IO;

namespace PushGag.Pages.Admin
{
    public partial class AdminUpload : System.Web.UI.Page , ImageUploader {

        private const string API_URL = "http://res.cloudinary.com/dqbwcvfq7/image/upload/";

        private ArticlesDAO articlesDAO;
        private EmployeeLogDAO employeeLogDAO; 
        private Cloudinary cloudinaryAccount;

        public Cloudinary GetCloudinaryAccount() {
            Account account = new Account(
              "dqbwcvfq7",
              "424299363629451",
               WebConfigurationManager.AppSettings["MyAPISecret"]);
            return new Cloudinary(account);
        }

        // Uploads Image and returns URL to the image 
        public string UploadImage(string imagePath) {
            var uploadParams = new ImageUploadParams() {
                File = new FileDescription(@imagePath)
            };
            if (cloudinaryAccount == null) {
                cloudinaryAccount = GetCloudinaryAccount();
            }
            var uploadResult = cloudinaryAccount.Upload(uploadParams);
            return API_URL + uploadResult.PublicId;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["user_name"] != null) {
                // User, in admin page? Out
                Response.Redirect("/");
            } else if (Session["Admin_ID"] == null) {
                Response.Redirect("/admin/login");
            } else {
                // Load le ListBox avec nos categories 
                articlesDAO = new ArticlesDAO();
                employeeLogDAO = new EmployeeLogDAO();
                foreach (EnumCategorie categorie in Enum.GetValues(typeof(EnumCategorie))) {
                    ListItem item = new ListItem(categorie.ToString());
                    DropDownListCategorie.Items.Add(item);
                }
            }
        }

        protected void Upload_Data(object sender, EventArgs e) {
            string title = titleTextBox.Text;
            string categorie = DropDownListCategorie.SelectedValue;
            string data = "";
            EnumType type = EnumType.text;

            // Image en priorité
            if (FileUploadImage.HasFile) {
                string fileName = FileUploadImage.FileName;
                string imagePath = Server.MapPath(".") + "//Uploads//" + fileName;
                FileUploadImage.PostedFile.SaveAs(imagePath);
                // Upload to Cloudinary 
                type = EnumType.picture;
                data = UploadImage(imagePath);
                // get url and store it to data variable 

            } else if (textTextBox.Text != "") {
                type = EnumType.text;
                data = textTextBox.Text;
            } else if (videoTextBox.Text != "") {
                type = EnumType.video;
                data = videoTextBox.Text;
            } 

            ArticleDTO articleDTO = new ArticleDTO();
            articleDTO.Title = title;
            articleDTO.Categorie = ArticleDTO.ParseEnum<EnumCategorie>(categorie);
            articleDTO.Data = data;
            articleDTO.Type = type;

            long result = articlesDAO.Add(articleDTO);
            if (result != 0) {
                // Add to history
                EmployeeLogDTO logDTO = new EmployeeLogDTO();
                logDTO.EmployeeID = Int32.Parse(Session["Admin_ID"].ToString());
                logDTO.ArticleID = (int) result;
                employeeLogDAO.Add(logDTO);

                AdminLabel.Text = "Succesfully Added your " + articleDTO.Type + " in " + articleDTO.Categorie;
            }
            else {
                AdminLabel.Text = "Error Please try again";
            }
        }


    }
}