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
            var model = _merchantRepository.Get(id);
            model.merchant_name = input.merchant_name;
            model.bank = input.bank;
            model.account = input.account;
            model.city_id = input.city_id;
            model.cat_id = input.cat_id;
            model.contact_name = input.contact_name;
            model.phone = input.phone;
            model.email = input.email;
            _merchantRepository.Update(model);
        }

        public MerchantDto GetMerchantDtoID(int id)
        {
            var merchantDto = _merchantRepository.Get(id);
            return Mapper.Map<MerchantDto>(merchantDto);
        }

        public Merchant GetMerchantID(int id)
        {
            var merchant = _merchantRepository.Get(id);
            return merchant;
        }
    }
}
