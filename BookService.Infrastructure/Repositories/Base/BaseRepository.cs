using BookService.Infrastructure.DataConnector;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace BookService.Infrastructure.Repositories.Base
{
    public class BaseRepository
    {
        public async Task<T> WithLogger<T>(Func<NpgsqlConnection, Task<T>> func)
        {
            try
            {
                using (var db = ConnectionFactory.Create())
                {
                    return await func(db);
                }
            }
            catch (Exception ex)
            {
                // todo logger

                throw;
            }
        }
    }
}
