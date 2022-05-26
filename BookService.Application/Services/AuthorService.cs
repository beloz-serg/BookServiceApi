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
            var rows = await _dataSource.GetAllAsync();

            return _mapper.Map<IEnumerable<AuthorDto>>(rows);
        }

        public Task<int> ModifyAsync(AuthorDto author)
        {
            throw new NotImplementedException();
        }

        public Task<int> NewAsync(AuthorDto author)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
