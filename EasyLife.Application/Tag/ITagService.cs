using EasyLife;
using Abp.Application.Services;
using PagedList;
using EasyLife.Core;
using EasyLife.Application;


namespace EasyLife
{
    public interface ITagService : IApplicationService
    {
        void Create(TagDto input);

        TagList GetTagsByMerchantID(int merchantid);

        IPagedList<TagDto> GetTagsByMerchantID(int merchantid, int pageNumber, int pageSize);

        TagDto GetByID(int id);

        void UpdateById(TagDto input, int id);

        void Delete(int id);

    }
}
