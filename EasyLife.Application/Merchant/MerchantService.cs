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
                MerchantDto = Mapper.Map<List<MerchantDto>>(model)
            };
            return reuslt;
        }

        public void CreateMerchant(CreateMerchantInput input)
        {
            var merchant = new Merchant
            {
                merchant_name = input.merchant_name,
                bank = input.bank,
                account = input.account,
                city_id = input.city_id,
                cat_id = input.cat_id,
                contact_name = input.contact_name,
                phone = input.phone,
                email = input.email
            };
            _merchantRepository.Insert(merchant);
        }

        public void UpdateMerchant(CreateMerchantInput input, int id)
        {
            throw new System.NotImplementedException();
        }

        public Merchant GetMerchantID(int id)
        {
            return _merchantRepository.Get(id);
        }
    }
}
