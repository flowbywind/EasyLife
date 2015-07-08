using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using AutoMapper;
using Castle.Core.Internal;
using PagedList;
using EasyLife.Core;

namespace EasyLife.Application
{
    public class CategoryService : EasyLifeAppServiceBase, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Create(CategoryDto input)
        {
            var category = Mapper.Map<CategoryDto, Category>(input);
            _categoryRepository.Insert(category);
        }

        public CategoryList GetList()
        {
            var model = _categoryRepository.GetAll();
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
        public IPagedList<CategoryDto> GetList(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            var list = _categoryRepository.GetCategorys(pageNumber, pageSize, out totalCount);
            // 转换dto
            var result = Mapper.Map<List<CategoryDto>>(list);
            //分页
            var pagedlist = new StaticPagedList<CategoryDto>(result, pageNumber, pageSize, totalCount);
            return pagedlist;
        }


        public CategoryDto GetByID(int id)
        {
            var category = _categoryRepository.Get(id);
            return Mapper.Map<CategoryDto>(category);
        }


        public void UpdateByID(CategoryDto input, int id)
        {
            var model = Mapper.Map<Category>(input);
            model.cat_name = input.cat_name;
            model.cat_code = input.cat_code;
            _categoryRepository.Update(model);
        }


        public void Delete(int id)
        {
            var model = _categoryRepository.Get(id);
            model.IsDeleted = true;
            _categoryRepository.Update(model);
        }
    }
}
