using BookService.Application.Interfaces.Services;
using BookService.Domain.Dto;
using CartService.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CartService.Api.Controllers
{
    public class CartController : BaseController
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<CartItemDto>> GetCartItemss()
        {
            return await _cartService.GetCartItemsAsync();
        }

        [HttpGet("get")]
        public async Task<ActionResult<CartItemDto>> GetById(int id)
        {
            var result = await _cartService.GetCartItemByIdAsync(id);

            return result == null ? NotFound() : result;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCartItem(CartItemDto dto)
        {
            var result = await _cartService.NewAsync(dto);

            return result > 0 ? Ok() : StatusCode(500);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(CartItemDto dto)
        {
            var result = await _cartService.ModifyAsync(dto);

            return result > 0 ? Ok() : NotFound();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cartService.RemoveAsync(id);

            return result > 0 ? Ok() : NotFound();
        }
    }
}
