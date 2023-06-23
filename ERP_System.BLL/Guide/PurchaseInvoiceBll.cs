﻿using ERP_System.Common;
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
    public class PurchaseInvoiceBll
    {
        private const string _spInvoices = "[Guide].[spPurchaseInvoice]";
        private readonly IRepository<PurchaseInvoice> _repoInvoice;
        private readonly UnitBll _UnitBll;
        private readonly SupplierBll _supplierBll;
        private readonly IRepository<Supplier> _repoSupplier;
        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<ProductUnit> _repoProductUnit;
        private readonly IRepository<PurchaseInvoiceDetail> _repoInvoiceDetail;
        private readonly IMapper _mapper;

        public PurchaseInvoiceBll(IRepository<Product> repoProduct, IRepository<Supplier> repoSupplier, SupplierBll supplierBll, IRepository<ProductUnit> repoProductUnit, IRepository<Stock> repoStock, UnitBll UnitBll, IRepository<PurchaseInvoice> repoInvoice, IRepository<PurchaseInvoiceDetail> repoInvoiceDetail, IMapper mapper)
        {
            _repoInvoice = repoInvoice;
            _mapper = mapper;
            _repoInvoiceDetail = repoInvoiceDetail;
            _repoProduct = repoProduct;
            _UnitBll = UnitBll;
            _repoStock = repoStock;
            _repoProductUnit = repoProductUnit;
            _supplierBll = supplierBll;
            _repoSupplier = repoSupplier;
        }

        #region Get
        public int GetLastInvoiceNumberByDate(DateTime? date)
        {
            var invoiceNumber = _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date >= date.Value.Date)
                 .OrderByDescending(c => c.InvoiceDate).Select(c => c.InvoiceNumber).FirstOrDefault();

            return invoiceNumber;
        }
        public PurchaseInvoiceDTO GetById(Guid id)
        {
            return _repoInvoice.GetAllAsNoTracking().Include(c => c.PurchaseInvoiceDetail).Where(p => p.ID == id).Select(x => new PurchaseInvoiceDTO
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
                TotalPaid = x.TotalPaid,
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
                    GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)
                }).ToList(),


            }).FirstOrDefault();
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
                    GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)

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
                        GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)

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
                    GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)

                }).ToList(),

            });

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
                    GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)

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
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoInvoice.GetAllAsNoTracking().Include(x => x.PurchaseInvoiceDetail).Where(p => p.ID == InvoiceDTO.ID && p.IsActive && !p.IsDeleted).FirstOrDefault();
            if (data != null)
            {
                var Supplier = _repoSupplier.GetById(data.SupplierId.Value);
                if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                {
                    var newInvoice = data;

                    newInvoice.StockId = InvoiceDTO.StockId;
                    newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
                    newInvoice.SupplierId = Supplier.ID;
                    newInvoice.SupplierName = Supplier.Name;
                    newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
                    newInvoice.TransactionType = (TransactionType?)InvoiceDTO.TransactionType;
                    if (newInvoice.InvoiceTotalPrice < 0)
                    {
                        resultViewModel.Status = false;
                        resultViewModel.Message = "لا يمكن حفظ الاجمالي للفاتورة بالقيمة السالبة";
                        return resultViewModel;
                    }
                    decimal? TotalPrice = 0;
                    var oldInvoiceDetails = data.PurchaseInvoiceDetail;

                    var AllDetails = new List<PurchaseInvoiceDetail>();
                    foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                    {
                        var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() && x.StockProducts.Any(x => x.ProductId == invoiceDetail.ProductId)).FirstOrDefault();
                        if (product != null)
                        {
                            var oldDetail = oldInvoiceDetails.Where(x => x.ID == invoiceDetail.ID).FirstOrDefault();
                            if (oldDetail != null)
                            {

                                var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                                var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                                var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                                var TotalQtyInStock = (QtyInStock * ConversionFactor) + (oldDetail.Qty * oldDetail.ConversionFactor);
                                var oldEntireQty = oldDetail.Qty * oldDetail.ConversionFactor;
                                var EntireQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;


                                product.QtyInStock = TotalQtyInStock - oldEntireQty;
                                product.QtyInStock = TotalQtyInStock + EntireQty;
                                if (product.QtyInStock < 0)
                                {
                                    resultViewModel.Status = false;
                                    resultViewModel.Message = "الكمية المراد استرجاعها للمنتج " + product.Name + " غير كافية ";
                                    return resultViewModel;
                                }
                                else
                                {
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

                                    TotalPrice += newInvoiceDetail.TotalQtyPrice;
                                }


                            }
                            else
                            {
                                var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                                var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                                var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                                var TotalQtyInStock = (QtyInStock * ConversionFactor) + (oldDetail.Qty * oldDetail.ConversionFactor);
                                var EntireQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

                                product.QtyInStock = product.QtyInStock + EntireQty;
                                product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);

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

                                TotalPrice += newInvoiceDetail.TotalQtyPrice;

                            }
                        }
                        else
                        {
                            resultViewModel.Status = false;
                            resultViewModel.Message = "لا يوجد منتج بهذا الباركود " + invoiceDetail.ProductBarCode;
                            return resultViewModel;

                        }

                    }
                    newInvoice.InvoiceTotalPrice = TotalPrice;
                    if (_repoInvoice.Insert(newInvoice))
                    {
                        _repoSupplier.Update(Supplier);
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
                var Supplier = _repoSupplier.GetById(data.SupplierId.Value);


                if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                {
                    var newInvoice = new PurchaseInvoice();
                    newInvoice.StockId = InvoiceDTO.StockId;
                    newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.SupplierId = Supplier.ID;
                    newInvoice.SupplierName = Supplier.Name;
                    newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
                    newInvoice.TransactionType = (TransactionType?)InvoiceDTO.TransactionType;
                    if (InvoiceDTO.TransactionType == 1)
                    {
                        if (Supplier.ProcessType != null)
                        {
                            if (Supplier.ProcessType == ProcessType.Debtor)
                            {
                                Supplier.ProcessAmount += newInvoice.InvoiceTotalPrice;
                            }
                            else
                            {
                                Supplier.ProcessAmount -= newInvoice.InvoiceTotalPrice;
                            }
                        }
                        else
                        {
                            Supplier.ProcessType = ProcessType.Debtor;
                            Supplier.ProcessAmount = newInvoice.InvoiceTotalPrice;
                        }
                    }
                    decimal? TotalPrice = 0;
                    if (newInvoice.InvoiceTotalPrice < 0)
                    {
                        resultViewModel.Status = false;
                        resultViewModel.Message = "لا يمكن حفظ الاجمالي للفاتورة بالقيمة السالبة";
                        return resultViewModel;
                    }
                    var AllDetails = new List<PurchaseInvoiceDetail>();
                    foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                    {
                        var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                        var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() && x.StockProducts.Any(x => x.ProductId == invoiceDetail.ProductId)).FirstOrDefault();
                        if (product != null)
                        {
                            var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                            var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                            var TotalQtyInStock = QtyInStock * ConversionFactor;
                            var EntrieQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

                            product.QtyInStock = TotalQtyInStock + EntrieQty;
                            product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);
                            _repoProduct.UpdateWithoutSaveChange(product);
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
                            TotalPrice += newInvoiceDetail.TotalQtyPrice;
                        }
                        else
                        {
                            resultViewModel.Status = false;
                            resultViewModel.Message = "لا يوجد منتج بهذا الباركود " + invoiceDetail.ProductBarCode;
                            return resultViewModel;

                        }

                    }
                    newInvoice.InvoiceTotalPrice = TotalPrice;
                    if (_repoInvoice.Insert(newInvoice))
                    {
                        _repoSupplier.Update(Supplier);
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
