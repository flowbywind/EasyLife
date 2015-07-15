using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using Castle.Core.Internal;
using EasyLife.Application.Common;
using PagedList;
using EasyLife.Core;

namespace EasyLife.Application
{
    public class MemberService : EasyLifeAppServiceBase, IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void Create(MemberDto input)
        {
            var member = Mapper.Map<Member>(input);
            _memberRepository.Insert(member);
        }

        public MemberList GetByMerchantID(int merchantid)
        {
            var model = _memberRepository.GetAllList(a => a.merchant_id == merchantid);
            return new MemberList
            {
                MemberDtos = Mapper.Map<List<MemberDto>>(model)
            };
        }

        public IPagedList<MemberDto> GetByMerchantID(int merchantid, int pageNumber, int pageSize)
        {
            int totalCount = 0;
            var list = _memberRepository.GetMembersByMemberID(merchantid, pageNumber, pageSize, out totalCount);
            var result = Mapper.Map<List<MemberDto>>(list);
            var pagelist = new StaticPagedList<MemberDto>(result, pageNumber, pageSize, totalCount);
            return pagelist;
        }

        public MemberDto GetByID(int id)
        {
            var member = _memberRepository.Get(id);
            return Mapper.Map<MemberDto>(member);
        }

        public void UpdateById(MemberDto input, int id)
        {
            var model = Mapper.Map<Member>(input);
            model.Id = id;
            _memberRepository.Update(model);
        }

        public void Delete(int id)
        {
            var model = _memberRepository.Get(id);
            model.IsDeleted = true;
            _memberRepository.Update(model);
        }

        /// <summary>
        /// 通过手机号查找会员信息
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public MemberDto GetMemberByPhone(string phone)
        {
            Member m = _memberRepository.GetMemberByPhone(phone);
            if (m != null)
            {
                MemberDto model = Mapper.Map<MemberDto>(m);
                return model;
            }
            return null;
        }

        /// <summary>
        /// 客户端登陆
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public MemberDto AppLogin(string phone, string pwd)
        {
            MemberDto memberInfo = null;
            pwd = pwd.GetMd5();
            Member m = _memberRepository.FirstOrDefault(a => a.member_phone == phone && a.member_pwd == pwd && a.IsDeleted == false);
            if (m != null)
            {
                memberInfo = Mapper.Map<MemberDto>(m);
            }
            return memberInfo;
        }

        /// <summary>
        /// 更新会员密码信息
        /// </summary>
        /// <param name="pwd">密码</param>
        /// <param name="id">会员id</param>
        /// <returns></returns>
        public bool AppUpdateMemberPwd(string pwd, int id)
        {
            var model = _memberRepository.Get(id);
            pwd = pwd.GetMd5();
            model.member_pwd = pwd;
            Member m = _memberRepository.Update(model);
            if (m != null)
            {
                return true;
            }
            return false;
        }
    }
}
