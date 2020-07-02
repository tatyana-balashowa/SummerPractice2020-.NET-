using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
namespace Gym.DAL
{
    public class KindOfSportDaoDB:IKindOfSportDao
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True";
        public IEnumerable<KindOfSport> GetKindOfSports()
        {
            var result = new List<KindOfSport>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetSports", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var kindOfSport = new KindOfSport
                    {
                        idKindOfSport = (int)read["IDOfKind"],
                        nameOfKind = (string)read["NameOfKind"]
                    };
                    result.Add(kindOfSport);
                }
            }
            return result;
        }
        public IEnumerable <KindOfSport> GetNeedKindOfSports (int idKind)
        {
            var result = new List<KindOfSport>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetNeedSportsById", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idKind", idKind);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var kindOfSport = new KindOfSport
                    {
                        idKindOfSport = (int)read["IDOfKind"],
                        nameOfKind = (string)read["NameOfKind"]
                    };
                    result.Add(kindOfSport);
                }
            }
            return result;
        }
        public IEnumerable <KindOfSport> GetNeedKindOfSports(string name)
        {
            var result = new List<KindOfSport>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetNeedSports", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameOfKind", name);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var kindOfSport = new KindOfSport
                    {
                        idKindOfSport = (int)read["IDOfKind"],
                        nameOfKind = (string)read["NameOfKind"]
                    };
                    result.Add(kindOfSport);
                }
            }
            return result;
        }
        public IEnumerable <string> Schedule (string nameOfKind, int workingDay)
        {
            var result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("buildColumnSchedule", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@day", workingDay);
                cmd.Parameters.AddWithValue("@nameOfKind", nameOfKind);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var Group = (string)read["Group"];
                    var ch = (string)read["Coach"];
                    var time = (string)read["Time"].ToString();
                    var hll = (string)read["Hall"];
                    var Sport = (string)read["Sport"];
                    result.Add(Group + "," + ch + "," + time + "," + hll + "," + Sport);
                }
            }
            return result;
        }
        public void AddKindOfSport (KindOfSport kindOfSport)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddKindOfSport", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameOfKind", kindOfSport.nameOfKind);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void RemoveKindOfSport (int idKindOfSport)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveKindOfSport", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idKindOfSport", idKindOfSport);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
