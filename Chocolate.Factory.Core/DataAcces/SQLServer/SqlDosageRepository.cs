using Chocolate.Factory.Core.Domain.Abstract;
using Chocolate.Factory.Core.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.DataAcces.SQLServer
{
    internal class SqlDosageRepository:IDosageRepository
    {
        private readonly string _connectionString;
        public SqlDosageRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Dosage dosage)
        {

            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"insert into dosages(Quantity,Deviation,ProductId,IngredientId)
                                   output inserted.Id
                             values(@quantity,@deviation,@productId,@ingredientId)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("quantity", dosage.Quantity);
            cmd.Parameters.AddWithValue("deviation", dosage.Deviation);
            cmd.Parameters.AddWithValue("productId", dosage.Product.Id);
            cmd.Parameters.AddWithValue("ingredientId", dosage.Ingredient.Id);
            
            dosage.Id=(int)cmd.ExecuteScalar();
        }

        public void Delete(int Id)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);
            const string query = @"delete from dosages where Id=@Id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            cmd.ExecuteNonQuery();
        }

   

        public Dosage Get(int Id)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from dosages where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapDosage(reader);
            }
            return null;
        }

        public List<Dosage> GetAll()
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"
SELECT 
    d.Id AS DosageId, d.Quantity, d.Deviation,
    p.Id AS ProductID, p.Name AS ProductName, p.CompanyName, p.StandartWeight,
    i.Id AS IngredientID, i.Name AS IngredientName, i.UseTime, i.InStock
FROM Dosages d
JOIN Products p ON d.ProductID = p.Id
JOIN Ingredients i ON d.IngredientID = i.Id


";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Dosage> dosages = new List<Dosage>();
            while (reader.Read())
            {
                Dosage dosage = SqlMapper.MapDosage(reader);
                dosages.Add(dosage);
            }
            return dosages;
        }

        public List<Dosage> GetByIngredientId(int ingredientId)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);


            const string query = @"

SELECT 
    i.Id AS IngredientId,
    i.Name AS IngredientName,
    i.UseTime,
    i.InStock,
    d.Quantity,
    d.Deviation,
    p.Id AS ProductId,
    p.Name AS ProductName,
    p.CompanyName,
    p.StandartWeight
FROM 
    Ingredients i
LEFT JOIN 
    Dosages d ON i.Id = d.IngredientId
LEFT JOIN 
    Products p ON d.ProductId = p.Id
WHERE 
    d.IngredientId = @ingredientId  
ORDER BY 
    i.Id;  


";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("ingredientId", ingredientId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Dosage> dosages = new List<Dosage>();
            while (reader.Read())
            {
                Dosage dosage = SqlMapper.MapDosage(reader);
                dosages.Add(dosage);
            }
            return dosages;
        }

        public List<Dosage> GetByProductId(int productId)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);


            const string query = @"
SELECT    
    p.Id AS ProductId,
    p.Name AS ProductName,
    p.CompanyName,
    p.StandartWeight,
    i.Id AS IngredientId,
    i.Name AS IngredientName,
    i.UseTime,
    i.InStock,
    d.Quantity,
    d.Deviation
FROM 
    Products p
LEFT JOIN 
    Dosages d ON p.Id = d.ProductId
LEFT JOIN 
    Ingredients i ON d.IngredientId = i.Id
WHERE 
    d.ProductId = @productId 
ORDER BY 
    p.Id;

";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("productId", productId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Dosage> dosages= new List<Dosage>();
            while (reader.Read())
            {
                Dosage dosage = SqlMapper.MapDosage(reader);
                dosages.Add(dosage);
            }
            return dosages ;
        }

        
    }
}
