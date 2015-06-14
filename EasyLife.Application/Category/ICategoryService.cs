using Abp.Application.Services;
using EasyLife;
using System.Threading.Tasks;
using PagedList;

namespace EasyLife
{
    public interface ICategoryService : IApplicationService
    {
        void CreateCategory(CreateCategoryInput input);

        IPagedList<CategoryDto> GetCategorys(int pageNumber, int pageSize);

        Category GetCategoryByID(int id);

        void UpdateCategoryByID(CreateCategoryInput input, int id);

        void DeleteCategory(int id);


    }
}
