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
            if (list != null && list.TagDtos != null)
            {
                list.TagDtos.Insert(0,new TagDto()
                {
                    id=0,
                    merchant_id = merchantId,
                    tag_name = "全部",
                    tag_code = "",
                    icon = "data/all.png"
                });
               List<string>  nameList=new List<string>()
               {
                   ""
               };
                for (int i = 1; i < 6; i++)
                {
                    list.TagDtos.Add(new TagDto() {
                         id=1,
                         icon="tab"+i.ToString(),
                         merchant_id = merchantId,
                         tag_name = "",
                         line_icon = "tab"+i.ToString()+"_"
                    });
                }
              
            }
            result.result = list.TagDtos;
            result.success = true;
           return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}