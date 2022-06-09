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
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(IConfigProvider config, ILogger<CartRepository> logger) : base(config, logger)
        {
        }

        public async Task<int> AddAsync(CartItem entity)
        {
            return await WithLogger(db => db.ExecuteAsync(CartQuery.Insert.One, entity));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await WithLogger(db => db.ExecuteAsync(CartQuery.Delete.One, new { CartItemId = id }));
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return await WithLogger(db => db.QueryAsync<CartItem>(CartQuery.Select.All));
        }

        public async Task<CartItem> GetAsync(int id)
        {
            return await WithLogger(db => db.QueryFirstOrDefaultAsync<CartItem>(CartQuery.Select.ById,
                new { CartItemId = id }));
        }

        public async Task<int> UpdateAsync(CartItem entity)
        {
            return await WithLogger(db => db.ExecuteAsync(CartQuery.Update.One, entity));
        }
    }
}
