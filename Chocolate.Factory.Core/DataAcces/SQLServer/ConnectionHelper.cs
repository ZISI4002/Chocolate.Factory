using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Chocolate.Factory.Core.DataAcces.SQLServer
{
    internal static class ConnectionHelper
    {
        internal static SqlConnection GetConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;

        }

    }
}
