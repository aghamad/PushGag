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

        public const string COUNT_REQUEST = "SELECT COUNT(name) FROM employee WHERE name = @name";

        public const string COUNTEMDP_REQUEST = "SELECT COUNT(name) FROM employee WHERE name = @name AND mdp = @mdp";

        int count = 0;

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

        public EmployeeDTO Read(int employeeID) {
            EmployeeDTO employeeDTO = null;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))  {
                using (MySqlCommand readCommand = new MySqlCommand(READ_REQUEST, connection)) {
                    connection.Open();
                    readCommand.Parameters.AddWithValue("@Id", employeeID);
                    MySqlDataReader result = readCommand.ExecuteReader();

                    if (result.Read()) {
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


        public int doesUserExist(string userName) {
            //UserDTO userDTO = null;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand readCommand = new MySqlCommand(COUNT_REQUEST, connection)) {
                    connection.Open();
                    readCommand.Parameters.AddWithValue("@user_name", userName);
                    count = Convert.ToInt32(readCommand.ExecuteScalar());

                }
            }
            return count;
        }


        public int doesUserMdpExist(string Password, string Name) {
            //UserDTO userDTO = null;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                using (MySqlCommand readCommand = new MySqlCommand(COUNTEMDP_REQUEST, connection)) {
                    connection.Open();
                    readCommand.Parameters.AddWithValue("@mdp", Password);
                    readCommand.Parameters.AddWithValue("@name", Name);
                    count = Convert.ToInt32(readCommand.ExecuteScalar());

                }
            }
            return count;
        }

    }

}