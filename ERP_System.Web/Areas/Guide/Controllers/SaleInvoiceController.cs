using ERP_System.BLL.Guide;
using ERP_System.Common.General;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class SaleInvoiceController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SaleInvoiceBll _invoiceBll;
        private readonly StockBll _stockBll;
        private readonly UnitBll _unitBll;
        private readonly ProductBll _productBll;
        public SaleInvoiceController(IHttpContextAccessor httpContextAccessor, ProductBll productBll, StockBll stockBll, UnitBll unitBll, SaleInvoiceBll invoiceBll)
        {
            _httpContextAccessor = httpContextAccessor;
            _stockBll = stockBll;
            _unitBll = unitBll;
            _invoiceBll = invoiceBll;
            _productBll = productBll;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            var userId = _httpContextAccessor.UserId();
            ViewData["Stocks"] = _stockBll.GetStocksSelectByUserId(userId);
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var userId = _httpContextAccessor.UserId();
            var invoice = _invoiceBll.GetById(id);
            ViewData["Stocks"] = _stockBll.GetStocksSelectByUserId(userId);

            if (invoice != null)
            {

                return View(invoice);
            }
            else
                return Redirect("/Guide/SaleInvoice/Index");
        }


        public IActionResult Save(SaleInvoiceDTO mdl) => Ok(_invoiceBll.Save(mdl));
        public IActionResult GetProductByBarCode(string text) => Ok(_productBll.GetByProductBarCode(text));

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_invoiceBll.Delete(id));

        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_invoiceBll.LoadData(mdl));

        #endregion
    }
}
