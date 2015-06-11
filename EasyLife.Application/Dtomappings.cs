using AutoMapper;
using EasyLife;
namespace EasyLife
{
    public class Dtomappings
    {
        public static void Map()
        {
            Mapper.CreateMap<Category, CategoryDto>();
        }
    }
}
