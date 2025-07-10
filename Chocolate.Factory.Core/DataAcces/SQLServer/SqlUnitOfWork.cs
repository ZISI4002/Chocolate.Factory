using Chocolate.Factory.Core.Domain.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.DataAcces.SQLServer
{
    public class SqlUnitOfWork:IUnitOfWork
    {
        private readonly string _connectionString;
        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IProductRepository ProductRepository =>  new SqlProductRepository(_connectionString);

        public IIngredientRepository IngredientRepository =>  new SqlIngredientRepository(_connectionString);

        public IDosageRepository DosageRepository =>  new SqlDosageRepository(_connectionString);

        public IMachineRepository MachineRepository =>  new SqlMachineRepository(_connectionString);

        public IWorkTimeRepository WorkTimeRepository =>  new SqlWorkTimeRepository(_connectionString);

        public ICarRepository CarRepository =>  new SqlCarRepository(_connectionString);

        public ICarWorkTimeRepository CarWorkTimeRepository =>  new SqlCarWorkTimeRepository(_connectionString);

        public IUserRepository UserRepository => new SqlUserRepository(_connectionString);
        public bool CheckConnection()
        {
            try
            {
                 SqlConnection sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }



    }
}
