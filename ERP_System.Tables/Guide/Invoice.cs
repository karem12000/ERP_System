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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceNumber { get; set; }
        public string? Name { get; set; }
        public string? BarCode { get; set; }
        public double? PricePerUnit { get; set; }
        //public decimal TotalQtyPrice  =>Convert.ToDecimal(PricePerUnit * Qty);
        public decimal? TotalPrice { get; set; }
        public double? Qty { get; set; }
        public string? Image { get; set; }
        public DateTime InvoiceDate { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string? ResourceName { get; set; }
        public string? BuyerName { get; set; }

        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }

    }

    [Table(nameof(InvoiceProduct) + "s", Schema = AppConstants.Areas.Guide)]
    public class InvoiceProduct : BaseEntity
    {

        [ForeignKey(nameof(Invoice))]
        public Guid? InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
