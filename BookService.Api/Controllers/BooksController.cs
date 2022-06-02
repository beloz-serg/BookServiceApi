using BookService.Api.Controllers.Base;
using BookService.Application.Interfaces.Services;
using BookService.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Api.Controllers
{
    public class BooksController : BaseController
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            return await _bookService.GetBooksAsync();
        }

        [HttpGet("get")]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            var result = await _bookService.GetBookByIdAsync(id);

            return result == null ? NotFound() : result;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBook(BookDto dto)
        {
            var result = await _bookService.NewAsync(dto);

            return result > 0 ? Ok() : StatusCode(500);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(BookDto dto)
        {
            var result = await _bookService.ModifyAsync(dto);

            return result > 0 ? Ok() : NotFound();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.RemoveAsync(id);

            return result > 0 ? Ok() : NotFound();
        }
    }
}
