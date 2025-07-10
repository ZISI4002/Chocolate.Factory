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

        // Дополнительный метод для выполнения запроса с автоматическим управлением соединением
        internal static T ExecuteWithConnection<T>(string connectionString, Func<SqlConnection, T> executeQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return executeQuery(connection); // Выполнение запроса или операции
            }
        }
    }

}
