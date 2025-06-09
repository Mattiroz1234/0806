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
            string query = "INSERT INTO agents (CodeName , RealName, Location, Status, MissionsCompleted ) VALUES (@CodeName, @RealName, @Location, @Status, @MissionsCompleted )";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
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


        public static List<Agent> GetAgents()
        {
            string connstring = "Server=127.0.0.1; database=eagleeyedb; UID=root; password=";
            List<Agent> ageList = new List<Agent>();
            string query = "SELECT * FROM agents";
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


        public static void UpdateAgent(int agentId, string newLocation)
        {
            string connstring = "Server=127.0.0.1; database=eagleeyedb; UID=root; password=";
            string query = $"UPDATE agents SET location = {newLocation} WHERE id = {agentId}";//
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


        public static void DeleteAgent(int agentId)
        {
            string connstring = "Server=127.0.0.1; database=eagleeyedb; UID=root; password=";
            string query = $"DELETE FROM agents WHERE id = {agentId};";//
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
