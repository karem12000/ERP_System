using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class StockController : Controller
    {
        private readonly StockBll _stockBll;
        public StockController(StockBll stockBll)
        {
            _stockBll = stockBll;
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
            var item = _stockBll.GetById(id);
            if (item != null)
            {

                return View(item);
            }
            else
                return Redirect("/Guide/Stock/Index");
        }

        public IActionResult Save(StockDto mdl) => Ok(_stockBll.Save(mdl));

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_stockBll.Delete(id));

        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl)
        {
            var userId = HttpContext.UserId();
            mdl.UserID = userId;
            return JsonDataTable(_stockBll.LoadData(mdl));
        }
        #endregion

    }
}
