using BookService.Application.Interfaces.Configuration;
using BookService.Application.Interfaces.Repositories;
using BookService.Domain.Entities;
using BookService.Infrastructure.Constants.DbQuery;
using BookService.Infrastructure.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Infrastructure.Repositories
{
    public class BookDataRepository : BaseRepository, IBookDataRepository
    {
        public BookDataRepository(IConfigProvider config, ILogger<BookDataRepository> logger) : base(config, logger)
        {
        }

        public Task<int> AddAsync(BookData entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookData>> GetAllAsync()
        {
            return await WithLogger(db => db.QueryAsync<BookData>(BookDataQuery.Select.All));
        }

        public async Task<BookData> GetAsync(int id)
        {
            return await WithLogger(db => db.QueryFirstOrDefaultAsync<BookData>(BookDataQuery.Select.ByBookId,
                new { BookId = id }));
        }

        public Task<int> UpdateAsync(BookData entity)
        {
            throw new NotImplementedException();
        }
    }
}
