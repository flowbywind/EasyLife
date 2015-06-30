using EasyLife;
using Abp.Application.Services;
using PagedList;
using EasyLife.Core;

namespace EasyLife
{
    public interface IMemberService : IApplicationService
    {
        bool CreateMember(MemberInfo input);

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
        MemberDto GetMemberByPhone(string phone);

        /// <summary>
        /// 客户端登陆
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        bool AppLogin(string phone, string pwd);

        /// <summary>
        /// 更新会员密码
        /// </summary>
        /// <param name="pwd">密码</param>
        /// <param name="id">会员id</param>
        /// <returns>是否更新成功</returns>
        bool AppUpdateMemberPwd(string pwd, int id);
    }
}
