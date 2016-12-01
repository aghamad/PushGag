using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PushGag.DTO;
using System.Data.SqlClient;

namespace PushGag.DAO {

    /// <summary>
    /// DAO pour effectuer des CRUDs avec la table users.
    /// </summary>
    public class UsersDAO {

        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString;

        public const string ADD_REQUEST = "INSERT INTO users (user_name, mdp_user, email) " +
                                                            "VALUES (@user_name, @mdp_user, @email)";

        public const string READ_REQUEST = "SELECT user_id, user_name, date_start, mdp_user, email " +
                                                                 "FROM users WHERE user_id = @user_id"; 

        public void Add(UserDTO userDTO) {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand addCommand = new MySqlCommand(ADD_REQUEST, connection)) {
                    addCommand.Parameters.AddWithValue("@user_name", userDTO.Username);
                    addCommand.Parameters.AddWithValue("@mdp_user", userDTO.Password);
                    addCommand.Parameters.AddWithValue("@email", userDTO.Email);
                    addCommand.ExecuteNonQuery();
                }
            }
        }

        public UserDTO Read(int userID) {
            UserDTO userDTO = null;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))  {
                using (MySqlCommand readCommand = new MySqlCommand(READ_REQUEST, connection)) {
                    readCommand.Parameters.AddWithValue("@user_id", userID);
                    MySqlDataReader result = readCommand.ExecuteReader();

                    if (result.Read()) {
                        userDTO.ID = result.GetInt32(0);
                        userDTO.Username = result.GetString(1);
                        userDTO.DateStart = result.GetDateTime(2);
                        userDTO.Password = result.GetString(3);
                        userDTO.Email = result.GetString(4);
                    }
                }
            }

            return userDTO;
        }


    }


}