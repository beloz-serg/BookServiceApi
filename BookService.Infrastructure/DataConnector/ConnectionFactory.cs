using Npgsql;

namespace BookService.Infrastructure.DataConnector
{
    public class ConnectionFactory
    {
        public static NpgsqlConnection Create(string connectionString)
        {
            var con = new NpgsqlConnection(connectionString);

            con.Open();

            return con;
        }
    }
}
