using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
namespace Gym.DAL
{
    public class CoachDaoDB:ICoachDao
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True";
        public IEnumerable <Coach> GetCoaches()
        {
            var result = new List<Coach>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetCoaches", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var coach = new Coach
                    {
                        idCoach = (int)read["IDCoach"],
                        firstName = (string)read["FirstName"],
                        lastName = (string)read["LastName"],
                        telephoneNumber = (string)read["TelephoneNumber"],
                        mainHall = (int)read["MainHall"]
                    };
                    result.Add(coach);
                }
            }
            return result;
        }
        public IEnumerable <Coach> GetNeedCoaches(int idCoach)
        {
            var result = new List<Coach>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetNeedCoaches", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCoach", idCoach);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var coach = new Coach
                    {
                        idCoach = (int)read["IDCoach"],
                        firstName = (string)read["FirstName"],
                        lastName = (string)read["LastName"],
                        telephoneNumber = (string)read["TelephoneNumber"],
                        mainHall = (int)read["MainHall"]
                    };
                    result.Add(coach);
                }
            }
            return result;
        }
         public IEnumerable <int> SelectIdNeedCoaches(string firstName, string lastName)
        {
            var result = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SelectIdNeedCoach", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    result.Add((int)read["IDCoach"]);
                }
            }
            return result;
        }
        public IEnumerable <int> GetSportsByCoach (int idCoach)
        {
            var result = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetSportsByCoach", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCoach", idCoach);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    result.Add((int)read["IDOfKind"]);
                }
            }
            return result;
        }
        public IEnumerable <string> GetNamesOfSportsByCoach(int idOfKind)
        {
            var result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetNameOfKindsByCoach", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idKind", idOfKind);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    result.Add((string)read["NameOfKind"]);
                }
            }
            return result;
        }
        public IEnumerable<int> GetNeedNote(string nameGroup, int idCoach)
        {
            var result = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("getNeedNote", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameGroup", nameGroup);
                cmd.Parameters.AddWithValue("@idCoach", idCoach);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    result.Add((int)read["IDGroup"]);
                }
            }
            return result;
        }
        public int CountOfPeople(int idCoach, int day)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("CountOfPeople", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCoach", idCoach);
                cmd.Parameters.AddWithValue("@workingDay", day);
                connection.Open();
                SqlParameter retValue = cmd.Parameters.Add("@sum", System.Data.SqlDbType.Int);
                retValue.Direction = System.Data.ParameterDirection.ReturnValue;
                int result = cmd.ExecuteNonQuery();
                return (int)retValue.Value;
            }
        }
        public void AddCoach(Coach coach)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddCoach", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", coach.firstName);
                cmd.Parameters.AddWithValue("@lastName", coach.lastName);
                cmd.Parameters.AddWithValue("@telephoneNumber", coach.telephoneNumber);
                cmd.Parameters.AddWithValue("@mainHall", coach.mainHall);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void AddSportByCoach (int idCoach, string nameOfKind)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddSportByCoach", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCoach", idCoach);
                cmd.Parameters.AddWithValue("@nameOfKind", nameOfKind);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void AddGroupByCoach(int idCoach, string nameGroup)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("addGroupByCoach", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCoach", idCoach);
                cmd.Parameters.AddWithValue("@nameGroup", nameGroup);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void RemoveCoach (int idCoach)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveCoach", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCoach", idCoach);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
