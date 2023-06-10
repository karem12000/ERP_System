using System;
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
    public class SupplierController : Controller
    {
        #region Fields

        private readonly SupplierBll _SupplierBll;


        public SupplierController(SupplierBll SupplierBll)
        {
            _SupplierBll = SupplierBll;
        }
        #endregion

        #region Actions
       
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
            var item = _SupplierBll.GetById(id);
            if (item != null)
            {

                return View(item);
            }
            else
                return Redirect("/People/Supplier/Index");
        }

        public IActionResult Save(SupplierDTO mdl)
        {
           return Ok(_SupplierBll.Save(mdl));
        }

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_SupplierBll.Delete(id));
       

       
        #endregion
        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_SupplierBll.LoadData(mdl));

        #endregion
    }
}
