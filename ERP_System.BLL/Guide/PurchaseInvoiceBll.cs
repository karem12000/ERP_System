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
using ERP_System.Common.General;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ERP_System.DTO.Print;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;

namespace ERP_System.BLL.Guide
{
	public class PurchaseInvoiceBll
	{
		private const string _spInvoices = "[Guide].[spPurchaseInvoice]";
		private readonly IRepository<PurchaseInvoice> _repoInvoice;
		private readonly IRepository<PurchaseThrowback> _repoThrowbackInvoice;
		private readonly UnitBll _UnitBll;
		private readonly SupplierBll _supplierBll;
		private readonly IRepository<Supplier> _repoSupplier;
		private readonly IRepository<Unit> _repoUnit;
		private readonly IRepository<Stock> _repoStock;
		private readonly IRepository<Product> _repoProduct;
		private readonly IRepository<ProductUnit> _repoProductUnit;
		private readonly IRepository<PurchaseInvoiceDetail> _repoInvoiceDetail;
		private readonly IRepository<PurchaseThrowbackDetail> _repoPurchaseInvoiceDetail;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _weebhost; 

		public PurchaseInvoiceBll(IRepository<Product> repoProduct, IWebHostEnvironment weebhost, IRepository<PurchaseThrowbackDetail> repoPurchaseInvoiceDetail, IRepository<PurchaseThrowback> repoThrowbackInvoice, IRepository<Unit> repoUnit, IRepository<Supplier> repoSupplier, SupplierBll supplierBll, IRepository<ProductUnit> repoProductUnit, IRepository<Stock> repoStock, UnitBll UnitBll, IRepository<PurchaseInvoice> repoInvoice, IRepository<PurchaseInvoiceDetail> repoInvoiceDetail, IMapper mapper)
		{
			_repoInvoice = repoInvoice;
			_mapper = mapper;
			_repoInvoiceDetail = repoInvoiceDetail;
			_repoProduct = repoProduct;
			_UnitBll = UnitBll;
			_repoStock = repoStock;
			_repoProductUnit = repoProductUnit;
			_repoPurchaseInvoiceDetail = repoPurchaseInvoiceDetail;
			_weebhost = weebhost;
			_supplierBll = supplierBll;
			_repoSupplier = repoSupplier;
			_repoUnit = repoUnit;
			_repoThrowbackInvoice = repoThrowbackInvoice;
		}

		#region Get
		public int GetLastInvoiceNumberByDate(DateTime? date)
		{
			var invoiceNumber = _repoInvoice.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.InvoiceDate.Date >= date.Value.Date)
				 .OrderByDescending(c => c.CreatedDate).Select(c => c.InvoiceNumber).FirstOrDefault();

