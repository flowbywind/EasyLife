using EasyLife;
using Abp.Application.Services;
using PagedList;

namespace EasyLife
{
    public interface IMemberService : IApplicationService
    {
        void CreateMember(MemberInfo input);

        MemberList GetMembersByMerchantID(int merchantid);

        IPagedList<MemberDto> GetMembersByMerchantID(int merchantid, int pageNumber, int pageSize);

        Member GetMemberByID(int id);

        void UpdateMemberById(MemberInfo input, int id);

        void DeleteMember(int id);
    }
}
