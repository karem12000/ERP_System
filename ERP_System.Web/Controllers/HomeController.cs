
using ERP_System;
using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.DTO;
using ERP_System.Tables;
using ERP_System.Web;
using ERP_System.Web.Models;
using IronBarCode;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Dynamic;

namespace ERP.Web.Controllers
{
    public class HomeController : ParentController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserBll _userBll;
        private readonly HelperBll _helperBll;
        private readonly SettingBll _settingBll;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public HomeController(ILogger<HomeController> logger, HelperBll helperBll, UserBll userBll, IHttpContextAccessor httpContextAccessor, SettingBll settingBll)
        {
            _logger = logger;
            _userBll = userBll;
            _settingBll = settingBll;
            _httpContextAccessor = httpContextAccessor;
            _helperBll = helperBll;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CompanyData()
        {
            return View();
        }
        public IActionResult ChangePassword() => View();

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult UnAuthorize() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Helpers
        [HttpPost]
        public JsonResult ChangeOldPassword(ChangePasswordDTO mdl) => Json(_userBll.ChangeOldPasswordWeb(mdl));


        #endregion
    }
}