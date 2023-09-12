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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using ZXing.QrCode.Internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Http;

namespace ERP_System.BLL.Guide
{
	public class ProductBll
	{
		private const string _spProduct = "[Guide].[spProduct]";
		private const string _spStock = "[Guide].[spStocks]";

		private readonly IRepository<Product> _repoProduct;
		private readonly IRepository<Unit> _repoUnit;
		private readonly IRepository<Attachment> _repoAttatchment;
		private readonly IRepository<Stock> _repoStock;
		private readonly IRepository<ProductUnit> _repoProductUnit;
		private readonly IRepository<PurchaseInvoice> _repoPurchaseInvoice;
		private readonly IRepository<PurchaseThrowback> _repoPurchaseThrowback;
		private readonly IRepository<StockProduct> _stockProduct;
		private readonly IRepository<ProductUnit> _productUnit;
		private readonly IMapper _mapper;
		private readonly HelperBll _helperBll;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IHttpContextAccessor _httpContext;

		public ProductBll(IRepository<Attachment> repoAttatchment, IRepository<Stock> repoStock, IRepository<ProductUnit> repoProductUnit, IRepository<Unit> repoUnit, IRepository<ProductUnit> productUnit,
			IWebHostEnvironment webHostEnvironment, IRepository<Product> repoProduct, IMapper mapper, HelperBll helperBll,
			IRepository<StockProduct> stockProduct, IHttpContextAccessor httpContext, IRepository<PurchaseInvoice> repoPurchaseInvoice, IRepository<PurchaseThrowback> repoPurchaseThrowback)
		{
			_repoProduct = repoProduct;
			_mapper = mapper;
			_helperBll = helperBll;
			_repoAttatchment = repoAttatchment;
			_webHostEnvironment = webHostEnvironment;
			_stockProduct = stockProduct;
			_productUnit = productUnit;
			_repoUnit = repoUnit;
			_repoPurchaseInvoice = repoPurchaseInvoice;
			_repoPurchaseThrowback = repoPurchaseThrowback;
			_repoProductUnit = repoProductUnit;
			_repoStock = repoStock;
			_httpContext = httpContext;
		}

		#region Get

		public IEnumerable<string> GetProductsNames()
		{
			var userId = _httpContext.UserId();
			var stocks = _repoStock.GetAllAsNoTracking().Where(x => x.UserStocks.Any(c => c.UserId == userId)).Select(x => x.ID).ToList();
			//var stockP = _stockProduct.GetAllAsNoTracking().Where(x => stocks.Contains(x.ID)).ToList();

            var data = _repoProduct.GetAllAsNoTracking().Where(x=>x.IsActive && !x.IsDeleted && x.StockProducts.Any(x=>stocks.Contains(x.StockId.Value))).Select(x => x.Name).ToList();
			
			return data?? Enumerable.Empty<string>();
		}
		public ProductDTO GetById(Guid id)
		{
			var data = _repoProduct.GetAllAsNoTracking().Include(p => p.Attachments).Include(x => x.StockProducts).ThenInclude(x => x.Stock).Where(p => p.ID == id).Select(x => new ProductDTO
			{


				ID = x.ID,
				Name = x.Name,
				BarCodeText = x.BarCodeText,
				BarCodePath = x.BarCodePath,
				GroupId = x.GroupId,
				QtyInStock = x.QtyInStock,
				ProductImages = x.Attachments.ToList(),
				GroupName = x.Group.Name,
				StockId = x.StockProducts.FirstOrDefault().StockId,
				StockName = x.StockProducts.FirstOrDefault().Stock.Name,
				IsActive = x.IsActive,
				ImagePath = x.Image,
				Description = x.Description,
				IdUnitOfQty = x.IdUnitOfQty,
				ExpireDateStr = x.ExpireDate == null ? null : x.ExpireDate.Value.Date.ToString(),
				GetProductUnits = x.ProductUnits.Where(c => c.IsActive && !c.IsDeleted).OrderBy(c => c.ConversionFactor).Select(c => new ProductUnitsDTO
				{
					ID = c.ID,
					ConversionFactor = c.ConversionFactor,
					PurchasingPrice = c.PurchasingPrice,
					SellingPrice = c.SellingPrice,
					UnitBarcodeText = c.UnitBarcodeText,
					UnitId = c.UnitId
				}).ToArray()
			}).FirstOrDefault();

			data.BaseUnitPurchasePrice = data.GetProductUnits.Where(x => x.UnitId == data.IdUnitOfQty).FirstOrDefault().PurchasingPrice;
			data.BaseUnitSalePrice = data.GetProductUnits.Where(x => x.UnitId == data.IdUnitOfQty).FirstOrDefault().SellingPrice;

			return data;

		}

		//public ResultViewModel GetByBarCodeOrName(string text)
		//{
		//    var resultView = new ResultViewModel();
		//    resultView.Status = false;
		//    var data = _repoProduct.GetAllAsNoTracking().Where(p => p.Name == text || p.BarCodeText.Trim().ToLower() == text.Trim().ToLower() || p.ProductUnits.Any(x=>x.UnitBarcodeText.Trim().ToLower() == text.Trim().ToLower()) && p.IsActive && !p.IsDeleted).Select(x => new
		//    {
		//        ID = x.ID,
		//        Name = x.Name,
		//        BarCodeText = x.BarCodeText,
		//        QtyInStock = x.QtyInStock ==null? 0 : x.QtyInStock,
		//        GroupId = x.GroupId,
		//        ProductImages = x.Attachments.ToList(),
		//        GroupName = x.Group.Name,
		//        ImagePath = x.Image,
		//        Description = x.Description,
		//        IdUnitOfQty = x.IdUnitOfQty,
		//        NameUnitOfQty = x.NameUnitOfQty,
		//        GetProductUnits = x.ProductUnits.Where(c => c.IsActive && !c.IsDeleted).Select(c => new ProductUnitsDTO
		//        {
		//            ID = c.ID,
		//            ConversionFactor = c.ConversionFactor,
		//            PurchasingPrice = c.PurchasingPrice,
		//            SellingPrice = c.SellingPrice,
		//            UnitBarcodePath = string.Concat("\\ProductsBarCode\\UnitsBarCode\\", c.UnitBarcodePath),
		//            UnitBarcodeText = c.UnitBarcodeText,
		//            UnitId = c.UnitId
		//        }).ToArray()
		//    }).FirstOrDefault();

