using ERP_System.Common;
using ERP_System.Common.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(SaleThrowback) + "s", Schema = AppConstants.Areas.Guide)]
    public class SaleThrowback : BaseEntity
    {
        public Guid? StockId { get; set; }
        public string? StockName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? Buyer { get; set; }
        public decimal? InvoiceTotalPrice { get; set; }

        public ICollection<SaleThrowbackDetail> SaleInvoiceDetails { get; set; }


    }
    [Table(nameof(SaleThrowbackDetail) + "s", Schema = AppConstants.Areas.Guide)]
    public class SaleThrowbackDetail : BaseEntity
    {
        public string? ProductBarCode { get; set; }
        public Guid? ProductId { get; set; }
        public string? ProductName { get; set; }
        public Guid? UnitId { get; set; }
        public decimal? ConversionFactor { get; set; }
        public decimal? ItemUnitPrice { get; set; }
        public decimal? Qty { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? TotalQtyPrice { get; set; }


        [ForeignKey(nameof(SaleThrowback))]
        public Guid? SaleThrowbackId { get; set; }
        public virtual SaleThrowback SaleThrowback { get; set; }

    }


}
