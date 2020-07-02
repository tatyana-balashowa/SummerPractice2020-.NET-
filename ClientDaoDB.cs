using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
namespace Gym.DAL
{
    public class ClientDaoDB:IClientDao
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True";
        public IEnumerable<Client> GetClients()
        {
            var result = new List<Client>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAllClients", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var client = new Client
                    {
                        idClient = (int)read["IDClient"],
                        firstName = (string)read["FirstName"],
                        lastName = (string)read["LastName"],
                        telephoneNumber = (string)read["TelephoneNumber"],
                        idfavoriteCoach = (int)read["IDFavoriteCoach"]
                    };
                    result.Add(client);
                }
            }
            return result;
        }
        public IEnumerable <Client> GetNeedClients(int idClient)
        {
            var result = new List<Client>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetNeedClients", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idClient", idClient);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var client = new Client
                    {
                        idClient = (int)read["IDClient"],
                        firstName = (string)read["FirstName"],
                        lastName = (string)read["LastName"],
                        telephoneNumber = (string)read["TelephoneNumber"],
                        idfavoriteCoach = (int)read["IDFavoriteCoach"]
                    };
                    result.Add(client);
                }
            }
            return result;
        }
        public void AddClient (Client client)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddClient", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", client.firstName);
                cmd.Parameters.AddWithValue("@lastName", client.lastName);
                cmd.Parameters.AddWithValue("@telephoneNumber", client.telephoneNumber);
                cmd.Parameters.AddWithValue("@idFavoriteCoach", client.idfavoriteCoach);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void RemoveClient (int idClient)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveClient", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idClient", idClient);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
