using EasyLife;
using Abp.Application.Services;

namespace EasyLife
{
    public interface IMerchantService : IApplicationService
    {
        GetMerchantsOutput GetMerchants();

        Merchant GetMerchantID(int id);

        void CreateMerchant(CreateMerchantInput input);

        void UpdateMerchant(CreateMerchantInput input,int id);

    }
}
