using BookService.Application.Interfaces.Configuration;
using BookService.Infrastructure.DataConnector;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace BookService.Infrastructure.Repositories.Base
{
    public class BaseRepository
    {
        private IConfigProvider _config;
        private ILogger _logger;

        public BaseRepository(IConfigProvider config, ILogger logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<T> WithLogger<T>(Func<NpgsqlConnection, Task<T>> func)
        {
            try
            {
                using (var db = ConnectionFactory.Create(_config.GetConnectionString()))
                {
                    return await func(db);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                if (_config.IsDevelopment)
                {
                    throw;
                }

                return default;
            }
        }
    }
}
