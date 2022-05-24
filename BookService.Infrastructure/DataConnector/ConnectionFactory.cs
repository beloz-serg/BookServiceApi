using BookService.Infrastructure.Constants;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BookService.Infrastructure.DataConnector
{
    public class ConnectionFactory
    {
        public static NpgsqlConnection Create()
        {
            var str = new ConfigurationManager().GetConnectionString(DbSettings.DefaultConnectionStringName);

            return Create(str);
        }

        public static NpgsqlConnection Create(string connectionString)
        {
            var con = new NpgsqlConnection(connectionString);

            con.Open();

            return con;
        }
    }
}
