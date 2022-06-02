using AutoMapper;
using BookService.Domain.Dto;
using BookService.Domain.Entities;

namespace BookService.Application.Mapping.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>()
                .ForMember(target => target.BookId,
                           opt => opt.MapFrom(source => source.Id))
                .ForMember(target => target.AuthorId,
                           opt => opt.MapFrom(source => source.AuthorId))
                .ForMember(target => target.Title,
                           opt => opt.MapFrom(source => source.Title))
                .ForMember(target => target.Img,
                           opt => opt.MapFrom(source => source.Img))
                .ForMember(target => target.Price,
                           opt => opt.MapFrom(source => source.Price));

            CreateMap<Book, BookDto>()
                .ForMember(target => target.Id,
                           opt => opt.MapFrom(source => source.BookId))
                .ForMember(target => target.AuthorId,
                           opt => opt.MapFrom(source => source.AuthorId))
                .ForMember(target => target.Title,
                           opt => opt.MapFrom(source => source.Title))
                .ForMember(target => target.Img,
                           opt => opt.MapFrom(source => source.Img))
                .ForMember(target => target.Price,
                           opt => opt.MapFrom(source => source.Price));
        }
    }
}
