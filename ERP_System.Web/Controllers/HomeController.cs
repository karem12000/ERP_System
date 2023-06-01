
using ERP_System.BLL;
using ERP_System.DTO;
using ERP_System.Tables;
using ERP_System.Web;
using ERP_System.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ERP.Web.Controllers
{
    public class HomeController : ParentController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserBll _userBll;


        public HomeController(ILogger<HomeController> logger,UserBll userBll)
        {
            _logger = logger;
            _userBll = userBll;
        }

        public IActionResult Index()
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