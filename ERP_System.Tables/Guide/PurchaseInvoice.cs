﻿using ERP_System.Common;
using ERP_System.Common.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(PurchaseInvoice) + "s", Schema = AppConstants.Areas.Guide)]
    public class PurchaseInvoice : BaseEntity
    {
        public Guid? StockId { get; set; }
        public string? StockName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? Supplier { get; set; }
        public decimal? TotalPrice { get; set; }
        public ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetail { get; set; }

    }

    [Table(nameof(PurchaseInvoiceDetail) + "s", Schema = AppConstants.Areas.Guide)]
    public class PurchaseInvoiceDetail : BaseEntity
    {
        public string? ProductName { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? QtyPrice { get; set; }
        public decimal? Qty { get; set; }
        public string? UnitName { get; set; }
        public Guid? UnitId { get; set; }

        [ForeignKey(nameof(PurchaseInvoice))]
        public Guid? PurchaseInvoiceId { get; set; }
        public virtual PurchaseInvoice PurchaseInvoice { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}