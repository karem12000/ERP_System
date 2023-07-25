using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.BLL.Report;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static ERP_System.BLL.HelperBll;

namespace ERP_System.Web.Areas.Report.Controllers
{
    public class ReportController : Controller
    {
        private readonly SaleReportBll _saleReportBll;
        private readonly PurchaseReportBll _purchaseReportBll;
        private readonly SettingBll _settingBll;
        private readonly ProductReportBll _productReport;
        private readonly SupplierReportBll _supplierReport;
        private readonly StockBll _stockBll;
        private readonly UserBll _userBll;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportController(SaleReportBll saleReportBll , UserBll userBll, PurchaseReportBll purchaseReportBll, SupplierReportBll supplierReport, StockBll stockBll, ProductReportBll productReport, SettingBll settingBll, IWebHostEnvironment webHostEnvironment)
        {
            _saleReportBll = saleReportBll;
			_productReport = productReport;
            _webHostEnvironment = webHostEnvironment;
			_supplierReport = supplierReport;
            _settingBll = settingBll;
			_userBll = userBll;
			_stockBll = stockBll;
			_purchaseReportBll = purchaseReportBll;
			//System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
		}
        public IActionResult Index()
        {
			var userId = HttpContext.UserId();
			ViewData["Stocks"] = _stockBll.GetStocksSelectByUserId(userId);
			ViewData["Cashers"] = _userBll.GetAllCasher();
			//return Redirect("/Report/Report/GetProductQtyReport");
			//return Redirect("/Report/Report/GetProductPriceReport");
			return View();
		}
		//public IActionResult GetProductQtyReport(Guid? StockId, Guid? ProductId)
		//{
		//	//var companyData = _settingBll.GetSetting();
		//	var data = _productReport.ProductsQty(StockId, ProductId);
		//	if (data != null)
		//	{
		//		ListtoDataTableConverter converter = new ListtoDataTableConverter();
		//		DataTable dt = converter.ToDataTable(data);
		//		string mimType = "";
		//		int extension = 1;
		//		var path = $"{_webHostEnvironment.WebRootPath}//Reports//ProductQtyReport.rdlc";
		//		Dictionary<string, string> parameters = new Dictionary<string, string>();
				
		//		LocalReport localReport = new LocalReport(path);
		//		localReport.AddDataSource("dsProductQty", dt);
		//		var result = localReport.Execute(RenderType.Pdf, extension, null, mimType);
		//		return File(result.MainStream, "application/pdf");
		//	}
		//	return Ok(data);
		//}

		//public IActionResult GetProductPriceReport(Guid? StockId, Guid? ProductId)
		//{
		//	//var companyData = _settingBll.GetSetting();
		//	var data = _productReport.ProductsPrice(StockId, ProductId);
		//	if (data != null)
		//	{
		//		ListtoDataTableConverter converter = new ListtoDataTableConverter();
		//		DataTable dt = converter.ToDataTable(data);
		//		string mimType = "";
		//		int extension = 1;
		//		var path = $"{_webHostEnvironment.WebRootPath}//Reports//ProductPriceReport.rdlc";
		//		Dictionary<string, string> parameters = new Dictionary<string, string>();

