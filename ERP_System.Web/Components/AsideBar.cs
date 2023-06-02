
using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

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
            _pageBll = pageBll;
            _settingBll = settingBll;
            _httpContextAccessor = httpContextAccessor;
            _userBll= userBll;
        }

        // _UserBll.GetAllowedUserAppForms()
        public IViewComponentResult Invoke(UserDTO user) {
            var userId = _httpContextAccessor.UserId();
            SideBarPagesLogoDto myModel = new SideBarPagesLogoDto();
            myModel.AsideBarPagesDTO= _pageBll.GetAsideBarPages();
            var setting = _settingBll.GetSetting();
            if (setting==null)
            {
                setting.Logo = "";
            }
            myModel.Setting = setting;
            myModel.UserData = user;
            return View("Index", myModel); 
        }
    }
}
