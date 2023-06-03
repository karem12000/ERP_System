using ERP_System;
using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.Common;
using ERP_System.DTO;
using ERP_System.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ERP_System.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserBll _userBll;
        private readonly SettingBll _settingBll;

        public AccountController(UserBll userBll , SettingBll settingBll )
        {
            _userBll = userBll;
            _settingBll = settingBll;
        }
        public IActionResult Login()
        {
            // HttpContext.Response.Redirect("/Account/Index");
            var setting = _settingBll.GetSetting();
            if (setting == null)
            {
                setting = new Setting();
                setting.Logo = "";
            }
            
            return View(setting);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangePassword() => View();

        [HttpPost]
        public IActionResult LogIn(LogInDTO mdl, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _userBll.LogInWeb(mdl);
                if (user != null)
                {
                    HttpContext.Response.Cookies.AppendCookie(AppConstants._UserIdCookie, user.ID.ToString(), true);

                    if (!returnUrl.IsEmpty())
                    {
                        return Redirect(returnUrl);
                    }
                    return Redirect("~/Home/Index");
                    //return RedirectToAction("Index", "Home", new { user = user });
                }
            }

            return View(mdl);
        }
        [HttpPost]
        public JsonResult ChangeOldPassword(ChangePasswordDTO mdl) => Json(_userBll.ChangeOldPasswordWeb(mdl));
        public IActionResult LogOff(string returnUrl)
        {
            if (Response.HttpContext.Request.Cookies.ContainsKey(AppConstants._UserIdCookie))
            {
                var uid = Guid.Parse(Response.HttpContext.Request.Cookies[AppConstants._UserIdCookie]);
                Response.Cookies.Delete(AppConstants._UserIdCookie);
            }
            return Redirect(Url.GetAction(nameof(LogIn)) + (returnUrl.IsEmpty() ? "" : "returnUrl=" + returnUrl));
        }

        public IActionResult ForgotPassword()
        {
            // HttpContext.Response.Redirect("/Account/Index");
            return View();
        }
        #region Forget Password
        [HttpPost, AllowAnonymous]
        public IActionResult SendCode(UserSendCodeParameters para)
        {
            ResultDTO result = new ResultDTO();

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
                result.Message = AppConstants.Messages.EnterRequiredFields;
                return StatusCode(AppConstants.StatusCodes.Error, result);

            }
            var data = _userBll.SendCode(para);
            if (data.data != null)
            {

                return StatusCode(AppConstants.StatusCodes.Success, data);

            }


            return StatusCode(AppConstants.StatusCodes.Error, data);
        }
        [HttpPost, AllowAnonymous]
        public IActionResult ForgetPassword(UserForgetPasswordParameters para)
        {
            ResultDTO result = new ResultDTO();

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
                result.Message = AppConstants.Messages.EnterRequiredFields;
                return StatusCode(AppConstants.StatusCodes.Error, result);

            }
            var data = _userBll.ForgetPassword(para);
            if (data.data != null)
            {

                return StatusCode(AppConstants.StatusCodes.Success, data);

            }


            return StatusCode(AppConstants.StatusCodes.Error, data);
        }

        #endregion
    }

}
