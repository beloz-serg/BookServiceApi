using AutoMapper;
using BookService.Application.Interfaces.Repositories;
using BookService.Application.Interfaces.Services;
using BookService.Domain.Dto;
using BookService.Domain.Entities;
using BookService.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Application.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _dataSource;
        private IMapper _mapper;

        public BookService(IBookRepository dataSource, IMapper mapper)
        {
            _dataSource = dataSource;
            _mapper = mapper;
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _dataSource.GetAsync(id);

            return _mapper.Map<BookDto>(book);
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _dataSource.GetAllAsync();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<int> ModifyAsync(BookDto dto)
        {
            ValidateBookDto(dto);

            var book = _mapper.Map<Book>(dto);

            return await _dataSource.UpdateAsync(book);
        }

        public async Task<int> NewAsync(BookDto dto)
        {
            ValidateBookDto(dto);

            var book = _mapper.Map<Book>(dto);

            return await _dataSource.AddAsync(book);
        }

        public async Task<int> RemoveAsync(int id)
        {
            return await _dataSource.DeleteAsync(id);
        }

        public static void ValidateBookDto(BookDto dto)
        {
            if (dto.Title.IsEmpty())
            {
                throw new ArgumentException(nameof(dto.Title));
            }

            if (dto.Img.IsEmpty())
            {
                throw new ArgumentException(nameof(dto.Img));
            }

            if (dto.Price <= 0)
            {
                throw new ArgumentException(nameof(dto.Price));
            }

            if (dto.AuthorId <= 0)
            {
                throw new ArgumentException(nameof(dto.AuthorId));
            }
        }
    }
}
