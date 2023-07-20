using ERP_System.DAL;
using ERP_System.DTO.Guide;
using ERP_System.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ERP_System.BLL.Report
{
    public class ProductReportBll
    {
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<ItemGrpoup> _repoItemGrpoup;
        private readonly IRepository<ProductUnit> _repoProductUnit;
        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<StockProduct> _repoStockProduct;
        private readonly IRepository<Unit> _repoUnit;
        private readonly IRepository<SaleInvoiceDetail> _repoSaleInvoiceDetail;
        public ProductReportBll(IRepository<Product> repoProduct, IRepository<SaleInvoiceDetail> repoSaleInvoiceDetail, IRepository<StockProduct> repoStockProduct, IRepository<ItemGrpoup> repoItemGrpoup, IRepository<ProductUnit> repoProductUnit, IRepository<Stock> repoStock, IRepository<Unit> repoUnit)
        {
            _repoProduct = repoProduct;
            _repoStock = repoStock;
            _repoUnit = repoUnit;
            _repoProductUnit = repoProductUnit;
            _repoItemGrpoup = repoItemGrpoup;
            _repoStockProduct = repoStockProduct;
            _repoSaleInvoiceDetail = repoSaleInvoiceDetail;
        }
		public DataTableResponse GetProductReportData(ProductReportDataTableRequest mdl)
		{
			var data = _repoProduct.ExecuteStoredProcedure<ProductReportData>
				("[Report].[spProductReportData]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}
		public DataTableResponse GetMostProductsSale(ProductReportDataTableRequest mdl)
		{
			var data = _repoProduct.ExecuteStoredProcedure<GetMostProductSellingReportDto>
				("[Report].[spGetMostProductsSale]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}

		public DataTableResponse GetLeastProductsSale(ProductReportDataTableRequest mdl)
		{
			var data = _repoProduct.ExecuteStoredProcedure<GetMostProductSellingReportDto>
				("[Report].[spGetLeastProductsSale]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}

		public DataTableResponse GetProductsPrice(ProductReportDataTableRequest mdl)
		{
			var data = _repoProduct.ExecuteStoredProcedure<ProductPriceDto>
				("[Report].[spProductPriceReport]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}
        
        public DataTableResponse GetProductsQty(ProductReportDataTableRequest mdl)
		{
			var data = _repoProduct.ExecuteStoredProcedure<ProductQtyDto>
				("[Report].[spProductQtyReport]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}
        
        public DataTableResponse GetLeastSupplierNumPurchasingReportDto(ProductReportDataTableRequest mdl)
		{
			var data = _repoProduct.ExecuteStoredProcedure<GetSupplierNumPurchasingReportDto>
				("[Report].[spGetLeastSupplierPurchase]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}
		public DataTableResponse GetMostSupplierNumPurchasingReportDto(ProductReportDataTableRequest mdl)
		{
			var data = _repoProduct.ExecuteStoredProcedure<GetSupplierNumPurchasingReportDto>
				("[Report].[spGetMostSupplierPurchase]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}
		//public List<ProductQtyDto> ProductsQty(Guid? StockId, Guid? ProductId)
		//      {
		//          var data = _repoProduct.GetAllAsNoTracking()
		//              .Where(x => x.StockProducts.Any(c => c.StockId == StockId || StockId == null) && (x.ID == ProductId || ProductId == null) && x.IsActive && !x.IsDeleted)
		//              .Select(x => new ProductQtyDto
		//              {
		//                  ProductName = x.Name,
		//                  StockName = string.Join(" , ", _repoStock.GetAllAsNoTracking().Where(c => c.ID == StockId || StockId == null && c.IsActive && !c.IsDeleted).Select(c => c.Name).ToList()),
		//                  Qty = x.QtyInStock,
		//                  QtyName = _repoUnit.GetById(x.IdUnitOfQty).Name
		//              }).ToList();

		//          return data;
		//      }

		//public List<ProductPriceDto> ProductsPrice(Guid? StockId, Guid? ProductId)
		//{
		//    var data = _repoProductUnit.GetAllAsNoTracking().Include(x => x.Product)
		//        .Where(x => x.Product.StockProducts.Any(c => c.StockId == StockId || StockId == null))
		//        .Where(x => x.ProductId == ProductId || ProductId == null)
		//        .Where(x => x.Product.IsActive && !x.Product.IsDeleted).Select(x => new ProductPriceDto
		//        {
		//            ProductName = x.Product.Name,
		//            PurchasingPrice = x.PurchasingPrice,
		//            SellingPrice = x.SellingPrice,
		//            QtyName = _repoUnit.GetById(x.UnitId).Name,
		//            StockName = string.Join(" , ", _repoStock.GetAllAsNoTracking().Where(c => c.ID == StockId || StockId == null && c.IsActive && !c.IsDeleted).Select(c => c.Name).ToList())
		//        }).ToList();
		//    return data;
		//}

		public List<ProductsReportDto> ProductsReport(Guid? StockId, Guid? ProductId)
        {
            var data = _repoProduct.GetAllAsNoTracking().Include(x=>x.StockProducts).ThenInclude(x=>x.Stock)
                .Where(x => x.StockProducts.Any(c => c.StockId == StockId || StockId == null))
                .Where(x => x.ID == ProductId || ProductId == null)
                .Where(x => x.IsActive && !x.IsDeleted).Select(x => new ProductsReportDto
                {
                    ProductId = x.ID,
                    BarCodeText = x.BarCodeText,
                    Description = x.Description,
                    ExpireDate = x.ExpireDate == null ? "لايوجد" : x.ExpireDate.Value.Date.ToString(),
                    GroupName = _repoItemGrpoup.GetById(x.GroupId).Name,
                    IsActive = x.IsActive,
                    ProductName = x.Name,
                    QtyInStock = x.QtyInStock,
                    QtyUnitName = _repoUnit.GetById(x.IdUnitOfQty).Name,
                    //StockName = string.Join(" , ",x.StockProducts.SelectMany(c=>c.Stock.Name).ToList() )
                }).ToList();
            return data;
        }

		//public List<MostSaleProducts> GetMostProductsSaleCount()
		//{
		//	var data = (from s in _repoSaleInvoiceDetail.GetAllAsNoTracking()
		//				group s by new { s.ProductId, s.ProductName } into val
		//				select new MostSaleProducts()
		//				{
		//					ProductId = val.Key.ProductId,
		//					ProductName = val.Key.ProductName,
		//					Qty = val.Sum(s => s.Qty)
		//				}).OrderByDescending(i => i.Qty).Take(3).ToList();

		//	return data;
		//}

	}
	public class GetMostProductSellingReportDto
	{
		public Guid ID { get; set; }
		public string ProductName { get; set; }
		public string UnitName { get; set; }
		public int NumOfPay { get; set; }
		public int? TotalCount { get; set; }
	}
    public class GetSupplierNumPurchasingReportDto
	{
		public string SupplierName { get; set; }
		public string CompanyName { get; set; }
		//public string StockName { get; set; }
		public int NumOfProcess { get; set; }
        public bool IsActive { get; set; }
        public int? TotalCount { get; set; }
	}

	public class ProductReportData
    {
        public Guid ID { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Name { get; set; }
        public string BarCodeText { get; set; }
        public string Description { get; set; }
        public string NameUnitOfQty { get; set; }
        public string GroupName { get; set; }
        public string StockName { get; set; }
        public decimal? QtyInStock { get; set; }
        public bool IsActive { get; set; }
		public int TotalCount { get; set; }

	}
	public class BaseProductReportDto
    {
        public string StockName { get; set; }
        public string ProductName { get; set; }
        public string QtyName { get; set; }
    }
    public class ProductQtyDto
    {
		public string ProductName { get; set; }
		public string QtyName { get; set; }
		public string BarCode { get; set; }
		public decimal? QtyInStock { get; set; }
        public int TotalCount { get; set; }
    }
    public class ProductsReportDto
    {
        public Guid? ProductId { get; set; }
        public List<string> StockName { get; set; }
        public string GroupName { get; set; }
        public string ProductName { get; set; }
        public string BarCodeText { get; set; }
        public decimal? QtyInStock { get; set; }
        public string QtyUnitName { get; set; }
        public string ExpireDate { get; set; }
        public List<string> ImagePath { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
    public class ProductPriceDto
    {
		public string ProductName { get; set; }
		public string QtyName { get; set; }
		public string BarCode { get; set; }
		public decimal? SellingPrice { get; set; }
        public decimal? PurchasingPrice { get; set; }
        public int TotalCount { get; set; }
    }
}
