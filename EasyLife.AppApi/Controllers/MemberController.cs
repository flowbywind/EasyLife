using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.AppApi.Models;
using EasyLife.Core;

namespace EasyLife.AppApi.Controllers
{
    public class MemberController : Controller
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
        /// <returns></returns>
        public ActionResult Register(string phone,string pwd)
        {
            ReturnResult<bool> returnResult = new ReturnResult<bool>();
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
                return Json(returnResult);
            }
            MemberInfo info=new MemberInfo()
            {
                member_phone = phone,
                member_password = pwd
            };
            bool flag = _memberService.CreateMember(info);
            if (flag == false)
            {
                returnResult.success = false;
                returnResult.error=new Error(ReturnCode.Failure, "注册失败");
            }
            else
            {
                returnResult.result = flag;
                returnResult.success = true;
            }
            return Json(returnResult);
        }

        /// <summary>
        /// 登陆接口
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(string phone,string pwd)
        {
            ReturnResult<bool> result = new ReturnResult<bool>();
            bool flag =  _memberService.AppLogin(phone, pwd);
            if (flag == true)
            {
                result.success = true;
                result.result = flag;
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
        /// 忘记密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgetPwd(string phone,string pwd)
        {
            ReturnResult<bool> result = new ReturnResult<bool>();
            MemberDto dto = _memberService.GetMemberByPhone(phone);
            if (dto == null)
            {
                result.success = false;
                result.error=new Error(ReturnCode.Failure, "该手机号未注册或已停用");
                return Json(result);
            }
            bool flag = _memberService.AppUpdateMemberPwd(pwd, dto.id);
            if (flag==true)
            {
                result.success = true;
                result.result = true;
            }
            else
            {
                result.success = false;
                result.error = new Error() {
                    code = (int)ReturnCode.Failure,
                    message = "用户名或密码不正确"
                };
            }
            return Json(result);
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public ActionResult GetMemberInfo(string phone)
        {
            ReturnResult<MemberDto> result = new ReturnResult<MemberDto>();
            MemberDto dto = _memberService.GetMemberByPhone(phone);
            if (dto == null)
            {
                result.success = false;
                result.error = new Error(ReturnCode.Failure, "该手机号未注册或已停用");
                return Json(result);
            }
            result.success = true;
            result.result = dto;
            return Json(result,JsonRequestBehavior.AllowGet);
        }


    }
}