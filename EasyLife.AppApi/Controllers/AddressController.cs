using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.AppApi.Models;
using EasyLife.Application.Address;
using EasyLife.Application.Address.Dtos;
using EasyLife.Core.Address;

namespace EasyLife.AppApi.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService AddressService;
        public AddressController(IAddressService service)
        {
            AddressService = service;
        }

        /// <summary>
        /// 添加地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult SaveAddress(AddressDto model)
        {
            ReturnResult<AddressDto> result=new ReturnResult<AddressDto>();

            var address= AddressService.SaveAddress(model);
            result.result = address;
            result.success = address != null ? true : false;
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="memberId">会员Id</param>
        /// <returns></returns>
        public ActionResult GetAddress(int memberId)
        {
            ReturnResult<AddressDto> result = new ReturnResult<AddressDto>();
            var address = AddressService.GetAddress(memberId);
            result.result = address??new AddressDto();
            result.success = address != null ? true : false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 小区列表
        /// </summary>
        /// <returns>获取小区列表</returns>
        public ActionResult QueryCommunitList()
        {
            ReturnResult<List<CommunityDto>> result=new ReturnResult<List<CommunityDto>>();
            List<CommunityDto> list=new List<CommunityDto>();
            list.Add(new CommunityDto()
            {
                city_id = 12,
                city_name = "北京市",
                community_id = 1,
                community_name = "昌平区",
                district_id = 1,
                district_name = "新龙城二期"
            });
            list.Add(new CommunityDto()
            {
                city_id = 12,
                city_name = "北京市",
                district_id = 1,
                district_name = "昌平区",
                community_id = 1,
                community_name = "龙泽苑东区"
            });
            result.result = list;
            result.success = true;
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}