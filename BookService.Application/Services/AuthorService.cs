using AutoMapper;
using BookService.Application.Interfaces.Repositories;
using BookService.Application.Interfaces.Services;
using BookService.Domain.Dto;
using BookService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _dataSource;
        private IMapper _mapper;

        public AuthorService(IAuthorRepository dataSource, IMapper mapper)
        {
            _dataSource = dataSource;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
        {
            var authors = await _dataSource.GetAllAsync();

            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var author = await _dataSource.GetAsync(id);

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<int> ModifyAsync(AuthorDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException(nameof(dto.Name));
            }

            var author = _mapper.Map<Author>(dto);

            return await _dataSource.UpdateAsync(author);
        }

        public async Task<int> NewAsync(AuthorDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException(nameof(dto.Name));
            }

            var author = _mapper.Map<Author>(dto);

            return await _dataSource.AddAsync(author);
        }

        public async Task<int> RemoveAsync(int id)
        {
            return await _dataSource.DeleteAsync(id);
        }
    }
}
