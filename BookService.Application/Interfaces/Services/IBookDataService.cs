using BookService.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Application.Interfaces.Services
{
    public interface IBookDataService
    {
        Task<IEnumerable<BookDataDto>> GetBooksAsync();
        Task<BookDataDto> GetBookAsync(int id);
    }
}
