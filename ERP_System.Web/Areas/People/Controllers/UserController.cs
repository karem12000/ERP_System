﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.Common;
using ERP_System.Common.General;
using ERP_System.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP_System.Web.Areas.People.Controllers
{
    public class UserController : Controller
    {
        #region Fields

        private readonly UserBll _userBll;
        private readonly PageBll _pageBll;
        private readonly UserTypeBll _userTypeBll;  
        private readonly StockBll _stockBll;  

        public UserController(UserBll userBll, PageBll pageBll, UserTypeBll userTypeBll, StockBll stockBll)
        {
            _userBll = userBll;
            _userTypeBll = userTypeBll;
            _stockBll = stockBll;
            _pageBll    = pageBll;
        }
        #endregion

        #region Actions
       
        public IActionResult Index(UserClassification userClassification)
        {

            return View();
        }

        public IActionResult Add()
        {
            ViewData["UserTypes"] = _userTypeBll.GetSelect();
            ViewData["Stocks"] = _stockBll.GetSelect();
            ViewData["Pages"] = _pageBll.GetSelect();
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            ViewData["UserTypes"] = _userTypeBll.GetSelect();
            ViewData["Stocks"] = _stockBll.GetSelect();
            ViewData["Pages"] = _pageBll.GetSelect();
            var item = _userBll.GetById(id);
            if (item != null)
            {
                return View(item);
            }
            else
                return Redirect("/People/User/Index");
        }
        public IActionResult Permissions()
        {
            return View();
        }
        public IActionResult Save(UserDTO mdl)
        {
            return Ok(_userBll.Save(mdl));
        }
        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_userBll.Delete(id));
        [HttpPost]
        public IActionResult ChangeStatus(Guid id) => Ok(_userBll.ChangeStatus(id));

        [HttpPost]
        public IActionResult ResetPassword(Guid id) => Ok(_userBll.ResetPassword(id));


        #endregion
        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_userBll.LoadData(mdl));

        #endregion
    }
}
