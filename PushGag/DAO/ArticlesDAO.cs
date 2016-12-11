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

        public const string GET_ALL_ARTICLES = "SELECT id_article, type, categorie, date_article, data, article_title, pulled FROM articles ";

        public int Add(ArticleDTO articleDTO) {
            int result = 0;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand addCommand = new MySqlCommand(ADD_REQUEST, connection)) {
                    connection.Open();
                    addCommand.Parameters.AddWithValue("@type", (int) articleDTO.Type);
                    addCommand.Parameters.AddWithValue("@categorie", (int) articleDTO.Categorie);
                    addCommand.Parameters.AddWithValue("@data", articleDTO.Data);
                    addCommand.Parameters.AddWithValue("@article_title", articleDTO.Title);
                    result = addCommand.ExecuteNonQuery();
                } 
            }
            return result;
        }

        public List<ArticleDTO> GetAll() {
            List<ArticleDTO> listArticles = new List<ArticleDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand getCommand = new MySqlCommand(GET_ALL_ARTICLES, connection)) {
                    connection.Open();
                    MySqlDataReader result = getCommand.ExecuteReader();
                    ArticleDTO articleDTO = null;
                    while (result.Read()) {
                        articleDTO = new ArticleDTO();
                        articleDTO.ArticleID = result.GetInt32(0);
                        articleDTO.Type = (EnumType) result.GetInt32(1);
                        articleDTO.Categorie = (EnumCategorie) result.GetInt32(2);
                        articleDTO.DatePublished = result.GetDateTime(3);
                        articleDTO.Data = result.GetString(4);
                        articleDTO.Title = result.GetString(5);                                 
                        articleDTO.Pulled = result.GetInt32(6);
                        listArticles.Add(articleDTO);
                    }

                }
            }
            return listArticles;
        }


    }
}