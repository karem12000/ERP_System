﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.Common;
using ERP_System.Common.General;
using ERP_System.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP_System.Web.Areas.People.Controllers
{
    public class ClientController : Controller
    {
        #region Fields

        private readonly UserBll _userBll;
        private readonly StockBll _stockBll;

        public ClientController(UserBll userBll , StockBll stockBll)
        {
            _userBll = userBll;
            _stockBll = stockBll;
        }
        #endregion

        #region Actions
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            //var userId = _httpContextAccessor.UserId();
            ViewData["Stocks"] = _stockBll.GetSelect();
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            ViewData["Stocks"] = _stockBll.GetSelect();
            var item = _userBll.GetById(id);
            if (item != null)
            {

                return View(item);
            }
            else
                return Redirect("/People/Client/Index");
        }

        public IActionResult Save(UserDTO mdl)
        {
            mdl.UserClassification = UserClassification.Client;
            mdl.UserTypeId = Guid.Parse(AppConstants.ClientTypeId);
           return Ok(_userBll.Save(mdl));
        }

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_userBll.Delete(id));
        [HttpPost]
        public IActionResult ChangeStatus(Guid id) => Ok(_userBll.ChangeStatus(id));

       
        #endregion
        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl , UserClassification? classification=UserClassification.Client) => JsonDataTable(_userBll.LoadData(mdl , classification));

        #endregion
    }
}
