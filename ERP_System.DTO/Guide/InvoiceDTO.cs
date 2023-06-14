using AutoMapper.Internal;
using ERP_System.Common.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO.Guide
{
    public class InvoiceDTO
    {
        public Guid? ID { get; set; }
        public InvoiceType? InvoiceType { get; set; }
        public Guid? StockId { get; set; }
        public string? StockName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? Supplier { get; set; }
        public string? InvoiceProductsStr { get; set; }
        public InvoiceProductsDTO[] InvoiceDetails => JsonConvert.DeserializeObject<InvoiceProductsDTO[]>(InvoiceProductsStr);
        public List<InvoiceProductsDTO> GetInvoiceDetails { get; set; }
        public string? Buyer { get; set; }

    }

    public class InvoiceProductsDTO
    {
        public Guid? ID { get; set; }
        public Guid? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductBarCode { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? QtyPrice { get; set; }
        public decimal? TotalQtyPrice => Qty * QtyPrice;
        public decimal? Qty { get; set; }

        public string? UnitName { get; set; }
        public Guid? UnitId { get; set; }

    }

    public class InvoicesTableDTO
    {
        public Guid? ID { get; set; }

        public int InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }
        public string? ResourceName { get; set; }
        public string? BuyerName { get; set; }
        public bool? IsActive { get; set; }
        public int TotalCount { get; set; }

    }

    //public class PurchaseInvoicesTableDTO
    //{
    //    public Guid? ID { get; set; }

    //    public int InvoiceNumber { get; set; }

    //    public string InvoiceDate { get; set; }
    //    public string? Supplier { get; set; }
    //    public Guid? StockId { get; set; }
    //    public string? StockName { get; set; }

    //    public int? ProductsCount { get; set; }
    //    public bool? IsActive { get; set; }
    //    public string AddedDate { get; set; }
    //    public int TotalCount { get; set; }

    //}
}
