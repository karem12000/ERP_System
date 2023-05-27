using ERP_System;
using ERP_System.BLL;

using Microsoft.AspNetCore.Mvc;

namespace ERP_System.Web.Compnents
{
    [ViewComponent(Name = nameof(UserDetailsLi))]
    public class UserDetailsLi : ViewComponent
    {
        private readonly UserBll _userBll;

        public UserDetailsLi(UserBll userBll) => _userBll = userBll;

        public IViewComponentResult Invoke() => View("Index", _userBll.GetById(HttpContext.UserId()));

    }
}
