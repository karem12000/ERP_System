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

namespace ERP_System.BLL.Guide
{
	public class SaleInvoiceBll
	{
		private const string _spInvoices = "[Guide].[spSaleInvoice]";
		private readonly IRepository<SaleInvoice> _repoInvoice;
		private readonly IRepository<SaleThrowback> _repoThrowbackInvoice;
		private readonly UnitBll _UnitBll;
		private readonly IRepository<Stock> _repoStock;
		private readonly IRepository<Product> _repoProduct;
		private readonly IRepository<ProductUnit> _repoProductUnit;
		private readonly IRepository<SaleInvoiceDetail> _repoInvoiceDetail;
		private readonly IMapper _mapper;

		public SaleInvoiceBll(IRepository<Product> repoProduct, IRepository<SaleThrowback> repoThrowbackInvoice, IRepository<ProductUnit> repoProductUnit, IRepository<Stock> repoStock, UnitBll UnitBll, IRepository<SaleInvoice> repoInvoice, IRepository<SaleInvoiceDetail> repoInvoiceDetail, IMapper mapper)
		{
			_repoInvoice = repoInvoice;
			_mapper = mapper;
			_repoInvoiceDetail = repoInvoiceDetail;
			_repoProduct = repoProduct;
			_UnitBll = UnitBll;
			_repoStock = repoStock;
			_repoProductUnit = repoProductUnit;
			_repoThrowbackInvoice = repoThrowbackInvoice;
		}

