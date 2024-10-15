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
            SqlConnection connection = new SqlConnection(_connectionString);
            const string query = @"UPDATE CarWorkTime SET ThisDay = @ThisDay, StartTime = @StartTime, StopTime = @StopTime,
                               TranslateProduction = @TranslateProduction, WastedGas = @WastedGas, IsInspected = @IsInspected, CarId = @CarId
                               WHERE Id = @Id";
         SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Id", carWorkTime.Id);
        cmd.Parameters.AddWithValue("@ThisDay", carWorkTime.ThisDay);
        cmd.Parameters.AddWithValue("@StartTime", carWorkTime.StartTime);
        cmd.Parameters.AddWithValue("@StopTime", carWorkTime.StopTime);
        cmd.Parameters.AddWithValue("@TranslateProduction", carWorkTime.TranslateProduction);
        cmd.Parameters.AddWithValue("@WastedGas", carWorkTime.WastedGas);
        cmd.Parameters.AddWithValue("@IsInspected", carWorkTime.IsInspected);
        cmd.Parameters.AddWithValue("@CarId", carWorkTime.Car.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int Id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
        const string query = @"DELETE FROM CarWorkTime WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Id", Id);

        connection.Open();
        cmd.ExecuteNonQuery();
        }

        public CarWorkTime Get(int Id)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from CarWorkTime where Id=@Id";
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

            const string query = @"select * from CarWorkTime";
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

            const string query = @"select * from CarWorkTime where CarId=@carId";


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

        public void Update(CarWorkTime carWorkTime)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
        const string query = @"UPDATE CarWorkTime SET ThisDay = @ThisDay, StartTime = @StartTime, StopTime = @StopTime,
                               TranslateProduction = @TranslateProduction, WastedGas = @WastedGas, IsInspected = @IsInspected, CarId = @CarId
                               WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Id", carWorkTime.Id);
        cmd.Parameters.AddWithValue("@ThisDay", carWorkTime.ThisDay);
        cmd.Parameters.AddWithValue("@StartTime", carWorkTime.StartTime);
        cmd.Parameters.AddWithValue("@StopTime", carWorkTime.StopTime);
        cmd.Parameters.AddWithValue("@TranslateProduction", carWorkTime.TranslateProduction);
        cmd.Parameters.AddWithValue("@WastedGas", carWorkTime.WastedGas);
        cmd.Parameters.AddWithValue("@IsInspected", carWorkTime.IsInspected);
        cmd.Parameters.AddWithValue("@CarId", carWorkTime.Car.Id);

        
        cmd.ExecuteNonQuery();
        }
    }
}
