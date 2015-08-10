using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyLife.Application.Address.Dtos;
using EasyLife.Core.Address;

namespace EasyLife.Application.Address
{
   public  class AddressService:IAddressService
   {
       private readonly IMemberAddressRepository _memberAddressRepository;

       public AddressService(IMemberAddressRepository repository)
       {
           _memberAddressRepository = repository;
       }

       /// <summary>
       /// 添加地址
       /// </summary>
       /// <param name="model">地址信息</param>
       /// <returns></returns>
       public AddressDto AddAddress(AddressDto model)
       {
           if (model == null)
           {
               return null;
           }
           var result = Mapper.Map<AddressDto, MemberAddress>(model);
           MemberAddress address =  _memberAddressRepository.Insert(result);
           return  Mapper.Map<MemberAddress, AddressDto>(address);
       }

       /// <summary>
       /// 添加或更新地址
       /// </summary>
       /// <param name="model">地址信息</param>
       /// <returns></returns>
       public AddressDto SaveAddress(AddressDto model)
       {
           if (model == null)
           {
               return null;
           }
           //获取地址信息
           var oldAddress = _memberAddressRepository.FirstOrDefault(a => a.member_id == model.member_id && a.IsDeleted == false);
           if (oldAddress == null)
           {
               oldAddress = Mapper.Map<AddressDto, MemberAddress>(model);
               oldAddress.CreatorUserId = model.member_id;
               oldAddress.CreationTime=DateTime.Now;
               oldAddress.LastModifierUserId = model.member_id;
               oldAddress.LastModificationTime = DateTime.Now;
               MemberAddress address = _memberAddressRepository.Insert(oldAddress);
               return Mapper.Map<MemberAddress, AddressDto>(address);
           }
           else
           {
               oldAddress.LastModifierUserId = model.member_id;
               oldAddress.LastModificationTime = DateTime.Now;
               oldAddress.city = model.city;
               oldAddress.city_id = model.city_id;
               oldAddress.community_id = model.community_id;
               oldAddress.community_name = model.community_name;
               oldAddress.member_address = model.member_address;
               oldAddress.member_name = model.member_name;
               oldAddress.phone = model.phone;
               oldAddress.is_default = model.is_default;
               MemberAddress address = _memberAddressRepository.Update(oldAddress);
               return Mapper.Map<MemberAddress, AddressDto>(address);
           }
       }

       /// <summary>
       /// 获取地址
       /// </summary>
       /// <param name="memberid">会员ID</param>
       /// <returns></returns>
       public AddressDto GetAddress(int memberid)
       {
          var model =  this._memberAddressRepository.QueryList(a => a.member_id == memberid && a.IsDeleted == false).FirstOrDefault();
           if (model == null)
           {
               return null;
           }
           return Mapper.Map<MemberAddress, AddressDto>(model);
       }
   }
}
