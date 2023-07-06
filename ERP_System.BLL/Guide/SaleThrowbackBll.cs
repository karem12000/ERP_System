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
    public class SaleThrowbackBll
    {
        private const string _spSaleThrowback = "[Guide].[spSaleThrowback]";
        private readonly IRepository<SaleThrowback> _repoSaleThrowback;
        private readonly UnitBll _UnitBll;
        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<ProductUnit> _repoProductUnit;
        private readonly IRepository<SaleThrowbackDetail> _repoSaleThrowbackDetail;
        private readonly IMapper _mapper;

        public SaleThrowbackBll(IRepository<Product> repoProduct, IRepository<ProductUnit> repoProductUnit, IRepository<Stock> repoStock, UnitBll UnitBll, IRepository<SaleThrowback> repoSaleThrowback, IRepository<SaleThrowbackDetail> repoSaleThrowbackDetail, IMapper mapper)
        {
            _repoSaleThrowback = repoSaleThrowback;
            _mapper = mapper;
            _repoSaleThrowbackDetail = repoSaleThrowbackDetail;
            _repoProduct = repoProduct;
            _UnitBll = UnitBll;
            _repoStock = repoStock;
            _repoProductUnit = repoProductUnit;
        }

        #region Get
        public int GetLastInvoiceNumberByDate(DateTime? date)
        {
            var invoiceNumber = _repoSaleThrowback.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.InvoiceDate.Date >= date.Value.Date)
                 .OrderByDescending(c => c.CreatedDate).Select(c => c.InvoiceNumber).FirstOrDefault();

            return invoiceNumber;
        }
        public SaleThrowbackDTO GetById(Guid id)
        {
            return _repoSaleThrowback.GetAllAsNoTracking().Include(c => c.SaleInvoiceDetails).Where(p => p.ID == id).Select(x => new SaleThrowbackDTO
            {
                ID = x.ID,
                InvoiceDateStr = x.InvoiceDate.Date.ToString(),
                //InvoiceDate = x.InvoiceDate,
                InvoiceNumber = x.InvoiceNumber,
                StockId = x.StockId,
                StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
                Buyer = x.Buyer,
                IsActive = x.IsActive,
                InvoiceTotalPrice = x.InvoiceTotalPrice,
                TotalPaid = x.TotalPaid,
                GetInvoiceDetails = x.SaleInvoiceDetails.Select(c => new SaleThrowbackProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
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
        public SaleThrowbackDTO GetByInvoiceNumber(int? number)
        {
            return _repoSaleThrowback.GetAllAsNoTracking().Where(p => p.InvoiceNumber == number && p.IsActive && !p.IsDeleted).Select(x => new SaleThrowbackDTO
            {
                ID = x.ID,
                InvoiceDateStr = x.InvoiceDate.Date.ToString(),
                InvoiceNumber = x.InvoiceNumber,
                StockId = x.StockId,
                StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
                Buyer = x.Buyer,
                IsActive = x.IsActive,
                TotalPaid = x.TotalPaid,

                InvoiceTotalPrice = x.InvoiceTotalPrice,
                GetInvoiceDetails = x.SaleInvoiceDetails.Select(c => new SaleThrowbackProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
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


        public SaleThrowbackDTO GetByInvoiceDate(DateTime? date)
        {
            if (date != null)
            {
                return _repoSaleThrowback.GetAllAsNoTracking().Where(p => p.InvoiceDate.Date == date.Value.Date && p.IsActive && !p.IsDeleted).Select(x => new SaleThrowbackDTO
                {
                    ID = x.ID,
                    InvoiceDateStr = x.InvoiceDate.Date.ToString(),
                    InvoiceNumber = x.InvoiceNumber,
                    StockId = x.StockId,
                    StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
                    Buyer = x.Buyer,
                    IsActive = x.IsActive,
                    TotalPaid = x.TotalPaid,

                    InvoiceTotalPrice = x.InvoiceTotalPrice,
                    GetInvoiceDetails = x.SaleInvoiceDetails.Select(c => new SaleThrowbackProductsDTO
                    {
                        ID = c.ID,
                        ProductId = c.ProductId,
                        ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
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

        public IQueryable<SaleThrowbackDTO> GetAllByDate(DateTime? date)
        {

            return _repoSaleThrowback.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date == date.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new SaleThrowbackDTO
            {
                ID = x.ID,
                InvoiceDateStr = x.InvoiceDate.Date.ToString(),
                InvoiceNumber = x.InvoiceNumber,
                StockId = x.StockId,
                StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
                Buyer = x.Buyer,
                IsActive = x.IsActive,
                TotalPaid = x.TotalPaid,

                InvoiceTotalPrice = x.InvoiceTotalPrice,
                GetInvoiceDetails = x.SaleInvoiceDetails.Select(c => new SaleThrowbackProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
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
        public IQueryable<SaleThrowbackDTO> GetAllByDate(DateTime? fromDate, DateTime? toDate)
        {

            return _repoSaleThrowback.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date >= fromDate.Value.Date && x.InvoiceDate.Date <= toDate.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new SaleThrowbackDTO
            {
                ID = x.ID,
                InvoiceDateStr = x.InvoiceDate.Date.ToString(),
                InvoiceNumber = x.InvoiceNumber,
                StockId = x.StockId,
                StockName = _repoStock.GetAllAsNoTracking().Where(p => p.ID == x.StockId).Select(p => p.Name).FirstOrDefault(),
                Buyer = x.Buyer,
                IsActive = x.IsActive,
                TotalPaid = x.TotalPaid,

                InvoiceTotalPrice = x.InvoiceTotalPrice,
                GetInvoiceDetails = x.SaleInvoiceDetails.Select(c => new SaleThrowbackProductsDTO
                {
                    ID = c.ID,
                    ProductId = c.ProductId,
                    ProductName = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == c.ProductId).Select(p => p.Name).FirstOrDefault(),
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
            var data = _repoSaleThrowback.ExecuteStoredProcedure<SaleThrowbackTableDTO>
                (_spSaleThrowback, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }


        #endregion
        #region Save 
        public ResultViewModel Save(SaleThrowbackDTO InvoiceDTO)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoSaleThrowback.GetAllAsNoTracking().Include(x => x.SaleInvoiceDetails).Where(p => p.ID == InvoiceDTO.ID && p.IsActive && !p.IsDeleted).FirstOrDefault();
            if (data != null)
            {
                var newInvoice = data;
                newInvoice.StockId = InvoiceDTO.StockId;
                //newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
                newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
                newInvoice.Buyer = InvoiceDTO.Buyer;
                newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
                newInvoice.AddedTax = data.AddedTax;
                newInvoice.InvoiceTotalDiscount = InvoiceDTO.InvoiceTotalDiscount;
                newInvoice.InvoiceTotalDiscountType = InvoiceDTO.InvoiceTotalDiscountType;
                
                //newInvoice.InvoiceTotalPrice = InvoiceDTO.InvoiceDetails != null ? InvoiceDTO.InvoiceDetails.Sum(x => x.TotalQtyPrice) : 0;
                newInvoice.AddedBy = data.AddedBy;
                newInvoice.ModifiedDate = AppDateTime.Now;
                newInvoice.ModifiedBy = _repoSaleThrowback.UserId;
                newInvoice.CreatedDate = data.CreatedDate;
				newInvoice.SaleInvoiceId = InvoiceDTO.SaleInvoiceId;

                var oldInvoiceDetails = data.SaleInvoiceDetails;

                if (newInvoice.SaleInvoiceId == null || newInvoice.SaleInvoiceId == Guid.Empty)
                {
                    resultViewModel.Status = false;
                    resultViewModel.Message = "يجب تحديد الفاتورة المراد عمل ارجاع لمنتجاتها";
                    return resultViewModel;
                }
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

           
				if (newInvoice.InvoiceTotalPrice < 0)
                {
                    resultViewModel.Status = false;
                    resultViewModel.Message = "لا يمكن حفظ الاجمالي للفاتورة بالقيمة السالبة";
                    return resultViewModel;
                }
                if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                {
                    var AllInvoiceProducts = new List<Product>();
                    var AllDetails = new List<SaleThrowbackDetail>();
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
                                var oldTotalThrowbackQty = Math.Round(oldDetail.Qty.Value * oldDetail.ConversionFactor.Value, 2);
                                var TotalThrowbackQty = Math.Round(invoiceDetail.Qty.Value * invoiceDetail.ConversionFactor.Value, 2);
                                product.QtyInStock = TotalQtyInStock - oldTotalThrowbackQty;
                                product.QtyInStock = product.QtyInStock + TotalThrowbackQty;

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
                                oldDetail.TotalQtyPrice = invoiceDetail.TotalQtyPrice;
                                oldDetail.SaleThrowbackId = newInvoice.ID;
                                oldDetail.DiscountTypePProduct = invoiceDetail.DiscountTypePProduct;
                                oldDetail.DiscountPProduct = invoiceDetail.DiscountPProduct;

                                AllDetails.Add(oldDetail);
                                //TotalPrice += oldDetail.TotalQtyPrice;
                            }
                            else
                            {

                                //var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                                //var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                                //var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                                //var TotalQtyInStock = (QtyInStock * ConversionFactor) + (oldDetail.Qty * oldDetail.ConversionFactor);
                                var TotalThrowbackQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

                                product.QtyInStock = TotalQtyInStock + TotalThrowbackQty;
                                product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);
                                AllInvoiceProducts.Remove(existProduct);
                                AllInvoiceProducts.Add(product);
                                var newInvoiceDetail = new SaleThrowbackDetail()
                                {
                                    AddedBy = _repoSaleThrowback.UserId,
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
                                    SaleThrowbackId = newInvoice.ID,
                                    ProductName = product.Name,
                                    DiscountPProduct = invoiceDetail.DiscountPProduct,
                                    DiscountTypePProduct = invoiceDetail.DiscountTypePProduct
                                };
                                AllDetails.Add(newInvoiceDetail);

                                //TotalPrice += newInvoiceDetail.TotalQtyPrice;

                            }
                        }
                        else
                        {
                            resultViewModel.Status = false;
                            resultViewModel.Message = " لا يوجد منتج بهذا الباركود " + invoiceDetail.ProductBarCode + " أو المنتج المختار لاينتمي الي المخزن المحدد ";
                            return resultViewModel;

                        }

                    }
                    var deleteInvoiceDetaails = _repoSaleThrowbackDetail.DeleteRange(oldInvoiceDetails);
                    var saveInvoiceDetaails = _repoSaleThrowbackDetail.InsertRange(AllDetails);
                   
                    if (deleteInvoiceDetaails && saveInvoiceDetaails)
                    {
                        foreach (var item in AllInvoiceProducts)
                        {
                            _repoProduct.Update(item);
                        }
                        _repoSaleThrowback.Update(newInvoice);
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
                var newInvoice = new SaleThrowback();
                newInvoice.SaleInvoiceId = InvoiceDTO.SaleInvoiceId;
                newInvoice.StockId = InvoiceDTO.StockId;
                newInvoice.StockName = _repoStock.GetById(newInvoice.StockId).Name;
                newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                newInvoice.InvoiceNumber = InvoiceDTO.InvoiceNumber;
                newInvoice.InvoiceDate = InvoiceDTO.InvoiceDate;
                newInvoice.Buyer = InvoiceDTO.Buyer;
                newInvoice.TotalPaid = InvoiceDTO.TotalPaid;
                newInvoice.AddedBy = _repoSaleThrowback.UserId;
                newInvoice.AddedTax = InvoiceDTO.AddedTax;
                newInvoice.InvoiceTotalDiscount = InvoiceDTO.InvoiceTotalDiscount;
                newInvoice.InvoiceTotalDiscountType = InvoiceDTO.InvoiceTotalDiscountType;
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


                if (newInvoice.InvoiceTotalPrice < 0)
                {
                    resultViewModel.Status = false;
                    resultViewModel.Message = "لا يمكن حفظ الاجمالي للفاتورة بالقيمة السالبة";
                    return resultViewModel;
                }
				if (newInvoice.SaleInvoiceId == null || newInvoice.SaleInvoiceId ==Guid.Empty)
				{
					resultViewModel.Status = false;
					resultViewModel.Message = "يجب تحديد الفاتورة المراد عمل ارجاع لمنتجاتها";
					return resultViewModel;
				}
				decimal? TotalPrice = 0;
                newInvoice.InvoiceTotalPrice = InvoiceDTO.InvoiceDetails != null ? InvoiceDTO.InvoiceDetails.Sum(x => x.TotalQtyPrice) : 0;
                if (InvoiceDTO.InvoiceDetails != null && InvoiceDTO.InvoiceDetails.Count() > 0)
                {
                    var AllInvoiceProducts = new List<Product>();
                    if (_repoSaleThrowback.Insert(newInvoice))
                    {
                        var AllDetails = new List<SaleThrowbackDetail>();
                        foreach (var invoiceDetail in InvoiceDTO.InvoiceDetails)
                        {
                            var productUnit = _repoProductUnit.GetAll().Include(x => x.Product).Where(x => x.ProductId == invoiceDetail.ProductId && x.IsActive && !x.IsDeleted);
                            var product = _repoProduct.GetAll().Where(x => x.ID == invoiceDetail.ProductId.Value && x.StockProducts.Any(x => x.ProductId == invoiceDetail.ProductId && x.StockId==InvoiceDTO.StockId) && (x.BarCodeText.Trim() == invoiceDetail.ProductBarCode.Trim() || x.ProductUnits.Any(x => x.UnitBarcodeText.Trim() == invoiceDetail.ProductBarCode.Trim()))).FirstOrDefault();
                            if (product != null)
                            {
                                var existProduct = AllInvoiceProducts.Where(x => x.BarCodeText == product.BarCodeText).FirstOrDefault();
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
                                //var QtyInStock = productUnit.FirstOrDefault().Product.QtyInStock;
                                //var ConversionFactor = productUnit.Where(x => x.UnitId == productUnit.FirstOrDefault().Product.IdUnitOfQty).Select(x => x.ConversionFactor).FirstOrDefault();
                                //var TotalQtyInStock = QtyInStock * ConversionFactor;
                                var TotalThrowbackQty = invoiceDetail.Qty * invoiceDetail.ConversionFactor;

                                product.QtyInStock = TotalQtyInStock + TotalThrowbackQty;
                                product.QtyInStock = Math.Round((product.QtyInStock.Value / ConversionFactor.Value), 2);
                                AllInvoiceProducts.Remove(existProduct);
                                AllInvoiceProducts.Add(product);
                                //_repoProduct.Update(product);
                                var newInvoiceDetail = new SaleThrowbackDetail()
                                {
                                    AddedBy = _repoSaleThrowback.UserId,
                                    IsActive = true,
                                    UnitId = invoiceDetail.UnitId,
                                    ConversionFactor = invoiceDetail.ConversionFactor,
                                    DiscountPProduct = invoiceDetail.DiscountPProduct,
                                    DiscountTypePProduct = invoiceDetail.DiscountTypePProduct,
                                    ProductBarCode = invoiceDetail.ProductBarCode,
                                    ProductId = invoiceDetail.ProductId,
                                    ItemUnitPrice = invoiceDetail.ItemUnitPrice,
                                    SellingPrice = invoiceDetail.SellingPrice,
                                    Qty = invoiceDetail.Qty,
                                    ID = Guid.NewGuid(),
                                    TotalQtyPrice = invoiceDetail.TotalQtyPrice,
                                    SaleThrowbackId = newInvoice.ID,
                                    ProductName = product.Name
                                };
                                //_repoSaleThrowbackDetail.Insert(newInvoiceDetail);
                                AllDetails.Add(newInvoiceDetail);
                                //TotalPrice += newInvoiceDetail.TotalQtyPrice;
                            }
                            else
                            {
                                resultViewModel.Status = false;
                                resultViewModel.Message = " لا يوجد منتج بهذا الباركود " + invoiceDetail.ProductBarCode + " أو المنتج المختار لاينتمي الي المخزن المحدد ";
                                _repoSaleThrowback.Detached(newInvoice);
                                newInvoice.IsDeleted = true;
                                _repoSaleThrowback.Update(newInvoice);
                                return resultViewModel;

                            }

                        }


                        if (_repoSaleThrowbackDetail.InsertRange(AllDetails))
                        {
                            var newInvoiceNumber = newInvoice.InvoiceNumber + 1;
                            foreach (var item in AllInvoiceProducts)
                            {
                                _repoProduct.Update(item);
                            }
                            resultViewModel.Status = true;
                            resultViewModel.Message = AppConstants.Messages.SavedSuccess;
                            resultViewModel.Data = newInvoiceNumber;
                        }
                        else
                        {
                            resultViewModel.Status = false;
                            resultViewModel.Message = "خطأ في حفظ تفاصيل الفاتورة";
                            //_repoSaleThrowback.Delete(newInvoice);
                            return resultViewModel;
                        }

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
            return resultViewModel;
        }
        #endregion


        #region Delete
        public ResultViewModel Delete(Guid id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            var tbl = _repoSaleThrowback.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

            if (tbl == null)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = AppConstants.Messages.DeletedFailed;
                return resultViewModel;
            }

            tbl.IsDeleted = true;
            if (_repoSaleThrowback.UserId != Guid.Empty)
            {
                tbl.DeletedBy = _repoSaleThrowback.UserId;
            }
            tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoSaleThrowback.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


            return resultViewModel;
        }
        #endregion
    }
}
