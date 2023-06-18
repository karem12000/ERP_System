using AspNetCore.Reporting;
using ERP_System.BLL.Guide;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Web.Areas.Report.Controllers
{
    public class ReportController : Controller
    {
        private readonly SaleReportBll _saleReportBll;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportController(SaleReportBll saleReportBll , IWebHostEnvironment webHostEnvironment)
        {
            _saleReportBll = saleReportBll;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            return Redirect("/Report/Report/GetSaleInvoiceReport");
        }

        
        public IActionResult GetSaleInvoiceReport(DateTime? FromDate , DateTime ToDate)
        {
            
            var data = _saleReportBll.GetAllByDate(FromDate , ToDate);
            if (data.Data != null)
            {
                string mimType = "";
                int extension = 1;
                var path = $"{_webHostEnvironment.WebRootPath}//Reports//SaleInvoiceReport.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("rp1", "Welcome");
                LocalReport localReport = new LocalReport(path);
                var result = localReport.Execute(RenderType.Pdf, extension, null, mimType);
                return File(result.MainStream, "application/pdf");
            }
            return Ok(data);
        }
    }
}
