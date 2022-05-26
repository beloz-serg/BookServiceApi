using BookService.Application.Interfaces.Repositories;
using BookService.Domain.Entities;
using BookService.Infrastructure.Constants.DbQuery;
using BookService.Infrastructure.Repositories.Base;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Infrastructure.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public async Task<int> AddAsync(Author entity)
        {
            return await WithLogger(db => db.ExecuteAsync(AuthorQuery.Insert.One, entity));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await WithLogger(db => db.ExecuteAsync(AuthorQuery.Delete.ById, new { AuthorId = id }));
        }

        public async Task<Author> GetAsync(int id)
        {
            return await WithLogger(db => db.QueryFirstOrDefaultAsync<Author>(AuthorQuery.Select.ById,
                                                                                    new { AuthorId = id }));
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await WithLogger(db => db.QueryAsync<Author>(AuthorQuery.Select.All));
        }

        public async Task<int> UpdateAsync(Author entity)
        {
            return await WithLogger(db => db.ExecuteAsync(AuthorQuery.Update.One, entity));
        }
    }
}
