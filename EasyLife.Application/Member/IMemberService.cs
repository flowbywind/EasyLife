using EasyLife;
using Abp.Application.Services;
using PagedList;
using EasyLife.Core;

namespace EasyLife.Application
{
    public interface IMemberService : IApplicationService
    {
        void Create(MemberDto input);

        MemberList GetByMerchantID(int merchantid);

        IPagedList<MemberDto> GetByMerchantID(int merchantid, int pageNumber, int pageSize);

        MemberDto GetByID(int id);

        void UpdateById(MemberDto input, int id);

        void Delete(int id);

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
        MemberDto AppLogin(string phone, string pwd);

        /// <summary>
        /// 更新会员密码
        /// </summary>
        /// <param name="pwd">密码</param>
        /// <param name="id">会员id</param>
        /// <returns>是否更新成功</returns>
        bool AppUpdateMemberPwd(string pwd, int id);
    }
}
