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

        public const string GET_ALL_ARTICLES = "SELECT id_article, type, categorie, date_article, data, article_title, pulled " 
                                                                                                    + "FROM articles "
                                                                                                    + "ORDER BY date_article";

        public const string GET_ALL_ARTICLES_BY_CATEGORY = "SELECT id_article, type, categorie, date_article, data, article_title, pulled "
                                                                                                    + "FROM articles "
                                                                                                    + "WHERE categorie = @categorie "
                                                                                                    + "ORDER BY date_article";
        public const string GET_ALL_ARTICLES_ID = "SELECT id_article, type, categorie, date_article, data, article_title, pulled "
                                                                                                    + "FROM articles "
                                                                                                    + "WHERE id_article = @id_article "
                                                                                                    + "ORDER BY date_article";
        public const string ADD_COMMENT = "INSERT INTO comments (id_article, user_name, comment)"
                                                    + "VALUES (@id_article, @user_name, @comment)";
        public const string GET_COMMENTS = "SELECT comment, user_name FROM comments WHERE id_article = @id_article";
        /// <summary>
        /// Add to table articles
        /// </summary>
        /// <param name="articleDTO"> Article to add </param>
        /// <returns> ID of the last inserted article </returns>
        public long Add(ArticleDTO articleDTO) {
            long result = 0;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand addCommand = new MySqlCommand(ADD_REQUEST, connection)) {
                    connection.Open();
                    addCommand.Parameters.AddWithValue("@type", (int) articleDTO.Type);
                    addCommand.Parameters.AddWithValue("@categorie", (int) articleDTO.Categorie);
                    addCommand.Parameters.AddWithValue("@data", articleDTO.Data);
                    addCommand.Parameters.AddWithValue("@article_title", articleDTO.Title);
                    addCommand.ExecuteNonQuery();
                    result = addCommand.LastInsertedId;
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

        public List<ArticleDTO> GetAllByCategory(string filter) {
            List<ArticleDTO> listArticles = new List<ArticleDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)){
                using (MySqlCommand getCommand = new MySqlCommand(GET_ALL_ARTICLES_BY_CATEGORY, connection)){
                    getCommand.Parameters.AddWithValue("@categorie", filter);
                    connection.Open();
                    MySqlDataReader result = getCommand.ExecuteReader();
                    ArticleDTO articleDTO = null;
                    while (result.Read()){
                        articleDTO = new ArticleDTO();
                        articleDTO.ArticleID = result.GetInt32(0);
                        articleDTO.Type = (EnumType)result.GetInt32(1);
                        articleDTO.Categorie = (EnumCategorie)result.GetInt32(2);
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

        public List<ArticleDTO> GetAllById(string filter)
        {
            List<ArticleDTO> listArticles = new List<ArticleDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand getCommand = new MySqlCommand(GET_ALL_ARTICLES_ID, connection))
                {
                    getCommand.Parameters.AddWithValue("@id_article", filter);
                    connection.Open();
                    MySqlDataReader result = getCommand.ExecuteReader();
                    ArticleDTO articleDTO = null;
                    while (result.Read())
                    {
                        articleDTO = new ArticleDTO();
                        articleDTO.ArticleID = result.GetInt32(0);
                        articleDTO.Type = (EnumType)result.GetInt32(1);
                        articleDTO.Categorie = (EnumCategorie)result.GetInt32(2);
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

        public void AddComment(int idArticle, string username, string comment)
        {
           
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand addCommand = new MySqlCommand(ADD_COMMENT, connection))
                {
                    connection.Open();
                    addCommand.Parameters.AddWithValue("@id_article", idArticle);
                    addCommand.Parameters.AddWithValue("@user_name", username);
                    addCommand.Parameters.AddWithValue("@comment", comment);
                    addCommand.ExecuteNonQuery();
               
                }
            }
        }

        public List<CommentsDTO> GetComments(string filter)
        {
            List<CommentsDTO> listComments = new List<CommentsDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand getCommand = new MySqlCommand(GET_COMMENTS, connection))
                {
                    getCommand.Parameters.AddWithValue("@id_article", filter);
                    connection.Open();
                    MySqlDataReader result = getCommand.ExecuteReader();
                    CommentsDTO commentsDTO = null;
                    while (result.Read())
                    {
                        commentsDTO = new CommentsDTO();
                        commentsDTO.Comment = result.GetString(0);
                        commentsDTO.Username = result.GetString(1);
                        listComments.Add(commentsDTO);
                    }
                }
            }
            return listComments;
        }

    }
}