using EasyLife;
using Abp.Application.Services;
using EasyLife.Core;

namespace EasyLife
{
    public interface IMerchantService : IApplicationService
    {
        GetMerchantsOutput GetMerchants();

        MerchantDto GetMerchantDtoID(int id);

        Merchant GetMerchantID(int id);

        void CreateMerchant(CreateMerchantInput input);

        void UpdateMerchant(CreateMerchantInput input,int id);

    }
}
