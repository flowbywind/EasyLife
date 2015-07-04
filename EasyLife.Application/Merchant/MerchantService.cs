using Abp.Domain.Repositories;
using AutoMapper;
using EasyLife.Application;
using EasyLife.Core;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace EasyLife.Application
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

        public MerchantList GetList()
        {
            var model = _merchantRepository.GetAll().Where(a => a.IsDeleted == false);
            var reuslt = new MerchantList
            {
                MerchantDto = Mapper.Map<List<MerchantDto>>(model)
            };
            return reuslt;
        }

        public IPagedList<MerchantDto> GetList(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            var list = _merchantRepository.GetMerchants(pageNumber, pageSize, out totalCount);
            var result = Mapper.Map<List<MerchantDto>>(list);
            var pagelist = new StaticPagedList<MerchantDto>(result, pageNumber, pageSize, totalCount);
            return pagelist;
        }

        public void Create(MerchantDto input)
        {
            var merchant = Mapper.Map<MerchantDto, Merchant>(input);
            _merchantRepository.Insert(merchant);
        }

        public void Update(MerchantDto input, int id)
        {
            var model = Mapper.Map<Merchant>(input);
            model.Id = id;
            _merchantRepository.Update(model);
        }

        public MerchantDto GetByID(int id)
        {
            var merchantDto = _merchantRepository.Get(id);
            return Mapper.Map<MerchantDto>(merchantDto);
        }

        public void Delete(int id)
        {
            var model = _merchantRepository.Get(id);
            model.IsDeleted = true;
            _merchantRepository.Update(model);
        }
    }
}
