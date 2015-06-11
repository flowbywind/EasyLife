using EasyLife;
using Abp.Application.Services;

namespace EasyLife
{
    public interface IMerchantService : IApplicationService
    {
        GetMerchantsOutput GetMerchants();

    }
}