		//    if (data != null)
		//    {
		//        resultView.Status = true;
		//        resultView.Data = data;
		//    }
		//    else
		//    {
		//        resultView.Status = false;
		//        resultView.Message = AppConstants.Messages.ProductByNameNotFound;
		//    }

		//    return resultView;
		//}
		public ResultViewModel GetByProductBarCode(string barcode)
		{
			var resultView = new ResultViewModel();
			resultView.Status = false;
			if (barcode != null)
			{
				var data = _repoProduct.GetAllAsNoTracking().Include(x => x.ProductUnits).ThenInclude(x => x.Unit)
			   .Where(p => (p.BarCodeText.Trim().ToLower() == barcode.Trim().ToLower() || p.ProductUnits.Any(x => x.UnitBarcodeText.Trim().ToLower() == barcode.Trim().ToLower())) && p.IsActive && !p.IsDeleted)
			   .Select(p => new ProductDTO
			   {
				   ID = p.ID,
				   Name = p.Name,
				   BarCodeText = p.BarCodeText,
				   GroupId = p.GroupId,
				   QtyInStock = p.QtyInStock,
				   IdUnitOfQty = p.IdUnitOfQty,
				   NameUnitOfQty = p.NameUnitOfQty,
				   SalePrice = p.ProductUnits.Where(x => x.UnitBarcodeText.Trim() == barcode.Trim()).Select(x => x.SellingPrice).FirstOrDefault(),
				   GetQtyInStock = p.QtyInStock / p.ProductUnits.Where(x => x.UnitBarcodeText.Trim() == barcode.Trim()).Select(x => x.ConversionFactor).FirstOrDefault(),
				   GetProductUnits = p.ProductUnits.Where(c => c.IsActive && !c.IsDeleted).Select(c => new ProductUnitsDTO
				   {
					   ID = c.ID,
					   ConversionFactor = c.ConversionFactor,
					   PurchasingPrice = c.PurchasingPrice,
					   SellingPrice = c.SellingPrice,
					   UnitBarcodeText = c.UnitBarcodeText,
					   UnitId = c.UnitId,
					   UnitName = c.Unit.Name
				   }).ToArray(),
				   QtyInStockStr = p.ProductUnits.Where(x => x.UnitBarcodeText.Trim() == barcode.Trim()).Select(x => x.Unit.Name).FirstOrDefault() ?? ""

			   }).FirstOrDefault();

				if (data != null)
				{
					if (barcode.Trim().ToLower() != data.BarCodeText.Trim().ToLower())
					{
						var currentProduct = data.GetProductUnits.Where(x => x.UnitBarcodeText.Trim() == barcode.Trim()).FirstOrDefault();
						data.BarCodeText = currentProduct.UnitBarcodeText;
						data.BarCodePath = currentProduct.UnitBarcodePath;
						data.IdUnitOfQty = currentProduct.UnitId;
						data.NameUnitOfQty = currentProduct.UnitName;
						data.SalePrice = currentProduct.SellingPrice;
						data.ConversionFactor = currentProduct.ConversionFactor;

					}

					var conversionFactor = data.GetProductUnits.Where(x => x.UnitId == data.IdUnitOfQty).FirstOrDefault().ConversionFactor;
					conversionFactor = conversionFactor ?? 0;
					var qtyStock = data.QtyInStock ?? 0;

					if (conversionFactor == 0 || qtyStock == 0)
					{

						data.QtyInStockStr = string.Join(" - ", Math.Round(0.0, 2), data.QtyInStockStr);

					}
					else
					{
						var qtyStr = qtyStock / conversionFactor;
						data.QtyInStockStr = string.Join(" - ", Math.Round(qtyStr.Value, 2), data.QtyInStockStr);
					}
					resultView.Status = true;
					resultView.Data = data;
				}
				else
				{
					resultView.Message = AppConstants.Messages.ProductByBarCodeNotFound;
				}
			}
			else
			{
				resultView.Status = true;
				resultView.Data = null;
			}
			return resultView;
		}
		public ResultViewModel GetByProductBarCodeAndStockId(string barcode, Guid StockId)
		{
			var resultView = new ResultViewModel();
			resultView.Status = false;
			if (StockId == Guid.Empty)
			{
				resultView.Message = "اختر المخزن";
				return resultView;
			}
			if (barcode != null)
			{
				var data = _repoProduct.GetAllAsNoTracking().Include(x => x.ProductUnits).ThenInclude(x => x.Unit)
			   .Where(p => (p.BarCodeText.Trim().ToLower() == barcode.Trim().ToLower() || p.ProductUnits.Any(x => x.UnitBarcodeText.Trim().ToLower() == barcode.Trim().ToLower())) && p.IsActive && !p.IsDeleted)
			   .Where(p => p.StockProducts.Any(x => x.StockId == StockId))
			   .Select(p => new ProductDTO
			   {
				   ID = p.ID,
				   Name = p.Name,
				   BarCodeText = p.BarCodeText,
				   GroupId = p.GroupId,
				   QtyInStock = p.QtyInStock,
				   IdUnitOfQty = p.IdUnitOfQty,
				   NameUnitOfQty = p.NameUnitOfQty,
				   SalePrice = p.ProductUnits.Where(x => x.UnitBarcodeText.Trim() == barcode.Trim()).Select(x => x.SellingPrice).FirstOrDefault(),
				   GetQtyInStock = p.QtyInStock / p.ProductUnits.Where(x => x.UnitBarcodeText.Trim() == barcode.Trim()).Select(x => x.ConversionFactor).FirstOrDefault(),
				   GetProductUnits = p.ProductUnits.Where(c => c.IsActive && !c.IsDeleted).Select(c => new ProductUnitsDTO
				   {
					   ID = c.ID,
					   ConversionFactor = c.ConversionFactor,
					   PurchasingPrice = c.PurchasingPrice,
					   SellingPrice = c.SellingPrice,
					   UnitBarcodeText = c.UnitBarcodeText,
					   UnitId = c.UnitId,
					   UnitName = c.Unit.Name
				   }).ToArray(),
				   QtyInStockStr = p.ProductUnits.Where(x => x.UnitBarcodeText.Trim() == barcode.Trim()).Select(x => x.Unit.Name).FirstOrDefault() ?? ""

			   }).FirstOrDefault();

				if (data != null)
				{
					if (barcode.Trim().ToLower() != data.BarCodeText.Trim().ToLower())
					{
						var currentProduct = data.GetProductUnits.Where(x => x.UnitBarcodeText.Trim() == barcode.Trim()).FirstOrDefault();
						data.BarCodeText = currentProduct.UnitBarcodeText;
						data.BarCodePath = currentProduct.UnitBarcodePath;
						data.IdUnitOfQty = currentProduct.UnitId;
						data.NameUnitOfQty = currentProduct.UnitName;
						data.SalePrice = currentProduct.SellingPrice;
						data.ConversionFactor = currentProduct.ConversionFactor;

					}

					var conversionFactor = data.GetProductUnits.Where(x => x.UnitId == data.IdUnitOfQty).FirstOrDefault().ConversionFactor;
					conversionFactor = conversionFactor ?? 0;
					var qtyStock = data.QtyInStock ?? 0;

					if (conversionFactor == 0 || qtyStock == 0)
					{

						data.QtyInStockStr = string.Join(" - ", Math.Round(0.0, 2), data.QtyInStockStr);

					}
					else
					{
						var qtyStr = qtyStock / conversionFactor;
						data.QtyInStockStr = string.Join(" - ", Math.Round(qtyStr.Value, 2), data.QtyInStockStr);
					}
					resultView.Status = true;
					resultView.Data = data;
				}
				else
				{
					resultView.Message = "هذا المنتج غير موجود بالمخزن المحدد";
				}
			}
			else
			{
				resultView.Status = true;
				resultView.Data = null;
			}
			return resultView;
		}

