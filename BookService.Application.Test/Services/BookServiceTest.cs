using AutoMapper;
using BookService.Application.Interfaces.Repositories;
using BookService.Domain.Dto;
using BookService.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Service = BookService.Application.Services.BookService;

namespace BookService.Application.Test.Services
{
    public class BookServiceTest
    {
        private readonly Mock<IBookRepository> _bookRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Service _service;

        public BookServiceTest()
        {
            _service = new Service(_bookRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async void NewAsyncWithValidData()
        {
            var authorId = 1;
            var title = "Moby Dick";
            var img = "http://some.com/pictures/img.png";
            var price = 1000;
            var expected = 1;

            var dto = new BookDto { AuthorId = authorId, Title = title, Img = img, Price = price };
            var book = new Book { AuthorId = authorId, Title = title, Img = img, Price = price };

            _mapperMock.Setup(x => x.Map<Book>(dto)).Returns(book);
            _bookRepoMock.Setup(x => x.AddAsync(book)).ReturnsAsync(expected);

            var actual = await _service.NewAsync(dto);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public async void NewAsyncWithInvalidData(int authorId, string title, string img, decimal price)
        {
            var dto = new BookDto { AuthorId = authorId, Title = title, Img = img, Price = price };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.NewAsync(dto));
        }

        [Fact]
        public async void ModifyAsyncWithValidData()
        {
            var authorId = 1;
            var title = "Moby Dick";
            var img = "http://some.com/pictures/img.png";
            var price = 1000;
            var expected = 1;

            var dto = new BookDto { AuthorId = authorId, Title = title, Img = img, Price = price };
            var book = new Book { AuthorId = authorId, Title = title, Img = img, Price = price };

            _mapperMock.Setup(x => x.Map<Book>(dto)).Returns(book);
            _bookRepoMock.Setup(x => x.UpdateAsync(book)).ReturnsAsync(expected);

            var actual = await _service.ModifyAsync(dto);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public async void ModifyAsyncWithInvalidData(int authorId, string title, string img, decimal price)
        {
            var dto = new BookDto { AuthorId = authorId, Title = title, Img = img, Price = price };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.ModifyAsync(dto));
        }

        public static IEnumerable<object[]> GetTestData()
        {
            // ----------------------- author id, title, img, price
            yield return new object[] { 0, "Good book", "http://img.src", 100 };
            yield return new object[] { -10, "Good book", "http://img.src", 100 };
            yield return new object[] { 2, null, "http://img.src", 100 };
            yield return new object[] { 3, "", "http://img.src", 100 };
            yield return new object[] { 4, "   ", "http://img.src", 100 };
            yield return new object[] { 5, "Good book", null, 100 };
            yield return new object[] { 6, "Good book", "", 100 };
            yield return new object[] { 7, "Good book", "  ", 100 };
            yield return new object[] { 8, "Good book", "http://img.src", -111 };
        }
    }
}
