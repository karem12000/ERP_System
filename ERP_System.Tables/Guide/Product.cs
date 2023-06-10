using ERP_System.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(Product) + "s", Schema = AppConstants.Areas.Guide)]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? BarCodeText { get; set; }
        public string? BarCodePath { get; set; }
        public decimal? QtyInStock { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }


        public string NameUnitOfQty { get; set; }
        public Guid? IdUnitOfQty { get; set; }

        public DateTime? ExpireDate { get; set; }


        [ForeignKey(nameof(Group))]
        public Guid? GroupId { get; set; }
        public virtual ItemGrpoup Group { get; set; }

        //[ForeignKey(nameof(Unit))]
        //public Guid? UnitId { get; set; }
        //public virtual Unit Unit { get; set; }
        public ICollection<StockProduct> StockProducts { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<ProductUnit> ProductUnits { get; set; }


    }

    [Table(nameof(ProductUnit) + "s", Schema = AppConstants.Areas.Guide)]
    public class ProductUnit : BaseEntity
    {
        public decimal? ConversionFactor { get; set; }
        public decimal? PurchasingPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string UnitBarcodeText { get; set; }
        public string UnitBarcodePath { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(Unit))]
        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

    }
}
