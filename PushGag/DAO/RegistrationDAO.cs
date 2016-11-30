using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushGag.DAO
{
    public class RegistrationDAO
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString;

        private static string ADD_REQUEST = 
            "INSERT INTO users (user_name, mdp_user, email) " +
            "VALUES (@user_name, @mdp_user, @email)";

        public void Add(UserDTO userDTO) {
            using (MySqlConnection connexion = new MySqlConnection(connStr)) {
                connexion.Open();
                MySqlCommand addCommand = connexion.CreateCommand();
                addCommand.CommandText = RegistrationDAO.ADD_REQUEST;
                addCommand.Parameters.AddWithValue("@user_name", userDTO.Username);
                addCommand.Parameters.AddWithValue("@mdp_user", userDTO.Password);
                addCommand.Parameters.AddWithValue("@email", userDTO.Email);
                addCommand.ExecuteNonQuery();

            }
        }
}