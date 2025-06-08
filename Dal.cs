using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _0806
{
    internal class DAL
    {

        public static void AddAgent(Agent agent)
        {
            string connstring = "Server=127.0.0.1; database=eagleeyedb; UID=root; password=";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {

                    connection.Open();
                    string query = "INSERT INTO agents (CodeName , RealName, Location, Status, MissionsCompleted ) VALUES (@CodeName, @RealName, @Location, @Status, @MissionsCompleted )";
                    var cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@CodeName", agent.CodeName);
                    cmd.Parameters.AddWithValue("@RealName", agent.RealName);
                    cmd.Parameters.AddWithValue("@Location", agent.Location);
                    cmd.Parameters.AddWithValue("@Status", agent.Status);
                    cmd.Parameters.AddWithValue("@MissionsCompleted", agent.MissionsCompleted);

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

        public List<Agent> getEmployees(string query = "SELECT * FROM agents")
        {
            string connstring = "Server=127.0.0.1; database=eagleeyedb; UID=root; password=";
            List<Agent> ageList = new List<Agent>();

            try
            {
                using (var connection = new MySqlConnection(connstring))
                {

                    connection.Open();
                    var cmd = new MySqlCommand(query, connection);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string codeName = reader.GetString("CodeName");
                            string realName = reader.GetString("RealName");
                            string location = reader.GetString("Location");
                            string status = reader.GetString("Status");
                            int missionsCompleted = reader.GetInt32("MissionsCompleted");

                            Agent age = new Agent(id, codeName, realName, location, status, missionsCompleted);
                            ageList.Add(age);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching employees: {ex.Message}");
            }

            return ageList;
        }



    }
    
}
