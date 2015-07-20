using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.AppApi.Models;
using EasyLife.Core;

namespace EasyLife.AppApi.Controllers
{
    public class MemberController : BaseApiController
    {
        private MemberService _memberService;
        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }

        /// <summary>
        /// 注册接口
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <param name="merchantId">商家ID</param>
        /// <returns></returns>
        public ActionResult Register(string phone,string pwd,int merchantId)
        {
            ReturnResult<MemberDto> returnResult = new ReturnResult<MemberDto>();
            MemberDto member = _memberService.GetMemberByPhone(phone);
            if (member != null)
            {
                returnResult.success = false;
                returnResult.error=new Error()
                {
                    code=(int)ReturnCode.Failure,
                    details = "",
                    message = "当前手机号已经注册"
                };
                return Json(returnResult,JsonRequestBehavior.AllowGet);
            }
            MemberInfo info=new MemberInfo()
            {
                member_phone = phone,
                member_password = pwd,
                merchant_id = merchantId
            };
            var model = _memberService.CreateMember(info);
            if (model == null)
            {
                returnResult.success = false;
                returnResult.error=new Error(ReturnCode.Failure, "注册失败");
            }
            else
            {
                returnResult.result = model;
                returnResult.success = true;
            }
            return Json(returnResult,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 登陆接口
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(string phone,string pwd)
        {
            ReturnResult<MemberDto> result = new ReturnResult<MemberDto>();
            var memberInfo =  _memberService.AppLogin(phone, pwd);
            if (memberInfo != null)
            {
                result.success = true;
                result.result = memberInfo;
            }
            else
            {
                result.success = false;
                result.error=new Error()
                {
                    code=(int)ReturnCode.Failure,
                    message = "用户名或密码不正确"
                };
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
          
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ResertPwd(string phone,string pwd)
        {
            ReturnResult<MemberDto> result = new ReturnResult<MemberDto>();
            MemberDto dto = _memberService.GetMemberByPhone(phone);
            if (dto == null)
            {
                result.success = false;
                result.error=new Error(ReturnCode.Failure, "该手机号未注册或已停用");
                return Json(result,JsonRequestBehavior.AllowGet);
            }
            var memberDto = _memberService.AppUpdateMemberPwd(pwd, dto.id);
            if (memberDto != null)
            {
                result.success = true;
                result.result = memberDto;
            }
            else
            {
                result.success = false;
                result.error = new Error() {
                    code = (int)ReturnCode.Failure,
                    message = "用户名或密码不正确"
                };
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public string GetMemberInfo(string phone)
        {
            string json;
            ReturnResult<MemberDto> result = new ReturnResult<MemberDto>();
            MemberDto dto = _memberService.GetMemberByPhone(phone);
            if (dto == null)
            {
                result.success = false;
                result.error = new Error(ReturnCode.Failure, "该手机号未注册或已停用");
                json = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                return json;
            }
            result.success = true;
            result.result = dto;
            json = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return json;
        }


    }
}