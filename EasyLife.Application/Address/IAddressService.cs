using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using EasyLife.Application.Address.Dtos;

namespace EasyLife.Application.Address
{
    public interface IAddressService:IApplicationService
    {
        /// <summary>
        /// 添加地址
        /// </summary>
        /// <param name="model">地址信息</param>
        /// <returns></returns>
        AddressDto AddAddress(AddressDto model);

        /// <summary>
        /// 添加或更新地址
        /// </summary>
        /// <param name="model">地址信息</param>
        /// <returns></returns>
        AddressDto SaveAddress(AddressDto model);

        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="memberid">会员ID</param>
        /// <returns></returns>
        AddressDto GetAddress(int memberid);
    }
}
