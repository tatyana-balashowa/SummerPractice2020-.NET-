using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
namespace Gym.DAL
{
    public class UserDaoDB : IUserDao
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True";
        public void registerUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddUser", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", user.firstName);
                cmd.Parameters.AddWithValue("@lastName", user.lastName);
                cmd.Parameters.AddWithValue("@telephoneNumber", user.telephoneNumber);
                cmd.Parameters.AddWithValue("@email", user.emailAddress);
                cmd.Parameters.AddWithValue("@login", user.login);
                cmd.Parameters.AddWithValue("@passwordHashCode", user.passwordHashCode);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
