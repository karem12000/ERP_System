using AspNetCore.Reporting;
using ERP_System.BLL.Guide;
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
        private readonly SettingBll _settingBll;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportController(SaleReportBll saleReportBll , SettingBll settingBll, IWebHostEnvironment webHostEnvironment)
        {
            _saleReportBll = saleReportBll;
            _webHostEnvironment = webHostEnvironment;
            _settingBll = settingBll;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            return Redirect("/Report/Report/GetSaleInvoiceReport");
        }

        
        public IActionResult GetSaleInvoiceReport(DateTime? FromDate , DateTime ToDate)
        {
            var companyData = _settingBll.GetSetting();
            var data = _saleReportBll.GetAllByDate(FromDate , ToDate);
            if (data != null)
            {
                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                DataTable dt = converter.ToDataTable(data);
                string mimType = "";
                int extension = 1;
                var path = $"{_webHostEnvironment.WebRootPath}//Reports//SaleInvoiceReport.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                if(companyData != null)
                {
                    parameters.Add("CompanyName", companyData.CompanyName);
                    parameters.Add("CompanyAddress", companyData.CompanyAddress);
                    parameters.Add("CompanyPhone", companyData.CompanyPhone);
                    parameters.Add("CompanyImage", string.Concat("//SiteImages//", companyData.Logo));
                    parameters.Add("Description", companyData.Description);
                }
                else
                {
                    parameters.Add("CompanyName", "");
                    parameters.Add("CompanyAddress","");
                    parameters.Add("CompanyPhone", "");
                    parameters.Add("CompanyImage", "");
                    parameters.Add("Description","");
                }
               
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("dsSales", dt);
                var result = localReport.Execute(RenderType.Pdf, extension, null, mimType);
                return File(result.MainStream, "application/pdf");
            }
            return Ok(data);
        }   
        
      
    }
}
