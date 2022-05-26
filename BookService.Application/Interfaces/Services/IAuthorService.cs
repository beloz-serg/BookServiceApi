using BookService.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Application.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAuthorsAsync();

        Task<int> NewAsync(AuthorDto author);

        Task<int> ModifyAsync(AuthorDto author);

        Task<int> RemoveAsync(int id);
    }
}
