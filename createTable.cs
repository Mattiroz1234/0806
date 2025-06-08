using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _0806
{
    internal class createTable
    {
        public static void CreateTable()
        {
            string query = "CREATE TABLE agents ( id INT AUTO_INCREMENT PRIMARY KEY, codeName VARCHAR(50), realName VARCHAR(50), location VARCHAR(100), status VARCHAR(100), missionsCompleted INT);";
            string connstring = "server=127.0.0.1;database=eagleeyedb;UID=root;password=";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {

                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);
                    using (var reader = cmd.ExecuteReader()) ;

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
        }



    }
}
