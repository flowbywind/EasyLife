using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using System.Linq;
using AutoMapper;
using EasyLife;
using System;

namespace EasyLife
{
    public class CityService : EasyLifeAppServiceBase, ICityService
    {
        private readonly IRepository<City> _cityRepository;

        public CityService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void CreateCity(CreateCityInput input)
        {
            var city = new City
            {
                city_name = input.city_name,
                pin_yin = input.pin_yin,
            };
            _cityRepository.Insert(city);
        }

        public GetCitysOutput GetCitys()
        {
            var result = _cityRepository.GetAll().Where(a => a.IsDeleted == false);
            var list = new GetCitysOutput
            {
                Citys = Mapper.Map<List<CityDto>>(result)
            };
            return list;
        }

        public City GetCityByID(int id)
        {
            return _cityRepository.Get(id);
        }

        public void UpdateCityByID(CreateCityInput input, int id)
        {
            var model = GetCityByID(id);
            model.city_name = input.city_name;
            model.pin_yin = input.pin_yin;
            //model.first_char = input.first_char;
            _cityRepository.Update(model);
        }

        public void DeleteCity(int id)
        {
            var model = GetCityByID(id);
            model.IsDeleted = true;
            _cityRepository.Update(model);
        }
    }
}
