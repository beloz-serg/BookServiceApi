using BookService.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Application.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();

        Task<BookDto> GetBookByIdAsync(int id);

        Task<int> NewAsync(BookDto dto);

        Task<int> ModifyAsync(BookDto dto);

        Task<int> RemoveAsync(int id);
    }
}
