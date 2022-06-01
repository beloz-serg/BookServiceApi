using AutoMapper;
using BookService.Domain.Dto;
using BookService.Domain.Entities;

namespace BookService.Application.Mapping.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(target => target.Name,
                           opt => opt.MapFrom(source => source.AuthorName));

            CreateMap<AuthorDto, Author>()
                .ForMember(target => target.AuthorName,
                           opt => opt.MapFrom(source => source.Name));
        }
    }
}
