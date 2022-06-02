using BookService.Api.Controllers.Base;
using BookService.Application.Interfaces.Services;
using BookService.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Api.Controllers
{
    public class AuthorsController : BaseController
    {
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<AuthorDto>> GetAuthors()
        {
            return await _authorService.GetAuthorsAsync();
        }

        [HttpGet("get")]
        public async Task<ActionResult<AuthorDto>> GetById(int id)
        {
            var result = await _authorService.GetAuthorById(id);

            return result == null ? NotFound() : result;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAuthor(AuthorDto dto)
        {
            var result = await _authorService.NewAsync(dto);

            return result > 0 ? Ok() : StatusCode(500);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(AuthorDto dto)
        {
            var result = await _authorService.ModifyAsync(dto);

            return result > 0 ? Ok() : NotFound();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _authorService.RemoveAsync(id);

            return result > 0 ? Ok() : NotFound();
        }
    }
}
