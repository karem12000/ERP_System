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
        private readonly UnitBll _unitBll;
        private readonly ItemGrpoupBll _groupBll;
        private readonly ProductBll _productBll;

        public AccountController(UserBll userBll, SettingBll settingBll, UnitBll unitBll, ItemGrpoupBll groupBll, ProductBll productBll)
        {
            _userBll = userBll;
            _settingBll = settingBll;
            _unitBll = unitBll;
            _groupBll = groupBll;
            _productBll = productBll;
        }
        public IActionResult Login()
        {

            // HttpContext.Response.Redirect("/Account/Index");

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangePassword() => View();

        [HttpPost]
        public IActionResult LogIn(LogInDTO mdl, string returnUrl)
        {
            var user = new UserDTO();


            if (ModelState.IsValid)
            {
                user = _userBll.LogInWeb(mdl);
                var setting = _settingBll.GetSettingWithDto();
                if (_userBll.ReadFromFile(setting , user))
                {
                    if (user != null)
                    {
                        HttpContext.Response.Cookies.AppendCookie(AppConstants._UserIdCookie, user.ID.ToString(), true);

                        if (user.ScreenId != Guid.Empty && !string.IsNullOrEmpty(user.AreaName) && !string.IsNullOrEmpty(user.ControllerName))
                        {
                            var route = $"/{user.AreaName}/{user.ControllerName}/Index";
                            return Redirect(route);
                        }
                        else
                        {
                            return Redirect("~/Home/Index");
                        }
                    }
                    else
                    {
                        ViewBag.Status = 0;
                    }
                }
                else
                {
                    ViewBag.Status = 500;
                }
            }
            else
            {
                ViewBag.Status = 0;
            }
            return View(user);

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
            return Ok(data);
            //if (data.Status)
            //{
            //    return StatusCode(AppConstants.StatusCodes.Success, data);
            //}


            //return StatusCode(AppConstants.StatusCodes.Error, data);
        }
        [HttpPost, AllowAnonymous]
        public IActionResult ForgetPassword(UserForgetPasswordParameters para)
        {
            //ResultDTO result = new ResultDTO();

            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Select(x => x.Value.Errors)
            //              .Where(y => y.Count > 0)
            //              .ToList();
            //    result.Message = AppConstants.Messages.EnterRequiredFields;
            //    return StatusCode(AppConstants.StatusCodes.Error, result);

            //}
            var data = _userBll.ForgetPassword(para);
            return Ok(data);
            //if (data.data != null)
            //{

            //    return StatusCode(AppConstants.StatusCodes.Success, data);

            //}


            //return StatusCode(AppConstants.StatusCodes.Error, data);
        }

        #endregion
    }

}
