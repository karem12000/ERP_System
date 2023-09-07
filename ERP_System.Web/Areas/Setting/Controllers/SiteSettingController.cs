using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.Common;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace ERP_System.Web.Areas.Setting.Controllers
{
    public class SiteSettingController : Controller
    {
        private readonly SettingBll _settingBll;
        private readonly UserBll _userBll;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IWebHostEnvironment _webRoot;
        public SiteSettingController(SettingBll settingBll, IWebHostEnvironment webRoot, UserBll userBll, IHttpContextAccessor HttpContextAccessor)
        {
            _settingBll = settingBll;
            _HttpContextAccessor = HttpContextAccessor;
            _webRoot = webRoot;
            _userBll = userBll;
        }
        public IActionResult Index()
        {
            var setting = _settingBll.GetSettingWithDto();
            var userType = _userBll.GetById(_HttpContextAccessor.UserId());
            if (setting == null)
            {
                setting = new SettingDTO();
            }
            if (userType != null)
            {
                if ((int)userType.UserClassification == 1)
                {
                    ViewBag.UserClassification = 1;
                    ViewBag.MacAddress = GetMacAddress();
                }
            }
            return View(setting);
        }


        public IActionResult Save(SettingDTO mdl) => Ok(_settingBll.Save(mdl));

        private string GetMacAddress()
        {
            var basePath = _webRoot.WebRootPath + AppConstants.MacAddressPath;
            using(StreamReader sr = new StreamReader(basePath))
            {
                return sr.ReadLine();
            }
        }
    }
}
