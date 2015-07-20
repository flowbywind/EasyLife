using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using AutoMapper;
using Castle.Core.Internal;
using PagedList;
using EasyLife.Core;
using EasyLife.Application;


namespace EasyLife.Application
{
    public class TagService : EasyLifeAppServiceBase, ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public void Create(TagDto input)
        {
            var tag = Mapper.Map<Tag>(input);
            _tagRepository.Insert(tag);
        }

        public TagList GetTagsByMerchantID(int merchantid)
        {
            var model = _tagRepository.GetAll().Where(a => a.merchant_id == merchantid);
            return new TagList
            {
                TagDtos = Mapper.Map<List<TagDto>>(model)
            };
        }

        public IPagedList<TagDto> GetTagsByMerchantID(int merchantid, int pageNumber, int pageSize)
        {
            int totalCount = 0;
            var list = _tagRepository.GetTagsByMerchantID(merchantid, pageNumber, pageSize, out totalCount);
            var result = Mapper.Map<List<TagDto>>(list);
            var pagelist = new StaticPagedList<TagDto>(result, pageNumber, pageSize, totalCount);
            return pagelist;
        }

        public TagDto GetByID(int id)
        {
            var tag = _tagRepository.Get(id);
            return Mapper.Map<TagDto>(tag);
        }

        public void UpdateById(TagDto input, int id)
        {
            var model = Mapper.Map<Tag>(input);
            model.Id = id;
            _tagRepository.Update(model);
        }

        public void Delete(int id)
        {
            var model = _tagRepository.Get(id);
            model.IsDeleted = true;
            _tagRepository.Update(model);
        }
    }
}
