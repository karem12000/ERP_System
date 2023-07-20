using ERP_System.Common;
using ERP_System.DAL;
using ERP_System.DTO.Guide;
using ERP_System.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ERP_System.Tables;
using AutoMapper;
using ERP_System.Common.General;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using ERP_System.DTO.Report;
using ERP_System.BLL.Report;

namespace ERP_System.BLL.Guide
{
    public class PurchaseReportBll
	{
        private readonly IRepository<PurchaseInvoice> _repoInvoice;
        private readonly IRepository<Setting> _repoSetting;
        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<SaleInvoiceDetail> _repoInvoiceDetail;
        private readonly IMapper _mapper;

        public PurchaseReportBll(IRepository<Product> repoProduct,  IRepository<Stock> repoStock, IRepository<Setting> repoSetting, IRepository<PurchaseInvoice> repoInvoice, IRepository<SaleInvoiceDetail> repoInvoiceDetail, IMapper mapper)
        {
            _repoInvoice = repoInvoice;
            _mapper = mapper;
            _repoInvoiceDetail = repoInvoiceDetail;
            _repoProduct = repoProduct;
            _repoSetting = repoSetting;
            _repoStock = repoStock;
        }

		#region Purchase 
		public DataTableResponse GetPurchaseInvoicesReport(ProductReportDataTableRequest mdl)
		{
			var data = _repoInvoice.ExecuteStoredProcedure<PurchaseInvoicesReportDto>
				("[Report].[spPurchaseInvoiceReport]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}
		//public List<SaleReportDTO> GetAllByDate(DateTime? fromDate, DateTime? toDate)
		//{

		//    //var reportData = _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date >= fromDate.Value.Date && x.InvoiceDate.Date <= toDate.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new SaleReportDTO
		//    var reportData = _repoInvoice.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive).Select(x => new SaleReportDTO
		//    {
		//        BuyerName = x.Buyer,
		//        InvoiceDate = x.InvoiceDate.Date.ToString(),
		//        InvoiceNumber = x.InvoiceNumber,
		//        InvoiceTotalPrice = x.InvoiceTotalPrice.Value,
		//        InvoiceType = "فاتورة مبيعات",
		//        StockName = x.StockName
		//    }).ToList();

		//    return reportData;
		//}
		//public DataTableResponse LoadData(ReportsDataTableRequest mdl)
		//{
		//    var data = _repoProduct.ExecuteStoredProcedure<ProductTableDTO>
		//        (_spProduct, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

		//    return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		//}

		#endregion
		#region Throwback
		public DataTableResponse GetPurchaseThrowbackInvoicesReport(ProductReportDataTableRequest mdl)
		{
			var data = _repoInvoice.ExecuteStoredProcedure<PurchaseThrowbackInvoicesReportDto>
				("[Report].[spPurchaseThrowbackInvoiceReport]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}
		#endregion

	}

	public class PurchaseThrowbackInvoicesReportDto
	{
		public Guid ID { get; set; }
		public int TransactionType { get; set; }
		public string StockName { get; set; }
		public int InvoiceNumber { get; set; }
		public int PurchaseInvoiceNumber { get; set; }
		public DateTime? InvoiceDate { get; set; }
		public DateTime? PurchaseInvoiceDate { get; set; }
		public string InvoiceDateStr => InvoiceDate.Value.Date.ToString();
		public string PurchaseInvoiceDateStr => PurchaseInvoiceDate.Value.Date.ToString();
		public string SupplierName { get; set; }
		public int NumOfProducts { get; set; }
		public decimal? InvoiceTotalPrice { get; set; }
		public decimal? TotalPaid { get; set; }
		public int TotalCount { get; set; }
	}
	public class PurchaseInvoicesReportDto
	{
		public Guid ID { get; set; }
		public int TransactionType { get; set; }
		public string StockName { get; set; }
		public int InvoiceNumber { get; set; }
		public DateTime? InvoiceDate { get; set; }
		public string InvoiceDateStr => InvoiceDate.Value.Date.ToString();
		public string SupplierName { get; set; }
		public int NumOfProducts { get; set; }
		public decimal? InvoiceTotalPrice { get; set; }
		public decimal? TotalPaid { get; set; }
		public int TotalCount { get; set; }
	}
}
