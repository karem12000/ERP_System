using ERP_System.BLL;
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
        private readonly SaleThrowbackBll _ThrowbackinvoiceBll;
        private readonly StockBll _stockBll;
        private readonly UnitBll _unitBll;
        private readonly UserBll _userBll;
        private readonly ProductBll _productBll;
        public SaleInvoiceController(IHttpContextAccessor httpContextAccessor, UserBll userBll, SaleThrowbackBll ThrowbackinvoiceBll, ProductBll productBll, StockBll stockBll, UnitBll unitBll, SaleInvoiceBll invoiceBll)
        {
            _httpContextAccessor = httpContextAccessor;
            _stockBll = stockBll;
            _unitBll = unitBll;
            _invoiceBll = invoiceBll;
            _productBll = productBll;
            _ThrowbackinvoiceBll = ThrowbackinvoiceBll;
            _userBll = userBll;
        }
        public IActionResult Index(bool previous = false)
        {
            previous = true;
            if (previous)
                return View();
            else
            return Redirect("/Guide/SaleInvoice/Add");
        }
        public IActionResult Add()
        {
            var userId = _httpContextAccessor.UserId();
            ViewData["DisscountPermission"] = _userBll.GetById(userId).DiscountPermission;
            ViewData["SalePriceEditPermission"] = _userBll.GetById(userId).SalePriceEdit;
            ViewData["Stocks"] = _stockBll.GetStocksSelectByUserId(userId);
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var userId = _httpContextAccessor.UserId();
            ViewData["DisscountPermission"] = _userBll.GetById(userId).DiscountPermission;
            ViewData["SalePriceEditPermission"] = _userBll.GetById(userId).SalePriceEdit;
            var invoice = _invoiceBll.GetById(id);
            ViewData["Stocks"] = _stockBll.GetStocksSelectByUserId(userId);

            if (invoice != null)
            {

                return View(invoice);
            }
            else
                return Redirect("/Guide/SaleInvoice/Index?previous=true");
        }


        public IActionResult Save(SaleInvoiceDTO mdl) => Ok(_invoiceBll.Save(mdl));
        public IActionResult SearchByProductName(string term) => Ok(_productBll.SearchByName(term));
        public IActionResult GetInvoiceToPrint(Guid? invoiceId) => Ok(_invoiceBll.GetInvoiceToPrint(invoiceId));
        public IActionResult GetByProductBarCodeAndStockId(string text , Guid stockId) => Ok(_productBll.GetByProductBarCodeAndStockId(text , stockId));
        //public IActionResult GetProductByBarCode(string text , Guid stockId) => Ok(_productBll.GetByProductBarCode(text));
		public IActionResult GetLastInvoiceNumberByDate(DateTime? date) => Ok(_invoiceBll.GetLastInvoiceNumberByDate(date));
        public IActionResult GetLastThrowbackInvoiceNumberByDate(DateTime? date) => Ok(_ThrowbackinvoiceBll.GetLastInvoiceNumberByDate(date));
		[HttpPost]
		public IActionResult GetCahierMoney()
        {
            var userId = _httpContextAccessor.UserId();
            var date = DateTime.Now.Date;
           return Ok(_invoiceBll.GetCahierMoney(userId , date));
        }
        public IActionResult GetByProductNameAndStockId(string text,Guid stockId) => Ok(_productBll.GetByProductNameAndStockId(text , stockId));
        //public IActionResult GetProductByName(string text) => Ok(_productBll.GetByProductName(text));
        public IActionResult GetProductDataByUnitId(Guid? productId, Guid? unitId) => Ok(_productBll.GetProductDataByUnitId(productId,unitId));

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_invoiceBll.Delete(id));

        #region Throwback
        public IActionResult SaveThrowback(SaleThrowbackDTO mdl) => Ok(_ThrowbackinvoiceBll.Save(mdl));

        [HttpPost]
        public IActionResult DeleteThrowback(Guid id) => Ok(_ThrowbackinvoiceBll.Delete(id));
        #endregion

        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) {
            var userId = HttpContext.UserId();
            mdl.UserID = userId;
           return JsonDataTable(_invoiceBll.LoadData(mdl)); 
        }

        #endregion
    }
}
