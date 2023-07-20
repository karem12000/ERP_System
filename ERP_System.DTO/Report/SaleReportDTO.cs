using ERP_System.Common.General;
using ERP_System.DTO.Guide;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO.Report
{
    public class SaleReportDTO
    {
        public int InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string BuyerName { get; set; }
        public string StockName { get; set; }
        public string ProductName { get; set; }
        public string ProductDiscountType { get; set; }
        public decimal? ProductDiscount { get; set; }
        public decimal? Qty { get; set; }
        public decimal? SellingPrice { get; set; }
        public string InvoiceType { get; set; }
        public decimal? InvoiceTotalPrice { get; set; }
        public decimal? InvoiceTotalPaid { get; set; }
        public decimal? InvoiceTotalDiscount { get; set; }
        public string InvoiceTotalDiscountType { get; set; }
    }


}
