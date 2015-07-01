using AutoMapper;
using EasyLife.Application;
using EasyLife.Application.Category.Dtos;
using EasyLife.Core;
namespace EasyLife
{
    public class Dtomappings
    {
        public static void Map()
        {
            Mapper.CreateMap<City, CityDto>();
            Mapper.CreateMap<CreateCityInput, City>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Tag, TagDto>();
            Mapper.CreateMap<Member, MemberDto>();
            Mapper.CreateMap<Goods, GoodsDto>();
            //Mapper.CreateMap<Merchant, MerchantDto>().ForMember(t => t.city_name, opts => opts.MapFrom(d => d.City.city_name))
            //    .ForMember(t => t.cat_name, opts => opts.MapFrom(d => d.Category.cat_name));
        }
    }
}