		public ResultViewModel GetProductPriceByBarCode(string barcode)
		{
			var resultView = new ResultViewModel();
			resultView.Status = false;
			if (barcode != null)
			{
				var data = _repoProductUnit.GetAllAsNoTracking()
			   .Where(p => (p.UnitBarcodeText.Trim().ToLower() == barcode.Trim().ToLower()) && p.IsActive && !p.IsDeleted)
			   .Select(p => new
			   {
				   ProductId = p.ProductId,
				   BarCode = p.UnitBarcodeText,
				   ProductName = p.Product.Name,
				   UnitId = p.UnitId,
				   UnitName = _repoUnit.GetById(p.UnitId).Name,
				   SalePrice = p.SellingPrice,
				   PurchasePrice = p.PurchasingPrice,
				   StockName = _repoStock.GetById(p.Product.StockProducts.FirstOrDefault().StockId).Name,
				   StockId = p.Product.StockProducts.FirstOrDefault().StockId
			   }).FirstOrDefault();
				if (data != null)
				{
					resultView.Status = true;
					resultView.Data = data;
					return resultView;
				}
				else
				{
					resultView.Status = false;
					resultView.Message = "هذا المنتج غير موجود";
					return resultView;
				}

			}
			else
			{
				resultView.Status = true;
				resultView.Data = null;
			}
			return resultView;
		}
		public ResultViewModel GetProductPriceByProductName(string barcode)
		{
			var resultView = new ResultViewModel();
			resultView.Status = false;
			if (barcode != null)
			{
				var data = _repoProductUnit.GetAllAsNoTracking().Include(x => x.Product)
			   .Where(p => (p.Product.Name.Trim().ToLower() == barcode.Trim().ToLower()) && p.IsActive && !p.IsDeleted)
			   .Select(p => new
			   {
				   ProductId = p.ProductId,
				   BarCode = p.UnitBarcodeText,
				   ProductName = p.Product.Name,
				   UnitId = p.Product.IdUnitOfQty,
				   UnitName = _repoUnit.GetById(p.Product.IdUnitOfQty).Name,
				   SalePrice = p.SellingPrice,
				   PurchasePrice = p.PurchasingPrice,
				   StockName = _repoStock.GetById(p.Product.StockProducts.FirstOrDefault().StockId).Name,
				   StockId = p.Product.StockProducts.FirstOrDefault().StockId
			   }).FirstOrDefault();
				if (data != null)
				{
					resultView.Status = true;
					resultView.Data = data;
					return resultView;
				}
				else
				{
					resultView.Status = false;
					resultView.Message = "هذا المنتج غير موجود";
					return resultView;
				}

			}
			else
			{
				resultView.Status = true;
				resultView.Data = null;
			}
			return resultView;
		}