		#region Get
		public SaleInvoiceDTO GetById(Guid id)
		{
			return _repoInvoice.GetAllAsNoTracking().Include(c => c.SaleInvoiceDetail).Where(p => p.ID == id).Select(x => new SaleInvoiceDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				//InvoiceDate = x.InvoiceDate,
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
				InvoiceTotalDiscount = x.InvoiceTotalDiscount,
				InvoiceTotalDiscountType = x.InvoiceTotalDiscountType,
				Buyer = x.Buyer,
				TotalPaid = x.TotalPaid,
				IsActive = x.IsActive,
				InvoiceTotalDiscountTypeInt = (int)x.InvoiceTotalDiscountType,

				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
					Qty = c.Qty,
					DiscountTypePProduct = c.DiscountTypePProduct,
					UnitId = c.UnitId,
					ConversionFactor = c.ConversionFactor,
					ItemUnitPrice = c.ItemUnitPrice,
					DiscountTypePProductInt = (int)c.DiscountTypePProduct,
					TotalQtyPriceAfterDisscount = (int)c.DiscountTypePProduct == 0 ? (c.Qty * c.SellingPrice) - ((c.Qty * c.SellingPrice) * (c.DiscountPProduct / 100)) : (c.Qty * c.SellingPrice) - c.DiscountPProduct,
					ProductBarCode = c.ProductBarCode,
					DiscountPProduct = c.DiscountPProduct,
					SellingPrice = c.SellingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId),
					QtyInStockStr = string.Join(" - ", Math.Round((_repoProduct.GetById(c.ProductId.Value).QtyInStock / c.ConversionFactor) ?? 0, 2), _UnitBll.GetById(c.UnitId.Value).Name)
				}).ToList(),


			}).FirstOrDefault();
		}
		public int GetLastInvoiceNumberByDate(DateTime? date)
		{
			var invoiceNumber = _repoInvoice.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.InvoiceDate.Date >= date.Value.Date)
				 .OrderByDescending(c => c.CreatedDate).Select(c => c.InvoiceNumber).FirstOrDefault();

			return invoiceNumber;
		}
		public ResultViewModel GetByInvoiceNumber(int? number)
		{
			var result = new ResultViewModel();
			result.Status = false;

			var invoice = _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceNumber == number && p.IsActive && !p.IsDeleted).Select(x => new GetSaleInvoiceDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				InvoiceTotalDiscountTypeInt = (int)x.InvoiceTotalDiscountType,

				StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
				InvoiceTotalDiscount = x.InvoiceTotalDiscount,
				InvoiceTotalDiscountType = x.InvoiceTotalDiscountType,
				Buyer = x.Buyer,
				TotalPaid = x.TotalPaid,

				IsActive = x.IsActive,

				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
					Qty = c.Qty,
					UnitId = c.UnitId,
					DiscountTypePProduct = c.DiscountTypePProduct,
					ConversionFactor = c.ConversionFactor,
					ItemUnitPrice = c.ItemUnitPrice,
					ProductBarCode = c.ProductBarCode,
					DiscountPProduct = c.DiscountPProduct,
					DiscountTypePProductInt = (int)c.DiscountTypePProduct,

					SellingPrice = c.SellingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)

				}).ToList(),

			}).FirstOrDefault();
			if (invoice != null)
			{
				result.Status = true;
				result.Data = invoice;
			}
			else
			{
				result.Message = "لاتوجد فاتورة مبيعات بهذا الرقم";
			}

			return result;
		}
		public ResultViewModel GetProductByBarCodeAndInvoiceId(string barcode, Guid? invoiceId)
		{
			var resultView = new ResultViewModel();
			resultView.Status = false;
			if (barcode != null)
			{
				var data = _repoInvoiceDetail.GetAllAsNoTracking()
			   .Where(p => (p.ProductBarCode.Trim() == barcode.Trim() || p.ProductName.Contains(barcode)) && p.SaleInvoiceId == invoiceId && p.IsActive && !p.IsDeleted && !p.SaleInvoice.IsDeleted)
			   .Select(p => new SaleInvoiceDetailDto
			   {
				   ID = p.ID,
				   ConversionFactor = p.ConversionFactor,
				   DiscountPProduct = p.DiscountPProduct,
				   DiscountTypePProduct = p.DiscountTypePProduct,
				   ItemUnitPrice = p.ItemUnitPrice,
				   ProductBarCode = p.ProductBarCode,
				   ProductName = _repoProduct.GetById(p.ProductId).Name,
				   ProductId = p.ProductId,
				   Qty = p.Qty,
				   UnitId = p.UnitId,
				   UnitName = _UnitBll.GetById(p.UnitId.Value).Name,
				   TotalQtyPrice = p.TotalQtyPrice,
				   SellingPrice = p.SellingPrice
			   }).FirstOrDefault();

				if (data != null)
				{

					resultView.Status = true;
					resultView.Data = data;
				}
				else
				{
					resultView.Message = " هذه الفاتورة لا تحتوي علي منتج بهذا الباركود " + barcode;
				}
			}
			else
			{
				resultView.Status = true;
				resultView.Data = null;
			}
			return resultView;
		}
		public ResultViewModel GetByInvoiceNumberAndDate(int? number, DateTime? date)
		{
			var result = new ResultViewModel();
			result.Status = false;
			var invoice = _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceNumber == number && p.InvoiceDate.Date == date.Value.Date && p.IsActive && !p.IsDeleted).Select(x => new GetSaleInvoiceDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				InvoiceTotalDiscountTypeInt = (int)x.InvoiceTotalDiscountType,
				StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
				InvoiceTotalDiscount = x.InvoiceTotalDiscount,
				InvoiceTotalDiscountType = x.InvoiceTotalDiscountType,
				Buyer = x.Buyer,
				TotalPaid = x.TotalPaid,
				IsActive = x.IsActive,
				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
					Qty = c.Qty,
					UnitId = c.UnitId,
					DiscountTypePProduct = c.DiscountTypePProduct,
					ConversionFactor = c.ConversionFactor,
					ItemUnitPrice = c.ItemUnitPrice,
					ProductBarCode = c.ProductBarCode,
					DiscountPProduct = c.DiscountPProduct,
					DiscountTypePProductInt = (int)c.DiscountTypePProduct,
					UnitName = _UnitBll.GetById(c.UnitId.Value).Name,
					TotalQtyPriceAfterDisscount = (int)c.DiscountTypePProduct == 0 ? (c.Qty * c.SellingPrice) - ((c.Qty * c.SellingPrice) * (c.DiscountPProduct / 100)) : (c.Qty * c.SellingPrice) - c.DiscountPProduct,
					SellingPrice = c.SellingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId),
					QtyInStockStr = string.Join(" - ", Math.Round((_repoProduct.GetById(c.ProductId.Value).QtyInStock * c.ConversionFactor) ?? 0, 2), _UnitBll.GetById(c.UnitId.Value).Name)
				}).ToList(),

			}).FirstOrDefault();

			if (invoice != null)
			{
				//var alreadThrowback = _repoThrowbackInvoice.GetAllAsNoTracking().Include(x => x.SaleInvoiceDetails).Where(x => x.SaleInvoiceId == invoice.ID && !x.IsDeleted).Select(x => x.SaleInvoiceDetails).ToList();
				var alreadThrowback = _repoThrowbackInvoice.GetAllAsNoTracking().Include(x => x.SaleInvoiceDetails).Where(x => x.SaleInvoiceId == invoice.ID && !x.IsDeleted).ToList();
				var finalInvoice = invoice.GetInvoiceDetails.ToList();
				foreach (var item in invoice.GetInvoiceDetails)
				{
					//var qty = alreadThrowback.Where(x => x.SaleInvoiceDetails.Any(xx => xx.UnitId == item.UnitId && xx.ProductId == item.ProductId)).ToList();
					decimal? allQty = 0;
					var allThrowback = new List<SaleThrowbackDetail>();
					foreach (var currentItem in alreadThrowback)
					{
						foreach (var subItem in currentItem.SaleInvoiceDetails)
						{
							if (subItem.UnitId == item.UnitId && subItem.ProductId == item.ProductId)
							{
								allThrowback.Add(subItem);
							}
						}
					}

					if (allThrowback.Count() > 0)
					{
						allQty = allThrowback.Sum(x => x.Qty);

						var currenRow = finalInvoice.Where(x => x.UnitId == item.UnitId && x.ProductId == item.ProductId).FirstOrDefault();
						var currenQty = currenRow.Qty;
						currenQty -= allQty;
						currenRow.Qty = currenQty;
						if (currenRow.DiscountTypePProduct == DisscountType.Value)
						{

							currenRow.TotalQtyPriceAfterDisscount = (currenQty * currenRow.SellingPrice) - currenRow.DiscountPProduct;
						}
						else if (currenRow.DiscountTypePProduct == DisscountType.Percent)
						{
							currenRow.TotalQtyPriceAfterDisscount = (currenQty * currenRow.SellingPrice) - (currenRow.DiscountPProduct / 100);

						}

						finalInvoice.Remove(invoice.GetInvoiceDetails.Where(x => x.UnitId == item.UnitId && x.ProductId == item.ProductId).FirstOrDefault());
						if (currenQty != 0)
							finalInvoice.Add(currenRow);
					}
				}
				invoice.GetInvoiceDetails = finalInvoice;
				
				if (finalInvoice.Count == 0)
				{
					result.Status = false;
					result.Message = "تم إرجاع جميع منتجات هذه الفاتورة";
					return result;
				}

				invoice.InvoiceTotalPrice = invoice.GetInvoiceDetails.Sum(x => x.TotalQtyPriceAfterDisscount);
				if (invoice.InvoiceTotalDiscountType == DisscountType.Value)
				{

					invoice.InvoiceTotalPrice = invoice.InvoiceTotalPrice - invoice.InvoiceTotalDiscount;
				}
				else if (invoice.InvoiceTotalDiscountType == DisscountType.Percent)
				{
					invoice.InvoiceTotalPrice = invoice.InvoiceTotalPrice - (invoice.InvoiceTotalDiscount / 100);

				}
				result.Status = true;
				result.Data = invoice;
			}
			else
			{
				result.Message = "لاتوجد فاتورة مبيعات بهذا الرقم";
			}

			return result;
		}


		public SaleInvoiceDTO GetByInvoiceDate(DateTime? date)
		{
			if (date != null)
			{
				return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceDate.Date == date.Value.Date && p.IsActive && !p.IsDeleted).Select(x => new SaleInvoiceDTO
				{
					ID = x.ID,
					InvoiceDateStr = x.InvoiceDate.Date.ToString(),
					InvoiceNumber = x.InvoiceNumber,
					StockId = x.StockId,
					StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
					InvoiceTotalDiscount = x.InvoiceTotalDiscount,
					InvoiceTotalDiscountType = x.InvoiceTotalDiscountType,
					Buyer = x.Buyer,
					InvoiceTotalDiscountTypeInt = (int)x.InvoiceTotalDiscountType,

					TotalPaid = x.TotalPaid,

					IsActive = x.IsActive,

					InvoiceTotalPrice = x.InvoiceTotalPrice,
					GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
					{
						ID = c.ID,
						ProductId = c.ProductId,
						ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
						Qty = c.Qty,
						UnitId = c.UnitId,
						DiscountTypePProduct = c.DiscountTypePProduct,
						ConversionFactor = c.ConversionFactor,
						ItemUnitPrice = c.ItemUnitPrice,
						ProductBarCode = c.ProductBarCode,
						DiscountPProduct = c.DiscountPProduct,
						DiscountTypePProductInt = (int)c.DiscountTypePProduct,

						SellingPrice = c.SellingPrice,
						GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)

					}).ToList(),

				}).FirstOrDefault();
			}
			return null;
		}

		public IQueryable<SaleInvoiceDTO> GetAllByDate(DateTime? date)
		{

			return _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date == date.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new SaleInvoiceDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
				InvoiceTotalDiscount = x.InvoiceTotalDiscount,
				InvoiceTotalDiscountType = x.InvoiceTotalDiscountType,
				Buyer = x.Buyer,
				InvoiceTotalDiscountTypeInt = (int)x.InvoiceTotalDiscountType,

				TotalPaid = x.TotalPaid,

				IsActive = x.IsActive,

				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
					Qty = c.Qty,
					UnitId = c.UnitId,
					DiscountTypePProduct = c.DiscountTypePProduct,
					ConversionFactor = c.ConversionFactor,
					ItemUnitPrice = c.ItemUnitPrice,
					ProductBarCode = c.ProductBarCode,
					DiscountTypePProductInt = (int)c.DiscountTypePProduct,

					DiscountPProduct = c.DiscountPProduct,
					SellingPrice = c.SellingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)

				}).ToList(),

			});

		}
		public IQueryable<SaleInvoiceDTO> GetAllByDate(DateTime? fromDate, DateTime? toDate)
		{

			return _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date >= fromDate.Value.Date && x.InvoiceDate.Date <= toDate.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new SaleInvoiceDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
				InvoiceTotalDiscount = x.InvoiceTotalDiscount,
				InvoiceTotalDiscountType = x.InvoiceTotalDiscountType,
				InvoiceTotalDiscountTypeInt = (int)x.InvoiceTotalDiscountType,
				Buyer = x.Buyer,
				IsActive = x.IsActive,
				TotalPaid = x.TotalPaid,
				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
					Qty = c.Qty,
					UnitId = c.UnitId,
					DiscountTypePProduct = c.DiscountTypePProduct,
					ConversionFactor = c.ConversionFactor,
					DiscountPProduct = c.DiscountPProduct,
					DiscountTypePProductInt = (int)c.DiscountTypePProduct,
					ItemUnitPrice = c.ItemUnitPrice,
					ProductBarCode = c.ProductBarCode,
					SellingPrice = c.SellingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)

				}).ToList(),

			});

		}
		public DataTableResponse LoadData(DataTableRequest mdl)
		{
			var data = _repoInvoice.ExecuteStoredProcedure<SaleInvoicesTableDTO>
				(_spInvoices, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}


		#endregion
		#region Save 
		public ResultViewModel Save(SaleInvoiceDTO InvoiceDTO)
		{
			ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };

			if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Length > 0)
			{
				if (InvoiceDTO.InvoiceDetails.Any(x => x.SellingPrice == 0))
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "لايمكن حفظ سعر البيع بالقيمة 0";
					return resultViewModel;
				}
			}
			var data = _repoInvoice.GetAllAsNoTracking().Include(x => x.SaleInvoiceDetail).Where(p => p.ID == InvoiceDTO.ID && p.IsActive && !p.IsDeleted).FirstOrDefault();
			if (data != null)
			{
				var newInvoice = data;
				newInvoice.StockId = InvoiceDTO.StockId;
				//newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
				newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
				newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
				newInvoice.Buyer = InvoiceDTO.Buyer;
				newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
				newInvoice.InvoiceTotalDiscountType = InvoiceDTO.InvoiceTotalDiscountType;
				newInvoice.InvoiceTotalDiscount = InvoiceDTO.InvoiceTotalDiscount;
				newInvoice.AddedTax = data.AddedTax;

				decimal? TotalPrice = 0;
				newInvoice.AddedBy = data.AddedBy;
				newInvoice.ModifiedDate = AppDateTime.Now;
				newInvoice.ModifiedBy = _repoInvoice.UserId;
				newInvoice.CreatedDate = data.CreatedDate;
				decimal? SumInvoiceTotalQtyPrice = 0;
				if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
				{
					foreach (var item in InvoiceDTO.InvoiceDetails)
					{
						if (item.DiscountTypePProduct == DisscountType.Percent)
						{
							SumInvoiceTotalQtyPrice += item.TotalQtyPrice - (item.TotalQtyPrice * item.DiscountPProduct / 100) ?? 0;
						}
						else
						{
							SumInvoiceTotalQtyPrice += item.TotalQtyPrice - item.DiscountPProduct;
						}
					}

				}
				if (newInvoice.InvoiceTotalDiscountType == DisscountType.Value)
				{
					SumInvoiceTotalQtyPrice = SumInvoiceTotalQtyPrice - newInvoice.InvoiceTotalDiscount ?? 0;
				}
				else
				{
					SumInvoiceTotalQtyPrice = SumInvoiceTotalQtyPrice - (SumInvoiceTotalQtyPrice * newInvoice.InvoiceTotalDiscount / 100) ?? 0;
				}
				newInvoice.InvoiceTotalPrice = SumInvoiceTotalQtyPrice + newInvoice.AddedTax;

				var oldInvoiceDetails = data.SaleInvoiceDetail;
				if (newInvoice.InvoiceTotalPrice < 0)
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "لا يمكن حفظ الاجمالي للفاتورة بالقيمة السالبة";
					return resultViewModel;
				}
				if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
				{
					var AllInvoiceProducts = new List<Product>();
					var AllDetails = new List<SaleInvoiceDetail>();
					foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
					{
						var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.StockProducts.Any(x => x.ProductId == invoiceDetail.ProductId && x.StockId == InvoiceDTO.StockId) && (x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() || x.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == invoiceDetail.ProductBarCode.Trim()))).FirstOrDefault();

						if (product != null)
						{
							var existProduct = AllInvoiceProducts.Where(x => x.BarCodeText == product.BarCodeText).FirstOrDefault();
							IQueryable<ProductUnit> productUnit = null;
							decimal? QtyInStock = 0;
							decimal? ConversionFactor = 0;
							dynamic? TotalQtyInStock = 0;
							var oldDetail = oldInvoiceDetails.Where(x => x.ID == invoiceDetail.ID).FirstOrDefault();
							if (existProduct != null)
							{
								productUnit = _repoProductUnit.GetAllAsNoTracking().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
								QtyInStock = existProduct.QtyInStock ?? 0;
								ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
								TotalQtyInStock = QtyInStock * ConversionFactor;
							}
							else
							{
								productUnit = _repoProductUnit.GetAllAsNoTracking().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
								QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
								ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
								TotalQtyInStock = QtyInStock * ConversionFactor;
							}

							if (oldDetail != null)
							{
								var oldRequiredQty = oldDetail.Qty * oldDetail.ConversionFactor;
								var reuiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

								product.QtyInStock = TotalQtyInStock + oldRequiredQty;
								TotalQtyInStock = TotalQtyInStock + oldRequiredQty;
								if (reuiredQty > TotalQtyInStock)
								{
									resultViewModel.Status = false;
									resultViewModel.Message = " غير متوفرة " + product.Name + " الكمية المطلوبة من المنتج  ";
									resultViewModel.Data = InvoiceDTO;
									return resultViewModel;
								}
								else
								{
									product.QtyInStock = product.QtyInStock - reuiredQty;
									product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);

									AllInvoiceProducts.Remove(existProduct);
									AllInvoiceProducts.Add(product);

									oldDetail.ID = invoiceDetail.ID.Value;
									oldDetail.ProductBarCode = invoiceDetail.ProductBarCode;
									oldDetail.ProductId = invoiceDetail.ProductId;
									oldDetail.ProductName = invoiceDetail.ProductName;
									oldDetail.UnitId = invoiceDetail.UnitId;
									oldDetail.ItemUnitPrice = invoiceDetail.ItemUnitPrice;
									oldDetail.Qty = invoiceDetail.Qty;
									oldDetail.SellingPrice = invoiceDetail.SellingPrice;
									oldDetail.DiscountPProduct = invoiceDetail.DiscountPProduct;
									oldDetail.TotalQtyPrice = invoiceDetail.TotalQtyPrice;
									oldDetail.SaleInvoiceId = newInvoice.ID;
									oldDetail.DiscountTypePProduct = invoiceDetail.DiscountTypePProduct;


									AllDetails.Add(oldDetail);

								}
							}
							else
							{
								var reuiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;
								if (reuiredQty > TotalQtyInStock)
								{
									resultViewModel.Status = false;
									resultViewModel.Message = " غير متوفرة " + product.Name + " الكمية المطلوبة من المنتج  ";
									resultViewModel.Data = InvoiceDTO;
									return resultViewModel;
								}
								else
								{

									product.QtyInStock = TotalQtyInStock - reuiredQty;
									product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);

									AllInvoiceProducts.Remove(existProduct);
									AllInvoiceProducts.Add(product);

									var newInvoiceDetail = new SaleInvoiceDetail()
									{
										AddedBy = _repoInvoice.UserId,
										IsActive = true,
										DiscountPProduct = invoiceDetail.DiscountPProduct,
										UnitId = invoiceDetail.UnitId,
										ConversionFactor = invoiceDetail.ConversionFactor,
										ProductBarCode = invoiceDetail.ProductBarCode,
										ProductId = invoiceDetail.ProductId,
										ItemUnitPrice = invoiceDetail.ItemUnitPrice,
										SellingPrice = invoiceDetail.SellingPrice,
										Qty = invoiceDetail.Qty,
										ID = Guid.NewGuid(),
										TotalQtyPrice = invoiceDetail.TotalQtyPrice,
										SaleInvoiceId = newInvoice.ID,
										ProductName = product.Name,
										DiscountTypePProduct = invoiceDetail.DiscountTypePProduct
									};
									AllDetails.Add(newInvoiceDetail);
								}
							}

						}
						else
						{
							resultViewModel.Status = false;
							resultViewModel.Message = " لا يوجد منتج بهذا الباركود " + invoiceDetail.ProductBarCode + " أو المنتج المختار لاينتمي الي المخزن المحدد";
							return resultViewModel;

						}


					}
					TotalPrice -= newInvoice.InvoiceTotalDiscount ?? 0;

					var deleteInvoiceDetaails = _repoInvoiceDetail.DeleteRange(oldInvoiceDetails);
					var saveInvoiceDetaails = _repoInvoiceDetail.InsertRange(AllDetails);
					if (deleteInvoiceDetaails && saveInvoiceDetaails)
					{
						foreach (var item in AllInvoiceProducts)
						{
							_repoProduct.Update(item);
						}
						_repoInvoice.Update(newInvoice);
						resultViewModel.Status = true;
						resultViewModel.Message = AppConstants.Messages.SavedSuccess;
					}
					else
					{
						resultViewModel.Status = false;
						resultViewModel.Message = "خطأ في حفظ تفاصيل الفاتورة";
					}

				}
				else
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "هذه الفاتورة لا تحتوي علي منتجات";
				}
			}
			else
			{
				var newInvoice = new SaleInvoice();
				newInvoice.StockId = InvoiceDTO.StockId;
				//newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
				newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
				newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
				newInvoice.InvoiceDate = DateTime.Now;
				newInvoice.Buyer = InvoiceDTO.Buyer;
				newInvoice.InvoiceTotalDiscountType = InvoiceDTO.InvoiceTotalDiscountType;
				newInvoice.InvoiceTotalDiscount = InvoiceDTO.InvoiceTotalDiscount;
				newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
				newInvoice.AddedTax = InvoiceDTO.AddedTax ?? 0;

				decimal? SumInvoiceTotalQtyPrice = 0;
				if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
				{
					foreach (var item in InvoiceDTO.InvoiceDetails)
					{
						if (item.DiscountTypePProduct == DisscountType.Percent)
						{
							SumInvoiceTotalQtyPrice += item.TotalQtyPrice - (item.TotalQtyPrice * item.DiscountPProduct / 100) ?? 0;
						}
						else
						{
							SumInvoiceTotalQtyPrice += item.TotalQtyPrice - item.DiscountPProduct;
						}
					}

				}
				if (newInvoice.InvoiceTotalDiscountType == DisscountType.Value)
				{
					SumInvoiceTotalQtyPrice = SumInvoiceTotalQtyPrice - newInvoice.InvoiceTotalDiscount ?? 0;
				}
				else
				{
					SumInvoiceTotalQtyPrice = SumInvoiceTotalQtyPrice - (SumInvoiceTotalQtyPrice * newInvoice.InvoiceTotalDiscount / 100) ?? 0;
				}
				newInvoice.InvoiceTotalPrice = SumInvoiceTotalQtyPrice + newInvoice.AddedTax;


				newInvoice.AddedBy = _repoInvoice.UserId;
				decimal? TotalPrice = 0;
				if (newInvoice.InvoiceTotalPrice < 0)
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "لا يمكن حفظ الاجمالي للفاتورة بالقيمة السالبة";
					return resultViewModel;
				}

				if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
				{
					var AllInvoiceProducts = new List<Product>();
					if (_repoInvoice.Insert(newInvoice))
					{
						var AllDetails = new List<SaleInvoiceDetail>();
						foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
						{
							var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.StockProducts.Any(x => x.ProductId == invoiceDetail.ProductId && x.StockId == InvoiceDTO.StockId) && (x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() || x.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == invoiceDetail.ProductBarCode.Trim()))).FirstOrDefault();
							if (product != null)
							{
								var existProduct = AllInvoiceProducts.Where(x => x.BarCodeText == product.BarCodeText).FirstOrDefault();
								IQueryable<ProductUnit> productUnit = null;
								decimal? QtyInStock = 0;
								decimal? ConversionFactor = 0;
								dynamic? TotalQtyInStock = 0;
								if (existProduct != null)
								{
									productUnit = _repoProductUnit.GetAllAsNoTracking().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
									QtyInStock = existProduct.QtyInStock ?? 0;
									ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
									TotalQtyInStock = QtyInStock * ConversionFactor;
								}
								else
								{
									productUnit = _repoProductUnit.GetAllAsNoTracking().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
									QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock ?? 0;
									ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
									TotalQtyInStock = QtyInStock * ConversionFactor;
								}

								var reuiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;
								if (reuiredQty > TotalQtyInStock)
								{
									resultViewModel.Status = false;
									resultViewModel.Message =$"الكمية الموجودة بالمخزن للمنتج {product.Name} غير كافية";
									resultViewModel.Data = InvoiceDTO;
									_repoInvoice.Detached(newInvoice);
									newInvoice.IsDeleted = true;
									_repoInvoice.Update(newInvoice);
									return resultViewModel;
								}
								else
								{
									product.QtyInStock = TotalQtyInStock - reuiredQty;
									product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);
									AllInvoiceProducts.Remove(existProduct);
									AllInvoiceProducts.Add(product);
									//_repoProduct.Update(product);
									var newInvoiceDetail = new SaleInvoiceDetail()
									{
										AddedBy = _repoInvoice.UserId,
										IsActive = true,
										UnitId = invoiceDetail.UnitId,
										DiscountPProduct = invoiceDetail.DiscountPProduct,
										ConversionFactor = invoiceDetail.ConversionFactor,
										ProductBarCode = invoiceDetail.ProductBarCode,
										ProductId = invoiceDetail.ProductId,
										ItemUnitPrice = invoiceDetail.ItemUnitPrice,
										SellingPrice = invoiceDetail.SellingPrice,
										Qty = invoiceDetail.Qty,
										ID = Guid.NewGuid(),
										TotalQtyPrice = invoiceDetail.TotalQtyPrice,
										SaleInvoiceId = newInvoice.ID,
										ProductName = product.Name,
										DiscountTypePProduct = invoiceDetail.DiscountTypePProduct,
									};
									//_repoInvoiceDetail.Insert(newInvoiceDetail);
									AllDetails.Add(newInvoiceDetail);
									TotalPrice -= invoiceDetail.DiscountPProduct ?? 0;
									TotalPrice += newInvoiceDetail.TotalQtyPrice;
								}
							}
							else
							{
								resultViewModel.Status = false;
								resultViewModel.Message = $"لايوجد منتج بهذا الباركود {invoiceDetail.ProductBarCode} أو هذا المنتج غير موجود بالمخزن المحدد";
								//resultViewModel.Message = " لا يوجد منتج بهذا الباركود " + invoiceDetail.ProductBarCode + " أو المنتج المختار لاينتمي الي المخزن المحدد ";
								_repoInvoice.Detached(newInvoice);
								newInvoice.IsDeleted = true;
								_repoInvoice.Update(newInvoice);
								return resultViewModel;
							}
						}
						//TotalPrice -= newInvoice.InvoiceTotalDiscount ?? 0;
						//newInvoice.InvoiceTotalPrice = TotalPrice;
						//_repoInvoice.Update(newInvoice);
						foreach (var item in AllInvoiceProducts)
						{
							_repoProduct.Update(item);
						}
						_repoInvoiceDetail.InsertRange(AllDetails);

						var lastInvoiceNumber = newInvoice.InvoiceNumber + 1;
						resultViewModel.Status = true;
						resultViewModel.Message = AppConstants.Messages.SavedSuccess;
						resultViewModel.Data = lastInvoiceNumber;

					}
					else
					{
						resultViewModel.Message = AppConstants.Messages.SavedFailed;
					}
				}
				else
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "هذه الفاتورة لا تحتوي علي منتجات";
				}
			}
			return resultViewModel;
		}
		#endregion


		#region Delete
		public ResultViewModel Delete(Guid id)
		{
			ResultViewModel resultViewModel = new ResultViewModel();
			var tbl = _repoInvoice.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();
			var RelatedInvoices = _repoThrowbackInvoice.GetAllAsNoTracking().Any(x => x.SaleInvoiceId == id && !x.IsDeleted);

			if (tbl == null)
			{
				resultViewModel.Status = false;
				resultViewModel.Message = AppConstants.Messages.DeletedFailed;
				return resultViewModel;
			}
			if (RelatedInvoices)
			{
				resultViewModel.Status = false;
				resultViewModel.Message = "لا يمكن حذف الفاتورة لوجود مرتجعات مرتبطة بها";
				return resultViewModel;
			}
			tbl.IsDeleted = true;
			if (_repoInvoice.UserId != Guid.Empty)
			{
				tbl.DeletedBy = _repoInvoice.UserId;
			}
			tbl.DeletedDate = AppDateTime.Now;
			var IsSuceess = _repoInvoice.Update(tbl);

			resultViewModel.Status = IsSuceess;
			resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


			return resultViewModel;
		}
		#endregion
	}
}
