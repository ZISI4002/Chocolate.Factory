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
    internal class SqlCarRepository : ICarRepository
    {



        private readonly string _connectionString;
        public SqlCarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Car car)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            const string query = @"INSERT INTO Cars (CarType, BrandName, SerialNumber, UsePeriod, PurchaseDate)
                               VALUES (@CarType, @BrandName, @SerialNumber, @UsePeriod, @PurchaseDate)";
             SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CarType", car.CarType);
            cmd.Parameters.AddWithValue("@BrandName", car.BrandName);
            cmd.Parameters.AddWithValue("@SerialNumber", car.SerialNumber);
            cmd.Parameters.AddWithValue("@UsePeriod", car.UsePeriod);
            cmd.Parameters.AddWithValue("@PurchaseDate", car.PurchaseDate);

            
            cmd.ExecuteNonQuery();
        }

        public void Delete(int Id)
        {
         SqlConnection connection = new SqlConnection(_connectionString);
        const string query = @"DELETE FROM Cars WHERE Id = @Id";
         SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Id", Id);

        
        cmd.ExecuteNonQuery();
        }

        public Car Get(int Id)
        {

            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from Cars where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapCar(reader);
            }
            return null;



        }

        public List<Car> GetAll()
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from Cars";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Car> cars = new List<Car>();
            while (reader.Read())
            {
                Car car = SqlMapper.MapCar(reader);
                cars.Add(car);
            }
            return cars;
        }

        public void Update(Car car)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            const string query = @"UPDATE Cars SET CarType = @CarType, BrandName = @BrandName,
                               SerialNumber = @SerialNumber, UsePeriod = @UsePeriod, PurchaseDate = @PurchaseDate
                               WHERE Id = @Id";
             SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", car.Id);
            cmd.Parameters.AddWithValue("@CarType", car.CarType);
            cmd.Parameters.AddWithValue("@BrandName", car.BrandName);
            cmd.Parameters.AddWithValue("@SerialNumber", car.SerialNumber);
            cmd.Parameters.AddWithValue("@UsePeriod", car.UsePeriod);
            cmd.Parameters.AddWithValue("@PurchaseDate", car.PurchaseDate);

            
            cmd.ExecuteNonQuery();
        }
    }
}
