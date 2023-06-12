using AutoMapper.Internal;
using ERP_System.Common.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO.Guide
{
    public class PurchaseInvoiceDTO
    {
        public Guid? ID { get; set; }
        public InvoiceType? InvoiceType { get; set; }
        public Guid? StockId { get; set; }
        public string? StockName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? Supplier { get; set; }
        public decimal? InvoiceTotalPrice { get; set; }

        public string? InvoiceProductsStr { get; set; }
        public PurchaseInvoiceProductsDTO[] InvoiceDetails => JsonConvert.DeserializeObject<PurchaseInvoiceProductsDTO[]>(InvoiceProductsStr);
        public List<PurchaseInvoiceProductsDTO> GetInvoiceDetails { get; set; }
    }

    public class PurchaseInvoiceProductsDTO
    {
        public Guid? ID { get; set; }
        public Guid? ProductId { get; set; }
        public string? ProductBarCode { get; set; }
        public string? ProductName { get; set; }
        public Guid? UnitId { get; set; }
        public decimal? ConversionFactor { get; set; }
        public decimal? ItemUnitPrice { get; set; }
        public decimal? Qty { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? TotalQtyPrice => (Qty * ConversionFactor) * ItemUnitPrice;
    }

    //public class InvoicesTableDTO
    //{
    //    public Guid? ID { get; set; }

    //    public int InvoiceNumber { get; set; }

    //    public DateTime InvoiceDate { get; set; }
    //    public string? ResourceName { get; set; }
    //    public string? BuyerName { get; set; }
    //    public bool? IsActive { get; set; }
    //    public int TotalCount { get; set; }

    //}

    //public class PurchaseInvoicesTableDTO
    //{
    //    public Guid? ID { get; set; }

    //    public int InvoiceNumber { get; set; }

    //    public DateTime InvoiceDate { get; set; }
    //    public string? Supplier { get; set; }
    //    public Guid? StockId { get; set; }
    //    public string? StockName { get; set; }

    //    public int? ProductsCount { get; set; }
    //    public bool? IsActive { get; set; }
    //    public string AddedDate { get; set; }
    //    public int TotalCount { get; set; }

    //}
}
