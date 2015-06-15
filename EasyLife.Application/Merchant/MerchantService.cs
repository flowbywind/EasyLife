using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using EasyLife;
using AutoMapper;

namespace EasyLife
{
    public class MerchantService : EasyLifeAppServiceBase, IMerchantService
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Category> _categoryRepository;

        public MerchantService(IMerchantRepository merchantRepository, IRepository<City> cityRepository, IRepository<Category> categoryRepository)
        {
            _merchantRepository = merchantRepository;
            _cityRepository = cityRepository;
            _categoryRepository = categoryRepository;
        }

        public GetMerchantsOutput GetMerchants()
        {
            var model = _merchantRepository.GetAll();
            var reuslt = new GetMerchantsOutput
            {
                MerchantDto=Mapper.Map<List<MerchantDto>>(model)
            };
            return reuslt;
        }

        public void CreateMerchant(CreateMerchantInput input)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateMerchant(CreateMerchantInput input, int id)
        {
            throw new System.NotImplementedException();
        }

        public Merchant GetMerchantID(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
