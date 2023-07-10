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
	public class PurchaseThrowbackBll
	{
		private const string _spPurchaseThrowback = "[Guide].[spPurchaseThrowback]";
		private readonly IRepository<PurchaseThrowback> _repoInvoice;
		private readonly PurchaseInvoiceBll _repoPInvoice;
		private readonly UnitBll _UnitBll;
		//private readonly SupplierBll _supplierBll
		private readonly IRepository<Supplier> _repoSupplier;
		private readonly IRepository<Stock> _repoStock;
		private readonly IRepository<Product> _repoProduct;
		private readonly IRepository<ProductUnit> _repoProductUnit;
		private readonly IRepository<PurchaseThrowbackDetail> _repoInvoiceDetail;
		private readonly IMapper _mapper;

		public PurchaseThrowbackBll(IRepository<Product> repoProduct, PurchaseInvoiceBll repoPInvoice, IRepository<Supplier> repoSupplier, IRepository<ProductUnit> repoProductUnit, IRepository<Stock> repoStock, UnitBll UnitBll, IRepository<PurchaseThrowback> repoInvoice, IRepository<PurchaseThrowbackDetail> repoInvoiceDetail, IMapper mapper)
		{
			_repoInvoice = repoInvoice;
			_mapper = mapper;
			_repoInvoiceDetail = repoInvoiceDetail;
			_repoProduct = repoProduct;
			_UnitBll = UnitBll;
			_repoStock = repoStock;
			_repoProductUnit = repoProductUnit;
			_repoSupplier = repoSupplier;
			_repoPInvoice = repoPInvoice;
		}

		#region Get
		public int GetLastInvoiceNumberByDate(DateTime? date)
		{
			var invoiceNumber = _repoInvoice.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.InvoiceDate.Date >= date.Value.Date)
				 .OrderByDescending(c => c.CreatedDate).Select(c => c.InvoiceNumber).FirstOrDefault();

			return invoiceNumber;
		}
		public PurchaseThrowbackDTO GetById(Guid id)
		{
			return _repoInvoice.GetAllAsNoTracking().Include(c => c.PurchaseThrowbackDetails).Where(p => p.ID == id).Select(x => new PurchaseThrowbackDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				//InvoiceDate = x.InvoiceDate,
				InvoiceNumber = x.InvoiceNumber,
				PurchaseInvoiceId = x.PurchaseInvoiceId,
				PurchaseInvoiceDateStr = x.PurchaseInvoiceDate.Value.Date.ToString(),
				PurchaseInvoiceNo = _repoPInvoice.GetById(x.PurchaseInvoiceId.Value).InvoiceNumber,
				StockId = x.StockId,
				StockName = x.StockName,
				SupplierId = x.SupplierId,
				SupplierName = x.SupplierName,
				IsActive = x.IsActive,
				InvoiceTotalPrice = x.InvoiceTotalPrice,
				TransactionType = (int)x.TransactionType,
				TotalPaid = x.TotalPaid,
				GetInvoiceDetails = x.PurchaseThrowbackDetails.Select(c => new PurchaseThrowbackProductsDTO
				{
					ID = c.ID,
					ProductId = c.ProductId,
					ProductName = c.ProductName,
					Qty = c.Qty,
					UnitId = c.UnitId,
					ConversionFactor = c.ConversionFactor,
					PurchaseDetailId = c.PurchaseDetailId,
					ProductBarCode = c.ProductBarCode,
					PurchasingPrice = c.PurchasingPrice,
					GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId),
					QtyInStockStr = string.Join(" - ", _repoProduct.GetById(c.ProductId).QtyInStock.Value, _repoProduct.GetById(c.ProductId).NameUnitOfQty)
				}).ToList(),


			}).FirstOrDefault();
		}

		public PurchaseThrowbackDTO GetByInvoiceNumber(int? number)
		{
			return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceNumber == number && p.IsActive && !p.IsDeleted).Select(x => new PurchaseThrowbackDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = x.StockName,
				SupplierId = x.SupplierId,
				SupplierName = x.SupplierName,
				IsActive = x.IsActive,
				TransactionType = (int)x.TransactionType,
				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.PurchaseThrowbackDetails.Select(c => new PurchaseThrowbackProductsDTO
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
					QtyInStockStr = string.Join(" - ", _repoProduct.GetById(c.ProductId).QtyInStock.Value, _repoProduct.GetById(c.ProductId).NameUnitOfQty)

				}).ToList(),

			}).FirstOrDefault();
		}


		public PurchaseThrowbackDTO GetByInvoiceDate(DateTime? date)
		{
			if (date != null)
			{
				return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceDate.Date == date.Value.Date && p.IsActive && !p.IsDeleted).Select(x => new PurchaseThrowbackDTO
				{
					ID = x.ID,
					InvoiceDateStr = x.InvoiceDate.Date.ToString(),
					InvoiceNumber = x.InvoiceNumber,
					StockId = x.StockId,
					StockName = x.StockName,
					SupplierId = x.SupplierId,
					SupplierName = x.SupplierName,
					IsActive = x.IsActive,
					TransactionType = (int)x.TransactionType,
					InvoiceTotalPrice = x.InvoiceTotalPrice,
					GetInvoiceDetails = x.PurchaseThrowbackDetails.Select(c => new PurchaseThrowbackProductsDTO
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
						QtyInStockStr = string.Join(" - ", _repoProduct.GetById(c.ProductId).QtyInStock.Value, _repoProduct.GetById(c.ProductId).NameUnitOfQty)


					}).ToList(),

				}).FirstOrDefault();
			}
			return null;
		}

		public IQueryable<PurchaseThrowbackDTO> GetAllByDate(DateTime? date)
		{

			return _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date == date.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new PurchaseThrowbackDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = x.StockName,
				SupplierId = x.SupplierId,
				SupplierName = x.SupplierName,
				IsActive = x.IsActive,

				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.PurchaseThrowbackDetails.Select(c => new PurchaseThrowbackProductsDTO
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
					QtyInStockStr = string.Join(" - ", _repoProduct.GetById(c.ProductId).QtyInStock.Value, _repoProduct.GetById(c.ProductId).NameUnitOfQty)


				}).ToList(),

			});

		}
		public IQueryable<PurchaseThrowbackDTO> GetAllByDate(DateTime? fromDate, DateTime? toDate)
		{

			return _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date >= fromDate.Value.Date && x.InvoiceDate.Date <= toDate.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new PurchaseThrowbackDTO
			{
				ID = x.ID,
				InvoiceDateStr = x.InvoiceDate.Date.ToString(),
				InvoiceNumber = x.InvoiceNumber,
				StockId = x.StockId,
				StockName = x.StockName,
				SupplierId = x.SupplierId,
				SupplierName = x.SupplierName,
				IsActive = x.IsActive,

				InvoiceTotalPrice = x.InvoiceTotalPrice,
				GetInvoiceDetails = x.PurchaseThrowbackDetails.Select(c => new PurchaseThrowbackProductsDTO
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
					QtyInStockStr = string.Join(" - ", _repoProduct.GetById(c.ProductId).QtyInStock.Value, _repoProduct.GetById(c.ProductId).NameUnitOfQty)


				}).ToList(),

			});

		}
		public DataTableResponse LoadData(DataTableRequest mdl)
		{
			var data = _repoInvoice.ExecuteStoredProcedure<PurchaseThrowbackTableDTO>
				(_spPurchaseThrowback, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}


		#endregion
		#region Save 
		public ResultViewModel Save(PurchaseThrowbackDTO InvoiceDTO)
		{
			ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };

			var purchaseInvoice = _repoPInvoice.GetById(InvoiceDTO.PurchaseInvoiceId.Value);
			if (purchaseInvoice == null)
			{
				resultViewModel.Status = false;
				resultViewModel.Message = "خطأ في تحديد فاتورة المشتريات من فضلك تأكد من البحث عن الفاتورة";
				return resultViewModel;
			}
			if(InvoiceDTO.SupplierId == null || InvoiceDTO.SupplierId == Guid.Empty)
			{
				resultViewModel.Status = false;
				resultViewModel.Message = "من فضلك أختر المورد";
				return resultViewModel;
			}
			var AllPurchaseThrowbackInvoices = _repoInvoice.GetAllAsNoTracking().Where(x => x.PurchaseInvoiceId == InvoiceDTO.PurchaseInvoiceId && !x.IsDeleted).ToList();
			var data = _repoInvoice.GetAllAsNoTracking().Include(x => x.PurchaseThrowbackDetails).Where(p => p.ID == InvoiceDTO.ID && p.IsActive && !p.IsDeleted).FirstOrDefault();
			var Supplier = _repoSupplier.GetById(InvoiceDTO.SupplierId.Value);
			if (Supplier != null)
			{
				if (data != null)
				{
					var oldInvoiceTotalPaid = data.TotalPaid ?? 0;
					var oldInvoiceTotalPrice = data.InvoiceTotalPrice ?? 0;

					var newInvoice = data;
					newInvoice.StockId = InvoiceDTO.StockId;
					newInvoice.PurchaseInvoiceId = InvoiceDTO.PurchaseInvoiceId;
					newInvoice.PurchaseInvoiceDate = InvoiceDTO.PurchaseInvoiceDate;
					newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
					newInvoice.AddedTax = data.AddedTax ?? 0;
					newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
					newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
					newInvoice.SupplierId = Supplier.ID;
					newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
					newInvoice.TransactionType = (TransactionType?)InvoiceDTO.TransactionType;
					newInvoice.InvoiceTotalPrice = InvoiceDTO.InvoiceDetails != null ? InvoiceDTO.InvoiceDetails.Sum(x => x.TotalQtyPrice) : 0;
					newInvoice.AddedBy = data.AddedBy;
					newInvoice.ModifiedDate = AppDateTime.Now;
					newInvoice.ModifiedBy = _repoInvoice.UserId;
					newInvoice.CreatedDate = data.CreatedDate;

					if (newInvoice.InvoiceTotalPrice < 0)
					{
						resultViewModel.Status = false;
						resultViewModel.Message = "لا يمكن حفظ الاجمالي للفاتورة بالقيمة السالبة";
						return resultViewModel;
					}
					#region Supplier ProcessType and Amount
					
					var InvoiceTotalPaid = newInvoice.TotalPaid ?? 0;
					var invoiceTotPrice = newInvoice.InvoiceTotalPrice??0;
					var diffPrice = invoiceTotPrice- InvoiceTotalPaid;
					if (InvoiceDTO.TransactionType == 1 || InvoiceDTO.TransactionType == 0)
					{
						if (Supplier.ProcessType != null)
						{
							Supplier.ProcessAmount = Supplier.ProcessAmount + oldInvoiceTotalPrice - oldInvoiceTotalPaid;
							if (Supplier.ProcessType == ProcessType.Creditor)
							{
								Supplier.ProcessAmount = diffPrice > 0 ? Supplier.ProcessAmount + diffPrice : Supplier.ProcessAmount - diffPrice;
								if (Supplier.ProcessAmount < 0)
								{
									Supplier.ProcessType = ProcessType.Debtor;
									Supplier.ProcessAmount = Math.Abs(Supplier.ProcessAmount.Value);
								}

							}
							else
							{
								Supplier.ProcessAmount = diffPrice > 0 ? Supplier.ProcessAmount - diffPrice : Supplier.ProcessAmount + diffPrice;
								if (Supplier.ProcessAmount < 0)
								{
									Supplier.ProcessType = ProcessType.Creditor;
									Supplier.ProcessAmount = Math.Abs(Supplier.ProcessAmount.Value);
								}
							}
						}
						else
						{
							Supplier.ProcessType = diffPrice > 0 ? ProcessType.Creditor : ProcessType.Debtor;
							Supplier.ProcessAmount = Supplier.ProcessAmount + diffPrice;
						}
						Supplier.ProcessAmount = Math.Abs(Supplier.ProcessAmount.Value);
					}
					#endregion


					decimal? TotalPrice = 0;
					var oldInvoiceDetails = data.PurchaseThrowbackDetails;
					if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
					{

						var AllInvoiceProducts = new List<Product>();
						var AllDetails = new List<PurchaseThrowbackDetail>();
						foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
						{
							var oldDetail = oldInvoiceDetails.Where(x => x.ID == invoiceDetail.ID).FirstOrDefault();
							var purchaseProduct = purchaseInvoice.GetInvoiceDetails.Where(x => x.ID == invoiceDetail.PurchaseDetailId).FirstOrDefault();
							var existPurchaseThrowbackProduct = _repoInvoice.GetAllAsNoTracking()
									.Where(x => x.PurchaseInvoiceId == InvoiceDTO.PurchaseInvoiceId && !x.IsDeleted && x.PurchaseInvoiceDate == InvoiceDTO.PurchaseInvoiceDate && x.PurchaseThrowbackDetails.Any(x => x.ProductId == invoiceDetail.ProductId && !x.IsDeleted))
									.Select(x => new SaleThrowbackproductDto
									{
										ConversionFactor = x.PurchaseThrowbackDetails.Where(xx => xx.ProductId == invoiceDetail.ProductId && !x.IsDeleted).FirstOrDefault().ConversionFactor,
										Qty = x.PurchaseThrowbackDetails.Where(xx => xx.ProductId == invoiceDetail.ProductId && !x.IsDeleted).FirstOrDefault().Qty
									});
							decimal? alreadyThrowbacks = 0;
							if(purchaseProduct != null)
							{
								var canThrowback = (invoiceDetail.Qty.Value * invoiceDetail.ConversionFactor.Value) > (purchaseProduct.Qty.Value * purchaseProduct.ConversionFactor.Value);
								if (canThrowback)
								{
									resultViewModel.Status = false;
									resultViewModel.Message = "لا يمكن إرجاع كمية أكبر من الكمية الموجودة بفاتورة المشتريات " + purchaseProduct.ProductName;
									return resultViewModel;
								}

								if (existPurchaseThrowbackProduct != null)
								{
									foreach (var item in existPurchaseThrowbackProduct)
									{
										alreadyThrowbacks += item.Qty * item.ConversionFactor;
									}
									canThrowback = (invoiceDetail.Qty.Value * invoiceDetail.ConversionFactor.Value) > (((purchaseProduct.Qty.Value * purchaseProduct.ConversionFactor.Value) +(oldDetail.Qty.Value * oldDetail.ConversionFactor.Value) ) - (alreadyThrowbacks));
									if (canThrowback)
									{
										resultViewModel.Status = false;
										resultViewModel.Message = "لايمكن إرجاع الكمية لانها تمت إرجاعها من قبل " + invoiceDetail.ProductName;
										return resultViewModel;
									}
								}

								var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.StockProducts.Any(c => c.ProductId == invoiceDetail.ProductId) && (x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() || x.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == invoiceDetail.ProductBarCode.Trim()))).FirstOrDefault();
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
										QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
										ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
										TotalQtyInStock = QtyInStock * ConversionFactor;
									}

									if (oldDetail != null)
									{
										var oldEntireQty = oldDetail.Qty * oldDetail.ConversionFactor;
										TotalQtyInStock = TotalQtyInStock + oldEntireQty;
										var requiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;


										product.QtyInStock = TotalQtyInStock;
										product.QtyInStock = Math.Round((TotalQtyInStock.Value - requiredQty.Value) / ConversionFactor.Value, 2);

										if (product.QtyInStock < 0)
										{
											resultViewModel.Status = false;
											resultViewModel.Message = " الكمية المطلوب استرجاعها للمنتج " + product.Name + " غير متوفرة  ";
											return resultViewModel;
										}
										else
										{
											AllInvoiceProducts.Remove(existProduct);
											AllInvoiceProducts.Add(product);

											oldDetail.Qty = invoiceDetail.Qty;
											oldDetail.ConversionFactor = invoiceDetail.ConversionFactor;
											oldDetail.TotalQtyPrice = invoiceDetail.TotalQtyPrice;
											oldDetail.TotalQtyPrice = invoiceDetail.TotalQtyPrice;
											oldDetail.PurchasingPrice = invoiceDetail.PurchasingPrice;
											oldDetail.UnitId = invoiceDetail.UnitId;
											oldDetail.ProductBarCode = invoiceDetail.ProductBarCode;
											oldDetail.ProductName = invoiceDetail.ProductName;
											oldDetail.ProductId = invoiceDetail.ProductId;
											oldDetail.PurchaseDetailId = invoiceDetail.PurchaseDetailId;
											oldDetail.PurchaseThrowbackId = oldDetail.PurchaseThrowbackId;
											AllDetails.Add(oldDetail);

										}
									}
									else
									{

										var requiredAQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

										product.QtyInStock = TotalQtyInStock - requiredAQty.Value;
										product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);
										if (requiredAQty > product.QtyInStock)
										{
											resultViewModel.Status = false;
											resultViewModel.Message = " الكمية المطلوب استرجاعها للمنتج " + product.Name + " غير متوفرة  ";
											return resultViewModel;
										}
										else
										{
											AllInvoiceProducts.Remove(existProduct);
											AllInvoiceProducts.Add(product);

											var newInvoiceDetail = new PurchaseThrowbackDetail()
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
												PurchaseThrowbackId = newInvoice.ID,
												ProductName = product.Name
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
							else
							{
								resultViewModel.Status = false;
								resultViewModel.Message = "لايمكن إرجاع منتج غير موجود بفاتورة المشتريات من فضلك تأكد من وجود المنتجات المراد عمل ارجاع لها بفاتورة المشتريات";
								return resultViewModel;
							}
							
						}

						#region Save
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
							return resultViewModel;

						}
						#endregion
					}
					else
					{
						resultViewModel.Status = false;
						resultViewModel.Message = "هذه الفاتورة لا تحتوي علي منتجات";
					}
				}
				else
				{
					var newInvoice = new PurchaseThrowback();
					newInvoice.StockId = InvoiceDTO.StockId;
					newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
					newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
					newInvoice.AddedTax = InvoiceDTO.AddedTax ?? 0;
					newInvoice.PurchaseInvoiceId = InvoiceDTO.PurchaseInvoiceId;
					newInvoice.PurchaseInvoiceDate = InvoiceDTO.PurchaseInvoiceDate;
					newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
					newInvoice.SupplierId = Supplier.ID;
					newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
					newInvoice.TransactionType = (TransactionType?)InvoiceDTO.TransactionType;
					newInvoice.InvoiceTotalPrice = InvoiceDTO.InvoiceDetails != null ? InvoiceDTO.InvoiceDetails.Sum(x => x.TotalQtyPrice) : 0;
					newInvoice.AddedBy = _repoInvoice.UserId;
					if (newInvoice.InvoiceTotalPrice < 0)
					{
						resultViewModel.Status = false;
						resultViewModel.Message = "لا يمكن حفظ الاجمالي للفاتورة بالقيمة السالبة";
						return resultViewModel;
					}

					#region Supplier Process Type And Amount
					var InvoiceTotalPaid = newInvoice.TotalPaid ?? 0;
					var invoiceTotPrice = newInvoice.InvoiceTotalPrice.Value;

					var diffPrice = invoiceTotPrice- InvoiceTotalPaid;
					if (InvoiceDTO.TransactionType == 1 || InvoiceDTO.TransactionType == 0)
					{
						if (Supplier.ProcessType != null)
						{
							if (Supplier.ProcessType == ProcessType.Creditor)
							{
								Supplier.ProcessAmount =diffPrice>0? Supplier.ProcessAmount+diffPrice : Supplier.ProcessAmount-diffPrice ;
								if (Supplier.ProcessAmount < 0)
								{
									Supplier.ProcessType = ProcessType.Debtor;
									Supplier.ProcessAmount = Math.Abs(Supplier.ProcessAmount.Value);
								}

							}
							else
							{
								Supplier.ProcessAmount =diffPrice>0? Supplier.ProcessAmount - diffPrice : Supplier.ProcessAmount+diffPrice;
								if (Supplier.ProcessAmount < 0)
								{
									Supplier.ProcessType = ProcessType.Creditor;
									Supplier.ProcessAmount = Math.Abs(Supplier.ProcessAmount.Value);
								}
							}
						}
						else
						{
							Supplier.ProcessType =diffPrice>0? ProcessType.Creditor : ProcessType.Debtor;
							Supplier.ProcessAmount = Supplier.ProcessAmount +diffPrice ;
							
						}
						Supplier.ProcessAmount = Math.Abs (Supplier.ProcessAmount.Value);
					}
					#endregion

					if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
					{
						if (_repoInvoice.Insert(newInvoice))
						{
							var AllInvoiceProducts = new List<Product>();
							var AllDetails = new List<PurchaseThrowbackDetail>();
							foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
							{

								var purchaseProduct = purchaseInvoice.GetInvoiceDetails.Where(x => x.ID == invoiceDetail.PurchaseDetailId).FirstOrDefault();
								var existPurchaseThrowbackProduct = _repoInvoice.GetAllAsNoTracking()
									.Where(x => x.PurchaseInvoiceId == InvoiceDTO.PurchaseInvoiceId && !x.IsDeleted && x.PurchaseInvoiceDate == InvoiceDTO.PurchaseInvoiceDate && x.PurchaseThrowbackDetails.Any(x => x.ProductId == invoiceDetail.ProductId && !x.IsDeleted))
									.Select(x => new SaleThrowbackproductDto
									{
										ConversionFactor = x.PurchaseThrowbackDetails.Where(xx => xx.ProductId == invoiceDetail.ProductId && !x.IsDeleted).FirstOrDefault().ConversionFactor,
										Qty = x.PurchaseThrowbackDetails.Where(xx => xx.ProductId == invoiceDetail.ProductId && !x.IsDeleted).FirstOrDefault().Qty
									});
								decimal? alreadyThrowbacks = 0;

								if (purchaseProduct != null)
								{

									var canThrowback = (invoiceDetail.Qty.Value * invoiceDetail.ConversionFactor.Value) > (purchaseProduct.Qty.Value * purchaseProduct.ConversionFactor.Value);
									if (canThrowback)
									{
										resultViewModel.Status = false;
										resultViewModel.Message = "لا يمكن إرجاع كمية أكبر من الكمية التي تم شراؤها للمنتج " + purchaseProduct.ProductName;
										_repoInvoice.Detached(newInvoice);
										newInvoice.IsDeleted = true;
										_repoInvoice.Update(newInvoice);
										return resultViewModel;
									}
									if (existPurchaseThrowbackProduct != null)
									{
										foreach (var item in existPurchaseThrowbackProduct)
										{
											alreadyThrowbacks += item.Qty * item.ConversionFactor;
										}
										canThrowback = (invoiceDetail.Qty.Value * invoiceDetail.ConversionFactor.Value) > ((purchaseProduct.Qty.Value * purchaseProduct.ConversionFactor.Value) - (alreadyThrowbacks));
										if (canThrowback)
										{
											resultViewModel.Status = false;
											resultViewModel.Message = "لايمكن إرجاع الكمية لانها تمت إرجاعها من قبل " + invoiceDetail.ProductName;
											_repoInvoice.Detached(newInvoice);
											newInvoice.IsDeleted = true;
											_repoInvoice.Update(newInvoice);
											return resultViewModel;
										}
									}

									var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.StockProducts.Any(x => x.ProductId == invoiceDetail.ProductId && x.StockId == InvoiceDTO.StockId) && (x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() || x.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == invoiceDetail.ProductBarCode.Trim()))).FirstOrDefault();
									var existProduct = AllInvoiceProducts.Where(x => x.BarCodeText == product.BarCodeText).FirstOrDefault();
									var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);


									decimal? QtyInStock = 0;
									decimal? ConversionFactor = 0;
									dynamic? TotalQtyInStock = 0;
									if (product != null)
									{
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

										var TotalRequiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

										if (TotalRequiredQty > TotalQtyInStock)
										{
											resultViewModel.Status = false;
											resultViewModel.Message = " الكمية المراد استرجاعها من المنتج " + product.Name + " غير متوفرة ";
											_repoInvoice.Detached(newInvoice);
											newInvoice.IsDeleted = true;
											_repoInvoice.Update(newInvoice);
											return resultViewModel;
										}
										else
										{
											product.QtyInStock = TotalQtyInStock - TotalRequiredQty;
											product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);
											AllInvoiceProducts.Remove(existProduct);
											AllInvoiceProducts.Add(product);
											var newInvoiceDetail = new PurchaseThrowbackDetail()
											{
												AddedBy = _repoInvoice.UserId,
												IsActive = true,
												UnitId = invoiceDetail.UnitId,
												ConversionFactor = invoiceDetail.ConversionFactor,
												ProductBarCode = invoiceDetail.ProductBarCode,
												ProductId = invoiceDetail.ProductId,
												PurchasingPrice = invoiceDetail.PurchasingPrice,
												PurchaseDetailId = invoiceDetail.PurchaseDetailId,
												Qty = invoiceDetail.Qty,
												ID = Guid.NewGuid(),
												TotalQtyPrice = invoiceDetail.TotalQtyPrice,
												PurchaseThrowbackId = newInvoice.ID,
												ProductName = product.Name
											};
											AllDetails.Add(newInvoiceDetail);
										}
									}
									else
									{
										resultViewModel.Status = false;
										resultViewModel.Message = " لا يوجد منتج بهذا الباركود " + invoiceDetail.ProductBarCode + " أو المنتج المختار لاينتمي الي المخزن المحدد ";
										_repoInvoice.Detached(newInvoice);
										newInvoice.IsDeleted = true;
										_repoInvoice.Update(newInvoice);
										return resultViewModel;

									}


								}
								else
								{
									resultViewModel.Status = false;
									resultViewModel.Message = "لايمكن إرجاع منتج غير موجود بفاتورة المشتريات من فضلك تأكد من وجود المنتجات المراد عمل ارجاع لها بفاتورة المشتريات";
									_repoInvoice.Detached(newInvoice);
									newInvoice.IsDeleted = true;
									_repoInvoice.Update(newInvoice);
									return resultViewModel;
								}

							}

							#region Save
							if (_repoInvoiceDetail.InsertRange(AllDetails) && _repoSupplier.Update(Supplier))
							{
								resultViewModel.Status = true;
								resultViewModel.Message = AppConstants.Messages.SavedSuccess;
							}
							else
							{
								_repoInvoice.Detached(newInvoice);
								newInvoice.IsDeleted = true;
								_repoInvoice.Update(newInvoice);
								resultViewModel.Status = false;
								resultViewModel.Message = AppConstants.Messages.SavedFailed;
							}

							#endregion
						}
						else
						{
							resultViewModel.Status = false;
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
				resultViewModel.Message = "من فضلك تأكد من المورد";

			}

			return resultViewModel;
		}
		#endregion


		#region Delete
		public ResultViewModel Delete(Guid id)
		{
			ResultViewModel resultViewModel = new ResultViewModel();
			var tbl = _repoInvoice.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

			if (tbl == null)
			{
				resultViewModel.Status = false;
				resultViewModel.Message = AppConstants.Messages.DeletedFailed;
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
