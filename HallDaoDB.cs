using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
namespace Gym.DAL
{
    public class HallDaoDB: IHallDao
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True";
        public IEnumerable <Hall> GetHalls()
        {
            var result = new List<Hall>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetHalls", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var hall = new Hall
                    {
                        idHall = (int)read["IDHall"],
                        nameOfHall = (string)read["NameOfHall"]
                    };
                    result.Add(hall);
                }
            }
            return result;
        }
        public IEnumerable <Hall> GetNeedHalls(int idHall)
        {
            var result = new List<Hall>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetNeedHalls", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idHall", idHall);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var hall = new Hall
                    {
                        idHall = (int)read["IDHall"],
                        nameOfHall = (string)read["NameOfHall"]
                    };
                    result.Add(hall);
                }
            }
            return result;
        }
        public IEnumerable <Hall> GetNeedHalls (string nameOfHall)
        {
            var result = new List<Hall>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetNeedHallsByName", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameOfHall", nameOfHall);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var hall = new Hall
                    {
                        idHall = (int)read["IDHall"],
                        nameOfHall = (string)read["NameOfHall"]
                    };
                    result.Add(hall);
                }
            }
            return result;
        }
        public void AddHall(Hall hall)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddHall", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameOfHall", hall.nameOfHall);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void RemoveHall (int idHall)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveHall", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idHall", idHall);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
