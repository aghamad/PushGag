using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PushGag.DTO;
using MySql.Data.MySqlClient;

namespace PushGag.DAO
{
    public class ArticlesDAO {

        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString;

        public const string ADD_REQUEST = "INSERT INTO articles (type, categorie, data, article_title) " +
                                                    "VALUES (@type, @categorie, @data, @article_title)";

        public const string GET_ALL_CATEGORIE_VALUES = "SELECT COLUMN_TYPE FROM INFORMATION_SCHEMA.COLUMNS " +
                                                        "WHERE TABLE_NAME = articles AND COLUMN_NAME = categorie";

        public const string GET_ALL_ARTICLES = "SELECT id_article, article_title, data, date_article, pulled FROM articles ";

        public int Add(ArticleDTO articleDTO) {
            int result = 0;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand addCommand = new MySqlCommand(ADD_REQUEST, connection)) {
                    connection.Open();
                    addCommand.Parameters.AddWithValue("@type", articleDTO.Type);
                    addCommand.Parameters.AddWithValue("@categorie", articleDTO.Categorie);
                    addCommand.Parameters.AddWithValue("@data", articleDTO.Data);
                    addCommand.Parameters.AddWithValue("@article_title", articleDTO.Title);
                    result = addCommand.ExecuteNonQuery();
                } 
            }
            return result;
        }

        public List<String> GetAllCategorieValues() {
            List<String> categories = null;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand getCommand = new MySqlCommand(GET_ALL_CATEGORIE_VALUES, connection)) {
                    connection.Open();
                    categories = new List<String>(); 
                    MySqlDataReader result = getCommand.ExecuteReader();
                    if (result.Read()) {
                        String categorie = result.GetString(0);
                        categories.Add(categorie);
                    }
                }
            }

            return categories; ;
        }

        public List<ArticleDTO> GetAll() {
            List<ArticleDTO> listArticles = new List<ArticleDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand getCommand = new MySqlCommand(GET_ALL_ARTICLES, connection))
                {
                    connection.Open();
                    //getCommand.Parameters.AddWithValue("@id_article", idArticle);
                    MySqlDataReader result = getCommand.ExecuteReader();
                    ArticleDTO articleDTO = null;
                    while (result.Read())
                    {
                        articleDTO = new ArticleDTO();
                        articleDTO.ArticleID = result.GetInt32(0);
                        articleDTO.Title = result.GetString(1);
                        articleDTO.Data = result.GetString(2);
                        articleDTO.DatePublished = result.GetDateTime(3);               
                        articleDTO.Pulled = result.GetInt32(4);
                        listArticles.Add(articleDTO);
                    }

                }
            }
            return listArticles;
        }


    }
}