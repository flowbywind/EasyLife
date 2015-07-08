using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.AppApi.Models;

namespace EasyLife.AppApi.Controllers
{
    public class TagController : BaseApiController
    {
        private readonly ITagService _tagService;

        public  TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// 获取商家的洗衣类别
        /// </summary>
        /// <param name="merchantId">商家ID</param>
        /// <returns></returns>
        public ActionResult QueryTagList(int merchantId)
        {
            ReturnResult<List<TagDto>> result =new ReturnResult<List<TagDto>>();
            var list =  _tagService.GetTagsByMerchantID(merchantId);
            result.result = list.TagDtos;
            result.success = true;
           return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}