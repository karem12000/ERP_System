using AutoMapper.Internal;
using ERP_System.Common.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO.Guide
{
    public class PurchaseThrowbackDTO
    {

        public int? TransactionType { get; set; }
        public Guid? ID { get; set; }
        public Guid? StockId { get; set; }
        public Guid? PurchaseInvoiceId { get; set; }
        public DateTime? PurchaseInvoiceDate { get; set; }
        public string? PurchaseInvoiceDateStr { get; set; }
        public int? PurchaseInvoiceNo { get; set; }
        public string? StockName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceDateStr { get; set; }
        public Guid? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public decimal? InvoiceTotalPrice { get; set; }
        public decimal? AddedTax { get; set; }
        public decimal? TotalPaid { get; set; }
        public bool IsActive { get; set; }
        public string? InvoiceProductsStr { get; set; }
        public PurchaseThrowbackProductsDTO[] InvoiceDetails => JsonConvert.DeserializeObject<PurchaseThrowbackProductsDTO[]>(InvoiceProductsStr);
        public List<PurchaseThrowbackProductsDTO> GetInvoiceDetails { get; set; }
    }

    public class PurchaseThrowbackProductsDTO
    {
        public Guid? ID { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? PurchaseDetailId { get; set; }
        public string ProductBarCode { get; set; }
        public string ProductName { get; set; }
        public string QtyInStockStr { get; set; }
        public Guid? UnitId { get; set; }
        public decimal? ConversionFactor { get; set; }
        public decimal? Qty { get; set; }
        public decimal? PurchasingPrice { get; set; }
        public decimal? TotalQtyPrice =>Math.Round( Qty.Value  * PurchasingPrice.Value ,2);
        public List<ProductUnitsDTO> GetProductUnits { get; set; }

    }

   
    public class PurchaseThrowbackTableDTO
    {
        public int? TransactionType { get; set; }
        public string InvoiceDate { get; set; }
        public string SupplierName { get; set; }
        public Guid? StockId { get; set; }
        public string StockName { get; set; }
        public decimal? TotalPaid { get; set; }
        public int? ProductsCount { get; set; }
        public decimal? InvoiceTotalPrice { get; set; }
        public Guid? ID { get; set; }
        public int InvoiceNumber { get; set; }
        public string Supplier { get; set; }
        public bool? IsActive { get; set; }
        public string AddedDate { get; set; }
        public int TotalCount { get; set; }

    }
}
