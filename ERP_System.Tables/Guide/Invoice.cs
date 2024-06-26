﻿using ERP_System.Common;
using ERP_System.Common.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(Invoice) + "s", Schema = AppConstants.Areas.Guide)]
    public class Invoice : BaseEntity
    {
        public InvoiceType? InvoiceType { get; set; }
        public Guid? StockId { get; set; }
        public string? StockName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? Supplier { get; set; }
        public string? Buyer { get; set; }
        public decimal? TotalPrice { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    }

    [Table(nameof(InvoiceDetail) + "s", Schema = AppConstants.Areas.Guide)]
    public class InvoiceDetail : BaseEntity
    {
        public string? ProductName { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? QtyPrice { get; set; }
        public decimal? Qty { get; set; }

        public string? UnitName { get; set; }
        public Guid? UnitId { get; set; }

        [ForeignKey(nameof(Invoice))]
        public Guid? InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
