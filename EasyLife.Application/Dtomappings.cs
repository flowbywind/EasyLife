using AutoMapper;
using EasyLife.Application;
using EasyLife.Application.ShoppingCart.Dtos;
using EasyLife.Core;
using EasyLife.Core.ShoppingCart;

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
            Mapper.CreateMap<TagDto, Tag>();
            Mapper.CreateMap<Member, MemberDto>();
            Mapper.CreateMap<MemberDto, Member>();
            Mapper.CreateMap<Goods, GoodsDto>();
            Mapper.CreateMap<Merchant, MerchantDto>();
            Mapper.CreateMap<MerchantDto, Merchant>();
            Mapper.CreateMap<ShoppingCartDto, ShoppingCart>();
            Mapper.CreateMap<ShoppingCart, ShoppingCartDto>();
            Mapper.CreateMap<Merchant, MerchantDto>().ForMember(t => t.city_name, opts => opts.MapFrom(d => d.City.city_name))
                .ForMember(t => t.cat_name, opts => opts.MapFrom(d => d.Category.cat_name));
        }
    }
}
