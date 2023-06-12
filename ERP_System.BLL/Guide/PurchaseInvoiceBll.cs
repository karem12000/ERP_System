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
        private readonly IRepository<Unit> _repoUnits;
        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<PurchaseInvoiceDetail> _repoInvoiceDetail;
        private readonly IMapper _mapper;

        public PurchaseInvoiceBll(IRepository<Product> repoProduct, IRepository<Stock> repoStock, IRepository<Unit> repoUnits, IRepository<PurchaseInvoice> repoInvoice, IRepository<PurchaseInvoiceDetail> repoInvoiceDetail, IMapper mapper)
        {
            _repoInvoice = repoInvoice;
            _mapper = mapper;
            _repoInvoiceDetail = repoInvoiceDetail;
            _repoProduct = repoProduct;
            _repoUnits = repoUnits;
            _repoStock = repoStock;
        }

        #region Get
        public InvoiceDTO GetById(Guid id)
        {
            return _repoInvoice.GetAllAsNoTracking().Include(c => c.PurchaseInvoiceDetail).Where(p => p.ID == id).Select(x => new InvoiceDTO
            {
                ID = x.ID,
                InvoiceDate = x.InvoiceDate,
                InvoiceNumber = x.InvoiceNumber,
                StockId = x.StockId,
                StockName = x.StockName,
                Supplier = x.Supplier,
                 GetInvoiceDetails= x.PurchaseInvoiceDetail.Select(c => new InvoiceProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Qty = c.Qty,
                    QtyPrice = c.QtyPrice,
                    SalePrice = c.SalePrice,
                    UnitId = c.UnitId,
                    UnitName = c.UnitName
                }).ToList(),

            }).FirstOrDefault();
        }
        public InvoiceDTO GetByInvoiceNumber(int? number)
        {
            return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceNumber == number && p.IsActive && !p.IsDeleted).Select(x => new InvoiceDTO
            {
                ID = x.ID,
                InvoiceDate = x.InvoiceDate,
                InvoiceNumber = x.InvoiceNumber,
                StockId = x.StockId,
                StockName = x.StockName,
                Supplier = x.Supplier,
                GetInvoiceDetails = x.PurchaseInvoiceDetail.Select(c => new InvoiceProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Qty = c.Qty,
                    QtyPrice = c.QtyPrice,
                    SalePrice = c.SalePrice,
                    UnitId = c.UnitId,
                    UnitName = c.UnitName
                }).ToList(),

            }).FirstOrDefault();
        }


        public InvoiceDTO GetByInvoiceDate(DateTime? date)
        {
            if (date != null)
            {
                return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceDate.Date == date.Value.Date && p.IsActive && !p.IsDeleted).Select(x => new InvoiceDTO
                {
                    ID = x.ID,
                    InvoiceDate = x.InvoiceDate,
                    InvoiceNumber = x.InvoiceNumber,
                    StockId = x.StockId,
                    StockName = x.StockName,
                    Supplier = x.Supplier,
                    GetInvoiceDetails = x.PurchaseInvoiceDetail.Select(c => new InvoiceProductsDTO
                    {
                        ID = c.ID,
                        ProductId = c.ProductId,
                        ProductName = c.ProductName,
                        Qty = c.Qty,
                        QtyPrice = c.QtyPrice,
                        SalePrice = c.SalePrice,
                        UnitId = c.UnitId,
                        UnitName = c.UnitName
                    }).ToList(),

                }).FirstOrDefault();
            }
            return null;
        }

        public IQueryable<InvoiceDTO> GetAllByDate(DateTime? date)
        {

            return _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date == date.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new InvoiceDTO
            {
                ID = x.ID,
                InvoiceDate = x.InvoiceDate,
                InvoiceNumber = x.InvoiceNumber,
                StockId = x.StockId,
                StockName = x.StockName,
                Supplier = x.Supplier,
                GetInvoiceDetails = x.PurchaseInvoiceDetail.Select(c => new InvoiceProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Qty = c.Qty,
                    QtyPrice = c.QtyPrice,
                    SalePrice = c.SalePrice,
                    UnitId = c.UnitId,
                    UnitName = c.UnitName
                }).ToList(),

            });

        }
        public IQueryable<InvoiceDTO> GetAllByDate(DateTime? fromDate, DateTime? toDate)
        {

            return _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date >= fromDate.Value.Date && x.InvoiceDate.Date <= toDate.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new InvoiceDTO
            {
                ID = x.ID,
                InvoiceDate = x.InvoiceDate,
                InvoiceNumber = x.InvoiceNumber,
                StockId = x.StockId,
                StockName = x.StockName,
                Supplier = x.Supplier,
                GetInvoiceDetails = x.PurchaseInvoiceDetail.Select(c => new InvoiceProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Qty = c.Qty,
                    QtyPrice = c.QtyPrice,
                    SalePrice = c.SalePrice,
                    UnitId = c.UnitId,
                    UnitName = c.UnitName
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
        public ResultViewModel Save(InvoiceDTO InvoiceDTO)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoInvoice.GetAllAsNoTracking().Include(x => x.PurchaseInvoiceDetail).Where(p => p.ID != InvoiceDTO.ID).FirstOrDefault();
            if (data != null)
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
                    newInvoice.Supplier = InvoiceDTO.Supplier;
                    decimal? TotalPrice = 0;

                    var AllDetails = new List<PurchaseInvoiceDetail>();
                    foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                    {
                        var product = _repoProduct.GetById(invoiceDetail.ProductId.Value);
                        if (invoiceDetail.Qty > product.QtyInStock)
                        {
                            resultViewModel.Status = false;
                            resultViewModel.Message = "الكمية المطلوبة من المنتج " + product.Name + " تجاوزت الكميو الموجودة بالمخزن";
                            resultViewModel.Data = InvoiceDTO;
                            return resultViewModel;
                        }
                        else
                        {
                            product.QtyInStock = product.QtyInStock - invoiceDetail.Qty;

                            var newInvoiceDetail = new PurchaseInvoiceDetail()
                            {
                                AddedBy = _repoInvoice.UserId,
                                IsActive = true,
                                UnitId = invoiceDetail.UnitId,
                                UnitName = _repoUnits.GetById(invoiceDetail.UnitId.Value).Name,
                                ProductId = invoiceDetail.ProductId.Value,
                                ProductName = product.Name,
                                Qty = invoiceDetail.Qty,
                                QtyPrice = invoiceDetail.QtyPrice,
                                PurchaseInvoiceId = newInvoice.ID,
                                SalePrice = invoiceDetail.SalePrice
                            };
                            TotalPrice += newInvoiceDetail.QtyPrice;
                        }

                    }
                    newInvoice.TotalPrice = TotalPrice;
                    if (_repoInvoice.Insert(newInvoice))
                    {
                        _repoProduct.SaveChange();
                        var saveInvoiceDetaails = _repoInvoiceDetail.InsertRange(AllDetails);
                        if (saveInvoiceDetaails)
                        {
                            resultViewModel.Status = true;
                            resultViewModel.Message = AppConstants.Messages.SavedSuccess;
                        }

                    }
                }

            }
            else
            {
                if (_repoInvoice.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.InvoiceNumber == InvoiceDTO.InvoiceNumber
                && p.InvoiceDate == InvoiceDTO.InvoiceDate && p.StockId==InvoiceDTO.StockId).FirstOrDefault() != null)
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
                    newInvoice.Supplier = InvoiceDTO.Supplier;
                    decimal? TotalPrice = 0;

                    var AllDetails = new List<PurchaseInvoiceDetail>();
                    foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                    {
                        var product = _repoProduct.GetById(invoiceDetail.ProductId.Value);
                        if (invoiceDetail.Qty > product.QtyInStock)
                        {
                            resultViewModel.Status = false;
                            resultViewModel.Message = "الكمية المطلوبة من المنتج " + product.Name + " تجاوزت الكميو الموجودة بالمخزن";
                            resultViewModel.Data = InvoiceDTO;
                            return resultViewModel;
                        }
                        else
                        {
                            product.QtyInStock = product.QtyInStock - invoiceDetail.Qty;

                            var newInvoiceDetail = new PurchaseInvoiceDetail()
                            {
                                AddedBy = _repoInvoice.UserId,
                                IsActive = true,
                                UnitId = invoiceDetail.UnitId,
                                UnitName = _repoUnits.GetById(invoiceDetail.UnitId.Value).Name,
                                ProductId = invoiceDetail.ProductId.Value,
                                ProductName = product.Name,
                                Qty = invoiceDetail.Qty,
                                QtyPrice = invoiceDetail.QtyPrice,
                                PurchaseInvoiceId = newInvoice.ID,
                                SalePrice = invoiceDetail.SalePrice
                            };
                            TotalPrice += newInvoiceDetail.QtyPrice;
                        }

                    }
                    newInvoice.TotalPrice = TotalPrice;
                    if (_repoInvoice.Insert(newInvoice))
                    {
                        _repoProduct.SaveChange();
                        var saveInvoiceDetaails = _repoInvoiceDetail.InsertRange(AllDetails);
                        if (saveInvoiceDetaails)
                        {
                            resultViewModel.Status = true;
                            resultViewModel.Message = AppConstants.Messages.SavedSuccess;
                        }

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
