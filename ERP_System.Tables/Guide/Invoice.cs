using ERP_System.Common;
using ERP_System.Common.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(Invoice) + "s", Schema = AppConstants.Areas.Guide)]
    public class Invoice : BaseEntity
    {
       
        public int InvoiceNumber { get; set; }
        
        public decimal? TotalPrice { get; set; }
       
        public DateTime InvoiceDate { get; set; }
        public InvoiceType? InvoiceType { get; set; }


        public string? ResourceName { get; set; }
        public string? BuyerName { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    }

    [Table(nameof(InvoiceDetail) + "s", Schema = AppConstants.Areas.Guide)]
    public class InvoiceDetail : BaseEntity
    {
        public string? UnitName { get; set; }
        public Guid? UnitId { get; set; }
        public string? GroupName { get; set; }
        public Guid? GroupId { get; set; }

        public string? StockName { get; set; }
        public Guid? StockId { get; set; }

        public decimal? Qty { get; set; }
        public decimal? PricePerUnit { get; set; }
        public decimal? PricePerQty  => Qty * PricePerUnit;


        [ForeignKey(nameof(Invoice))]
        public Guid? InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }


        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
