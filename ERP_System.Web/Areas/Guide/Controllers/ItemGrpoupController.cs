﻿using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class ItemGrpoupController : Controller
    {
        private readonly ItemGrpoupBll _itemGrpoupBll;
        public ItemGrpoupController(ItemGrpoupBll itemGrpoupBll)
        {
            _itemGrpoupBll = itemGrpoupBll;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Add()
        {

            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var item = _itemGrpoupBll.GetById(id);
            if (item != null)
            {
                
                return View(item);
            }
            else
                return Redirect("/Guide/ItemGrpoup/Index");
        }

        public IActionResult Save(ItemGroupDTO mdl) => Ok(_itemGrpoupBll.Save(mdl));

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_itemGrpoupBll.Delete(id));



        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_itemGrpoupBll.LoadData(mdl));

        #endregion
    }
}
