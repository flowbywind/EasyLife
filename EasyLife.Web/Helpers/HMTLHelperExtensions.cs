using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace EasyLife.Web
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            string cssClass = "active";
            string currentAction = ((string)html.ViewContext.RouteData.Values["action"]).ToLower();
            string currentController = ((string)html.ViewContext.RouteData.Values["controller"]).ToLower();
            string[] arr = null;

            if (String.IsNullOrEmpty(controller))
                controller = currentController;
            else
            {
                arr = controller.ToLower().Split('|');
            }

            if (String.IsNullOrEmpty(action))
                action = currentAction.ToLower();

            return (controller == currentController || arr.Contains(currentController)) && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

    }
}
