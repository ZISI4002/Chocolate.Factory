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
        private readonly string _conectonString;
        public SqlUnitOfWork(string conectonString)
        {
            _conectonString = conectonString;
        }

        public IProductRepository ProductRepository =>  new SqlProductRepository(_conectonString);

        public IIngredientRepository IngredientRepository =>  new SqlIngredientRepository(_conectonString);

        public IDosageRepository DosageRepository =>  new SqlDosageRepository(_conectonString);

        public IMachineRepository MachineRepository =>  new SqlMachineRepository(_conectonString);

        public IWorkTimeRepository WorkTimeRepository =>  new SqlWorkTimeRepository(_conectonString);

        public ICarRepository CarRepository =>  new SqlCarRepository(_conectonString);

        public ICarWorkTimeRepository CarWorkTimeRepository =>  new SqlCarWorkTimeRepository(_conectonString);

        public bool CheckConnection()
        {
            try
            {
                     SqlConnection sqlConnection = new SqlConnection(_conectonString);
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
