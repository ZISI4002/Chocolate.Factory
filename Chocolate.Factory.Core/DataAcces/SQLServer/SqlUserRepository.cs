using Chocolate.Factory.Core.Domain.Abstract;
using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.DataAcces.SQLServer
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(User user)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);
            const string query = @"insert into Users(username,passwordHash,created)
                                  values(@username,@passwordhash,@created)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("username",user.Username);
            cmd.Parameters.AddWithValue("passwordhash",user.PasswordHash);
            cmd.Parameters.AddWithValue("created",user.Created);
            cmd.ExecuteNonQuery();
        }

        public User GetByUsername(string username)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from users where username=@username";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("username", username);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapUser(reader);
            }
            return null;
        }
    }
}
