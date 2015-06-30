using Abp.Application.Services;
using EasyLife;
using System.Threading.Tasks;
using PagedList;
using EasyLife.Core;
using EasyLife.Application.Category.Dtos;

namespace EasyLife
{
    public interface ICategoryService : IApplicationService
    {
        void CreateCategory(CategoryDto input);

        CategoryList GetCategorys();

        IPagedList<CategoryDto> GetCategorys(int pageNumber, int pageSize);

        Category GetCategoryByID(int id);

        void UpdateCategoryByID(CategoryDto input, int id);

        void DeleteCategory(int id);


    }
}
