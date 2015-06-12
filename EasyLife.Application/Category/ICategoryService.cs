using Abp.Application.Services;
using EasyLife;
using System.Threading.Tasks;

namespace EasyLife
{
    public interface ICategoryService : IApplicationService
    {
        void CreateCategory(CreateCategoryInput input);

        GetCategorysOutput GetCategorys();

        Category GetCategoryByID(int id);

        void UpdateCategoryByID(CreateCategoryInput input, int id);

        void DeleteCategory(int id);


    }
}
