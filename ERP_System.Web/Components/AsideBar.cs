
using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ERP_System.Web.Components
{

    [ViewComponent(Name = "AsideBar")]
    public class AsideBar : ViewComponent
    {
        private readonly PageBll _pageBll;
        private readonly SettingBll _settingBll;

        public AsideBar(PageBll pageBll, SettingBll settingBll) { 
            _pageBll = pageBll;
            _settingBll = settingBll;
        }

        // _UserBll.GetAllowedUserAppForms()
        public IViewComponentResult Invoke() {
            SideBarPagesLogoDto myModel = new SideBarPagesLogoDto();
            myModel.AsideBarPagesDTO= _pageBll.GetAsideBarPages();
            var setting = _settingBll.GetSetting();
            if (setting==null)
            {
                setting.Logo = "";
            }
            myModel.Setting = setting;

            return View("Index", myModel); 
        }
    }
}
