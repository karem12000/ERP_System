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

namespace ERP_System.BLL.Guide
{
	public class ProductBll
	{
		private const string _spProduct = "[Guide].[spProduct]";
		private const string _spStock = "[Guide].[spStocks]";

		private readonly IRepository<Product> _repoProduct;
		private readonly IRepository<Unit> _repoUnit;
		private readonly IRepository<Attachment> _repoAttatchment;
		private readonly IRepository<StockProduct> _stockProduct;
		private readonly IRepository<ProductUnit> _productUnit;
		private readonly IMapper _mapper;
		private readonly HelperBll _helperBll;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ProductBll(IRepository<Attachment> repoAttatchment, IRepository<Unit> repoUnit, IRepository<ProductUnit> productUnit, IWebHostEnvironment webHostEnvironment, IRepository<Product> repoProduct, IMapper mapper, HelperBll helperBll, IRepository<StockProduct> stockProduct)
		{
			_repoProduct = repoProduct;
			_mapper = mapper;
			_helperBll = helperBll;
			_repoAttatchment = repoAttatchment;
			_webHostEnvironment = webHostEnvironment;
			_stockProduct = stockProduct;
			_productUnit = productUnit;
			_repoUnit = repoUnit;
		}

		#region Get
		public ProductDTO GetById(Guid id)
		{
			return _repoProduct.GetAllAsNoTracking().Include(p => p.Attachments).Include(x => x.StockProducts).ThenInclude(x => x.Stock).Where(p => p.ID == id).Select(x => new ProductDTO
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
					UnitBarcodePath = string.Concat("\\ProductsBarCode\\UnitsBarCode\\", c.UnitBarcodePath),
					UnitBarcodeText = c.UnitBarcodeText,
					UnitId = c.UnitId
				}).ToArray()
			}).FirstOrDefault();

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
				   BarCodePath = string.Concat("\\ProductsBarCode\\", p.BarCodePath),
				   GroupId = p.GroupId,
				   QtyInStock = p.QtyInStock,
				   IdUnitOfQty = p.IdUnitOfQty,
				   NameUnitOfQty = p.NameUnitOfQty,
				   GetQtyInStock = p.BarCodeText.Trim()==barcode.Trim()? p.QtyInStock 
				   : p.QtyInStock * p.ProductUnits.Where(x=>x.UnitBarcodeText.Trim()==barcode.Trim()).Select(x=>x.ConversionFactor).FirstOrDefault(),
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
				   }).ToArray()
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
					}
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
				   //GetQtyInStock = p.QtyInStock* p.ProductUnits.Where(x=>x.UnitId==p.IdUnitOfQty).Select(c =>c.ConversionFactor).FirstOrDefault()

			   }).FirstOrDefault();

				if (data != null)
				{
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
				   ConversionFactor = p.ProductUnits.Where(x=>x.UnitId==unitId).Select(x=>x.ConversionFactor).FirstOrDefault(),
				   GetQtyInStock = p.IdUnitOfQty ==unitId ? p.QtyInStock : 0,
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
					}
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
		#region Save 
		public ResultViewModel Save(ProductDTO productDto)
		{
			ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };
			var BarCodeFoldeName = "\\ProductsBarCode\\";
			var UnitBarCodeFoldeName = "\\ProductsBarCode\\UnitsBarCode\\";
			var ImagesFoldeName = "\\Images\\Products\\";

			var data = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == productDto.ID).FirstOrDefault();
			if (data != null)
			{
				var existMdl = _repoProduct.GetAllAsNoTracking().Where(p => !p.IsDeleted && p.IsActive)
					.Where(p => p.ID != data.ID && p.Name.Trim().ToLower() == productDto.Name.Trim().ToLower()).FirstOrDefault();
				if (existMdl != null)
				{
					resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
					return resultViewModel;

				}

				var existBarCode = _repoProduct.GetAllAsNoTracking().Where(p => !p.IsDeleted && p.IsActive)
					.Where(p => p.ID != data.ID && p.BarCodeText.Trim().ToLower() == productDto.BarCodeText.Trim().ToLower()).FirstOrDefault();
				if (existBarCode != null)
				{
					resultViewModel.Message = AppConstants.Messages.BarCodeAlreadyExists;
					return resultViewModel;
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
					tbl.BarCodePath = data.BarCodePath;
					tbl.BarCodeText = data.BarCodeText;
				}
				else
				{
					tbl.BarCodePath = _helperBll.GenerateBarcode(productDto.BarCodeText, BarCodeFoldeName);
					tbl.BarCodeText = productDto.BarCodeText;
					if (!string.IsNullOrEmpty(data.BarCodePath))
					{
						File.Delete(_webHostEnvironment + data.BarCodePath);
					}
				}
				tbl.AddedBy = data.AddedBy;

				tbl.ModifiedDate = AppDateTime.Now;
				if (_repoProduct.UserId != Guid.Empty)
				{
					tbl.ModifiedBy = _repoProduct.UserId;
				}
				if (productDto.Image != null && productDto.Image.Length > 0)
				{
					tbl.Image = _helperBll.UploadFile(productDto.Image, ImagesFoldeName);
				}
				if (productDto.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == productDto.BarCodeText.Trim() && x.UnitId != productDto.IdUnitOfQty))
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "لا يجوز أن يتكرر الباركود للمنتج مع الباركود الخاص بوحدات المنتج";
					return resultViewModel;
				}
				if (_repoProduct.Update(tbl))
				{
					if (productDto.ProductUnits != null && productDto.ProductUnits.Length > 0)
					{
						_productUnit.ExecuteSQLQuery<int>("UPDATE [Guide].[ProductUnits] SET [IsDeleted] = 1 WHERE [ProductId]='" + tbl.ID + "'", CommandType.Text);

						var NewRecords = new List<ProductUnit>();
						foreach (var unit in productDto.ProductUnits)
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
							newR.UnitBarcodePath = _helperBll.GenerateBarcode(unit.UnitBarcodeText, UnitBarCodeFoldeName);
							NewRecords.Add(newR);
						}
						_productUnit.InsertRange(NewRecords);
					}

					if (productDto.StockId != Guid.Empty)
					{
						_stockProduct.ExecuteSQLQuery<int>("UPDATE [Guide].[StockProducts] SET [IsDeleted] = 1  WHERE ProductId='" + tbl.ID + "'", CommandType.Text);

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
					resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
					return resultViewModel;
                }
                if (_repoProduct.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.BarCodeText.Trim() == productDto.BarCodeText.Trim()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.BarCodeAlreadyExists;
                    return resultViewModel;
                }

                var tbl = _mapper.Map<Product>(productDto);
				if (productDto.IdUnitOfQty != null && productDto.IdUnitOfQty != Guid.Empty)
				{
					tbl.NameUnitOfQty = _repoUnit.GetById(productDto.IdUnitOfQty).Name;
				}
				if (!string.IsNullOrEmpty(productDto.BarCodeText))
				{
					tbl.BarCodePath = _helperBll.GenerateBarcode(productDto.BarCodeText, BarCodeFoldeName);
					tbl.BarCodeText = productDto.BarCodeText;
				}
				if (_repoProduct.UserId != Guid.Empty)
				{
					tbl.AddedBy = _repoProduct.UserId;
				}
				if (productDto.Image != null && productDto.Image.Length > 0)
				{
					tbl.Image = _helperBll.UploadFile(productDto.Image, ImagesFoldeName);
				}

				if (productDto.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == productDto.BarCodeText.Trim() && x.UnitId != productDto.IdUnitOfQty))
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "لا يجوز أن يتكرر الباركود للمنتج مع الباركود الخاص بوحدات المنتج";
					return resultViewModel;
				}
				if (_repoProduct.Insert(tbl))
				{
					if (productDto.ProductUnits != null && productDto.ProductUnits.Length > 0)
					{
						var NewRecords = new List<ProductUnit>();
						foreach (var unit in productDto.ProductUnits)
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
							newR.UnitBarcodePath = _helperBll.GenerateBarcode(unit.UnitBarcodeText, UnitBarCodeFoldeName);
							NewRecords.Add(newR);
						}
						_productUnit.InsertRange(NewRecords);
					}
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

			tbl.IsDeleted = true;
			if (_repoProduct.UserId != Guid.Empty)
			{
				tbl.DeletedBy = _repoProduct.UserId;
			}
			tbl.DeletedDate = AppDateTime.Now;
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
