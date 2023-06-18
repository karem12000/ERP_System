using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO.Report
{
    public class SaleReportDTO : BaseReportDTO
    {
        public string InvoiceType { get; set; }
        public string InvoiceDate { get; set; }
        public string StockName { get; set; }
        public string BuyerName { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal InvoiceTotalPrice { get; set; }
    }
}
