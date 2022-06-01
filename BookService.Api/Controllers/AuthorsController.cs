using BookService.Api.Controllers.Base;
using BookService.Application.Interfaces.Services;
using BookService.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [HttpPost("add")]
        public async Task<IActionResult> AddAuthor(AuthorDto author)
        {
            var result = await _authorService.NewAsync(author);

            return result > 0 ? Ok() : StatusCode(500);
        }
    }
}
