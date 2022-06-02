using BookService.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Application.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAuthorsAsync();

        Task<AuthorDto> GetAuthorByIdAsync(int id);

        Task<int> NewAsync(AuthorDto dto);

        Task<int> ModifyAsync(AuthorDto dto);

        Task<int> RemoveAsync(int id);
    }
}
