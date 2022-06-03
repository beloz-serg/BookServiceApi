using AutoMapper;
using BookService.Application.Interfaces.Repositories;
using BookService.Application.Interfaces.Services;
using BookService.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Application.Services
{
    public class BookDataService : IBookDataService
    {
        private IBookDataRepository _dataSource;
        private IMapper _mapper;

        public BookDataService(IBookDataRepository dataSource, IMapper mapper)
        {
            _dataSource = dataSource;
            _mapper = mapper;
        }

        public async Task<BookDataDto> GetBookAsync(int id)
        {
            var book = await _dataSource.GetAsync(id);

            return _mapper.Map<BookDataDto>(book);
        }

        public async Task<IEnumerable<BookDataDto>> GetBooksAsync()
        {
            var books = await _dataSource.GetAllAsync();

            return _mapper.Map<IEnumerable<BookDataDto>>(books);
        }
    }
}
