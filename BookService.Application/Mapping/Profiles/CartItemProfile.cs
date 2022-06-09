using AutoMapper;
using BookService.Domain.Dto;
using BookService.Domain.Entities;

namespace BookService.Application.Mapping.Profiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, CartItemDto>().ReverseMap();
        }
    }
}
