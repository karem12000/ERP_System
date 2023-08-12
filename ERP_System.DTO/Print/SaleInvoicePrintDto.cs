using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP_System.DTO.Print
{
    public class SaleInvoicePrintDto
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyImage { get; set; }
        public string CompanyImageFullPath { get; set; }
        public string StockName { get; set; }
        public string InvoiceDate { get; set; }
        public string Buyer { get; set; }
        public string DetailsAsJson { get; set; }
        public double? TotalPaid { get; set; }
        public double? InvoiceTotalDiscount { get; set; }
        public double? InvoiceTotalPrice { get; set; }
        public double? Remainning { get; set; }
        public int InvoiceNumber { get; set; }
        public int InvoiceTotalDiscountType { get; set; }
        public string InvoiceDisscountTypeStr => InvoiceTotalDiscountType == 0 ? "%" : "قيمة";
		public IEnumerable<RootSaleInvoiceDto> InvoiceDetails
=> string.IsNullOrEmpty(DetailsAsJson) ? Enumerable.Empty<RootSaleInvoiceDto>() :
JsonConvert.DeserializeObject<List<RootSaleInvoiceDto>>(DetailsAsJson);
    }
	public class SaleThrowbackInvoicePrintDto
	{
		public string CompanyName { get; set; }
		public string CompanyAddress { get; set; }
		public string CompanyPhone { get; set; }
		public string CompanyImage { get; set; }
		public string CompanyImageFullPath { get; set; }
		public string StockName { get; set; }
		public string InvoiceDate { get; set; }
		public string SaleInvoiceDate { get; set; }
		public string Buyer { get; set; }
		public string DetailsSTAsJson { get; set; }
		public double? TotalPaid { get; set; }
		public double? InvoiceTotalDiscount { get; set; }
		public double? InvoiceTotalPrice { get; set; }
		public double? Remainning { get; set; }
		public int InvoiceNumber { get; set; }
		public int SaleInvoiceNumber { get; set; }
		public int InvoiceTotalDiscountType { get; set; }
		public string InvoiceDisscountTypeStr => InvoiceTotalDiscountType == 0 ? "%" : "قيمة";
		public IEnumerable<RootSaleInvoiceDto> InvoiceDetails
=> string.IsNullOrEmpty(DetailsSTAsJson) ? Enumerable.Empty<RootSaleInvoiceDto>() :
JsonConvert.DeserializeObject<List<RootSaleInvoiceDto>>(DetailsSTAsJson);
	}

	public class PurchaseInvoicePrintDto
	{
		public string CompanyName { get; set; }
		public string CompanyAddress { get; set; }
		public string CompanyPhone { get; set; }
		public string CompanyImage { get; set; }
		public string CompanyImageFullPath { get; set; }
		public string StockName { get; set; }
		public string InvoiceDate { get; set; }
		public string SupplierName { get; set; }
		public string SupplierPhone { get; set; }
		public string DetailsAsJson { get; set; }
		public double? TotalPaid { get; set; }
		public double? InvoiceTotalPrice { get; set; }
		public double? Remainning { get; set; }
		public int InvoiceNumber { get; set; }
		public IEnumerable<RootPurchaseInvoiceDto> InvoiceDetails
=> string.IsNullOrEmpty(DetailsAsJson) ? Enumerable.Empty<RootPurchaseInvoiceDto>() :
JsonConvert.DeserializeObject<List<RootPurchaseInvoiceDto>>(DetailsAsJson);
	}
	public class PurchaseThrowbackInvoicePrintDto
	{
		public string CompanyName { get; set; }
		public string CompanyAddress { get; set; }
		public string CompanyPhone { get; set; }
		public string CompanyImage { get; set; }
		public string CompanyImageFullPath { get; set; }
		public string StockName { get; set; }
		public string InvoiceDate { get; set; }
		public string PurchaseInvoiceDate { get; set; }
		public string SupplierName { get; set; }
		public string SupplierPhone { get; set; }
		public string DetailsPTAsJson { get; set; }
		public double? TotalPaid { get; set; }
		public double? InvoiceTotalPrice { get; set; }
		public double? Remainning { get; set; }
		public int InvoiceNumber { get; set; }
		public int PurchaseInvoiceNumber { get; set; }
		public IEnumerable<RootPurchaseInvoiceDto> InvoiceDetails
=> string.IsNullOrEmpty(DetailsPTAsJson) ? Enumerable.Empty<RootPurchaseInvoiceDto>() :
JsonConvert.DeserializeObject<List<RootPurchaseInvoiceDto>>(DetailsPTAsJson);
	}

	public class RootPurchaseInvoiceDto
	{
		public double ProductQty { get; set; }
		public double ProductTotalQtyPrice { get; set; }
		public double ProductPurchasingPrice { get; set; }
		public List<UnitJsonDto> UnitJsonDto { get; set; }
	}

	public class RootSaleInvoiceDto
	{
		public double ProductQty { get; set; }
		public double ProductTotalQtyPrice { get; set; }
		public double ProductSellingPrice { get; set; }
		public string ProductDiscountTypeStr  => ProductDiscountType == 0 ? "%" : "قيمة";
		public double ProductDisscount { get; set; }
		public int ProductDiscountType { get; set; }
		public List<UnitJsonDto> UnitJsonDto { get; set; }
	}
	public class ProductJsonDto
	{
		public string ProductName { get; set; }
		public string ProductParcode { get; set; }
	}

	public class UnitJsonDto
	{
		public string UnitName { get; set; }
		public List<ProductJsonDto> ProductJsonDto { get; set; }
	}
}
