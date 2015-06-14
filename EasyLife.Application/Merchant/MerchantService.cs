using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using EasyLife;

namespace EasyLife
{
    public class MerchantService : EasyLifeAppServiceBase, IMerchantService
    {
        private readonly IMerchantService _merchantRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Category> _categoryRepository;

        public MerchantService(IMerchantService merchantRepository, IRepository<City> cityRepository, IRepository<Category> categoryRepository)
        {
            _merchantRepository = merchantRepository;
            _cityRepository = cityRepository;
            _categoryRepository = categoryRepository;
        }

        public GetMerchantsOutput GetMerchants()
        {
            return null;
        }

        public void CreateMerchant(CreateMerchantInput input)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateMerchant(CreateMerchantInput input,int id)
        {
            throw new System.NotImplementedException();
        }

        public Merchant GetMerchantID(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
