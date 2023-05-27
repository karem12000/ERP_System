using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_System.BLL;
using ERP_System.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP_System.Web.Areas.People.Controllers
{
    public class UserController : Controller
    {
        #region Fields

        private readonly UserBll _userBll;
        private readonly UserTypeBll _userTypeBll;  

        public UserController(UserBll userBll, UserTypeBll userTypeBll)
        {
            _userBll = userBll;
            _userTypeBll = userTypeBll;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            
            ViewData["UserTypes"] = _userTypeBll.GetSelect();
           


            return View();
        }
        public IActionResult Permissions()
        {
            return View();
        }
        public IActionResult Save(UserDTO mdl) => Ok( _userBll.Save(mdl));
        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_userBll.Delete(id));
        [HttpPost]
        public IActionResult ChangeStatus(Guid id) => Ok(_userBll.ChangeStatus(id));

        [HttpPost]
        public IActionResult ResetPassword(Guid id) => Ok(_userBll.ResetPassword(id));

        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_userBll.LoadData(mdl));

        #endregion

    }
}
