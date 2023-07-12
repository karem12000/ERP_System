
using ERP_System.BLL;
using Microsoft.AspNetCore.Mvc;


namespace ERP_System.Web.Components
{

    [ViewComponent(Name = "AsideBar")]
    public class AsideBar : ViewComponent
    {
        private readonly PageBll _pageBll;

        public AsideBar(PageBll pageBll) => _pageBll = pageBll;

     
        public IViewComponentResult Invoke() => View("Index", _pageBll.GetAsideBarPages2());
        //public IViewComponentResult Invoke() => View("Index", _pageBll.GetAsideBarPages());
    }
}
