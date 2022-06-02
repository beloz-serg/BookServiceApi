using BookService.Application.Interfaces.Configuration;
using BookService.Application.Interfaces.Repositories;
using BookService.Domain.Entities;
using BookService.Infrastructure.Constants.DbQuery;
using BookService.Infrastructure.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(IConfigProvider config, ILogger<BookRepository> logger) : base(config, logger)
        {
        }

        public async Task<int> AddAsync(Book entity)
        {
            return await WithLogger(db => db.ExecuteAsync(BookQuery.Insert.One, entity));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await WithLogger(db => db.ExecuteAsync(BookQuery.Delete.ById, new { BookId = id }));
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await WithLogger(db => db.QueryAsync<Book>(BookQuery.Select.All));
        }

        public async Task<Book> GetAsync(int id)
        {
            return await WithLogger(db => db.QueryFirstOrDefaultAsync<Book>(BookQuery.Select.ById,
                                                                                new { BookId = id }));
        }

        public async Task<int> UpdateAsync(Book entity)
        {
            return await WithLogger(db => db.ExecuteAsync(BookQuery.Update.One, entity));
        }
    }
}
