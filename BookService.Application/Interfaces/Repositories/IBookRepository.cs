using BookService.Domain.Entities;

namespace BookService.Application.Interfaces.Repositories
{
    public interface IBookRepository : IGenericRepository<Book, int>
    { 
    }
}
