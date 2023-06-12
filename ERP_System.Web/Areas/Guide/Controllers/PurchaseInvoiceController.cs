using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class PurchaseInvoiceController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PurchaseInvoiceBll _invoiceBll;
        private readonly StockBll _stockBll;
        private readonly UnitBll _unitBll;
        private readonly ProductBll _productBll;
        public PurchaseInvoiceController(IHttpContextAccessor httpContextAccessor, ProductBll productBll, StockBll stockBll , UnitBll unitBll , PurchaseInvoiceBll invoiceBll)
        {
            _httpContextAccessor= httpContextAccessor;
            _stockBll= stockBll;
            _unitBll = unitBll;
            _invoiceBll= invoiceBll;
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


        public IActionResult Save(InvoiceDTO mdl) => Ok(_invoiceBll.Save(mdl));
        public IActionResult GetProductByBarCode(string text) => Ok(_productBll.GetByProductBarCode(text));
        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_invoiceBll.LoadData(mdl));

        #endregion
    }
}
