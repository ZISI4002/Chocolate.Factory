using Chocolate.Factory.Core.DataAcces.SQLServer;
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
    internal class SqlWorkTimeRepository : IWorkTimeRepository
    {



        private readonly string _connectionString;
        public SqlWorkTimeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(WorkTime workTime)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            const string query = @"INSERT INTO WorkTime (ThisDay, StartTime, StopTime, Production, IsInspected, MachineId)
                               VALUES (@ThisDay, @StartTime, @StopTime, @Production, @IsInspected, @MachineId)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ThisDay", workTime.ThisDay);
            cmd.Parameters.AddWithValue("@StartTime", workTime.StartTime);
            cmd.Parameters.AddWithValue("@StopTime", workTime.StopTime);
            cmd.Parameters.AddWithValue("@Production", workTime.Production);
            cmd.Parameters.AddWithValue("@IsInspected", workTime.IsInspected);
            cmd.Parameters.AddWithValue("@MachineId", workTime.Machine.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int Id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            const string query = @"DELETE FROM WorkTime WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();

        }

        public WorkTime Get(int Id)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from WorkTime where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapWorkTime(reader);
            }
            return null;
        }

        public List<WorkTime> GetAll()
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from WorkTime";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<WorkTime> workTime = new List<WorkTime>();
            while (reader.Read())
            {
                WorkTime work = SqlMapper.MapWorkTime(reader);
                workTime.Add(work);
            }
            return workTime;
        }

        public List<WorkTime> GetByMachineId(int MachineId)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from WorkTime where MachineId=@machineId";


            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("machineId", MachineId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<WorkTime> workTimes = new List<WorkTime>();
            while (reader.Read())
            {
                WorkTime workTime = SqlMapper.MapWorkTime(reader);
                workTimes.Add(workTime);
            }
            return workTimes;

        }

        public void Update(WorkTime workTime)
        {
                SqlConnection connection = new SqlConnection(_connectionString);
            const string query = @"UPDATE WorkTime SET ThisDay = @ThisDay, StartTime = @StartTime, StopTime = @StopTime,
                               Production = @Production, IsInspected = @IsInspected, MachineId = @MachineId
                               WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", workTime.Id);
            cmd.Parameters.AddWithValue("@ThisDay", workTime.ThisDay);
            cmd.Parameters.AddWithValue("@StartTime", workTime.StartTime);
            cmd.Parameters.AddWithValue("@StopTime", workTime.StopTime);
            cmd.Parameters.AddWithValue("@Production", workTime.Production);
            cmd.Parameters.AddWithValue("@IsInspected", workTime.IsInspected);
            cmd.Parameters.AddWithValue("@MachineId", workTime.Machine.Id);


            cmd.ExecuteNonQuery();
        }
    }
}
