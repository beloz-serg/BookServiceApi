using AutoMapper;
using BookService.Application.Mapping.Profiles;

namespace BookService.Application.Mapping
{
    public class MappingConfiguration
    {
        public static IMapper GetMapper()
        {
            var mapConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthorProfile());
            });

            return mapConfiguration.CreateMapper();
        }
    }
}
