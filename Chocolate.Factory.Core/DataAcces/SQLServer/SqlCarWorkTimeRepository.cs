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
    internal class SqlCarWorkTimeRepository : ICarWorkTimeRepository
    {

        private readonly string _connectionString;
        public SqlCarWorkTimeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(CarWorkTime carWorkTime)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);
            const string query = @"INSERT INTO CarWorkTimes (ThisDay, StartTime, StopTime, TranslateProduction, WastedGas, IsInspected, CarId)
                                     output inserted.id
                           VALUES (@ThisDay, @StartTime, @StopTime, @TranslateProduction, @WastedGas, @IsInspected, @CarId);
                                          ";
         SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Id", carWorkTime.Id);
        cmd.Parameters.AddWithValue("@ThisDay", carWorkTime.ThisDay);
        cmd.Parameters.AddWithValue("@StartTime", carWorkTime.StartTime);
        cmd.Parameters.AddWithValue("@StopTime", carWorkTime.StopTime);
        cmd.Parameters.AddWithValue("@TranslateProduction", carWorkTime.TranslateProduction);
        cmd.Parameters.AddWithValue("@WastedGas", carWorkTime.WastedGas);
        cmd.Parameters.AddWithValue("@IsInspected", carWorkTime.IsInspected);
        cmd.Parameters.AddWithValue("@CarId", carWorkTime.Car.Id);

            carWorkTime.Id = (int)cmd.ExecuteScalar();
        }

        public void Delete(int Id)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);
        const string query = @"DELETE FROM CarWorkTimes WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Id", Id);

        
        cmd.ExecuteNonQuery();
        }

        public CarWorkTime Get(int Id)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from CarWorkTimes where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapCarWorkTime(reader);
            }
            return null;
        }

        public List<CarWorkTime> GetAll()
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"SELECT CarWorkTimes.*, Cars.*
FROM CarWorkTimes
JOIN Cars ON CarWorkTimes.CarId = Cars.Id;
";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CarWorkTime> carWorkTimes = new List<CarWorkTime>();
            while (reader.Read())
            {
                CarWorkTime work = SqlMapper.MapCarWorkTime(reader);
                carWorkTimes.Add(work);
            }
            return carWorkTimes;
        }

        public List<CarWorkTime> GetByCarId(int CarId)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from CarWorkTimes where CarId=@carId";


            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("carId", CarId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CarWorkTime> carWorkTimes = new List<CarWorkTime>();
            while (reader.Read())
            {
                CarWorkTime carWorkTime = SqlMapper.MapCarWorkTime(reader);
                carWorkTimes.Add(carWorkTime);
            }
            return carWorkTimes;
        }

       
    }
}
