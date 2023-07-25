using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class SaleThrowbackController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SaleThrowbackBll _invoiceBll;
        private readonly SaleInvoiceBll _saleInvoiceBll;
        private readonly StockBll _stockBll;
        private readonly UserBll _userBll;
        private readonly UnitBll _unitBll;
        private readonly ProductBll _productBll;
        public SaleThrowbackController(IHttpContextAccessor httpContextAccessor, SaleInvoiceBll saleInvoiceBll, UserBll userBll, ProductBll productBll, StockBll stockBll , UnitBll unitBll , SaleThrowbackBll invoiceBll)
        {
            _httpContextAccessor= httpContextAccessor;
            _stockBll= stockBll;
            _unitBll = unitBll;
            _invoiceBll= invoiceBll;
            _productBll = productBll;
            _userBll= userBll;
            _saleInvoiceBll= saleInvoiceBll;
        }
        public IActionResult Index(bool previous=false)
        {
            previous = true;

            if (previous)
                return View();
            else
                return Redirect("/Guide/SaleThrowback/Add");

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
            var invoice = _invoiceBll.GetById(id);
            ViewData["DisscountPermission"] = _userBll.GetById(userId).DiscountPermission;
			ViewData["SalePriceEditPermission"] = _userBll.GetById(userId).SalePriceEdit;
			ViewData["Stocks"] = _stockBll.GetStocksSelectByUserId(userId);

            if (invoice != null)
            {

                return View(invoice);
            }
            else
                return Redirect("/Guide/SaleThrowback/Index?previous=true");
        }


        public IActionResult Save(SaleThrowbackDTO mdl) => Ok(_invoiceBll.Save(mdl));
        public IActionResult SearchByProductName(string term) => Ok(_productBll.SearchByName(term));
        public IActionResult GetProductByBarCode(string text) => Ok(_productBll.GetByProductBarCode(text));
        public IActionResult GetProductByBarCodeAndInvoiceId(string text , Guid? saleInvoiceId) => Ok(_saleInvoiceBll.GetProductByBarCodeAndInvoiceId(text, saleInvoiceId));
        public IActionResult GetSaleInvoiceDetail(int? invoiceNumber , DateTime? invoiceDate) => Ok(_saleInvoiceBll.GetByInvoiceNumberAndDate(invoiceNumber , invoiceDate));
        public IActionResult GetLastInvoiceNumberByDate(DateTime? date) => Ok(_invoiceBll.GetLastInvoiceNumberByDate(date));
        public IActionResult GetProductByName(string text) => Ok(_productBll.GetByProductName(text));
        public IActionResult GetProductDataByUnitId(Guid? productId, Guid? unitId) => Ok(_productBll.GetProductDataByUnitId(productId, unitId));


        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_invoiceBll.Delete(id));

        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_invoiceBll.LoadData(mdl));

        #endregion
    }
}
