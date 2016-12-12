using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PushGag.DAO
{
    public class UsersLogDAO
    {

        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString;

        public const string COUNTARTICLE_REQUEST = "SELECT COUNT(user_name) FROM users_log"
        +   "WHERE id_article = @id_article AND user_name = @user_name";

        public const string INSERT_REQUEST = "INSERT INTO users_log (user_name, id_article, pull) "
        +   "VALUES (@user_name, @id_article, 'TRUE')";

        public const string UPDATE_REQUEST = "UPDATE users_log SET pull = @pull"
        +   "WHERE id_article = @id_article AND user_name = @user_name";

        public const string COUNTPULLED_REQUEST = "SELECT COUNT(user_name) FROM users_log" 
        +   "WHERE id_article = @id_article AND user_name = @user_name AND pull = @pull";

        int count = 0;

        public int doesArticlesExist(int idArticle, string userName)
        {
            //UserDTO userDTO = null;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand readCommand = new MySqlCommand(COUNTARTICLE_REQUEST, connection))
                {
                    connection.Open();
                    readCommand.Parameters.AddWithValue("@mdp_user", idArticle);
                    readCommand.Parameters.AddWithValue("@user_name", userName);
                    count = Convert.ToInt32(readCommand.ExecuteScalar());

                }
            }

            return count;
        }

        public void AddPull(int idArticle, string userName)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand addCommand = new MySqlCommand(INSERT_REQUEST, connection))
                {
                    connection.Open();
                    addCommand.Parameters.AddWithValue("@user_name", userName);
                    addCommand.Parameters.AddWithValue("@mdp_user", idArticle);
                    addCommand.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePull(int idArticle, string userName, bool pull)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand addCommand = new MySqlCommand(UPDATE_REQUEST, connection))
                {
                    connection.Open();
                    addCommand.Parameters.AddWithValue("@user_name", userName);
                    addCommand.Parameters.AddWithValue("@mdp_user", idArticle);
                    addCommand.Parameters.AddWithValue("@pull", pull);
                    addCommand.ExecuteNonQuery();
                }
            }
        }

        public int doesPullExist(int idArticle, string userName, bool pull)
        {
            //UserDTO userDTO = null;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand readCommand = new MySqlCommand(COUNTPULLED_REQUEST, connection))
                {
                    connection.Open();
                    readCommand.Parameters.AddWithValue("@mdp_user", idArticle);
                    readCommand.Parameters.AddWithValue("@user_name", userName);
                    readCommand.Parameters.AddWithValue("@pull", pull);
                    count = Convert.ToInt32(readCommand.ExecuteScalar());

                }
            }

            return count;
        }
    }
}