		//		LocalReport localReport = new LocalReport(path);
		//		localReport.AddDataSource("dsProductPrice", dt);
		//		var result = localReport.Execute(RenderType.Pdf, extension, null, mimType);
		//		return File(result.MainStream, "application/pdf");
		//	}
		//	return Ok(data);
		//}
		public IActionResult GetProductData(ProductReportDataTableRequest mdl) => JsonDataTable(_productReport.GetProductReportData(mdl));
		public IActionResult GetSaleProductData(ProductReportDataTableRequest mdl) => JsonDataTable(_productReport.GetSaleProductData(mdl));
		public IActionResult GetMostProductsSale(ProductReportDataTableRequest mdl) => JsonDataTable(_productReport.GetMostProductsSale(mdl));
		public IActionResult GetMostSupplierTransaction(ProductReportDataTableRequest mdl) => JsonDataTable(_productReport.GetMostSupplierNumPurchasingReportDto(mdl));
		public IActionResult GetLeastSupplierTransaction(ProductReportDataTableRequest mdl) => JsonDataTable(_productReport.GetLeastSupplierNumPurchasingReportDto(mdl));
		public IActionResult GetLeastProductsSale(ProductReportDataTableRequest mdl) => JsonDataTable(_productReport.GetLeastProductsSale(mdl));
		public IActionResult GetProductsPrice(ProductReportDataTableRequest mdl) => JsonDataTable(_productReport.GetProductsPrice(mdl));
		public IActionResult GetProductsQty(ProductReportDataTableRequest mdl) => JsonDataTable(_productReport.GetProductsQty(mdl));


		#region Supplier
		public IActionResult GetDebtorSupplierTransaction(ProductReportDataTableRequest mdl) => JsonDataTable(_supplierReport.GetDebtorSupplierNumPurchasingReportDto(mdl));
		public IActionResult GetCreditorSupplierTransaction(ProductReportDataTableRequest mdl) => JsonDataTable(_supplierReport.GetCreditorSupplierNumPurchasingReportDto(mdl));

		#endregion
		#region SaleInvoice Reports
		public IActionResult GetSaleInvoicesReport(ProductReportDataTableRequest mdl) => JsonDataTable(_saleReportBll.GetSaleInvoicesReport(mdl));
		#endregion
		#region Sale Throwback Report
		public IActionResult GetSaleThrowbackInvoicesReport(ProductReportDataTableRequest mdl) => JsonDataTable(_saleReportBll.GetSaleThrowbackInvoicesReport(mdl));
		#endregion
		#region PurchaseInvoice Reports
		public IActionResult GetPurchaseInvoicesReport(ProductReportDataTableRequest mdl) => JsonDataTable(_purchaseReportBll.GetPurchaseInvoicesReport(mdl));
		#endregion
		#region PurchaseThrowbackInvoice Reports
		public IActionResult GetPurchaseThrowbackInvoicesReport(ProductReportDataTableRequest mdl) => JsonDataTable(_purchaseReportBll.GetPurchaseThrowbackInvoicesReport(mdl));
		#endregion



		//public IActionResult GetSaleInvoiceReport(DateTime? FromDate , DateTime ToDate)
		//{
		//    var companyData = _settingBll.GetSetting();
		//    var data = _saleReportBll.GetAllByDate(FromDate , ToDate);
		//    if (data != null)
		//    {
		//        ListtoDataTableConverter converter = new ListtoDataTableConverter();
		//        DataTable dt = converter.ToDataTable(data);
		//        string mimType = "";
		//        int extension = 1;
		//        var path = $"{_webHostEnvironment.WebRootPath}//Reports//SaleInvoiceReport.rdlc";
		//        Dictionary<string, string> parameters = new Dictionary<string, string>();
		//        if(companyData != null)
		//        {
		//            parameters.Add("CompanyName", companyData.CompanyName);
		//            parameters.Add("CompanyAddress", companyData.CompanyAddress);
		//            parameters.Add("CompanyPhone", companyData.CompanyPhone);
		//            parameters.Add("CompanyImage", string.Concat("//SiteImages//", companyData.Logo));
		//            parameters.Add("Description", companyData.Description);
		//        }
		//        else
		//        {
		//            parameters.Add("CompanyName", "");
		//            parameters.Add("CompanyAddress","");
		//            parameters.Add("CompanyPhone", "");
		//            parameters.Add("CompanyImage", "");
		//            parameters.Add("Description","");
		//        }

		//        LocalReport localReport = new LocalReport(path);
		//        localReport.AddDataSource("dsSales", dt);
		//        var result = localReport.Execute(RenderType.Pdf, extension, null, mimType);
		//        return File(result.MainStream, "application/pdf");
		//    }
		//    return Ok(data);
		//}   


	}
}
