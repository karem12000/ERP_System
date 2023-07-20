﻿using AutoMapper.Internal;
using ERP_System.Common.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO.Guide
{
	public class GetSaleInvoiceDTO
	{
		public Guid? ID { get; set; }
		public InvoiceType? InvoiceType { get; set; }
		public Guid? StockId { get; set; }
		public string? StockName { get; set; }
		public int InvoiceNumber { get; set; }
		public decimal? AddedTax { get; set; }
		public DateTime InvoiceDate { get; set; }
		public string InvoiceDateStr { get; set; }
		public decimal? InvoiceTotalDiscount { get; set; }
		public DisscountType? InvoiceTotalDiscountType { get; set; }
		public int? InvoiceTotalDiscountTypeInt { get; set; }
		public decimal? TotalPaid { get; set; }
		public string? Buyer { get; set; }
		public decimal? InvoiceTotalPrice { get; set; }
		public bool IsActive { get; set; }
		public string? InvoiceProductsStr { get; set; }
		public List<SaleInvoiceProductsDTO> GetInvoiceDetails { get; set; }
	}
	public class SaleInvoiceDTO : GetSaleInvoiceDTO
	{

		public SaleInvoiceProductsDTO[] InvoiceDetails => JsonConvert.DeserializeObject<SaleInvoiceProductsDTO[]>(InvoiceProductsStr);
	}

	public class SaleInvoiceProductsDTO
	{
		public Guid? ID { get; set; }
		public Guid? ProductId { get; set; }
		public string? ProductBarCode { get; set; }
		public string? ProductName { get; set; }
		public decimal? DiscountPProduct { get; set; }
		public DisscountType? DiscountTypePProduct { get; set; }
		public decimal? TotalQtyPriceAfterDisscount { get; set; }
		public int? DiscountTypePProductInt { get; set; }
		public string? Buyer { get; set; }
		public Guid? UnitId { get; set; }
		public string? UnitName { get; set; }
		public decimal? ConversionFactor { get; set; }
		public decimal? ItemUnitPrice { get; set; }
		public decimal? Qty { get; set; }
		public string QtyInStockStr { get; set; }
		public decimal? SellingPrice { get; set; }
		public decimal? TotalQtyPrice => Math.Round(Qty.Value * ItemUnitPrice.Value, 2);
		public List<ProductUnitsDTO> GetProductUnits { get; set; }

	}


	public class SaleInvoicesTableDTO
	{
		public Guid? ID { get; set; }

		public int InvoiceNumber { get; set; }
		public string InvoiceDate { get; set; }
		public string Buyer { get; set; }
		public Guid? StockId { get; set; }
		public string? StockName { get; set; }
		public decimal? TotalPaid { get; set; }
		public decimal? InvoiceTotalPrice { get; set; }
		public decimal? InvoiceTotalDiscount { get; set; }
		public int? ProductsCount { get; set; }
		public bool? IsActive { get; set; }
		public string AddedDate { get; set; }
		public int TotalCount { get; set; }

	}


}
