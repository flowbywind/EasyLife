using EasyLife;
using Abp.Application.Services;
using PagedList;
using EasyLife.Core;


namespace EasyLife
{
    public interface ITagService : IApplicationService
    {
        void CreateTag(TagInfo input);

        TagList GetTagsByMerchantID(int merchantid);

        IPagedList<TagDto> GetTagsByMerchantID(int merchantid, int pageNumber, int pageSize);

        Tag GetTagByID(int id);

        void UpdateTagById(TagInfo input, int id);

        void DeleteTag(int id);

    }
}
