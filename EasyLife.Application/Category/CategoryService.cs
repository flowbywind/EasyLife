using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using EasyLife;
using System;

namespace EasyLife
{
    public class CategoryService : EasyLifeAppServiceBase, ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void CreateCategory(CreateCategoryInput input)
        {
            Logger.Debug("Creating a category for input:" + input);
            var category = new Category
            {
                cat_name = input.cat_name,
                cat_code = input.cat_code
            };
            _categoryRepository.Insert(category);
        }



        public GetCategorysOutput GetCategorys()
        {

            var result = _categoryRepository.GetAllList();
            var list = new GetCategorysOutput
             {
                 Categorys = Mapper.Map<List<CategoryDto>>(result)
             };
            return list;

        }


        public Category GetCategoryByID(int id)
        {
            return _categoryRepository.Get(id);
        }


        public void UpdateCategoryByID(CreateCategoryInput input, int id)
        {
            var model = GetCategoryByID(id);
            model.cat_name = input.cat_name;
            model.cat_code = input.cat_code;
            _categoryRepository.Update(model);
        }
    }
}
