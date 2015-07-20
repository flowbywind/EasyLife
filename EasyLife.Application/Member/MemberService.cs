using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using Abp.Domain.Uow;
using AutoMapper;
using Castle.Core.Internal;
using EasyLife.Application.Common;
using PagedList;
using EasyLife.Core;

namespace EasyLife
{
    public class MemberService : EasyLifeAppServiceBase, IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public MemberDto CreateMember(MemberInfo input)
        {
            MemberDto memberInfo=null;
            var member = new Member
            {
                member_name = input.member_name,
                member_sex = input.member_sex,
                member_address = input.member_address,
                member_birthday = input.member_birthday,
                member_phone = input.member_phone,
                merchant_id = input.merchant_id,
                member_pwd = input.member_password.GetMd5()
            };
            var model =  _memberRepository.Insert(member);
            {
                memberInfo = Mapper.Map<MemberDto>(model);
            }
             return memberInfo;
        }

        public MemberList GetMembersByMerchantID(int merchantid)
        {
            var model = _memberRepository.GetAllList(a => a.merchant_id == merchantid);
            return new MemberList
            {
                MemberDtos = Mapper.Map<List<MemberDto>>(model)
            };
        }

        public IPagedList<MemberDto> GetMembersByMerchantID(int merchantid, int pageNumber, int pageSize)
        {
            int totalCount = 0;
            var list = _memberRepository.GetMembersByMemberID(merchantid, pageNumber, pageSize, out totalCount);
            var result = Mapper.Map<List<MemberDto>>(list);
            var pagelist = new StaticPagedList<MemberDto>(result, pageNumber, pageSize, totalCount);
            return pagelist;
        }

        public Member GetMemberByID(int id)
        {
            return _memberRepository.Get(id);
        }

        public void UpdateMemberById(MemberInfo input, int id)
        {
            var model = _memberRepository.Get(id);
            model.member_name = input.member_name;
            model.member_sex = input.member_sex;
            model.member_address = input.member_address;
            model.member_birthday = input.member_birthday;
            model.member_phone = input.member_phone;
            model.merchant_id = input.merchant_id;
            _memberRepository.Update(model);
        }

        public void DeleteMember(int id)
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
           Member m =  _memberRepository.GetMemberByPhone(phone);
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
            Member m = _memberRepository.FirstOrDefault(a => a.member_phone == phone && a.member_pwd == pwd && a.IsDeleted==false);
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
        public MemberDto AppUpdateMemberPwd(string pwd,int id)
        {
            MemberDto memberDto = null;
            var model = _memberRepository.Get(id);
            pwd = pwd.GetMd5();
            model.member_pwd = pwd;
            Member m = _memberRepository.Update(model);
            if (m != null)
            {
                memberDto = Mapper.Map<MemberDto>(m);
                return memberDto;
            }
            return memberDto;
        }
    }
}
