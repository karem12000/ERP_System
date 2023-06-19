using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class PurchaseInvoiceController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PurchaseInvoiceBll _invoiceBll;
        private readonly StockBll _stockBll;
        private readonly SupplierBll _supplierBll;
        private readonly UnitBll _unitBll;
        private readonly ProductBll _productBll;
        public PurchaseInvoiceController(IHttpContextAccessor httpContextAccessor, SupplierBll supplierBll, ProductBll productBll, StockBll stockBll , UnitBll unitBll , PurchaseInvoiceBll invoiceBll)
        {
            _httpContextAccessor= httpContextAccessor;
            _stockBll= stockBll;
            _unitBll = unitBll;
            _invoiceBll= invoiceBll;
            _productBll = productBll;
            _supplierBll = supplierBll;
        }
        public IActionResult Index(bool previous=false)
        {
            if(previous)
                return View();
            else
            return Redirect("/Guide/PurchaseInvoice/Add");
        }
        public IActionResult Add()
        {
            var userId = _httpContextAccessor.UserId();
            ViewData["Stocks"] = _stockBll.GetStocksSelectByUserId(userId);
            ViewData["Suppliers"] = _supplierBll.GetSelect();
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var userId = _httpContextAccessor.UserId();
            var invoice = _invoiceBll.GetById(id);
            ViewData["Stocks"] = _stockBll.GetStocksSelectByUserId(userId);
            ViewData["Suppliers"] = _supplierBll.GetSelect();
            if (invoice != null)
            {

                return View(invoice);
            }
            else
                return Redirect("/Guide/PurchaseInvoice/Index");
        }


        public IActionResult Save(PurchaseInvoiceDTO mdl) => Ok(_invoiceBll.Save(mdl));
        public IActionResult GetProductByBarCode(string text) => Ok(_productBll.GetByProductBarCode(text));
        public IActionResult GetProductByName(string text) => Ok(_productBll.GetByProductName(text));
        public IActionResult GetProductDataByUnitId(Guid? productId, Guid? unitId) => Ok(_productBll.GetProductDataByUnitId(productId, unitId));
        public IActionResult GetSupplierById(Guid supplierId) => Ok(_supplierBll.GetById(supplierId));

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_invoiceBll.Delete(id));

        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_invoiceBll.LoadData(mdl));

        #endregion
    }
}
