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
    internal class SqlMachineRepository : IMachineRepository

    {
        private readonly string _connectionString;
        public SqlMachineRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Machine machine)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"insert into machines(MachineType, BrandName, SerialNumber, HourlyElectricWaste, UsePeriod, PurchaseDate)
                           output inserted.id
                           values(@machineType, @brandName, @serialNumber, @hourlyElectricWaste, @usePeriod, @purchaseDate)";

            SqlCommand cmd = new SqlCommand(query, connection);

            // Добавляем параметры с правильным синтаксисом
            cmd.Parameters.AddWithValue("@machineType", machine.MachineType);
            cmd.Parameters.AddWithValue("@brandName", machine.BrandName);
            cmd.Parameters.AddWithValue("@serialNumber", machine.SerialNumber);
            cmd.Parameters.AddWithValue("@hourlyElectricWaste", machine.HourlyElectricWaste);
            cmd.Parameters.AddWithValue("@usePeriod", machine.UsePeriod);
            cmd.Parameters.AddWithValue("@purchaseDate", machine.PurchaseDate);

            // Выполняем запрос и присваиваем результат
            machine.Id = (int)cmd.ExecuteScalar();
        }


        public void Delete(int Id)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);
            const string query = @"delete from machines where  Id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            cmd.ExecuteNonQuery();
        }

        public Machine Get(int Id)
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from machines where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapMachine(reader);
            }
            return null;
        }

        public List<Machine> GetAll()
        {
            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"select * from machines";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Machine> machines = new List<Machine>();
            while (reader.Read())
            {
                Machine machine = SqlMapper.MapMachine(reader);
                machines.Add(machine);
            }
            return machines;
        }

        public void Update(Machine machine)
        {

            SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"update machines set MachineType=@machineType,BrandName=@brandName,SerialNumber=@serialNumber,HourlyElectricWaste=@hourlyElectricWaste,UsePeriod=@usePeriod,PurchaseDate=@purchaseDate
 where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("Id", machine.Id);
            cmd.Parameters.AddWithValue("machineType", machine.MachineType);
            cmd.Parameters.AddWithValue("brandName", machine.BrandName);
            cmd.Parameters.AddWithValue("serialNumber", machine.SerialNumber);
            cmd.Parameters.AddWithValue("hourlyElectricWaste", machine.HourlyElectricWaste);
            cmd.Parameters.AddWithValue("usePeriod", machine.UsePeriod);
            cmd.Parameters.AddWithValue("purchaseDate", machine.PurchaseDate);
            cmd.ExecuteNonQuery();


        }
    }
}
