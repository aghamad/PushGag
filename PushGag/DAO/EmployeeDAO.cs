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
    /// DAO pour effectuer des CRUDs dans la table employee.
    /// </summary>
    public class EmployeeDAO {

        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString;

        public const string ADD_REQUEST = "INSERT INTO employee (name, mdp) " +
                                                            "VALUES (@name, @mdp)";

        public const string READ_REQUEST = "SELECT Id, name, mdp " +
                                                    "FROM employee WHERE Id = @Id";

        public const string GET_REQUEST = "SELECT Id, name, mdp " +
                                                    "FROM employee WHERE name = @name and mdp = @mdp";

        public const string UPDATE_REQUEST = "UPDATE employee " +
                                               "SET mdp = @mdp " +
                                               "WHERE Id = @Id";

        public void Add(EmployeeDTO employeeDTO) {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand addCommand = new MySqlCommand(ADD_REQUEST, connection)) {
                    connection.Open();
                    addCommand.Parameters.AddWithValue("@name", employeeDTO.Username);
                    addCommand.Parameters.AddWithValue("@mdp", employeeDTO.Password);
                    addCommand.ExecuteNonQuery();
                }
            }
        }

        public void Update(EmployeeDTO employeeDTO) {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand updateCommand = new MySqlCommand(UPDATE_REQUEST, connection)) {
                    connection.Open();
                    updateCommand.Parameters.AddWithValue("@mdp", employeeDTO.Password);
                    updateCommand.Parameters.AddWithValue("@Id", employeeDTO.ID);
                    updateCommand.ExecuteNonQuery();
                }
            }
        }

        public EmployeeDTO Read(int employeeID) {
            EmployeeDTO employeeDTO = null;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))  {
                using (MySqlCommand readCommand = new MySqlCommand(READ_REQUEST, connection)) {
                    connection.Open();
                    readCommand.Parameters.AddWithValue("@Id", employeeID);
                    MySqlDataReader result = readCommand.ExecuteReader();
                    if (result.Read()) {
                        employeeDTO = new EmployeeDTO();
                        employeeDTO.ID = result.GetInt32(0);
                        employeeDTO.Username = result.GetString(1);
                        employeeDTO.Password = result.GetString(2);
                    }
                }
            }

            return employeeDTO;
        }

        public EmployeeDTO Get(string password, string name) {
            EmployeeDTO employeeDTO = null;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand readCommand = new MySqlCommand(GET_REQUEST, connection)) {
                    connection.Open();
                    readCommand.Parameters.AddWithValue("@name", name);
                    readCommand.Parameters.AddWithValue("@mdp", password);
                    MySqlDataReader result = readCommand.ExecuteReader();
                    if (result.Read()) {
                        employeeDTO = new EmployeeDTO();
                        employeeDTO.ID = result.GetInt32(0);
                        employeeDTO.Username = result.GetString(1);
                        employeeDTO.Password = result.GetString(2);
                    }
                }
            }
            return employeeDTO;
        }

    } // End Class

}