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
                mc.AddProfile(new BookProfile());
                mc.AddProfile(new BookDataProfile());
                mc.AddProfile(new CartItemProfile());
            });

            return mapConfiguration.CreateMapper();
        }
    }
}
