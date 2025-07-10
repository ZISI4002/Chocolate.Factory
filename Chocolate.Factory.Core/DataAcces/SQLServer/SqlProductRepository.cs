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
    internal class SqlProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        public SqlProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Product product)
        {
            
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);   
           


            const string query = @"insert into products(Name,CompanyName,StandartWeight)
                            output inserted.id
                    values(@name,@companyName,@standartWeight)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name",product.Name);
            cmd.Parameters.AddWithValue("companyName", product.CompanyName);
            cmd.Parameters.AddWithValue("standartWeight", product.StandartWeight);

           product.Id=(int)cmd.ExecuteScalar();
        }

        public void Delete(int Id)
        {

            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);
            const string query = @"delete from products where Id=@Id";       

            SqlCommand cmd= new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            cmd.ExecuteNonQuery();

        }

        public Product Get(int Id)
        {
             SqlConnection connection= ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from products where Id=@Id";
            SqlCommand cmd=new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapProduct(reader);
            }
            return null;
        }

        public List<Product> GetAll()
        {

            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @" select * from products ";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
              Product product = SqlMapper.MapProduct(reader);
                products.Add(product);
            }
            return products ;
        }

        public void Update(Product product)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);



            const string query = @"update products set Name= @name,CompanyName=@companyName,StandartWeight=@standartWeight
                 where Id=@Id   ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", product.Id);
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("companyName", product.CompanyName);
            cmd.Parameters.AddWithValue("standartWeight", product.StandartWeight);

            cmd.ExecuteNonQuery();

        }
    }
}
