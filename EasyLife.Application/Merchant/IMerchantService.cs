using Abp.Application.Services;
using EasyLife.Core;
using PagedList;

namespace EasyLife.Application
{
    public interface IMerchantService : IApplicationService
    {
        MerchantList GetList();
        IPagedList<MerchantDto> GetList(int pageNumber, int pageSize);

        MerchantDto GetByID(int id);

        void Create(MerchantDto input);

        void Update(MerchantDto input, int id);

        void Delete(int id);

    }
}
