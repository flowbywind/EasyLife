using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.AppApi.Models;

namespace EasyLife.AppApi.Controllers
{
    public class MemberController : Controller
    {
        private MemberService MemberService;
        public MemberController(MemberService memberService)
        {
            MemberService = memberService;
        }

        /// <summary>
        /// 注册接口
        /// </summary>
        /// <returns></returns>
        public ActionResult Register(string phone,string pwd)
        {
            ReturnResult<Member> returnResult=new ReturnResult<Member>();
            Member member = MemberService.GetMemberByPhone(phone);
            if (member != null)
            {
                returnResult.success = false;
                returnResult.error=new Error()
                {
                    code=(int)ReturnCode.Fail,
                    details = "",
                    message = "当前手机号已经注册"
                };
                return Json(returnResult);
            }

            return View();
        }

        /// <summary>
        /// 登陆接口
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetPwd()
        {
            return View();
        }


    }
}