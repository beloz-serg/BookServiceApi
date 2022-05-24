using BookService.Domain.Entities;

namespace BookService.Application.Interfaces.Repositories
{
    public interface IBookDataRepository : IGenericRepository<BookData, int>
    {
    }
}
