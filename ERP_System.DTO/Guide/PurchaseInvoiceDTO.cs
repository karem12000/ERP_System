using AutoMapper.Internal;
using ERP_System.Common.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Xml.Linq;

namespace ERP_System.DTO.Guide
{

    public class GetPurchaseInvoiceDTO
    {
        public Guid? ID { get; set; }
        public Guid? PurchaseInvoiceId { get; set; }
        public int? TransactionType { get; set; }
        public Guid? StockId { get; set; }
        public string? StockName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceDateStr { get; set; }
        public Guid? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public decimal? InvoiceTotalPrice { get; set; }
        public decimal? TotalPaid { get; set; }
        public bool IsActive { get; set; }
        public string? InvoiceProductsStr { get; set; }
        public List<PurchaseInvoiceProductsDTO> GetInvoiceDetails { get; set; }
    }

    public class PurchaseInvoiceDTO : GetPurchaseInvoiceDTO
    {
        public PurchaseInvoiceProductsDTO[] InvoiceDetails => JsonConvert.DeserializeObject<PurchaseInvoiceProductsDTO[]>(InvoiceProductsStr);
    }

    public class PurchaseInvoiceProductsDTO
    {
        public Guid? ID { get; set; }
        public Guid? ProductId { get; set; }
        public string? ProductBarCode { get; set; }
        public string? ProductName { get; set; }
		public Guid? PurchaseDetailId { get; set; }

		public Guid? UnitId { get; set; }
        public string? UnitName { get; set; }
        public decimal? ConversionFactor { get; set; }
        public decimal? Qty { get; set; }
        public decimal? QtyInStock { get; set; }
        public decimal? ThrowbackQty { get; set; }
        public string QtyInStockStr { get; set; }
        public decimal? PurchasingPrice { get; set; }
        public decimal? TotalQtyPrice =>Math.Round( Qty.Value  * PurchasingPrice.Value ,2);
        public List<ProductUnitsDTO> GetProductUnits { get; set; }

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

    public class PurchaseInvoicesTableDTO
    {
        public Guid? ID { get; set; }

        public int InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public Guid? StockId { get; set; }
        public string StockName { get; set; }
        public int? ProductsCount { get; set; }
        public bool? IsActive { get; set; }
        public Guid? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int? TransactionType { get; set; }
        public decimal? TotalPaid { get; set; }
        public decimal? InvoiceTotalPrice { get; set; }
        public string AddedDate { get; set; }
        public int TotalCount { get; set; }
			
    }
}
