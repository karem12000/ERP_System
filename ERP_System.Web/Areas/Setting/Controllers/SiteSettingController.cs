using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Setting.Controllers
{
    public class SiteSettingController : Controller
    {
        private readonly SettingBll _settingBll;
        public SiteSettingController(SettingBll settingBll)
        {
            _settingBll = settingBll;
        }
        public IActionResult Index()
        {
            var setting = _settingBll.GetSetting();
            if (setting == null)
            {
                setting = new Tables.Setting();
            }
            return View(setting);
        }

        
        public IActionResult Save(SettingDTO mdl) => Ok(_settingBll.Save(mdl));

       
    }
}
