using Abp.Domain.Repositories;
using AutoMapper;
using EasyLife.Application;
using EasyLife.Core;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace EasyLife
{
    public class CityService : EasyLifeAppServiceBase, ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void Create(CreateCityInput input)
        {
            var city = Mapper.Map<City>(input);
            _cityRepository.Insert(city);
        }

        public CityList GetCitys()
        {
            var result = _cityRepository.GetAll().Where(a => a.IsDeleted == false);
            var list = new CityList
            {
                Citys = Mapper.Map<List<CityDto>>(result)
            };
            return list;
        }

        public IPagedList<CityDto> GetCitys(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            var list = _cityRepository.GetCitys(pageNumber, pageSize, out totalCount);
            var result = Mapper.Map<List<CityDto>>(list);
            var pagelist = new StaticPagedList<CityDto>(result, pageNumber, pageSize, totalCount);
            return pagelist;
        }

        public CityDto GetByID(int id)
        {
            var city = _cityRepository.Get(id);
            return Mapper.Map<CityDto>(city);
        }

        public void UpdateByID(CreateCityInput input, int id)
        {
            //var model = _cityRepository.Get(id);
            //model.city_name = input.city_name;
            //model.pin_yin = input.pin_yin;
            //model.hot=input.
            var model = Mapper.Map<City>(input);
            model.Id = id;
            _cityRepository.Update(model);
        }

        public void Delete(int id)
        {
            var model = _cityRepository.Get(id);
            model.IsDeleted = true;
            _cityRepository.Update(model);
        }
    }
}
