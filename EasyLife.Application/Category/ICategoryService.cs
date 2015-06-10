using Abp.Application.Services;
using EasyLife;

namespace EasyLife
{
    public interface ICategoryService : IApplicationService
    {
        void CreateCategory(CreateCategoryInput input);

    }
}
