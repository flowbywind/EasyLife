using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using AutoMapper;
using Castle.Core.Internal;
using PagedList;
using EasyLife.Core;
using EasyLife.Application.Category.Dtos;

namespace EasyLife
{
    public class CategoryService : EasyLifeAppServiceBase, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void CreateCategory(CategoryDto input)
        {
            Logger.Debug("Creating a category for input:" + input);
            var category = new Category
            {
                cat_name = input.cat_name,
                cat_code = input.cat_code
            };
            _categoryRepository.Insert(category);
        }

        public CategoryList GetCategorys()
        {
            var model=_categoryRepository.GetAll();
            return new CategoryList
            {
                Categorys = Mapper.Map<List<CategoryDto>>(model)
            };
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IPagedList<CategoryDto> GetCategorys(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            var list = _categoryRepository.GetCategorys(pageNumber,pageSize,out totalCount);
            // 转换dto
            var result =  Mapper.Map<List<CategoryDto>>(list);
            //分页
            var pagedlist=new StaticPagedList<CategoryDto>(result,pageNumber,pageSize,totalCount);
            return pagedlist;
        }


        public Category GetCategoryByID(int id)
        {
            return _categoryRepository.Get(id);
        }


        public void UpdateCategoryByID(CategoryDto input, int id)
        {
            var model = GetCategoryByID(id);
            model.cat_name = input.cat_name;
            model.cat_code = input.cat_code;
            _categoryRepository.Update(model);
        }


        public void DeleteCategory(int id)
        {
            var model = GetCategoryByID(id);
            model.IsDeleted = true;
            _categoryRepository.Update(model);
        }
    }
}
