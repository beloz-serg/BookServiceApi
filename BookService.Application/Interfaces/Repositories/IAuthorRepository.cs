using BookService.Domain.Entities;

namespace BookService.Application.Interfaces.Repositories
{
    public interface IAuthorRepository : IGenericRepository<Author, int>
    {
    }
}
