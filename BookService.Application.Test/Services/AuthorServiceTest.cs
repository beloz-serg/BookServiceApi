using AutoMapper;
using BookService.Application.Interfaces.Repositories;
using BookService.Application.Services;
using BookService.Domain.Dto;
using BookService.Domain.Entities;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BookService.Application.Test.Services
{
    public class AuthorServiceTest
    {
        private readonly Mock<IAuthorRepository> _authorRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly AuthorService _service;

        public AuthorServiceTest()
        {
            _service = new AuthorService(_authorRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task NewAsyncWithValidName()
        {
            var name = "test name";
            var expected = 1;

            var dto = new AuthorDto
            {
                Name = name
            };

            var author = new Author
            {
                AuthorName = name
            };

            _mapperMock.Setup(x => x.Map<Author>(dto)).Returns(author);
            _authorRepoMock.Setup(x => x.AddAsync(author)).ReturnsAsync(expected);

            var actual = await _service.NewAsync(dto);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task NewAsyncWithEmptyName()
        {
            var dto = new AuthorDto();

            await Assert.ThrowsAsync<ArgumentException>(() => _service.NewAsync(dto));
        }

        [Fact]
        public async Task ModifyAsyncWithValidName()
        {
            var name = "test name";
            var expected = 1;

            var dto = new AuthorDto
            {
                Name = name
            };

            var author = new Author
            {
                AuthorName = name
            };

            _mapperMock.Setup(x => x.Map<Author>(dto)).Returns(author);
            _authorRepoMock.Setup(x => x.UpdateAsync(author)).ReturnsAsync(expected);

            var actual = await _service.ModifyAsync(dto);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ModifyAsyncWithEmptyName()
        {
            var dto = new AuthorDto();

            await Assert.ThrowsAsync<ArgumentException>(() => _service.ModifyAsync(dto));
        }
    }
}