		public ResultViewModel GetByProductName(string barcode)
		{
			var resultView = new ResultViewModel();
			resultView.Status = false;
			if (barcode != null)
			{
				var data = _repoProduct.GetAllAsNoTracking().Include(x => x.ProductUnits).ThenInclude(x => x.Unit)
			   .Where(p => (p.Name.Trim().Contains(barcode.Trim())) && p.IsActive && !p.IsDeleted)
			   .Select(p => new ProductDTO
			   {
				   ID = p.ID,
				   Name = p.Name,
				   BarCodeText = p.BarCodeText,
				   BarCodePath = string.Concat("\\ProductsBarCode\\", p.BarCodePath),
				   GroupId = p.GroupId,
				   QtyInStock = p.QtyInStock,
				   IdUnitOfQty = p.IdUnitOfQty,
				   NameUnitOfQty = p.NameUnitOfQty,
				   SalePrice = p.ProductUnits.Where(x => x.UnitId == p.IdUnitOfQty).Select(x => x.SellingPrice).FirstOrDefault(),
				   ConversionFactor = p.ProductUnits.Where(c => c.IsActive && !c.IsDeleted && c.UnitId == p.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault(),
				   GetQtyInStock = p.QtyInStock,
				   GetProductUnits = p.ProductUnits.Where(c => c.IsActive && !c.IsDeleted).Select(c => new ProductUnitsDTO
				   {
					   ID = c.ID,
					   ConversionFactor = c.ConversionFactor,
					   PurchasingPrice = c.PurchasingPrice,
					   SellingPrice = c.SellingPrice,
					   UnitBarcodePath = string.Concat("\\ProductsBarCode\\UnitsBarCode\\", c.UnitBarcodePath),
					   UnitBarcodeText = c.UnitBarcodeText,
					   UnitId = c.UnitId,
					   UnitName = c.Unit.Name
				   }).ToArray(),
				   QtyInStockStr = p.ProductUnits.Where(x => x.UnitId == p.IdUnitOfQty).Select(x => x.Unit.Name).FirstOrDefault() ?? ""
			   }).FirstOrDefault();

				if (data != null)
				{
					var conversionFactor = data.ConversionFactor ?? 0;
					var qtyStock = data.QtyInStock ?? 0;
					if (conversionFactor == 0 || qtyStock == 0)
					{

						data.QtyInStockStr = string.Join(" - ", Math.Round(0.0, 2), data.QtyInStockStr);

					}
					else
					{
						var qtyStr = qtyStock / conversionFactor;
						data.QtyInStockStr = string.Join(" - ", Math.Round(qtyStr, 2), data.QtyInStockStr);
					}
					//if (barcode.Trim().ToLower() != data.BarCodeText.Trim().ToLower())
					//{
					//    var currentProduct = data.GetProductUnits.Where(x => x.UnitBarcodeText.Trim() == barcode.Trim()).FirstOrDefault();
					//    data.BarCodeText = currentProduct.UnitBarcodeText;
					//    data.BarCodePath = currentProduct.UnitBarcodePath;
					//    data.IdUnitOfQty = currentProduct.UnitId;
					//    data.NameUnitOfQty = currentProduct.UnitName;
					//    data.SalePrice = currentProduct.SellingPrice;
					//}
					resultView.Status = true;
					resultView.Data = data;
				}
				else
				{
					resultView.Message = AppConstants.Messages.ProductByNameNotFound;
				}
			}
			else
			{
				resultView.Status = true;
				resultView.Data = null;
			}
			return resultView;
		}

		public ResultViewModel GetByProductNameAndStockId(string barcode, Guid StockId)
		{
			var resultView = new ResultViewModel();
			resultView.Status = false;
			if (barcode != null)
			{
				if (StockId == Guid.Empty)
				{
					resultView.Message = "اختر المخزن";
					return resultView;
				}
				var data = _repoProduct.GetAllAsNoTracking().Include(x => x.ProductUnits).ThenInclude(x => x.Unit)
			   .Where(p => (p.Name.Trim().Contains(barcode.Trim())) && p.IsActive && !p.IsDeleted)
			   .Where(p => p.StockProducts.Any(x => x.StockId == StockId))
			   .Select(p => new ProductDTO
			   {
				   ID = p.ID,
				   Name = p.Name,
				   BarCodeText = p.BarCodeText,
				   BarCodePath = string.Concat("\\ProductsBarCode\\", p.BarCodePath),
				   GroupId = p.GroupId,
				   QtyInStock = p.QtyInStock,
				   IdUnitOfQty = p.IdUnitOfQty,
				   NameUnitOfQty = p.NameUnitOfQty,
				   SalePrice = p.ProductUnits.Where(x => x.UnitId == p.IdUnitOfQty).Select(x => x.SellingPrice).FirstOrDefault(),
				   ConversionFactor = p.ProductUnits.Where(c => c.IsActive && !c.IsDeleted && c.UnitId == p.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault(),
				   GetQtyInStock = p.QtyInStock,
				   GetProductUnits = p.ProductUnits.Where(c => c.IsActive && !c.IsDeleted).Select(c => new ProductUnitsDTO
				   {
					   ID = c.ID,
					   ConversionFactor = c.ConversionFactor,
					   PurchasingPrice = c.PurchasingPrice,
					   SellingPrice = c.SellingPrice,
					   UnitBarcodePath = string.Concat("\\ProductsBarCode\\UnitsBarCode\\", c.UnitBarcodePath),
					   UnitBarcodeText = c.UnitBarcodeText,
					   UnitId = c.UnitId,
					   UnitName = c.Unit.Name
				   }).ToArray(),
				   QtyInStockStr = p.ProductUnits.Where(x => x.UnitId == p.IdUnitOfQty).Select(x => x.Unit.Name).FirstOrDefault() ?? ""
			   }).FirstOrDefault();

				if (data != null)
				{
					var conversionFactor = data.ConversionFactor ?? 0;
					var qtyStock = data.QtyInStock ?? 0;
					if (conversionFactor == 0 || qtyStock == 0)
					{

						data.QtyInStockStr = string.Join(" - ", Math.Round(0.0, 2), data.QtyInStockStr);

					}
					else
					{
						var qtyStr = qtyStock / conversionFactor;
						data.QtyInStockStr = string.Join(" - ", Math.Round(qtyStr, 2), data.QtyInStockStr);
					}

					resultView.Status = true;
					resultView.Data = data;
				}
				else
				{
					resultView.Message = "هذا المنتج غير موجود بالمخزن المحدد";
				}
			}
			else
			{
				resultView.Status = true;
				resultView.Data = null;
			}
			return resultView;
		}
		public JsonResult SearchByName(string name)
		{
			var allData = _repoProduct.GetAllAsNoTracking()
				.Where(x => x.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)).Select(x => x.Name);
			return new JsonResult(allData);
		}

		public ResultViewModel GetProductDataByUnitId(Guid? productId, Guid? unitId)
		{
			var resultView = new ResultViewModel();
			resultView.Status = false;
			if (unitId != null)
			{
				var data = _repoProduct.GetAllAsNoTracking().Include(x => x.ProductUnits).ThenInclude(x => x.Unit)
			   .Where(p => (p.ProductUnits.Any(x => x.UnitId == unitId) && p.ID == productId) && p.IsActive && !p.IsDeleted)
			   .Select(p => new ProductDTO
			   {
				   ID = p.ID,
				   Name = p.Name,
				   BarCodeText = p.BarCodeText,
				   BarCodePath = string.Concat("\\ProductsBarCode\\", p.BarCodePath),
				   GroupId = p.GroupId,
				   IdUnitOfQty = p.IdUnitOfQty,
				   NameUnitOfQty = p.NameUnitOfQty,
				   ConversionFactor = p.ProductUnits.Where(x => x.UnitId == unitId).Select(x => x.ConversionFactor).FirstOrDefault(),
				   GetQtyInStock = p.QtyInStock,
				   GetProductUnits = p.ProductUnits.Where(c => c.IsActive && !c.IsDeleted).Select(c => new ProductUnitsDTO
				   {
					   ID = c.ID,
					   ConversionFactor = c.ConversionFactor,
					   PurchasingPrice = c.PurchasingPrice,
					   SellingPrice = c.SellingPrice,
					   UnitBarcodePath = string.Concat("\\ProductsBarCode\\UnitsBarCode\\", c.UnitBarcodePath),
					   UnitBarcodeText = c.UnitBarcodeText,
					   UnitId = c.UnitId,
					   UnitName = c.Unit.Name
				   }).ToArray(),
				   QtyInStockStr = p.ProductUnits.Where(x => x.UnitId == unitId).Select(x => x.Unit.Name).FirstOrDefault() ?? ""

			   }).FirstOrDefault();

				if (data != null)
				{
					if (unitId != data.IdUnitOfQty)
					{
						var currentProduct = data.GetProductUnits.Where(x => x.UnitId == unitId).FirstOrDefault();
						data.BarCodeText = currentProduct.UnitBarcodeText;
						data.BarCodePath = currentProduct.UnitBarcodePath;
						data.IdUnitOfQty = currentProduct.UnitId;
						data.NameUnitOfQty = currentProduct.UnitName;
						data.SalePrice = currentProduct.SellingPrice;

						data.ConversionFactor = currentProduct.ConversionFactor;
					}
					var conversionFactor = data.ConversionFactor ?? 0;
					var qtyStock = data.GetQtyInStock ?? 0;
					if (conversionFactor == 0 || qtyStock == 0)
					{

						data.QtyInStockStr = string.Join(" - ", Math.Round(0.0, 2), data.QtyInStockStr);

					}
					else
					{
						var qtyStr = qtyStock / conversionFactor;
						data.QtyInStockStr = string.Join(" - ", Math.Round(qtyStr, 2), data.QtyInStockStr);
					}
					//data.QtyInStockStr = string.Join(" - ", Math.Round((data.GetQtyInStock.Value / data.ConversionFactor.Value), 2), data.QtyInStockStr);
					resultView.Status = true;
					resultView.Data = data;
				}
				else
				{
					resultView.Message = AppConstants.Messages.ProductByNameNotFound;
				}
			}
			else
			{
				resultView.Status = true;
				resultView.Data = null;
			}
			return resultView;
		}

		public IQueryable<SelectListDTO> GetSelect()
		{
			var data = _repoProduct.GetAllAsNoTracking().Where(x => x.IsActive && !x.IsDeleted).Select(p => new SelectListDTO()
			{
				Value = p.ID,
				Text = p.Name
			});
			return data.Distinct();

		}
		public IQueryable<ProductDTO> GetAllByGroupId(Guid? id)
		{
			return _repoProduct.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive && x.GroupId == id)
				.Select(x => new ProductDTO
				{

					ID = x.ID,
					Name = x.Name,
					BarCodeText = x.BarCodeText,
					GroupId = x.GroupId,
					QtyInStock = x.QtyInStock,
					ProductImages = x.Attachments.ToList(),
					Description = x.Description,
					GroupName = x.Group.Name,
					ImagePath = x.Image,
					GetProductUnits = x.ProductUnits.Where(c => c.IsActive && !c.IsDeleted).Select(c => new ProductUnitsDTO
					{
						ID = c.ID,
						ConversionFactor = c.ConversionFactor,
						PurchasingPrice = c.PurchasingPrice,
						SellingPrice = c.SellingPrice,
						UnitBarcodePath = string.Concat("\\ProductsBarCode\\UnitsBarCode\\", c.UnitBarcodePath),
						UnitBarcodeText = c.UnitBarcodeText,
						UnitId = c.UnitId
					}).ToArray(),
					GetQtyInStock = x.QtyInStock * x.ProductUnits.Where(xx => xx.UnitId == x.IdUnitOfQty).Select(c => c.ConversionFactor).FirstOrDefault()

				});
		}
		public IQueryable<ProductDTO> GetAll()
		{

			return _repoProduct.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive)
				.Select(x => new ProductDTO
				{
					ID = x.ID,
					Name = x.Name,
					BarCodeText = x.BarCodeText,
					GroupId = x.GroupId,
					QtyInStock = x.QtyInStock,
					ProductImages = x.Attachments.ToList(),
					GroupName = x.Group.Name,
					ImagePath = x.Image,
					Description = x.Description,
					GetProductUnits = x.ProductUnits.Where(c => c.IsActive && !c.IsDeleted).Select(c => new ProductUnitsDTO
					{
						ID = c.ID,
						ConversionFactor = c.ConversionFactor,
						PurchasingPrice = c.PurchasingPrice,
						SellingPrice = c.SellingPrice,
						UnitBarcodePath = string.Concat("\\ProductsBarCode\\UnitsBarCode\\", c.UnitBarcodePath),
						UnitBarcodeText = c.UnitBarcodeText,
						UnitId = c.UnitId
					}).ToArray(),
					GetQtyInStock = x.QtyInStock * x.ProductUnits.Where(xx => xx.UnitId == x.IdUnitOfQty).Select(c => c.ConversionFactor).FirstOrDefault()

				});
		}

