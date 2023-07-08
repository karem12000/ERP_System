using ERP_System.Common;
using ERP_System.Common.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(PurchaseThrowback) + "s", Schema = AppConstants.Areas.Guide)]
    public class PurchaseThrowback : BaseEntity
    {
        public Guid? StockId { get; set; }
        public Guid? PurchaseInvoiceId { get; set; }
        public DateTime? PurchaseInvoiceDate { get; set; }
        public string? StockName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid? SupplierId { get; set; }
		public string? SupplierName { get; set; }
        public TransactionType? TransactionType { get; set; }
        public decimal? TotalPaid { get; set; }
        public decimal? AddedTax { get; set; }
        public decimal? InvoiceTotalPrice { get; set; }

        public ICollection<PurchaseThrowbackDetail> PurchaseThrowbackDetails { get; set; }


    }
    [Table(nameof(PurchaseThrowbackDetail) + "s", Schema = AppConstants.Areas.Guide)]
    public class PurchaseThrowbackDetail : BaseEntity
    {
        public Guid? ProductId { get; set; }
        public Guid? PurchaseDetailId { get; set; }
        public string? ProductBarCode { get; set; }
        public string? ProductName { get; set; }
        public Guid? UnitId { get; set; }
        public decimal? ConversionFactor { get; set; }
        public decimal? Qty { get; set; }
        public decimal? PurchasingPrice { get; set; }
        public decimal? TotalQtyPrice { get; set; }


        [ForeignKey(nameof(PurchaseThrowback))]
        public Guid? PurchaseThrowbackId { get; set; }
        public virtual PurchaseThrowback PurchaseThrowback { get; set; }

    }


}
