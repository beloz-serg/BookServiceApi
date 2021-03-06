using BookService.Domain.Entities;

namespace BookService.Application.Interfaces.Repositories
{
    public interface ICartRepository : IGenericRepository<CartItem, int>
    {
    }
}
