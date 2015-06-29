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

        public void CreateMember(MemberInfo input)
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
            _memberRepository.Insert(member);
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
    }
}
