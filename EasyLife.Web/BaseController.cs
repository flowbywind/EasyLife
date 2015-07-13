using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace EasyLife.Web
{
    /// <summary>
    /// 登录成功的时候被放入SESSION中
    /// </summary>
    public class UserState
    {
        public string PassCode { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }

        //public List<Role> RoleCollection { set; get; }   //角色集
        //public List<Auth> AuthCollection { set; get; }   //权限集
    }

    public class BaseController : Controller
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserState CurrentSession { set; get; }

        /// <summary>
        /// 微软设计这个无参的构造的Controller 有利于使用IOC容器提高对象的创建效率
        /// 如果设计了System.Web.Routing.RequestContext参数，由于每次来的RequestContext都不相同
        /// 则Controller 就要不停的动态创建
        /// </summary>
        public BaseController()
        {
            //无参的构造
        }

        /// <summary>
        /// 改造一个构造函数切入点
        /// 这种方式虽然使得切入机会早，并且可以较早的构造中对业务层注入一些用户信息。
        /// 但是缺点就是每次都要动态反射(因为每次来的HttpContext请求都不相同）
        /// </summary>
        /// <param name="requestContext"></param>
        public BaseController(System.Web.Routing.RequestContext requestContext)
        {
            this.OnInit(requestContext);  //这样可以在构造的时候就切入了
        }

        /// <summary>
        /// 比较早的切入点 在ControllerFactory被创建的时候顺便就实现权限验证
        /// </summary>
        /// <param name="requestContext"></param>
        public virtual void OnInit(System.Web.Routing.RequestContext requestContext)
        {
            //这里实现用户信息的相关验证业务
            if (requestContext.HttpContext.Session["UserState"] != null)
            {
                UserState userState = requestContext.HttpContext.Session["UserState"] as UserState;
                //string passCode = requestContext.HttpContext.Request.Cookies["UserState"].Value.Trim();

                string controllerName = requestContext.RouteData.Values["controller"].ToString() + "Controller";
                string actionName = requestContext.RouteData.Values["action"].ToString();

                //判断有没有Action操作权限
                //userState.AuthCollection.Contains(controllerName + "/" + acitonName);
            }
            else
            {
                //非登录用户跳转
                //requestContext.HttpContext.Response.Redirect("/html/complex.html");
                requestContext.HttpContext.Response.Redirect("/Pages/Login");
            }
        }

        /// <summary>
        /// 比较晚的切入点 IController在执行Execute之后，Action被执行之前使用的
        /// </summary>
        public virtual void OnInit()
        {
            //这里实现用户信息的相关验证业务
            if (this.HttpContext.Session["UserState"] != null)
            {
                UserState userState = this.HttpContext.Session["UserState"] as UserState;
                string passCode = this.HttpContext.Request.Cookies["UserState"].Value.Trim();

                string controllerName = this.RouteData.Values["controller"].ToString() + "Controller";
                string actionName = this.RouteData.Values["action"].ToString();

                //实现Action操作权限验证业务
                //userState.AuthCollection.Contains(controllerName + "/" + acitonName);
            }
            else
            {
                //非登录用户跳转
                //requestContext.HttpContext.Response.Redirect("/html/complex.html");
                RedirectToAction("login", "pages");
            }
        }

        protected override void Execute(System.Web.Routing.RequestContext requestContext)
        {
            base.Execute(requestContext);
            //this.OnInit();//---------------------------------------------切入点
        }

        protected override void ExecuteCore()
        {
            base.ExecuteCore();
            //this.OnInit();//---------------------------------------------切入点
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.OnInit(requestContext);  //---------------------------------------------切入点 
        }

        //除上述的方式以下方式 
        //我们还可以使用IActionFilter, IAuthorizationFilter标签属性的方式实现权限验证 （这个不在本次讨研究范围内)
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //this.OnInit();//---------------------------------------------切入点
        }

        protected override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            //this.OnInit();//---------------------------------------------切入点
        }
    }
}