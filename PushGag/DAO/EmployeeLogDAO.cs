using MySql.Data.MySqlClient;
using PushGag.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushGag.DAO
{
    /// <summary>
    /// DAO pour effectuer des CRUDs dans la table employee_log.
    /// En bref, l'historique de l'employee
    /// </summary>
    public class EmployeeLogDAO {

        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString;

        public const string ADD_REQUEST = "INSERT INTO employee_log (id_employee, id_article) " +
                                            "VALUES (@id_employee, @id_article)";

        // Inner Join / Move to Service class
        // Select tout les articles qui ont un id matching dans la table articles et employee_log where employee en question
        public const string GET_ALL_ARTICLES = "SELECT articles.id_article, articles.type, articles.categorie, articles.date_article, articles.data, articles.article_title, articles.pulled "
                                                                                                    + "FROM articles "
                                                                                                    + "INNER JOIN employee_log "
                                                                                                    + "ON articles.id_article = employee_log.id_article "
                                                                                                    + "WHERE employee_log.id_employee = @id_employee";

        public void Add(EmployeeLogDTO logDTO) {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand addCommand = new MySqlCommand(ADD_REQUEST, connection)) {
                    connection.Open();
                    addCommand.Parameters.AddWithValue("@id_employee", logDTO.EmployeeID);
                    addCommand.Parameters.AddWithValue("@id_article", logDTO.ArticleID);
                    addCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// History de l'employee en question
        /// </summary>
        /// <returns></returns>
        public List<ArticleDTO> GetAllArticles(int idEmployee) {
            List<ArticleDTO> listArticles = new List<ArticleDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand getCommand = new MySqlCommand(GET_ALL_ARTICLES, connection)) {
                    connection.Open();
                    getCommand.Parameters.AddWithValue("@id_employee", idEmployee);
                    MySqlDataReader result = getCommand.ExecuteReader();
                    ArticleDTO articleDTO = null;
                    while (result.Read()) {
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



    } // End Class
}