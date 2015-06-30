using Abp.Domain.Repositories;
using AutoMapper;
using EasyLife.Application;
using EasyLife.Core;
using System.Collections.Generic;
using System.Linq;

namespace EasyLife
{
    public class CityService : EasyLifeAppServiceBase, ICityService
    {
        private readonly IRepository<City> _cityRepository;

        public CityService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void Create(CityDto input)
        {
            var city = new City
            {
                city_name = input.city_name,
                pin_yin = input.pin_yin,
            };
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

        public City GetByID(int id)
        {
            return _cityRepository.Get(id);
        }

        public void UpdateByID(CityDto input, int id)
        {
            var model = _cityRepository.Get(id);
            model.city_name = input.city_name;
            model.pin_yin = input.pin_yin;
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
