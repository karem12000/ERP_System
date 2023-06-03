using System;
using ERP_System;
using ERP_System.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ERP_System.Web.Helper
{
    public class Authorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.UserId();
            var _userBll = context.HttpContext.RequestServices.GetService(typeof(UserBll)) as UserBll;
            var currentUser = _userBll.GetById(userId);


            if (currentUser == null)
            {

                context.Result = new RedirectResult("/Account/LogOff");
            }


        }
    }
}
