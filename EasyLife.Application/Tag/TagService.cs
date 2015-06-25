using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using AutoMapper;
using Castle.Core.Internal;
using PagedList;


namespace EasyLife
{
    public class TagService : EasyLifeAppServiceBase, ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public void CreateTag(TagInfo input)
        {
            var tag = new Tag
            {
                tag_name = input.tag_name,
                tag_code = input.tag_code,
                merchant_id = input.merchant_id
            };
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

        public Tag GetTagByID(int id)
        {
            return _tagRepository.Get(id);
        }

        public void UpdateTagById(TagInfo input, int id)
        {
            var model = _tagRepository.Get(id);
            model.tag_name = input.tag_name;
            model.tag_code = input.tag_code;
            _tagRepository.Update(model);
        }

        public void DeleteTag(int id)
        {
            var model = _tagRepository.Get(id);
            model.IsDeleted = true;
            _tagRepository.Update(model);
        }
    }
}
