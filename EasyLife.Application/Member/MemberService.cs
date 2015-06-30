using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using AutoMapper;
using Castle.Core.Internal;
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

        public bool CreateMember(MemberInfo input)
        {
            var member = new Member
            {
                member_name = input.member_name,
                member_sex = input.member_sex,
                member_address = input.member_address,
                member_birthday = input.member_birthday,
                member_phone = input.member_phone,
                merchant_id = input.merchant_id
            };
            var model =  _memberRepository.Insert(member);
            if (model != null)
            {
                return true;
            }
            return false;
        }

        public MemberList GetMembersByMerchantID(int merchantid)
        {
            var model = _memberRepository.GetAll().Where(a => a.merchant_id == merchantid);
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
           Member m =  _memberRepository.GetAll().FirstOrDefault(a => a.member_phone == phone);
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
        public bool AppLogin(string phone, string pwd)
        {
            Member m = _memberRepository.GetAll().FirstOrDefault(a => a.member_phone == phone && a.member_pwd == pwd && a.IsDeleted==false);
            if (m != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新会员密码信息
        /// </summary>
        /// <param name="pwd">密码</param>
        /// <param name="id">会员id</param>
        /// <returns></returns>
        public bool AppUpdateMemberPwd(string pwd,int id)
        {
            var model = _memberRepository.Get(id);
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
