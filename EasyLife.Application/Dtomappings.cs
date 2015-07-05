using AutoMapper;
using EasyLife.Application;
using EasyLife.Core;
namespace EasyLife
{
    public class Dtomappings
    {
        public static void Map()
        {
            Mapper.CreateMap<City, CityDto>();
            Mapper.CreateMap<CityDto, City>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();
            Mapper.CreateMap<Tag, TagDto>();
            Mapper.CreateMap<Member, MemberDto>();
            Mapper.CreateMap<Member, MemberInfo>();
            Mapper.CreateMap<Goods, GoodsDto>();
            Mapper.CreateMap<Merchant, MerchantDto>();
            //Mapper.CreateMap<Merchant, MerchantDto>().ForMember(t => t.city_name, opts => opts.MapFrom(d => d.City.city_name))
            //    .ForMember(t => t.cat_name, opts => opts.MapFrom(d => d.Category.cat_name));
        }
    }
}