			return invoiceNumber;
		}
		public PurchaseInvoiceDTO GetById(Guid id)
		{
			var invoice = _repoInvoice.GetAllAsNoTracking().Include(c => c.PurchaseInvoiceDetail).Where(p => p.ID == id).Select(x => new PurchaseInvoiceDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				//InvoiceDate = x.InvoiceDate,
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = x.StockName,
				SupplierId = x.SupplierId,
				SupplierName = _repoSupplier.GetById(x.SupplierId).Name,
				IsActive = x.IsActive,
				TotalPaid = x.TotalPaid,
				InvoiceTotalPrice = x.InvoiceTotalPrice,
				TransactionType = (int)x.TransactionType,
				GetInvoiceDetails = x.PurchaseInvoiceDetail.Select(c => new PurchaseInvoiceProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = c.ProductName,
					Qty = c.Qty,
					UnitId = c.UnitId,
					UnitName = _repoUnit.GetById(c.UnitId).Name,
					ConversionFactor = c.ConversionFactor,
					ProductBarCode = c.ProductBarCode,
					PurchasingPrice = c.PurchasingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId),
					QtyInStockStr = string.Join(" - ", Math.Round((_repoProduct.GetById(c.ProductId.Value).QtyInStock / c.ConversionFactor) ?? 0, 2), _UnitBll.GetById(c.UnitId.Value).Name)
				}).ToList()
			}).FirstOrDefault();

			//foreach (var item in invoice.GetInvoiceDetails)
			//{
			//	var stockQty = _repoProduct.Find(x => x.ID == invoice.GetInvoiceDetails.Where(x=>x.ID==item.ID).FirstOrDefault().ProductId).FirstOrDefault().QtyInStock;
			//	var conversionFactor = item.ConversionFactor;
			//	var fQty = stockQty / conversionFactor;
			//	fQty = Math.Round(fQty??0, 2);
			//	item.QtyInStockStr = string.Join(" - ", fQty, item.QtyInStockStr);
			//}

			return invoice;

		}
		public ResultViewModel GetProductByBarCodeAndInvoiceId(string barcode, Guid? invoiceId)
		{
			var resultView = new ResultViewModel();
			resultView.Status = false;
			if (barcode != null)
			{
				var throwback = _repoPurchaseInvoiceDetail.GetAllAsNoTracking().Include(x => x.PurchaseThrowback)
					.Where(x => (x.ProductBarCode.Trim() == barcode.Trim() || x.ProductName == barcode.Trim()) && x.PurchaseThrowback.PurchaseInvoiceId == invoiceId).ToList();
				decimal ThrowbackQty = 0;
				if (throwback != null)
				{
					ThrowbackQty = throwback.Sum(x => x.Qty.Value);
				}

				var data = _repoInvoiceDetail.GetAllAsNoTracking()
			   .Where(p => (p.ProductBarCode.Trim() == barcode.Trim() || p.ProductName.Contains(barcode)) && p.PurchaseInvoiceId == invoiceId && p.IsActive && !p.IsDeleted && !p.PurchaseInvoice.IsDeleted)
			   .Select(p => new PurchaseInvoiceProductsDTO
			   {
				   ConversionFactor = p.ConversionFactor,
				   ID = p.ID,
				   ProductBarCode = barcode,
				   ProductId = p.ProductId,
				   ProductName = _repoProduct.GetById(p.ProductId).Name,
				   PurchaseDetailId = p.ID,
				   Qty = p.Qty,
				   PurchasingPrice = p.PurchasingPrice,
				   UnitId = p.UnitId,
				   UnitName = _repoUnit.GetById(p.UnitId).Name,
				   QtyInStockStr = string.Join(" - ", _repoProduct.GetById(p.ProductId).QtyInStock.Value, _repoProduct.GetById(p.ProductId).NameUnitOfQty),
				   ThrowbackQty = ThrowbackQty

			   }).FirstOrDefault();

				if (data != null)
				{

					resultView.Status = true;
					resultView.Data = data;
				}
				else
				{
					resultView.Message = " هذه الفاتورة لا تحتوي علي منتج بهذا الاسم أو الباركود " + barcode;
				}
			}
			else
			{
				resultView.Status = true;
				resultView.Data = null;
			}
			return resultView;
		}
		public PurchaseInvoiceDTO GetByInvoiceNumber(int? number)
		{
			return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceNumber == number && p.IsActive && !p.IsDeleted).Select(x => new PurchaseInvoiceDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = x.StockName,
				SupplierId = x.SupplierId,
				TotalPaid = x.TotalPaid,
				TransactionType = (int)x.TransactionType,

				SupplierName = x.SupplierName,
				IsActive = x.IsActive,

				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.PurchaseInvoiceDetail.Select(c => new PurchaseInvoiceProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = c.ProductName,
					Qty = c.Qty,
					UnitId = c.UnitId,
					ConversionFactor = c.ConversionFactor,
					ProductBarCode = c.ProductBarCode,
					PurchasingPrice = c.PurchasingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId),
					//QtyInStock = Math.Round(_repoProduct.GetById(c.ProductId).QtyInStock.Value * c.ConversionFactor.Value, 2),
					QtyInStockStr = string.Join(" - ", _repoProduct.GetById(c.ProductId).QtyInStock.Value, _repoProduct.GetById(c.ProductId).NameUnitOfQty)

				}).ToList(),

			}).FirstOrDefault();
		}


		public PurchaseInvoiceDTO GetByInvoiceDate(DateTime? date)
		{
			if (date != null)
			{
				return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceDate.Date == date.Value.Date && p.IsActive && !p.IsDeleted).Select(x => new PurchaseInvoiceDTO
				{
					ID = x.ID,
					InvoiceDateStr = x.InvoiceDate.Date.ToString(),
					InvoiceNumber = x.InvoiceNumber,
					StockId = x.StockId,
					StockName = x.StockName,
					SupplierId = x.SupplierId,
					TotalPaid = x.TotalPaid,
					TransactionType = (int)x.TransactionType,

					SupplierName = x.SupplierName,
					IsActive = x.IsActive,

					InvoiceTotalPrice = x.InvoiceTotalPrice,
					GetInvoiceDetails = x.PurchaseInvoiceDetail.Select(c => new PurchaseInvoiceProductsDTO
					{
						ID = c.ID,
						ProductId = c.ProductId,
						ProductName = c.ProductName,
						Qty = c.Qty,
						UnitId = c.UnitId,
						ConversionFactor = c.ConversionFactor,
						ProductBarCode = c.ProductBarCode,
						PurchasingPrice = c.PurchasingPrice,
						GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId),
						//QtyInStock = Math.Round(_repoProduct.GetById(c.ProductId).QtyInStock.Value * c.ConversionFactor.Value, 2),
						QtyInStockStr = string.Join(" - ", _repoProduct.GetById(c.ProductId).QtyInStock.Value, _repoProduct.GetById(c.ProductId).NameUnitOfQty)


					}).ToList(),

				}).FirstOrDefault();
			}
			return null;
		}

		public IQueryable<PurchaseInvoiceDTO> GetAllByDate(DateTime? date)
		{

			return _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date == date.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new PurchaseInvoiceDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = x.StockName,
				SupplierId = x.SupplierId,
				TotalPaid = x.TotalPaid,
				TransactionType = (int)x.TransactionType,

				SupplierName = x.SupplierName,
				IsActive = x.IsActive,

				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.PurchaseInvoiceDetail.Select(c => new PurchaseInvoiceProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = c.ProductName,
					Qty = c.Qty,
					UnitId = c.UnitId,
					ConversionFactor = c.ConversionFactor,
					ProductBarCode = c.ProductBarCode,
					PurchasingPrice = c.PurchasingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId),
					//QtyInStock = Math.Round(_repoProduct.GetById(c.ProductId).QtyInStock.Value * c.ConversionFactor.Value, 2),
					QtyInStockStr = string.Join(" - ", _repoProduct.GetById(c.ProductId).QtyInStock.Value, _repoProduct.GetById(c.ProductId).NameUnitOfQty)


				}).ToList(),

			});

		}
		public ResultViewModel GetByInvoiceNumberAndDate(int? number, DateTime? date)
		{
			var result = new ResultViewModel();
			result.Status = false;

			var invoice = _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceNumber == number && p.InvoiceDate.Date == date.Value.Date && p.IsActive && !p.IsDeleted).Select(x => new GetPurchaseInvoiceDTO
			{
				ID = x.ID,
				PurchaseInvoiceId = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = _repoStock.GetById(x.StockId).Name,
				SupplierId = x.SupplierId,
				TotalPaid = x.TotalPaid ?? 0,
				TransactionType = (int)x.TransactionType,
				SupplierName = _repoSupplier.GetById(x.SupplierId).Name,
				IsActive = x.IsActive,
				InvoiceDate = x.InvoiceDate,
				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.PurchaseInvoiceDetail.Select(c => new PurchaseInvoiceProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = c.ProductName,
					Qty = c.Qty,
					UnitId = c.UnitId,
					UnitName = _repoUnit.GetById(c.UnitId).Name,
					ConversionFactor = c.ConversionFactor,
					ProductBarCode = c.ProductBarCode,
					PurchasingPrice = c.PurchasingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId),
					QtyInStockStr = string.Join(" - ", Math.Round((_repoProduct.GetById(c.ProductId).QtyInStock.Value / c.ConversionFactor.Value), 2), _repoUnit.GetById(c.UnitId).Name),

				}).ToList(),
			}).FirstOrDefault();
			if (invoice != null)
			{
				var alreadThrowback = _repoThrowbackInvoice.GetAllAsNoTracking().Include(x => x.PurchaseThrowbackDetails).Where(x => x.PurchaseInvoiceId == invoice.ID && !x.IsDeleted).Select(x => x.PurchaseThrowbackDetails).ToList();
				var finalInvoice = invoice.GetInvoiceDetails.ToList();
				foreach (var item in invoice.GetInvoiceDetails)
				{
					var qty = alreadThrowback.Where(x => x.Any(xx => xx.UnitId == item.UnitId && xx.ProductId == item.ProductId)).ToList();
					if (qty != null && qty.Count() > 0)
					{
						decimal? allQty = 0;
						foreach (var iq in qty)
						{
							allQty += iq.Sum(x => x.Qty);
						}

						var currenRow = finalInvoice.Where(x => x.UnitId == item.UnitId && x.ProductId == item.ProductId).FirstOrDefault();
						var currenQty = currenRow.Qty;
						currenQty -= allQty;
						currenRow.Qty = currenQty;
						finalInvoice.Remove(invoice.GetInvoiceDetails.Where(x => x.UnitId == item.UnitId && x.ProductId == item.ProductId).FirstOrDefault());
						if(currenQty != 0)
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

				invoice.InvoiceTotalPrice = invoice.GetInvoiceDetails.Sum(x => x.TotalQtyPrice);
				result.Status = true;
				result.Data = invoice;
			}
			else
			{
				result.Message = "لاتوجد فاتورة مشتريات بهذا الرقم";
			}

			return result;
		}
		public IQueryable<PurchaseInvoiceDTO> GetAllByDate(DateTime? fromDate, DateTime? toDate)
		{

			return _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date >= fromDate.Value.Date && x.InvoiceDate.Date <= toDate.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new PurchaseInvoiceDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = x.StockName,
				SupplierId = x.SupplierId,
				TotalPaid = x.TotalPaid,
				TransactionType = (int)x.TransactionType,

				SupplierName = x.SupplierName,
				IsActive = x.IsActive,

				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.PurchaseInvoiceDetail.Select(c => new PurchaseInvoiceProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = c.ProductName,
					Qty = c.Qty,
					UnitId = c.UnitId,
					ConversionFactor = c.ConversionFactor,
					ProductBarCode = c.ProductBarCode,
					PurchasingPrice = c.PurchasingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId),
					//QtyInStock = Math.Round(_repoProduct.GetById(c.ProductId).QtyInStock.Value * c.ConversionFactor.Value, 2),
					QtyInStockStr = string.Join(" - ", _repoProduct.GetById(c.ProductId).QtyInStock.Value, _repoProduct.GetById(c.ProductId).NameUnitOfQty)



				}).ToList(),

			});

		}
		public DataTableResponse LoadData(DataTableRequest mdl)
		{
			var data = _repoInvoice.ExecuteStoredProcedure<PurchaseInvoicesTableDTO>
				(_spInvoices, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}


		#endregion
		#region Save 
		public ResultViewModel Save(PurchaseInvoiceDTO InvoiceDTO)
		{
			ResultViewModel resultViewModel = new ResultViewModel() { Status = false, Message = AppConstants.Messages.SavedFailed };


			var data = _repoInvoice.GetAllAsNoTracking().Include(x => x.PurchaseInvoiceDetail).Where(p => p.ID == InvoiceDTO.ID && p.IsActive && !p.IsDeleted).FirstOrDefault();
			if (InvoiceDTO.SupplierId == null || InvoiceDTO.SupplierId == Guid.Empty)
			{
				resultViewModel.Status = false;
				resultViewModel.Message = "من فضلك أختر المورد";
				return resultViewModel;
			}
			var Supplier = _repoSupplier.GetById(InvoiceDTO.SupplierId.Value);

			if(InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Length>0) {
				if(InvoiceDTO.InvoiceDetails.Any(x=>x.PurchasingPrice == 0))
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "لايمكن حفظ سعر الشراء للوحده بالقيمة 0";
					return resultViewModel;
				}
			}

			if (Supplier != null)
			{

				if (data != null)
				{
					var oldTotalPaid = data.TotalPaid ?? 0;
					var oldTotalInvoicePrice = data.InvoiceTotalPrice.Value;
					if (InvoiceDTO.InvoiceDetails.Where(x => x.PurchasingPrice == null || x.TotalQtyPrice == null).FirstOrDefault() != null)
					{
						resultViewModel.Status = false;
						resultViewModel.Message = "تأكد من إدخال سعر الشراء لكل منتج";
						return resultViewModel;
					}
					var newInvoice = data;

					newInvoice.StockId = InvoiceDTO.StockId;
					newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
					newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
					newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
					newInvoice.SupplierId = Supplier.ID;
					newInvoice.SupplierName = Supplier.Name;
					newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
					newInvoice.TransactionType = (TransactionType?)InvoiceDTO.TransactionType;
					newInvoice.InvoiceTotalPrice = InvoiceDTO.InvoiceDetails != null ? InvoiceDTO.InvoiceDetails.Sum(x => x.TotalQtyPrice) : 0;
					newInvoice.AddedBy = data.AddedBy;
					newInvoice.ModifiedDate = AppDateTime.Now;
					newInvoice.ModifiedBy = _repoInvoice.UserId;
					newInvoice.CreatedDate = data.CreatedDate;

					
					var NewInvoiceTotalPaid = newInvoice.TotalPaid ?? 0;
					var NewInvoiceTotalPrice = newInvoice.InvoiceTotalPrice.Value;
					var PriceDiff = NewInvoiceTotalPrice - NewInvoiceTotalPaid;
					var oldDiff = oldTotalInvoicePrice - oldTotalPaid;

                    Supplier.ProcessAmount = Supplier.ProcessAmount - oldDiff;
                    Supplier.ProcessAmount = Supplier.ProcessAmount + PriceDiff;

                    if (Supplier.ProcessAmount > 0)
                        Supplier.ProcessType = ProcessType.Debtor;
                    else if (Supplier.ProcessAmount < 0)
                        Supplier.ProcessType = ProcessType.Creditor;
                    else Supplier.ProcessType = null;


                    //             if (InvoiceDTO.TransactionType == 1 || InvoiceDTO.TransactionType == 0)
                    //             {
                    //                 if (Supplier.ProcessType != null)
                    //                 {
                    //                     if (Supplier.ProcessType == ProcessType.Debtor)
                    //                     {


                    //                         if (PriceDiff > 0)
                    //                             Supplier.ProcessAmount = Supplier.ProcessAmount + PriceDiff;
                    //                         else if (PriceDiff < 0)
                    //                             Supplier.ProcessAmount = Supplier.ProcessAmount - PriceDiff;

                    //                         if (Supplier.ProcessAmount < 0)
                    //                         {
                    //                             Supplier.ProcessType = ProcessType.Creditor;
                    //                         }

                    //                     }
                    //                     else
                    //                     {
                    //                         if (PriceDiff > 0)
                    //                             Supplier.ProcessAmount = Supplier.ProcessAmount - PriceDiff;
                    //                         else if (PriceDiff < 0)
                    //                             Supplier.ProcessAmount = Supplier.ProcessAmount + PriceDiff;

                    //                         if (Supplier.ProcessAmount < 0)
                    //                         {
                    //                             Supplier.ProcessType = ProcessType.Debtor;
                    //                         }
                    //                     }
                    //                 }
                    //                 else
                    //                 {
                    //if (oldDiff > 0)
                    //{
                    //	Supplier.ProcessAmount = Supplier.ProcessAmount - oldTotalInvoicePrice + oldTotalPaid;
                    //}
                    //else if(oldDiff < 0)
                    //{
                    //                         Supplier.ProcessAmount = Supplier.ProcessAmount + oldTotalInvoicePrice - oldTotalPaid;
                    //}

                    //                     Supplier.ProcessAmount = PriceDiff;

                    //                 }
                    //                 Supplier.ProcessAmount = Math.Abs(Supplier.ProcessAmount.Value);

                    //             }

                    decimal? TotalPrice = 0;
					var oldInvoiceDetails = data.PurchaseInvoiceDetail;
					if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
					{
						var AllInvoiceProducts = new List<Product>();
						var AllDetails = new List<PurchaseInvoiceDetail>();
						foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
						{
							var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.StockProducts.Any(c => c.ProductId == invoiceDetail.ProductId) && (x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() || x.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == invoiceDetail.ProductBarCode.Trim()))).FirstOrDefault();
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
									QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock ?? 0;
									ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
									TotalQtyInStock = QtyInStock * ConversionFactor;
								}

								if (oldDetail != null)
								{
									var oldEntireQty = oldDetail.Qty * oldDetail.ConversionFactor;
									TotalQtyInStock = TotalQtyInStock - oldEntireQty;
									var EntireQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;


									product.QtyInStock = TotalQtyInStock;
									product.QtyInStock = Math.Round((TotalQtyInStock + EntireQty) / ConversionFactor, 2);
									//_repoProduct.Update(product);

									if (product.QtyInStock < 0)
									{
										resultViewModel.Status = false;
										resultViewModel.Message = " الكمية المطلوب استرجاعها للمنتج " + product.Name + " غير متوفرة ";
										return resultViewModel;
									}
									else
									{
										AllInvoiceProducts.Remove(existProduct);
										AllInvoiceProducts.Add(product);

										oldDetail.ID = invoiceDetail.ID.Value;
										oldDetail.ProductBarCode = invoiceDetail.ProductBarCode;
										oldDetail.ProductId = invoiceDetail.ProductId;
										oldDetail.ProductName = invoiceDetail.ProductName;
										oldDetail.UnitId = invoiceDetail.UnitId;
										oldDetail.ConversionFactor = invoiceDetail.ConversionFactor;
										oldDetail.PurchasingPrice = invoiceDetail.PurchasingPrice;
										oldDetail.Qty = invoiceDetail.Qty;
										oldDetail.TotalQtyPrice = invoiceDetail.TotalQtyPrice;
										oldDetail.PurchaseInvoiceId = newInvoice.ID;

										AllDetails.Add(oldDetail);

									}


								}
								else
								{

									var EntireQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

									product.QtyInStock = TotalQtyInStock + EntireQty;
									product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);
									AllInvoiceProducts.Remove(existProduct);
									AllInvoiceProducts.Add(product);
									var newInvoiceDetail = new PurchaseInvoiceDetail()
									{
										AddedBy = _repoInvoice.UserId,
										IsActive = true,
										UnitId = invoiceDetail.UnitId,
										ConversionFactor = invoiceDetail.ConversionFactor,
										ProductBarCode = invoiceDetail.ProductBarCode,
										ProductId = invoiceDetail.ProductId,
										PurchasingPrice = invoiceDetail.PurchasingPrice,
										Qty = invoiceDetail.Qty,
										ID = Guid.NewGuid(),
										TotalQtyPrice = invoiceDetail.TotalQtyPrice,
										PurchaseInvoiceId = newInvoice.ID,
										ProductName = product.Name
									};
									AllDetails.Add(newInvoiceDetail);
								}
							}
							else
							{
								resultViewModel.Status = false;
								resultViewModel.Message = " لا يوجد منتج بهذا الباركود " + invoiceDetail.ProductBarCode + " أو المنتج المختار لاينتمي الي المخزن المحدد ";

								return resultViewModel;

							}
						}


						var deleteInvoiceDetaails = _repoInvoiceDetail.DeleteRange(oldInvoiceDetails);
						var saveInvoiceDetaails = _repoInvoiceDetail.InsertRange(AllDetails);
						if (deleteInvoiceDetaails && saveInvoiceDetaails && _repoSupplier.Update(Supplier))
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

					if(InvoiceDTO.InvoiceDetails.Where(x=>x.PurchasingPrice ==null || x.TotalQtyPrice == null).FirstOrDefault() != null)
					{
						resultViewModel.Status = false;
						resultViewModel.Message = "تأكد من إدخال سعر الشراء لكل منتج";
						return resultViewModel;
					}
					var newInvoice = new PurchaseInvoice();
					newInvoice.StockId = InvoiceDTO.StockId;
					newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
					newInvoice.InvoiceDate = DateTime.Now;
					newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
					newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
					newInvoice.SupplierId = Supplier.ID;
					newInvoice.SupplierName = Supplier.Name;
					newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
					newInvoice.TransactionType = (TransactionType?)InvoiceDTO.TransactionType;
					newInvoice.InvoiceTotalPrice = InvoiceDTO.InvoiceDetails != null ? InvoiceDTO.InvoiceDetails.Sum(x => x.TotalQtyPrice) : 0;
					newInvoice.AddedBy = _repoInvoice.UserId;


					decimal? TotalPrice = 0;
					

					if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
					{
						var AllInvoiceProducts = new List<Product>();
						if (_repoInvoice.Insert(newInvoice))
						{
							var AllDetails = new List<PurchaseInvoiceDetail>();
							var productUnitList = new List<ProductUnit>();
							foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
							{
								var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
								var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.StockProducts.Any(x => x.ProductId == invoiceDetail.ProductId && x.StockId == InvoiceDTO.StockId) && (x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() || x.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == invoiceDetail.ProductBarCode.Trim()))).FirstOrDefault();
								if (product != null)
								{
									var existProduct = AllInvoiceProducts.Where(x => x.BarCodeText == product.BarCodeText).FirstOrDefault();
									//IQueryable<ProductUnit> productUnit = null;
									decimal? QtyInStock = 0;
									decimal? ConversionFactor = 0;
									dynamic? TotalQtyInStock = 0;
									if (existProduct != null)
									{
										//productUnit = _repoProductUnit.GetAllAsNoTracking().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
										QtyInStock = existProduct.QtyInStock ?? 0;
										ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
										TotalQtyInStock = QtyInStock * ConversionFactor;
									}
									else
									{
										//productUnit = _repoProductUnit.GetAllAsNoTracking().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
										QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock ?? 0;
										ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
										TotalQtyInStock = QtyInStock * ConversionFactor;
									}
									var EntrieQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;
									if (EntrieQty > 0)
									{

										product.QtyInStock = TotalQtyInStock + EntrieQty;
										var NewproductUnit = productUnit.Where(x => x.UnitBarcodeText.Trim() == invoiceDetail.ProductBarCode.Trim()).FirstOrDefault();
										if (invoiceDetail.PurchasingPrice > 0)
										{
											NewproductUnit.PurchasingPrice = invoiceDetail.PurchasingPrice;
										}
										productUnitList.Remove(NewproductUnit);
										productUnitList.Add(NewproductUnit);
										product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);
										//_repoProduct.Update(product);
										AllInvoiceProducts.Remove(existProduct);
										AllInvoiceProducts.Add(product);
										var newInvoiceDetail = new PurchaseInvoiceDetail()
										{
											AddedBy = _repoInvoice.UserId,
											IsActive = true,
											UnitId = invoiceDetail.UnitId,
											ConversionFactor = invoiceDetail.ConversionFactor,
											ProductBarCode = invoiceDetail.ProductBarCode,
											ProductId = invoiceDetail.ProductId,
											PurchasingPrice = invoiceDetail.PurchasingPrice,
											Qty = invoiceDetail.Qty,
											ID = Guid.NewGuid(),
											TotalQtyPrice = invoiceDetail.TotalQtyPrice,
											PurchaseInvoiceId = newInvoice.ID,
											ProductName = product.Name
										};
										//_repoInvoiceDetail.Insert(newInvoiceDetail);
										AllDetails.Add(newInvoiceDetail);
										//TotalPrice += newInvoiceDetail.TotalQtyPrice;
									}
									else
									{
										resultViewModel.Status = false;
										resultViewModel.Message = "لا يمكن إدخال كمية أقل من أو تساوي القيمة 0 من المنتج ";
										resultViewModel.Data = newInvoice;
										_repoInvoice.Detached(newInvoice);
										newInvoice.IsDeleted = true;
										_repoInvoice.Update(newInvoice);
										return resultViewModel;
									}
								}
								else
								{
									resultViewModel.Status = false;
									resultViewModel.Message = " لا يوجد منتج بهذا الباركود " + invoiceDetail.ProductBarCode + " أو المنتج المختار لاينتمي الي المخزن المحدد ";
									resultViewModel.Data = newInvoice;
									_repoInvoice.Detached(newInvoice);
									newInvoice.IsDeleted = true;
									_repoInvoice.Update(newInvoice);
									return resultViewModel;
								}
							}
							//newInvoice.InvoiceTotalPrice = TotalPrice;
							var PriceDiff = newInvoice.TotalPaid ?? 0;
							PriceDiff = newInvoice.InvoiceTotalPrice.Value - PriceDiff;


							Supplier.ProcessAmount = Supplier.ProcessAmount + PriceDiff;

							if (Supplier.ProcessAmount > 0)
								Supplier.ProcessType = ProcessType.Debtor;
							else if (Supplier.ProcessAmount < 0)
								Supplier.ProcessType = ProcessType.Creditor;
							else Supplier.ProcessType = null;

							//if (InvoiceDTO.TransactionType == 1 || InvoiceDTO.TransactionType == 0)
							//{
							//	if (Supplier.ProcessType != null)
							//	{
							//		if (Supplier.ProcessType == ProcessType.Debtor)
							//		{
							//			if (PriceDiff > 0)
							//				Supplier.ProcessAmount = Supplier.ProcessAmount + PriceDiff;
							//			else if (PriceDiff < 0)
							//				Supplier.ProcessAmount = Supplier.ProcessAmount - PriceDiff;

							//			if (Supplier.ProcessAmount < 0)
							//			{
							//				Supplier.ProcessType = ProcessType.Creditor;
							//			}

							//		}
							//		else
							//		{
							//			if (PriceDiff > 0)
							//				Supplier.ProcessAmount = Supplier.ProcessAmount - PriceDiff;
							//			else if (PriceDiff < 0)
							//				Supplier.ProcessAmount = Supplier.ProcessAmount + PriceDiff;

							//			if (Supplier.ProcessAmount < 0)
							//			{
							//				Supplier.ProcessType = ProcessType.Debtor;
							//			}
							//		}
							//	}
							//	else
							//	{
							//		if (PriceDiff > 0)
							//			Supplier.ProcessType = ProcessType.Debtor;
							//		else if (PriceDiff < 0)
							//			Supplier.ProcessType = ProcessType.Creditor;

							//		Supplier.ProcessAmount = PriceDiff;

							//	}
       //                         Supplier.ProcessAmount = Math.Abs(Supplier.ProcessAmount.Value);

       //                     }

                            var saveDetails = _repoInvoiceDetail.InsertRange(AllDetails);

							if (saveDetails && _repoSupplier.Update(Supplier))
							{
								foreach (var item in productUnitList)
								{
									_repoProductUnit.Update(item);
								}
								resultViewModel.Status = true;
								resultViewModel.Message = AppConstants.Messages.SavedSuccess;
								var DataToPrint = _repoInvoice.ExecuteStoredProcedure<PurchaseInvoicePrintDto>("[Report].[spGetPurchaseInvoiceToPrint]", new[]  {
								new SqlParameter("@invoiceId",newInvoice.ID)
								}, CommandType.StoredProcedure);
								if (DataToPrint != null)
								{
									DataToPrint.FirstOrDefault().CompanyImageFullPath = _weebhost.WebRootPath + DataToPrint.FirstOrDefault().CompanyImage;

								}
								resultViewModel.Data = DataToPrint;
							}
							else
							{
								resultViewModel.Status = false;
								resultViewModel.Message = "خطأ في حفظ تفاصيل الفاتورة";
								_repoInvoice.Detached(newInvoice);
								newInvoice.IsDeleted = true;
								_repoInvoice.Update(newInvoice);
								resultViewModel.Data = newInvoice;
							}

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
			}
			else
			{
				resultViewModel.Status = false;
				resultViewModel.Message = "خطأ في تحديد المورد";
				return resultViewModel;
			}
			return resultViewModel;
		}
		#endregion


		#region Delete
		public ResultViewModel Delete(Guid id)
		{
			ResultViewModel resultViewModel = new ResultViewModel();
			var tbl = _repoInvoice.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();
			var RelatedInvoices = _repoThrowbackInvoice.GetAllAsNoTracking().Any(x => x.PurchaseInvoiceId == id && !x.IsDeleted);
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
