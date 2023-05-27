using System;
using System.Collections.Generic;
using ERP_System.BLL;
using ERP_System.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP_System.Web.Areas.People.Controllers
{
    public class PermissionsController : Controller
    {
        #region Fields

        private readonly UserBll _userBll;
        private readonly UserTypeBll _userTypeBll;  

        public PermissionsController(UserBll userBll,  UserTypeBll userTypeBll)
        {
            _userBll = userBll;
            _userTypeBll = userTypeBll;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            ViewData["UserTypeId"] = _userTypeBll.GetSelect();

            //ViewBag.UserTypeId = new SelectList(_userTypeBll.GetSelect(), "Value", "Text");


            return View();
        }
   
        public IActionResult Save(UserDTO mdl) => Ok( _userBll.Save(mdl));

        #endregion
        #region Helpers
        public IActionResult ShowUserPermission(Guid userTypeId) => PartialView("_Permissions", _userBll.GetUserPermissions(userTypeId));
        [HttpPost]
        public IActionResult SaveUserPermission(Guid userTypeId, IEnumerable<UserPermissionsSaveDTO> mdl) => Ok(_userBll.SaveUserPermission(userTypeId, mdl));

        #endregion
    }
}
