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
    public class PurchaseInvoiceBll
    {
        private const string _spInvoices = "[Guide].[spPurchaseInvoice]";
        private readonly IRepository<PurchaseInvoice> _repoInvoice;
        private readonly UnitBll _UnitBll;
        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<ProductUnit> _repoProductUnit;
        private readonly IRepository<PurchaseInvoiceDetail> _repoInvoiceDetail;
        private readonly IMapper _mapper;

        public PurchaseInvoiceBll(IRepository<Product> repoProduct, IRepository<ProductUnit> repoProductUnit, IRepository<Stock> repoStock, UnitBll UnitBll, IRepository<PurchaseInvoice> repoInvoice, IRepository<PurchaseInvoiceDetail> repoInvoiceDetail, IMapper mapper)
        {
            _repoInvoice = repoInvoice;
            _mapper = mapper;
            _repoInvoiceDetail = repoInvoiceDetail;
            _repoProduct = repoProduct;
            _UnitBll = UnitBll;
            _repoStock = repoStock;
            _repoProductUnit = repoProductUnit;
        }

        #region Get
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
                Supplier = x.Supplier,
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
                    ItemUnitPrice = c.ItemUnitPrice,
                    ProductBarCode = c.ProductBarCode,
                    SellingPrice = c.SellingPrice,
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
                Supplier = x.Supplier,
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
                    ItemUnitPrice = c.ItemUnitPrice,
                    ProductBarCode = c.ProductBarCode,
                    SellingPrice = c.SellingPrice,
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
                    Supplier = x.Supplier,
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
                        ItemUnitPrice = c.ItemUnitPrice,
                        ProductBarCode = c.ProductBarCode,
                        SellingPrice = c.SellingPrice,
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
                Supplier = x.Supplier,
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
                    ItemUnitPrice = c.ItemUnitPrice,
                    ProductBarCode = c.ProductBarCode,
                    SellingPrice = c.SellingPrice,
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
                Supplier = x.Supplier,
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
                    ItemUnitPrice = c.ItemUnitPrice,
                    ProductBarCode = c.ProductBarCode,
                    SellingPrice = c.SellingPrice,
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


            var data = _repoInvoice.GetAllAsNoTracking().Include(x => x.PurchaseInvoiceDetail).Where(p => p.ID != InvoiceDTO.ID && p.InvoiceNumber == InvoiceDTO.InvoiceNumber
                                                                                                && p.StockId == InvoiceDTO.StockId && p.InvoiceDate.Date == InvoiceDTO.InvoiceDate.Date).FirstOrDefault();
            if (data != null)
            {
                //if (_repoInvoice.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.InvoiceNumber == InvoiceDTO.InvoiceNumber
                //&& p.InvoiceDate == InvoiceDTO.InvoiceDate && p.StockId == InvoiceDTO.StockId).FirstOrDefault() != null)
                //{
                //    resultViewModel.Message = AppConstants.Messages.InvoiceAlreadyExists;
                //    return resultViewModel;
                //}
                //if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                //{
                //    var newInvoice = new PurchaseInvoice();
                //    newInvoice.StockId = InvoiceDTO.StockId;
                //    newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
                //    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                //    newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
                //    newInvoice.Supplier = InvoiceDTO.Supplier;
                //    decimal? TotalPrice = 0;

                //    var AllDetails = new List<PurchaseInvoiceDetail>();
                //    foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                //    {
                //        var product = _repoProduct.GetById(invoiceDetail.ProductId.Value);
                //        if (invoiceDetail.Qty > product.QtyInStock)
                //        {
                //            resultViewModel.Status = false;
                //            resultViewModel.Message = "الكمية المطلوبة من المنتج " + product.Name + " تجاوزت الكميو الموجودة بالمخزن";
                //            resultViewModel.Data = InvoiceDTO;
                //            return resultViewModel;
                //        }
                //        else
                //        {
                //            product.QtyInStock = product.QtyInStock - invoiceDetail.Qty;

                //            var newInvoiceDetail = new PurchaseInvoiceDetail()
                //            {
                //                AddedBy = _repoInvoice.UserId,
                //                IsActive = true,
                //                UnitId = invoiceDetail.UnitId,
                //                UnitName = _repoUnits.GetById(invoiceDetail.UnitId.Value).Name,
                //                ProductId = invoiceDetail.ProductId.Value,
                //                ProductName = product.Name,
                //                Qty = invoiceDetail.Qty,
                //                QtyPrice = invoiceDetail.QtyPrice,
                //                PurchaseInvoiceId = newInvoice.ID,
                //                SalePrice = invoiceDetail.SalePrice
                //            };
                //            TotalPrice += newInvoiceDetail.QtyPrice;
                //        }

                //    }
                //    newInvoice.TotalPrice = TotalPrice;
                //    if (_repoInvoice.Insert(newInvoice))
                //    {
                //        _repoProduct.SaveChange();
                //        var saveInvoiceDetaails = _repoInvoiceDetail.InsertRange(AllDetails);
                //        if (saveInvoiceDetaails)
                //        {
                //            resultViewModel.Status = true;
                //            resultViewModel.Message = AppConstants.Messages.SavedSuccess;
                //        }

                //    }
                //}

            }
            else
            {
                if (_repoInvoice.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.InvoiceNumber == InvoiceDTO.InvoiceNumber
                && p.InvoiceDate == InvoiceDTO.InvoiceDate && p.StockId == InvoiceDTO.StockId).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.InvoiceAlreadyExists;
                    return resultViewModel;
                }
                if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                {
                    var newInvoice = new PurchaseInvoice();
                    newInvoice.StockId = InvoiceDTO.StockId;
                    newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.Supplier = InvoiceDTO.Supplier;
                    decimal? TotalPrice = 0;

                    var AllDetails = new List<PurchaseInvoiceDetail>();
                    foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                    {
                        var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                        var product = _repoProduct.GetById(invoiceDetail.ProductId);
                        var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                        var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                        var TotalQtyInStock = QtyInStock * ConversionFactor;
                        var reuiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;
                        if (reuiredQty > TotalQtyInStock)
                        {
                            resultViewModel.Status = false;
                            resultViewModel.Message = "الكمية المطلوبة من المنتج " + product.Name + " تجاوزت الكميو الموجودة بالمخزن";
                            resultViewModel.Data = InvoiceDTO;
                            return resultViewModel;
                        }
                        else
                        {
                            product.QtyInStock = TotalQtyInStock - reuiredQty;
                            _repoProduct.UpdateWithoutSaveChange(product);
                            var newInvoiceDetail = new PurchaseInvoiceDetail()
                            {
                                AddedBy = _repoInvoice.UserId,
                                IsActive = true,
                                UnitId = invoiceDetail.UnitId,
                                ConversionFactor = invoiceDetail.ConversionFactor,
                                ProductBarCode = invoiceDetail.ProductBarCode,
                                ProductId = invoiceDetail.ProductId,
                                ItemUnitPrice = invoiceDetail.ItemUnitPrice,
                                SellingPrice = invoiceDetail.SellingPrice,
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
