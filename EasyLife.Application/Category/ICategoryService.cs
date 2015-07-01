using Abp.Application.Services;
using EasyLife;
using System.Threading.Tasks;
using PagedList;
using EasyLife.Core;

namespace EasyLife.Application
{
    public interface ICategoryService : IApplicationService
    {
        void Create(CategoryDto input);

        CategoryList GetList();

        IPagedList<CategoryDto> GetList(int pageNumber, int pageSize);

        Category GetByID(int id);

        void UpdateByID(CategoryDto input, int id);

        void Delete(int id);


    }
}
