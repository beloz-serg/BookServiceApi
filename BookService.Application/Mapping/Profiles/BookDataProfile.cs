using AutoMapper;
using BookService.Domain.Dto;
using BookService.Domain.Entities;

namespace BookService.Application.Mapping.Profiles
{
    public class BookDataProfile : Profile
    {
        public BookDataProfile()
        {
            CreateMap<BookData, BookDataDto>()
                .ForMember(target => target.Id,
                           opt => opt.MapFrom(source => source.BookId))
                .ForMember(target => target.Title,
                           opt => opt.MapFrom(source => source.BookTitle))
                .ForMember(target => target.Author,
                           opt => opt.MapFrom(source => source.AuthorName))
                .ForMember(target => target.Img,
                           opt => opt.MapFrom(source => source.ImgSrc))
                .ForMember(target => target.Price,
                           opt => opt.MapFrom(source => source.BookPrice));

            CreateMap<BookDataDto, BookData>()
                .ForMember(target => target.BookId,
                            opt => opt.MapFrom(source => source.Id))
                .ForMember(target => target.BookTitle,
                            opt => opt.MapFrom(source => source.Title))
                .ForMember(target => target.AuthorName,
                            opt => opt.MapFrom(source => source.Author))
                .ForMember(target => target.ImgSrc,
                            opt => opt.MapFrom(source => source.Img))
                .ForMember(target => target.BookPrice,
                            opt => opt.MapFrom(source => source.Price));
        }
    }
}
