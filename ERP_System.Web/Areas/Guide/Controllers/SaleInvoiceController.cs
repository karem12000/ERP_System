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
        private readonly InvoiceBll _invoiceBll;
        public SaleInvoiceController(InvoiceBll invoiceBll)
        {
            _invoiceBll = invoiceBll;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Add()
        {

            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var item = _invoiceBll.GetById(id);
            if (item != null)
            {
                
                return View(item);
            }
            else
                return Redirect("/Guide/SaleInvoice/Index");
        }

        public IActionResult Save(InvoiceDTO mdl) => Ok(_invoiceBll.Save(mdl));

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_invoiceBll.Delete(id));



        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_invoiceBll.LoadData(mdl , InvoiceType.Sale));

        #endregion
    }
}
