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
        private readonly AddressService AddressService;
        public AddressController(AddressService service)
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
            result.result = address;
            result.success = address != null ? true : false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}