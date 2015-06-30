using EasyLife;
using Abp.Application.Services;
using PagedList;
using EasyLife.Core;

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

        /// <summary>
        /// 通过手机号查找会员信息
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        Member GetMemberByPhone(string phone);
    }
}
