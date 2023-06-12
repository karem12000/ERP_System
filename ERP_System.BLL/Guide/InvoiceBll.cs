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
    public class InvoiceBll
    {
        private const string _spInvoices = "[Guide].[spSales]";
        private readonly IRepository<Invoice> _repoInvoice;
        private readonly IRepository<Unit> _repoUnits;
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<InvoiceDetail> _repoInvoiceDetail;
        private readonly IMapper _mapper;

        public InvoiceBll( IRepository<Product> repoProduct, IRepository<Unit> repoUnits, IRepository<Invoice> repoInvoice, IRepository<InvoiceDetail> repoInvoiceDetail, IMapper mapper)
        {
            _repoInvoice = repoInvoice;
            _mapper = mapper;
            _repoInvoiceDetail = repoInvoiceDetail;
            _repoProduct = repoProduct;
            _repoUnits = repoUnits;
        }

        #region Get
        public Invoice GetById(Guid id)
        {
            return _repoInvoice.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();
        }
        public Invoice GetByInvoiceNumber(int? number)
        {
            return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceNumber == number && p.IsActive && !p.IsDeleted).FirstOrDefault();
        }
        public Invoice GetByProductCode(string? text)
        {
            return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceDetails.Any(pp => pp.Product.BarCodeText.Trim().ToLower() == text.Trim().ToLower()) && p.IsActive && !p.IsDeleted).FirstOrDefault();
        }
        public Invoice GetByProductName(string? text)
        {
            return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceDetails.Any(pp => pp.Product.Name.Trim().ToLower() == text.Trim().ToLower()) && p.IsActive && !p.IsDeleted).FirstOrDefault();
        }
        public Invoice GetByInvoiceDate(DateTime? date)
        {
            if (date != null)
            {
                return _repoInvoice.GetAllAsNoTracking().Where(p => p.InvoiceDate.Date == date.Value.Date && p.IsActive && !p.IsDeleted).FirstOrDefault();
            }
            return null;
        }
      
        public IQueryable<Invoice> GetAllByDate(DateTime? date)
        {

            return _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date == date.Value.Date).Where(x => !x.IsDeleted && x.IsActive);

        }
        public IQueryable<Invoice> GetAllByDate(DateTime? fromDate, DateTime? toDate)
        {

            return _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date >= fromDate.Value.Date && x.InvoiceDate.Date <= toDate.Value.Date).Where(x => !x.IsDeleted && x.IsActive);

        }
        public DataTableResponse LoadData(DataTableRequest mdl , InvoiceType invoiceType)
        {
            mdl.InvoiceType = invoiceType;
            var data = _repoInvoice.ExecuteStoredProcedure<InvoicesTableDTO>
                (_spInvoices, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }

       
        #endregion
        #region Save 
        public ResultViewModel Save(InvoiceDTO InvoiceDTO)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoInvoice.GetAllAsNoTracking().Include(x=>x.InvoiceDetails).Where(p => p.ID == InvoiceDTO.ID).FirstOrDefault();
            if (data != null)
            {

                //if (_repoInvoice.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.ID != data.ID && p.InvoiceNumber== InvoiceDTO.InvoiceNumber).FirstOrDefault() != null)
                //{
                //    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                //    return resultViewModel;
                //}

                //if (InvoiceDTO.InvoiceDetails!= null && InvoiceDTO.InvoiceDetails.Count()>0)
                //{
                   
                //    data.InvoiceDate = data.InvoiceDate;
                //    data.InvoiceNumber= data.InvoiceNumber;

                //    if (_repoInvoice.Update(data))
                //    {
                //        var AllDetails = data.InvoiceDetails;
                //        foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                //        {
                //            var oldDetail = data.InvoiceDetails.Where(x => x.ProductId == invoiceDetail.ProductId &&
                //            x.GroupId == invoiceDetail.GroupId).FirstOrDefault();

                //            oldDetail.ProductId = invoiceDetail.ProductId;
                //            oldDetail.Qty = invoiceDetail.RequiredQty;
                //            oldDetail.StockId = invoiceDetail.StockId;
                //            oldDetail.GroupName = invoiceDetail.GroupName;
                //            oldDetail.PricePerUnit = invoiceDetail.PricePerUnit;
                //            oldDetail.UnitId = invoiceDetail.UnitId;
                //            oldDetail.UnitName = invoiceDetail.UnitName;
                //            oldDetail.StockName = invoiceDetail.StockName;
                //            oldDetail.GroupId = invoiceDetail.GroupId;
                            
                //            _repoInvoiceDetail.Update(oldDetail);

                //        }

                //        _repoInvoiceDetail.SaveChange();
                //        resultViewModel.Status = true;
                //        resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                //    }
                //}
                
            }
            else
            {
                if (_repoInvoice.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.InvoiceNumber==InvoiceDTO.InvoiceNumber && p.InvoiceType==InvoiceDTO.InvoiceType
                && p.InvoiceDate == InvoiceDTO.InvoiceDate).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.InvoiceAlreadyExists;
                    return resultViewModel;
                }
                if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                {
                    var newInvoice = new Invoice();
                    newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                    newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;

                    if (InvoiceDTO.InvoiceType == InvoiceType.Sale || InvoiceDTO.InvoiceType == InvoiceType.SaleThrowBack)
                    {
                        newInvoice.InvoiceType = InvoiceDTO.InvoiceType;
                        newInvoice.Buyer = InvoiceDTO.Buyer;
                        newInvoice.Supplier = null;

                    }
                    else if (InvoiceDTO.InvoiceType == InvoiceType.Purchase || InvoiceDTO.InvoiceType == InvoiceType.PurchaseThrowBack)
                    {
                        newInvoice.InvoiceType = InvoiceDTO.InvoiceType;
                        newInvoice.Supplier = InvoiceDTO.Supplier;
                        newInvoice.Buyer = null;
                    }

                    var AllDetails = new List<InvoiceDetail>();
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
                            //var newInvoiceDetail = new InvoiceDetail()
                            //{
                            //    ProductId = invoiceDetail.ProductId,
                            //    Qty = invoiceDetail.Qty,
                            //    StockId = InvoiceDTO.StockId,
                            //    InvoiceId = newInvoice.ID,
                            //    PricePerUnit = invoiceDetail.QtyPrice,
                            //    UnitId = invoiceDetail.UnitId,
                            //    UnitName = _repoUnits.GetById(invoiceDetail.UnitId).Name,
                            //    StockName = invoiceDetail.StockName,
                            //    GroupId = invoiceDetail.GroupId
                            //};
                            //_repoProduct.UpdateWithoutSaveChange(product);
                            //AllDetails.Add(newInvoiceDetail);
                        }
                       
                    }

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
