
using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.DTO;
using ERP_System.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ERP_System.Web.Components
{

    [ViewComponent(Name = "AsideBar")]
    public class AsideBar : ViewComponent
    {
        private readonly PageBll _pageBll;
        private readonly UserBll _userBll;
        private readonly SettingBll _settingBll;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AsideBar(PageBll pageBll, SettingBll settingBll, UserBll userBll, IHttpContextAccessor httpContextAccessor) {
            _settingBll = settingBll;
            _pageBll = pageBll;
            _httpContextAccessor = httpContextAccessor;
            _userBll= userBll;
        }

        // _UserBll.GetAllowedUserAppForms()
        public IViewComponentResult Invoke()
        {
            var sideBarPages = _pageBll.GetAsideBarPages();
            var setting  = _settingBll.GetSetting();
            var userID = _httpContextAccessor.UserId();
            var userData = _userBll.GetById(userID);
            if (setting == null)
            {
                setting = new Setting();
                setting.SiteName = "نظام المحاسبه ";
                setting.Logo = "";
            }
            var Data = new SideBarPagesLogoDto();
            Data.AsideBarPagesDTO = sideBarPages;
            Data.Setting = setting;
            Data.UserData = userData;

            return View("Index", Data);
        }
    }
}
