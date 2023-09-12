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
        private readonly PurchaseThrowbackBll _ThrowbackBll;
        private readonly StockBll _stockBll;
        private readonly SupplierBll _supplierBll;
        private readonly UnitBll _unitBll;
        private readonly ProductBll _productBll;
        public PurchaseInvoiceController(IHttpContextAccessor httpContextAccessor, PurchaseThrowbackBll ThrowbackBll, SupplierBll supplierBll, ProductBll productBll, StockBll stockBll , UnitBll unitBll , PurchaseInvoiceBll invoiceBll)
        {
            _httpContextAccessor= httpContextAccessor;
            _stockBll= stockBll;
            _unitBll = unitBll;
            _invoiceBll= invoiceBll;
            _productBll = productBll;
            _supplierBll = supplierBll;
            _ThrowbackBll= ThrowbackBll;
        }
        public IActionResult Index(bool previous=false)
        {
            previous = true;

            if (previous)
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
                return Redirect("/Guide/PurchaseInvoice/Index?previous=true");
        }


        public IActionResult Save(PurchaseInvoiceDTO mdl) => Ok(_invoiceBll.Save(mdl));
        public IActionResult SearchByProductName(string term) => Ok(_productBll.SearchByName(term));
        public IActionResult GetProductsNames() => Ok(_productBll.GetProductsNames());
        public IActionResult GetProductByBarCode(string text ,Guid stockId) => Ok(_productBll.GetByProductBarCodeAndStockId(text , stockId));
        public IActionResult GetInvoiceToPrint(Guid? invoiceId) => Ok(_invoiceBll.GetInvoiceToPrint(invoiceId));

        //public IActionResult GetProductByBarCode(string text) => Ok(_productBll.GetByProductBarCode(text));
        public IActionResult GetProductByName(string text, Guid stockId) => Ok(_productBll.GetByProductNameAndStockId(text , stockId));
        //public IActionResult GetProductByName(string text) => Ok(_productBll.GetByProductName(text));
        public IActionResult GetLastInvoiceNumberByDate(DateTime? date) => Ok(_invoiceBll.GetLastInvoiceNumberByDate(date));
		public IActionResult GetLastThrowbackInvoiceNumberByDate(DateTime? date) => Ok(_ThrowbackBll.GetLastInvoiceNumberByDate(date));
		public IActionResult GetProductDataByUnitId(Guid? productId, Guid? unitId) => Ok(_productBll.GetProductDataByUnitId(productId, unitId));
        public IActionResult GetSupplierById(Guid supplierId) => Ok(_supplierBll.GetById(supplierId));
        public IActionResult GetSuppliersSelect() => Ok(_supplierBll.GetSelect());

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_invoiceBll.Delete(id));

        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl)
        {
            var userId = HttpContext.UserId();
            mdl.UserID = userId;
            return JsonDataTable(_invoiceBll.LoadData(mdl));
        }

        #endregion
    }
}
