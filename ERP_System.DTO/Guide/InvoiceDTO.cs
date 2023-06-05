using ERP_System.Common.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO.Guide
{
    public class InvoiceDTO
    {
        public Guid? ID { get; set; }
       
        public int InvoiceNumber { get; set; }

        public decimal? TotalPrice { get; set; }

        public DateTime InvoiceDate { get; set; }
        public InvoiceType? InvoiceType { get; set; }


        public string? ResourceName { get; set; }
        public string? BuyerName { get; set; }

        public List<InvoiceProductsDTO> InvoiceDetails { get; set; }
    }

    public class InvoiceProductsDTO
    {
        public Guid? ProductId { get; set; }
        public string? ProductName { get; set; }

        public string? UnitName { get; set; }
        public Guid? UnitId { get; set; }
        public string? GroupName { get; set; }
        public Guid? GroupId { get; set; }

        public string? StockName { get; set; }
        public Guid? StockId { get; set; }

        public decimal? RequiredQty { get; set; }
        public decimal? PricePerUnit { get; set; }
        public decimal? PricePerQty => RequiredQty * PricePerUnit;

    }

    public class InvoicesTableDTO
    {
        public Guid? ID { get; set; }

        public int InvoiceNumber { get; set; }

        public decimal? TotalPrice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public InvoiceType? InvoiceType { get; set; }
        public string? ResourceName { get; set; }
        public string? BuyerName { get; set; }
        public bool? IsActive { get; set; }
        public int TotalCount { get; set; }

    }
}
