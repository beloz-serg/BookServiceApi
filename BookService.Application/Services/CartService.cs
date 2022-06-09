using AutoMapper;
using BookService.Application.Interfaces.Repositories;
using BookService.Application.Interfaces.Services;
using BookService.Domain.Dto;
using BookService.Domain.Entities;
using BookService.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.Application.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _dataSource;
        private IMapper _mapper;

        public CartService(ICartRepository dataSource, IMapper mapper)
        {
            _dataSource = dataSource;
            _mapper = mapper;
        }

        public async Task<CartItemDto> GetCartItemByIdAsync(int id)
        {
            var item = await _dataSource.GetAsync(id);

            return _mapper.Map<CartItemDto>(item);
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItemsAsync()
        {
            var items = await _dataSource.GetAllAsync();

            return _mapper.Map<IEnumerable<CartItemDto>>(items);
        }

        public async Task<int> ModifyAsync(CartItemDto dto)
        {
            ValidateCartItemDto(dto);

            var item = _mapper.Map<CartItem>(dto);

            return await _dataSource.UpdateAsync(item);
        }

        public async Task<int> NewAsync(CartItemDto dto)
        {
            ValidateCartItemDto(dto);

            var item = _mapper.Map<CartItem>(dto);

            return await _dataSource.AddAsync(item);
        }

        public async Task<int> RemoveAsync(int id)
        {
            return await _dataSource.DeleteAsync(id);
        }

        public static void ValidateCartItemDto(CartItemDto dto)
        {
            if (dto.Book.IsEmpty())
            {
                throw new ArgumentException(nameof(dto.Book));
            }

            if (dto.Price <= 0)
            {
                throw new ArgumentException(nameof(dto.Price));
            }

            if (dto.UserEmail.IsEmpty())
            {
                throw new ArgumentException(nameof(dto.UserEmail));
            }
        }
    }
}
