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
                .ForMember(target => target.Id,
                           opt => opt.MapFrom(source => source.AuthorId))
                .ForMember(target => target.Name,
                           opt => opt.MapFrom(source => source.AuthorName));

            CreateMap<AuthorDto, Author>()
                .ForMember(target => target.AuthorId,
                           opt => opt.MapFrom(source => source.Id))
                .ForMember(target => target.AuthorName,
                           opt => opt.MapFrom(source => source.Name));
        }
    }
}
