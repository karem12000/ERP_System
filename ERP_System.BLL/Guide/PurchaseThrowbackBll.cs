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
        private readonly UnitBll _UnitBll;
        private readonly SupplierBll _supplierBll;
        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<ProductUnit> _repoProductUnit;
        private readonly IRepository<PurchaseThrowbackDetail> _repoInvoiceDetail;
        private readonly IMapper _mapper;

        public PurchaseThrowbackBll(IRepository<Product> repoProduct, SupplierBll supplierBll, IRepository<ProductUnit> repoProductUnit, IRepository<Stock> repoStock, UnitBll UnitBll, IRepository<PurchaseThrowback> repoInvoice, IRepository<PurchaseThrowbackDetail> repoInvoiceDetail, IMapper mapper)
        {
            _repoInvoice = repoInvoice;
            _mapper = mapper;
            _repoInvoiceDetail = repoInvoiceDetail;
            _repoProduct = repoProduct;
            _UnitBll = UnitBll;
            _repoStock = repoStock;
            _repoProductUnit = repoProductUnit;
            _supplierBll = supplierBll;
        }

        #region Get
        public int GetLastInvoiceNumberByDate(DateTime? date)
        {
            var invoiceNumber = _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date >= date.Value.Date)
                 .OrderByDescending(c => c.InvoiceDate).Select(c => c.InvoiceNumber).FirstOrDefault();

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
					QtyInStockStr = string.Join(" - " ,_repoProduct.GetById(c.ProductId).QtyInStock.Value , _repoProduct.GetById(c.ProductId).NameUnitOfQty)
                    
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


            var data = _repoInvoice.GetAllAsNoTracking().Include(x => x.PurchaseThrowbackDetails).Where(p => p.ID == InvoiceDTO.ID && p.IsActive && !p.IsDeleted).FirstOrDefault();
            if (data != null)
            {
                var Supplier = _supplierBll.GetById(data.SupplierId.Value);

                if (_repoInvoice.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.ID != data.ID && p.InvoiceNumber == InvoiceDTO.InvoiceNumber
                && p.InvoiceDate == InvoiceDTO.InvoiceDate && p.StockId == InvoiceDTO.StockId).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.InvoiceAlreadyExists;
                    return resultViewModel;
                }
                if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                {
                    var newInvoice = data;
                    newInvoice.StockId = InvoiceDTO.StockId;
                    newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
                    newInvoice.SupplierId = Supplier.ID;
                    newInvoice.SupplierName = Supplier.Name; decimal? TotalPrice = 0;
                    var oldInvoiceDetails = data.PurchaseThrowbackDetails;
                    if (newInvoice.InvoiceTotalPrice < 0)
                    {
                        resultViewModel.Status = false;
                        resultViewModel.Message = "لا يمكن حفظ الاجمالي للفاتورة بالقيمة السالبة";
                        return resultViewModel;
                    }
                    var AllDetails = new List<PurchaseThrowbackDetail>();
                    foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                    {
                        var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.StockProducts.Any(c => c.ProductId == invoiceDetail.ProductId) && (x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() || x.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == invoiceDetail.ProductBarCode.Trim()))).FirstOrDefault();

                        var oldDetail = oldInvoiceDetails.Where(x => x.ID == invoiceDetail.ID).FirstOrDefault();
                        if (oldDetail != null)
                        {

                            var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                            var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                            var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                            var TotalQtyInStock = (QtyInStock * ConversionFactor) + (oldDetail.Qty * oldDetail.ConversionFactor);
                            var oldRequiredQty = oldDetail.Qty * oldDetail.ConversionFactor;
                            var TotalRequiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

                            product.QtyInStock = Math.Round(TotalQtyInStock.Value, 2);

                            if (TotalRequiredQty > product.QtyInStock)
                            {
                                resultViewModel.Status = false;
                                resultViewModel.Message = "الكمية المراد استرجاعها للمنتج " + product.Name + " غير كافية ";
                                return resultViewModel;
                            }
                            else
                            {
                                product.QtyInStock = product.QtyInStock - TotalRequiredQty;

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

                                TotalPrice += newInvoiceDetail.TotalQtyPrice;
                            }


                        }
                        else
                        {
                            var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                            var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                            var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                            var TotalQtyInStock = QtyInStock * ConversionFactor;
                            var TotalRequiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

                            if (TotalRequiredQty > TotalQtyInStock)
                            {
                                resultViewModel.Status = false;
                                resultViewModel.Message = "الكمية المراد استرجاعها من المنتج " + product.Name + " غير متوفرة بالمخزن";
                                return resultViewModel;
                            }
                            else
                            {

                                product.QtyInStock = product.QtyInStock - TotalRequiredQty;
                                product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);

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

                                TotalPrice += newInvoiceDetail.TotalQtyPrice;
                            }

                        }


                    }
                    newInvoice.InvoiceTotalPrice = TotalPrice;
                    if (_repoInvoice.Insert(newInvoice))
                    {
                        _repoProduct.SaveChange();
                        var deleteInvoiceDetaails = _repoInvoiceDetail.DeleteRange(oldInvoiceDetails);
                        var saveInvoiceDetaails = _repoInvoiceDetail.InsertRange(AllDetails);
                        if (deleteInvoiceDetaails && saveInvoiceDetaails)
                        {
                            resultViewModel.Status = true;
                            resultViewModel.Message = AppConstants.Messages.SavedSuccess;
                        }
                        else
                        {
                            resultViewModel.Status = false;
                            resultViewModel.Message = "خطأ في حفظ تفاصيل الفاتورة";
                            return resultViewModel;

                        }

                    }
                }
            }
            else
            {
                var Supplier = _supplierBll.GetById(data.SupplierId.Value);

                if (_repoInvoice.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.InvoiceNumber == InvoiceDTO.InvoiceNumber
                && p.InvoiceDate == InvoiceDTO.InvoiceDate && p.StockId == InvoiceDTO.StockId).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.InvoiceAlreadyExists;
                    return resultViewModel;
                }
                if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                {
                    var newInvoice = new PurchaseThrowback();
                    newInvoice.StockId = InvoiceDTO.StockId;
                    newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.SupplierId = Supplier.ID;
                    newInvoice.SupplierName = Supplier.Name;
                    if (InvoiceDTO.TransactionType == 1)
                    {
                        var supplierAmount = newInvoice.InvoiceTotalPrice - newInvoice.TotalPaid;
                        if (Supplier.ProcessType != null)
                        {
                            if (Supplier.ProcessType == ProcessType.Creditor)
                            {
                                Supplier.ProcessAmount -= supplierAmount;
                                if (Supplier.ProcessAmount < 0)
                                {
                                    Supplier.ProcessType = ProcessType.Debtor;
                                    Supplier.ProcessAmount += Math.Abs(Supplier.ProcessAmount.Value);
                                }

                            }
                            else
                            {
                                Supplier.ProcessAmount += supplierAmount;
                                if (Supplier.ProcessAmount < 0)
                                {
                                    Supplier.ProcessType = ProcessType.Creditor;
                                    Supplier.ProcessAmount += Math.Abs(Supplier.ProcessAmount.Value);
                                }
                            }
                        }
                        else
                        {
                            Supplier.ProcessType = ProcessType.Creditor;
                            Supplier.ProcessAmount = supplierAmount;
                        }
                    }
                    if (newInvoice.InvoiceTotalPrice < 0)
                    {
                        resultViewModel.Status = false;
                        resultViewModel.Message = "لا يمكن حفظ الاجمالي للفاتورة بالقيمة السالبة";
                        return resultViewModel;
                    }
                    decimal? TotalPrice = 0;

                    var AllDetails = new List<PurchaseThrowbackDetail>();
                    foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                    {
                        var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                        var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.StockProducts.Any(c => c.ProductId == invoiceDetail.ProductId) && (x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() || x.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == invoiceDetail.ProductBarCode.Trim()))).FirstOrDefault();
                        var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                        var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                        var TotalQtyInStock = QtyInStock * ConversionFactor;
                        var TotalRequiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

                        if (TotalRequiredQty > TotalQtyInStock)
                        {
                            resultViewModel.Status = false;
                            resultViewModel.Message = "الكمية المراد استرجاعها من المنتج " + product.Name + " غير متوفرة بالمخزن";
                            return resultViewModel;
                        }
                        else
                        {
                            product.QtyInStock = TotalQtyInStock - TotalRequiredQty;
                            product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);
                            _repoProduct.UpdateWithoutSaveChange(product);
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
                            //_repoInvoiceDetail.Insert(newInvoiceDetail);
                            AllDetails.Add(newInvoiceDetail);
                            TotalPrice += newInvoiceDetail.TotalQtyPrice;
                        }

                    }
                    newInvoice.InvoiceTotalPrice = TotalPrice;
                    if (_repoInvoice.Insert(newInvoice))
                    {
                        _repoInvoiceDetail.InsertRange(AllDetails);
                        resultViewModel.Status = true;
                        resultViewModel.Message = AppConstants.Messages.SavedSuccess;


                    }
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
