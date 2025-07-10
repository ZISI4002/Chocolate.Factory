using Chocolate.Factory.Core.Domain.Abstract;
using Chocolate.Factory.Core.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.DataAcces.SQLServer
{
    internal class SqlIngredientRepository:IIngredientRepository
    {
        private readonly string _connectionString;
        public SqlIngredientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Ingredient ingredient)
        {
              SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query= @"insert into ingredients(Name,InStock,UseTime)
                               output inserted.id
                             values(@name,@inStock,@useTime)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", ingredient.Name); 
            cmd.Parameters.AddWithValue("inStock", ingredient.InStock);
            cmd.Parameters.AddWithValue("useTime", ingredient.UseTime);
            ingredient.Id = (int)cmd.ExecuteScalar();

        }

        public void Delete(int Id)
        {

            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);
            const string query = @"delete from ingredients where Id=@Id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            cmd.ExecuteNonQuery();
        }

        public Ingredient Get(int Id)
        {


            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from ingredients where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapIngredient(reader);
            }
            return null;
        }

        

        public List<Ingredient> GetAll()
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from ingredients";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Ingredient> ingredients = new List<Ingredient>();
            while (reader.Read())
            {
                Ingredient ingredient = SqlMapper.MapIngredient(reader);
                ingredients.Add(ingredient);
            }
            return ingredients;
        }

        public void Update(Ingredient ingredient)
        {
                SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);



            const string query = @"update ingredients set Name= @name,InStock=@inStock,UseTime=@useTime
                 where Id=@Id   ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", ingredient.Id);
            cmd.Parameters.AddWithValue("name", ingredient.Name);
            cmd.Parameters.AddWithValue("useTime", ingredient.UseTime);
            cmd.Parameters.AddWithValue("inStock", ingredient.InStock);

            cmd.ExecuteNonQuery();
        }
    }
}
