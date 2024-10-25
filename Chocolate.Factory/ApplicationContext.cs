using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocolate.Factory.Core.DataAcces.SQLServer;
using Chocolate.Factory.Core.Domain.Abstract;
using Chocolate.Factory.Helper;
using Chocolate.Factory.Models;

namespace Chocolate.Factory
{
    internal class ApplicationContext
    {
        public static IUnitOfWork UnitOfWork { get; private set; }


        public static void Initialize()
        {
            ConfigurationInfo configurationInfo = ConfigurationHelper.Read();

            SqlConnectionStringBuilder builder= new SqlConnectionStringBuilder
            {
                TrustServerCertificate = true,
                DataSource = configurationInfo.ServerName,
                InitialCatalog = configurationInfo.DatabaseName,
                IntegratedSecurity = configurationInfo.WindowsAuthentication
            };
            if (configurationInfo.WindowsAuthentication == false)
            {
                builder.UserID = configurationInfo.Username;
                builder.Password = configurationInfo.Password;
            }
            
            UnitOfWork = new SqlUnitOfWork("");
        }
    }
}
