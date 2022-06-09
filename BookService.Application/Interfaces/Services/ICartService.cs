using BookService.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Application.Interfaces.Services
{
    public interface ICartService
    {
        Task<IEnumerable<CartItemDto>> GetCartItemsAsync();

        Task<CartItemDto> GetCartItemByIdAsync(int id);

        Task<int> NewAsync(CartItemDto dto);

        Task<int> ModifyAsync(CartItemDto dto);

        Task<int> RemoveAsync(int id);
    }
}
