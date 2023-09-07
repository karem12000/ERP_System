using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.Common;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                    var ActivationData = GetMacAddress();
                    ViewBag.MacAddress = ActivationData.Address.Replace("key:",string.Empty);
                    ViewBag.Duration = ActivationData.Duration.Replace("Du:", string.Empty);
                }
            }
            return View(setting);
        }


        public IActionResult Save(SettingDTO mdl) => Ok(_settingBll.Save(mdl));

        private ActivationData GetMacAddress()
        {
            var basePath = _webRoot.WebRootPath + AppConstants.MacAddressPath;
            var address = "";
            var Du = "";
            var Data = new List<string>();
            var ActivationData = new ActivationData();
            ActivationData.Address = "";
            ActivationData.Duration = "";
            if (System.IO.File.Exists(basePath))
            {
                using (StreamReader sr = new StreamReader(basePath))
                {
                  var AllData =  System.IO.File.ReadAllLines(basePath);
                    if(AllData != null)
                    {
                        foreach (var line in AllData)
                        {
                            Data.Add(line);
                        }
                        address = Data.Where(x => x.StartsWith("key:")).FirstOrDefault();
                        Du = Data.Where(x => x.StartsWith("Du:")).FirstOrDefault();
                        ActivationData.Address = address??"";
                        ActivationData.Duration = Du??"";
                    }
                }
            }
           
           return ActivationData;
           
        }
    }
   
}
