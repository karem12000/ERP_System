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
        private readonly UnitBll _UnitBll;
        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<ProductUnit> _repoProductUnit;
        private readonly IRepository<SaleInvoiceDetail> _repoInvoiceDetail;
        private readonly IMapper _mapper;

        public SaleInvoiceBll(IRepository<Product> repoProduct, IRepository<ProductUnit> repoProductUnit, IRepository<Stock> repoStock, UnitBll UnitBll, IRepository<SaleInvoice> repoInvoice, IRepository<SaleInvoiceDetail> repoInvoiceDetail, IMapper mapper)
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
        public SaleInvoiceDTO GetById(Guid id)
        {
            return _repoInvoice.GetAllAsNoTracking().Include(c => c.SaleInvoiceDetail).Where(p => p.ID == id).Select(x => new SaleInvoiceDTO
            {
                ID = x.ID,
                InvoiceDateStr = x.InvoiceDate.Date.ToString(),
                //InvoiceDate = x.InvoiceDate,
                InvoiceNumber = x.InvoiceNumber,
                StockId = x.StockId,
                StockName = x.StockName,
                InvoiceTotalDiscount = x.InvoiceTotalDiscount,
                Buyer = x.Buyer,
                TotalPaid = x.TotalPaid,
                IsActive = x.IsActive,
                InvoiceTotalPrice = x.InvoiceTotalPrice,
                GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Qty = c.Qty,
                    UnitId = c.UnitId,
                    ConversionFactor = c.ConversionFactor,
                    ItemUnitPrice = c.ItemUnitPrice,
                    ProductBarCode = c.ProductBarCode,
                    DiscountPProduct = c.DiscountPProduct,
                    SellingPrice = c.SellingPrice,
                    GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)
                }).ToList(),


            }).FirstOrDefault();
        }
        public SaleInvoiceDTO GetByInvoiceNumber(int? number)
        {
            return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceNumber == number && p.IsActive && !p.IsDeleted).Select(x => new SaleInvoiceDTO
            {
                ID = x.ID,
                InvoiceDateStr = x.InvoiceDate.Date.ToString(),
                InvoiceNumber = x.InvoiceNumber,
                StockId = x.StockId,
                StockName = x.StockName,
                InvoiceTotalDiscount = x.InvoiceTotalDiscount,
                Buyer = x.Buyer,
                TotalPaid = x.TotalPaid,

                IsActive = x.IsActive,

                InvoiceTotalPrice = x.InvoiceTotalPrice,
                GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Qty = c.Qty,
                    UnitId = c.UnitId,
                    ConversionFactor = c.ConversionFactor,
                    ItemUnitPrice = c.ItemUnitPrice,
                    ProductBarCode = c.ProductBarCode,
                    DiscountPProduct = c.DiscountPProduct,
                    SellingPrice = c.SellingPrice,
                    GetProductUnits = _UnitBll.GetAllByProductId(c.ProductId)

                }).ToList(),

            }).FirstOrDefault();
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
                    StockName = x.StockName,
                    InvoiceTotalDiscount = x.InvoiceTotalDiscount,
                    Buyer = x.Buyer,
                    TotalPaid = x.TotalPaid,

                    IsActive = x.IsActive,

                    InvoiceTotalPrice = x.InvoiceTotalPrice,
                    GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
                    {
                        ID = c.ID,
                        ProductId = c.ProductId,
                        ProductName = c.ProductName,
                        Qty = c.Qty,
                        UnitId = c.UnitId,
                        ConversionFactor = c.ConversionFactor,
                        ItemUnitPrice = c.ItemUnitPrice,
                        ProductBarCode = c.ProductBarCode,
                        DiscountPProduct = c.DiscountPProduct,
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
                StockName = x.StockName,
                InvoiceTotalDiscount = x.InvoiceTotalDiscount,
                Buyer = x.Buyer,
                TotalPaid = x.TotalPaid,

                IsActive = x.IsActive,

                InvoiceTotalPrice = x.InvoiceTotalPrice,
                GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Qty = c.Qty,
                    UnitId = c.UnitId,
                    ConversionFactor = c.ConversionFactor,
                    ItemUnitPrice = c.ItemUnitPrice,
                    ProductBarCode = c.ProductBarCode,
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
                StockName = x.StockName,
                InvoiceTotalDiscount = x.InvoiceTotalDiscount,
                Buyer = x.Buyer,
                IsActive = x.IsActive,
                TotalPaid = x.TotalPaid,
                InvoiceTotalPrice = x.InvoiceTotalPrice,
                GetInvoiceDetails = x.SaleInvoiceDetail.Select(c => new SaleInvoiceProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Qty = c.Qty,
                    UnitId = c.UnitId,
                    ConversionFactor = c.ConversionFactor,
                    DiscountPProduct = c.DiscountPProduct,
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


            var data = _repoInvoice.GetAllAsNoTracking().Include(x => x.SaleInvoiceDetail).Where(p => p.ID == InvoiceDTO.ID  && p.IsActive && !p.IsDeleted).FirstOrDefault();
            if (data != null)
            {
                //if (_repoInvoice.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.ID != data.ID && p.InvoiceNumber == InvoiceDTO.InvoiceNumber
                //&& p.InvoiceDate == InvoiceDTO.InvoiceDate && p.StockId == InvoiceDTO.StockId).FirstOrDefault() != null)
                //{
                //    resultViewModel.Message = AppConstants.Messages.InvoiceAlreadyExists;
                //    return resultViewModel;
                //}
                if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                {
                    var newInvoice = data;
                    newInvoice.StockId = InvoiceDTO.StockId;
                    newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
                    newInvoice.Buyer = InvoiceDTO.Buyer;
                    newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
                    newInvoice.InvoiceTotalDiscount = InvoiceDTO.InvoiceTotalDiscount;
                    decimal? TotalPrice = 0;
                    var oldInvoiceDetails = data.SaleInvoiceDetail;

                    var AllDetails = new List<SaleInvoiceDetail>();
                    foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                    {
                        var product = _repoProduct.GetAll().Where(x=>x.ID== invoiceDetail.ProductId.Value && x.StockProducts.Any(x=>x.ProductId==invoiceDetail.ProductId)).FirstOrDefault();

                        var oldDetail = oldInvoiceDetails.Where(x => x.ID == invoiceDetail.ID).FirstOrDefault();
                        if (oldDetail != null)
                        {

                            var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                            var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                            var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                            var TotalQtyInStock = QtyInStock * ConversionFactor;
                            var oldRequiredQty = oldDetail.Qty * oldDetail.ConversionFactor;
                            var reuiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

                            product.QtyInStock = TotalQtyInStock + oldRequiredQty;
                            TotalQtyInStock = TotalQtyInStock + oldRequiredQty;
                            if (reuiredQty > TotalQtyInStock)
                            {
                                resultViewModel.Status = false;
                                resultViewModel.Message = "غير متوفرة " + product.Name + "الكمية المطلوبة من المنتج  ";
                                resultViewModel.Data = InvoiceDTO;
                                return resultViewModel;
                            }
                            else
                            {
                                product.QtyInStock = product.QtyInStock - reuiredQty;
                                product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);

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
                                    ProductName = product.Name
                                };
                                AllDetails.Add(newInvoiceDetail);

                                TotalPrice += newInvoiceDetail.TotalQtyPrice;
                                TotalPrice -= newInvoiceDetail.DiscountPProduct;
                            }
                        }
                        else
                        {
                            if (invoiceDetail.Qty > product.QtyInStock)
                            {
                                resultViewModel.Status = false;
                                resultViewModel.Message = "الكمية المطلوبة من المنتج " + product.Name + " تجاوزت الكميو الموجودة بالمخزن";
                                resultViewModel.Data = InvoiceDTO;
                                return resultViewModel;
                            }
                            else
                            {
                                var productUnit = _repoProductUnit.GetAllAsNoTracking().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                                var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                                var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                                var TotalQtyInStock = (QtyInStock * ConversionFactor) + (oldDetail.Qty * oldDetail.ConversionFactor);
                                var reuiredQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

                                product.QtyInStock = product.QtyInStock - reuiredQty;
                                product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);

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
                                    ProductName = product.Name
                                };
                                AllDetails.Add(newInvoiceDetail);

                                TotalPrice += newInvoiceDetail.TotalQtyPrice;
                            }
                        }


                    }
                    TotalPrice -= newInvoice.InvoiceTotalDiscount;
                    newInvoice.InvoiceTotalPrice = TotalPrice;
                    if (_repoInvoice.Update(newInvoice))
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
                        }

                    }
                }
            }
            else
            {
                //if (_repoInvoice.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.InvoiceNumber == InvoiceDTO.InvoiceNumber
                //&& p.InvoiceDate == InvoiceDTO.InvoiceDate && p.StockId == InvoiceDTO.StockId).FirstOrDefault() != null)
                //{
                //    resultViewModel.Message = AppConstants.Messages.InvoiceAlreadyExists;
                //    return resultViewModel;
                //}
                if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                {
                    var newInvoice = new SaleInvoice();
                    newInvoice.StockId = InvoiceDTO.StockId;
                    newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.Buyer = InvoiceDTO.Buyer;
                    newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
                    newInvoice.InvoiceTotalDiscount = InvoiceDTO.InvoiceTotalDiscount;
                    decimal? TotalPrice = 0;

                    var AllDetails = new List<SaleInvoiceDetail>();
                    foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                    {
                        var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.StockProducts.Any(x => x.ProductId == invoiceDetail.ProductId)).FirstOrDefault();
                        var productUnit = _repoProductUnit.GetAllAsNoTracking().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
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
                            product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);

                            _repoProduct.UpdateWithoutSaveChange(product);
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
                                ProductName = product.Name
                            };
                            //_repoInvoiceDetail.Insert(newInvoiceDetail);
                            AllDetails.Add(newInvoiceDetail);
                            TotalPrice += newInvoiceDetail.TotalQtyPrice;
                            TotalPrice -= invoiceDetail.DiscountPProduct;
                        }

                    }
                    TotalPrice -= newInvoice.InvoiceTotalDiscount;
                    newInvoice.InvoiceTotalPrice = TotalPrice;
                    if (_repoInvoice.Insert(newInvoice))
                    {
                        var lastInvoiceNumber = newInvoice.InvoiceNumber + 1;
                        _repoInvoiceDetail.InsertRange(AllDetails);
                        resultViewModel.Status = true;
                        resultViewModel.Message = AppConstants.Messages.SavedSuccess;
                        resultViewModel.Data = lastInvoiceNumber;

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