		public DataTableResponse LoadData(DataTableRequest mdl)
		{
			var data = _repoProduct.ExecuteStoredProcedure<ProductTableDTO>
				(_spProduct, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}


		#endregion

		#region ProductPrice 
		public ResultViewModel SaveProductPrice(ProductPriceDTO productDto)
		{
			ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };

			var data = _repoProductUnit.GetAll().Where(p => p.ProductId == productDto.ProductId && p.UnitId == productDto.UnitId)
				.Where(p => p.Product.StockProducts.Any(x => x.StockId == productDto.StockId)).FirstOrDefault();
			if (data != null)
			{
				var tbl = data;

				tbl.ModifiedDate = AppDateTime.Now;
				tbl.ModifiedBy = _repoProduct.UserId;
				tbl.SellingPrice = productDto.SalePrice;
				tbl.PurchasingPrice = productDto.PurchasePrice;


				if (_repoProductUnit.Update(tbl))
				{

					resultViewModel.Status = true;
					resultViewModel.Message = AppConstants.Messages.SavedSuccess;
				}
			}
			else
			{
				resultViewModel.Message = AppConstants.Messages.SavedFailed;
			}

			return resultViewModel;
		}
		#endregion
		#region Save 
		public ResultViewModel Save(ProductDTO productDto)
		{
			ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };
			//var BarCodeFoldeName = "\\ProductsBarCode\\";
			//var UnitBarCodeFoldeName = "\\ProductsBarCode\\UnitsBarCode\\";
			var ImagesFoldeName = "\\Images\\Products\\";
			if (productDto.ProductUnits != null && productDto.ProductUnits.Count() > 0)
			{
				var allUnits = productDto.ProductUnits.ToList();
				foreach (var item in allUnits)
				{
					if (item.UnitId == null || string.IsNullOrEmpty(item.UnitBarcodeText) || item.ConversionFactor == 0)
					{
						resultViewModel.Status = false;
						resultViewModel.Message = $"تاكد من ادخال معامل التحويل والباركود لكل وحدة من وحدات المنتج";
						return resultViewModel;
					}
					if (allUnits.Where(x => x.UnitId == item.UnitId).Count() > 1)
					{
						resultViewModel.Status = false;
						resultViewModel.Message = $"توجد وحدات مكررة في وحدات المنتج";
						return resultViewModel;
					}
				}
			}
			var data = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == productDto.ID).FirstOrDefault();
			if (data != null)
			{

				var oldProductUnits = data.ProductUnits;

				var existMdl = _repoProduct.GetAllAsNoTracking().Where(p => !p.IsDeleted)
					.Where(p => p.ID != data.ID && p.Name.Trim().ToLower() == productDto.Name.Trim().ToLower()).FirstOrDefault();
				if (existMdl != null)
				{
					resultViewModel.Message = "اسم الصنف مستخدم من قبل صنف اخر";
					return resultViewModel;

				}

				var existBarCode = _repoProduct.GetAllAsNoTracking().Where(p => !p.IsDeleted)
					.Where(p => p.ID != data.ID && p.BarCodeText.Trim().ToLower() == productDto.BarCodeText.Trim().ToLower()).FirstOrDefault();
				if (existBarCode != null)
				{
					resultViewModel.Message = "باركود الصنف مستخدم من قبل صنف اخر";
					return resultViewModel;
				}

				if (_productUnit.GetAllAsNoTracking().Any(x => x.ProductId != productDto.ID && x.UnitBarcodeText.Trim() == productDto.BarCodeText.Trim()))
				{
					resultViewModel.Message = "باركود الصنف مستخدم من قبل وحدة منتج أخر";
					return resultViewModel;
				}
				if (productDto.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == productDto.BarCodeText.Trim() && x.UnitId != productDto.IdUnitOfQty))
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "باركود المنتج متعارض  مع أحد باركودات وحدات المنتج";
					return resultViewModel;
				}
				var allAnotherUnitBarcode = _productUnit.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.ProductId != productDto.ID);
				foreach (var unit in productDto.ProductUnits)
				{
					var existBarcode = allAnotherUnitBarcode.Where(x => x.UnitBarcodeText.Trim() == unit.UnitBarcodeText.Trim()).FirstOrDefault();
					if (existBarcode != null)
					{
						resultViewModel.Status = false;
						resultViewModel.Message = "الباركود " + existBarcode.UnitBarcodeText + " مستخدم لوحدة منتج اخر";
						return resultViewModel;
					}
				}


				var tbl = _mapper.Map<Product>(productDto);
				if (data.IdUnitOfQty != productDto.IdUnitOfQty)
				{
					if (productDto.IdUnitOfQty != null && productDto.IdUnitOfQty != Guid.Empty)
					{
						tbl.NameUnitOfQty = _repoUnit.GetById(productDto.IdUnitOfQty).Name;
					}
				}
				else
				{
					tbl.NameUnitOfQty = data.NameUnitOfQty;
				}

				if (string.IsNullOrEmpty(productDto.BarCodeText))
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "باركود المنتج مطلوب";
					return resultViewModel;
				}
				//else
				//{
				//	if(tbl.BarCodeText.Trim() != data.BarCodeText.Trim())
				//	{
				//                    tbl.BarCodePath = _helperBll.GenerateBarcode(productDto.BarCodeText, BarCodeFoldeName);
				//                    tbl.BarCodeText = productDto.BarCodeText;
				//                    if (!string.IsNullOrEmpty(data.BarCodePath))
				//                    {
				//                        File.Delete(_webHostEnvironment + data.BarCodePath);
				//                    }
				//                }
				//}
				if (tbl.QtyInStock == 0 || tbl.QtyInStock == null)
				{
					tbl.QtyInStock = 10000000;
				}
				tbl.AddedBy = data.AddedBy;
				tbl.CreatedDate = data.CreatedDate;
				tbl.ModifiedDate = AppDateTime.Now;
				tbl.ModifiedBy = _repoProduct.UserId;

				if (productDto.Image != null && productDto.Image.Length > 0)
				{
					tbl.Image = _helperBll.UploadFile(productDto.Image, ImagesFoldeName);
				}
				var baseUnitExist = productDto.ProductUnits.Where(x => x.UnitId == productDto.IdUnitOfQty).FirstOrDefault();
				if (baseUnitExist != null)
				{
					if (baseUnitExist.UnitBarcodeText.Trim() != tbl.BarCodeText.Trim())
					{
						resultViewModel.Status = false;
						resultViewModel.Message = $"باركود المنتج يجب أن يطابق باركود الوحده الأساسية";
						return resultViewModel;
					}
				}

				//if (baseUnitExist == null)
				//{
				//    resultViewModel.Status = false;
				//    resultViewModel.Message = $"من فضلك تأكد من إدخال الوحده {tbl.NameUnitOfQty} في الوحدات الخاصه بالمنتج";
				//    return resultViewModel;
				//}
				//else
				//{
				//    if (baseUnitExist.UnitBarcodeText.Trim() != tbl.BarCodeText.Trim())
				//    {
				//        resultViewModel.Status = false;
				//        resultViewModel.Message = $"باركود المنتج يجب أن يطابق باركود الوحده الأساسية";
				//        return resultViewModel;
				//    }
				//}


				if (_repoProduct.Update(tbl))
				{
					//_productUnit.ExecuteSQLQuery<int>("UPDATE [Guide].[ProductUnits] SET [IsDeleted] = 1 WHERE [ProductId]='" + tbl.ID + "'", CommandType.Text);
					var NewRecords = new List<ProductUnit>();
					var oldUnits = _productUnit.GetAll().Where(x => x.ProductId == tbl.ID).ToList();
					_productUnit.DeleteRange(oldUnits);
					//foreach (var unit in oldUnits)
					//{
					//	if (unit.UnitBarcodeText.Trim() == data.BarCodeText.Trim() && unit.UnitId == data.IdUnitOfQty)
					//	{
					//		_productUnit.Delete(unit);
					//	}
					//	else
					//	{
					//		unit.IsDeleted = true;
					//		_productUnit.Update(unit);
					//	}
					//}

					if (productDto.ProductUnits != null && productDto.ProductUnits.Length > 0)
					{
						//var baseUnit = productDto.ProductUnits.Where(x => x.UnitId == tbl.IdUnitOfQty).FirstOrDefault();
						/// اضافة الوحده الاساسية
						var baseUnit = new ProductUnit
						{
							ProductId = tbl.ID,
							ConversionFactor = 1,
							PurchasingPrice = productDto.BaseUnitPurchasePrice,
							SellingPrice = productDto.BaseUnitSalePrice,
							UnitBarcodeText = tbl.BarCodeText,
							UnitId = tbl.IdUnitOfQty
						};
						NewRecords.Add(baseUnit);

						/// اضافة جميع الوحدات في الجدول ماعدا الوحده الاساسية لانها تمت اضافتها من قبل 
						foreach (var unit in productDto.ProductUnits)
						{
							if (unit.UnitId != tbl.IdUnitOfQty)
							{
								var newR = new ProductUnit
								{
									ID = unit.ID == null ? Guid.NewGuid() : unit.ID.Value,
									ProductId = tbl.ID,
									ConversionFactor = unit.ConversionFactor,
									PurchasingPrice = unit.PurchasingPrice,
									SellingPrice = unit.SellingPrice,
									UnitBarcodeText = unit.UnitBarcodeText,
									UnitId = unit.UnitId
								};
								if (newR.UnitId == tbl.IdUnitOfQty)
								{
									newR.UnitBarcodeText = tbl.BarCodeText;
								}
								//newR.UnitBarcodePath = _helperBll.GenerateBarcode(unit.UnitBarcodeText, UnitBarCodeFoldeName);
								NewRecords.Add(newR);
								//}
							}

						}
					}
					else
					{
						var baseUnit = productDto.ProductUnits.Where(x => x.UnitId == tbl.IdUnitOfQty).FirstOrDefault();

						if (baseUnit == null)
						{
							var newR = new ProductUnit
							{
								ProductId = tbl.ID,
								ConversionFactor = 1,
								PurchasingPrice = productDto.BaseUnitPurchasePrice,
								SellingPrice = productDto.BaseUnitSalePrice,
								UnitBarcodeText = tbl.BarCodeText,
								UnitId = tbl.IdUnitOfQty
							};
							NewRecords.Add(newR);
						}
					}
					_productUnit.InsertRange(NewRecords);


					if (productDto.StockId != null && productDto.StockId != Guid.Empty)
					{
						var oldStocks = _stockProduct.GetAll().Where(x => x.ProductId == tbl.ID && !x.IsDeleted).FirstOrDefault();
						if (oldStocks != null)
						{
							oldStocks.IsDeleted = true;
							_stockProduct.Update(oldStocks);
						}

						//_stockProduct.ExecuteSQLQuery<int>("UPDATE [Guide].[StockProducts] SET [IsDeleted] = 1  WHERE ProductId='" + tbl.ID + "'", CommandType.Text);

						var newStockProduct = new StockProduct
						{
							StockId = productDto.StockId,
							ProductId = tbl.ID
						};
						_stockProduct.Insert(newStockProduct);
					}

					resultViewModel.Status = true;
					resultViewModel.Message = AppConstants.Messages.SavedSuccess;

				}
			}
			else
			{
				if (_repoProduct.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.Name.Trim().ToLower() == productDto.Name.Trim().ToLower()).FirstOrDefault() != null)
				{
					resultViewModel.Message = "اسم الصنف مستخدم من قبل صنف اخر";
					return resultViewModel;
				}

				if (_repoProduct.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.BarCodeText.Trim() == productDto.BarCodeText.Trim()).FirstOrDefault() != null)
				{
					resultViewModel.Message = "باركود الصنف مستخدم من قبل صنف اخر";
					return resultViewModel;
				}

				if (_productUnit.GetAllAsNoTracking().Any(x => x.ProductId != productDto.ID && x.UnitBarcodeText.Trim() == productDto.BarCodeText.Trim()))
				{
					resultViewModel.Message = "باركود الصنف مستخدم من قبل وحدة منتج أخر";
					return resultViewModel;
				}

				if (productDto.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == productDto.BarCodeText.Trim() && x.UnitId != productDto.IdUnitOfQty))
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "باركود المنتج متعارض  مع أحد باركودات وحدات المنتج";
					return resultViewModel;
				}
				var allAnotherUnitBarcode = _productUnit.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.ProductId != productDto.ID);
				foreach (var unit in productDto.ProductUnits)
				{
					var existBarcode = allAnotherUnitBarcode.Where(x => x.UnitBarcodeText.Trim() == unit.UnitBarcodeText.Trim()).FirstOrDefault();
					if (existBarcode != null)
					{
						resultViewModel.Status = false;
						resultViewModel.Message = "الباركود " + existBarcode.UnitBarcodeText + " مستخدم لوحدة منتج اخر";
						return resultViewModel;
					}
				}

				var tbl = _mapper.Map<Product>(productDto);
				if (tbl.QtyInStock == 0 || tbl.QtyInStock == null)
				{
					tbl.QtyInStock = 10000000;
				}

				if (productDto.IdUnitOfQty != null && productDto.IdUnitOfQty != Guid.Empty)
				{
					tbl.NameUnitOfQty = _repoUnit.GetById(productDto.IdUnitOfQty).Name;
				}
				if (!string.IsNullOrEmpty(productDto.BarCodeText))
				{
					//tbl.BarCodePath = _helperBll.GenerateBarcode(productDto.BarCodeText, BarCodeFoldeName);
					tbl.BarCodeText = productDto.BarCodeText;
				}
				else
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "باركود الصنف مطلوب";
					return resultViewModel;
				}
				tbl.AddedBy = _repoProduct.UserId;
				if (productDto.Image != null && productDto.Image.Length > 0)
				{
					tbl.Image = _helperBll.UploadFile(productDto.Image, ImagesFoldeName);
				}

				var baseUnitExist = productDto.ProductUnits.Where(x => x.UnitId == productDto.IdUnitOfQty).FirstOrDefault();
				if (baseUnitExist != null)
				{
					if (baseUnitExist.UnitBarcodeText.Trim() != tbl.BarCodeText.Trim())
					{
						resultViewModel.Status = false;
						resultViewModel.Message = $"باركود المنتج يجب أن يطابق باركود الوحده الأساسية";
						return resultViewModel;
					}
				}

				//var baseUnitExist = productDto.ProductUnits.Where(x => x.UnitId == productDto.IdUnitOfQty).FirstOrDefault();
				//if (baseUnitExist == null)
				//{
				//    resultViewModel.Status = false;
				//    resultViewModel.Message = $"من فضلك تأكد من إدخال الوحده {tbl.NameUnitOfQty} في الوحدات الخاصه بالمنتج";
				//    return resultViewModel;
				//}
				//else
				//{
				//    if (baseUnitExist.UnitBarcodeText.Trim() != tbl.BarCodeText.Trim())
				//    {
				//        resultViewModel.Status = false;
				//        resultViewModel.Message = $"باركود المنتج يجب أن يطابق باركود الوحده الأساسية";
				//        return resultViewModel;
				//    }
				//}

				if (_repoProduct.Insert(tbl))
				{
					var NewRecords = new List<ProductUnit>();
					if (productDto.ProductUnits != null && productDto.ProductUnits.Length > 0)
					{
						//var baseUnit = productDto.ProductUnits.Where(x => x.UnitId == tbl.IdUnitOfQty).FirstOrDefault();

						//if (baseUnit == null)
						//{
						var baseUnit = new ProductUnit
						{
							ProductId = tbl.ID,
							ConversionFactor = 1,
							PurchasingPrice = productDto.BaseUnitPurchasePrice,
							SellingPrice = productDto.BaseUnitSalePrice,
							UnitBarcodeText = tbl.BarCodeText,
							UnitId = tbl.IdUnitOfQty
						};
						NewRecords.Add(baseUnit);
						//}

						foreach (var unit in productDto.ProductUnits)
						{
							if (unit.UnitId != tbl.IdUnitOfQty)
							{
								var newR = new ProductUnit
								{
									ProductId = tbl.ID,
									ConversionFactor = unit.ConversionFactor,
									PurchasingPrice = unit.PurchasingPrice,
									SellingPrice = unit.SellingPrice,
									UnitBarcodeText = unit.UnitBarcodeText,
									UnitId = unit.UnitId
								};
								if (newR.UnitId == tbl.IdUnitOfQty)
								{
									newR.UnitBarcodeText = tbl.BarCodeText;
								}

								//newR.UnitBarcodePath = _helperBll.GenerateBarcode(unit.UnitBarcodeText, UnitBarCodeFoldeName);
								NewRecords.Add(newR);
							}
						}
					}
					else
					{
						var baseUnit = productDto.ProductUnits.Where(x => x.UnitId == tbl.IdUnitOfQty).FirstOrDefault();

						if (baseUnit == null)
						{
							var newR = new ProductUnit
							{
								ProductId = tbl.ID,
								ConversionFactor = 1,
								PurchasingPrice = productDto.BaseUnitPurchasePrice,
								SellingPrice = productDto.BaseUnitSalePrice,
								UnitBarcodeText = tbl.BarCodeText,
								UnitId = tbl.IdUnitOfQty
							};
							NewRecords.Add(newR);
						}
					}
					_productUnit.InsertRange(NewRecords);

					if (productDto.StockId != Guid.Empty)
					{
						var newStockProduct = new StockProduct
						{
							StockId = productDto.StockId,
							ProductId = tbl.ID
						};
						_stockProduct.Insert(newStockProduct);
					}

					resultViewModel.Status = true;
					resultViewModel.Message = AppConstants.Messages.SavedSuccess;

				}
			}
			return resultViewModel;
		}
		#endregion


		#region Delete
		public ResultViewModel Delete(Guid id)
		{
			ResultViewModel resultViewModel = new ResultViewModel();
			var tbl = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

			if (tbl == null)
			{
				resultViewModel.Status = false;
				resultViewModel.Message = AppConstants.Messages.DeletedFailed;
				return resultViewModel;
			}
			var haveInvoicesP = _repoPurchaseInvoice.GetAllAsNoTracking().Any(p => p.PurchaseInvoiceDetail.Any(p => p.ProductId == id && !p.IsDeleted));
			var haveInvoicesThrowback = _repoPurchaseThrowback.GetAllAsNoTracking().Any(p => p.PurchaseThrowbackDetails.Any(p => p.ProductId == id && !p.IsDeleted));
			//tbl.IsDeleted = true;
			//if (_repoProduct.UserId != Guid.Empty)
			//{
			//	tbl.DeletedBy = _repoProduct.UserId;
			//}
			//tbl.DeletedDate = AppDateTime.Now;
			if (haveInvoicesP || haveInvoicesThrowback)
			{
				resultViewModel.Status = false;
				resultViewModel.Message = "لا يمكن حذف المنتج لانه يوجد له فواتير";
				return resultViewModel;
			}
			tbl.IsDeleted = true;
			tbl.DeletedDate = DateTime.Now;
			tbl.DeletedBy = _repoProduct.UserId;
			var IsSuceess = _repoProduct.Update(tbl);

			resultViewModel.Status = IsSuceess;
			resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


			return resultViewModel;
		}

		public ResultViewModel DeleteImage(Guid id)
		{
			ResultViewModel resultViewModel = new ResultViewModel();
			var tbl = _repoAttatchment.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

			if (tbl == null)
			{
				resultViewModel.Status = false;
				resultViewModel.Message = AppConstants.Messages.DeletedFailed;
				return resultViewModel;
			}

			tbl.IsDeleted = true;
			if (_repoProduct.UserId != Guid.Empty)
			{
				tbl.DeletedBy = _repoProduct.UserId;
			}
			tbl.DeletedDate = AppDateTime.Now;
			var IsSuceess = _repoAttatchment.Update(tbl);

			resultViewModel.Status = IsSuceess;
			resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


			return resultViewModel;
		}
		#endregion


	}
}
