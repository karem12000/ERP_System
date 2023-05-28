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
        public readonly HelperBll _helperBll;

        public PermissionsController(HelperBll helperBll ,UserBll userBll,  UserTypeBll userTypeBll)
        {
            _userBll = userBll;
            _helperBll = helperBll;
            _userTypeBll = userTypeBll;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            //_helperBll.GenerateBarcode("2AC545VF", "\\BarCodes\\");

            ViewData["UserTypeId"] = _userTypeBll.GetSelect();

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
