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
            Mapper.CreateMap<Merchant, MerchantDto>().ForMember(t => t.city_id, opts => opts.MapFrom(d => d.City.Id))
                .ForMember(t => t.cat_id, opts => opts.MapFrom(d => d.Category.Id));
        }
    }
}
