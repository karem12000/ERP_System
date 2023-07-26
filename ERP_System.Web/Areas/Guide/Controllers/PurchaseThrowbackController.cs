using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class PurchaseThrowbackController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PurchaseThrowbackBll _invoiceBll;
        private readonly PurchaseInvoiceBll _PinvoiceBll;
        private readonly StockBll _stockBll;
        private readonly UnitBll _unitBll;
        private readonly ProductBll _productBll;
        private readonly SupplierBll _supplierBll;
        public PurchaseThrowbackController(IHttpContextAccessor httpContextAccessor, PurchaseInvoiceBll PinvoiceBll, SupplierBll supplierBll, ProductBll productBll, StockBll stockBll , UnitBll unitBll , PurchaseThrowbackBll invoiceBll)
        {
            _httpContextAccessor= httpContextAccessor;
            _stockBll= stockBll;
            _unitBll = unitBll;
            _invoiceBll= invoiceBll;
            _productBll = productBll;
            _supplierBll = supplierBll;
            _PinvoiceBll = PinvoiceBll;
        }
        public IActionResult Index(bool previous=false)
        {
            previous = true;

            if (previous)
                return View();
            else
                return Redirect("/Guide/PurchaseThrowback/Add");
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
                return Redirect("/Guide/PurchaseThrowback/Index?previous=true");
        }


        public IActionResult Save(PurchaseThrowbackDTO mdl) => Ok(_invoiceBll.Save(mdl));
        public IActionResult SearchByProductName(string term) => Ok(_productBll.SearchByName(term));
        public IActionResult GetProductByBarCode(string text) => Ok(_productBll.GetByProductBarCode(text));
		public IActionResult GetProductByBarCodeAndInvoiceId(string text, Guid? purchaseInvoiceId) => Ok(_PinvoiceBll.GetProductByBarCodeAndInvoiceId(text, purchaseInvoiceId));
		public IActionResult GetPurchaseInvoiceDetail(int? invoiceNumber, DateTime? invoiceDate) => Ok(_PinvoiceBll.GetByInvoiceNumberAndDate(invoiceNumber, invoiceDate));
        public IActionResult GetProductByName(string text) => Ok(_productBll.GetByProductName(text));
        public IActionResult GetLastInvoiceNumberByDate(DateTime? date) => Ok(_invoiceBll.GetLastInvoiceNumberByDate(date));
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
