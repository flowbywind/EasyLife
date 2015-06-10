using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using EasyLife;

namespace EasyLife
{
    public class CategoryService : EasyLifeAppServiceBase, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
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

    }
}
