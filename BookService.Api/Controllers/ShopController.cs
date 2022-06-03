using BookService.Api.Controllers.Base;
using BookService.Application.Interfaces.Services;
using BookService.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Api.Controllers
{
    public class ShopController : BaseController
    {
        private IBookDataService _bookDataService;

        public ShopController(IBookDataService bookDataService)
        {
            _bookDataService = bookDataService;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<BookDataDto>> Index()
        {
            return await _bookDataService.GetBooksAsync();
        }

        [HttpGet("get")]
        public async Task<ActionResult<BookDataDto>> GetById(int id)
        {
            var dto = await _bookDataService.GetBookAsync(id);

            return dto != null ? dto : NotFound();
        }
    }
}
