using AutoMapper;
using EasyLife;
namespace EasyLife
{
    public class Dtomappings
    {
        public static void Map()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<City, CityDto>();
            Mapper.CreateMap<Merchant, MerchantDto>().ForMember(t => t.city_name, opts => opts.MapFrom(d => d.City.city_name))
                .ForMember(t => t.cat_name, opts => opts.MapFrom(d => d.Category.cat_name));
        }
    }
}
