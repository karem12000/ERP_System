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
using ERP_System.DTO.Report;

namespace ERP_System.BLL.Guide
{
    public class SaleReportBll
    {
        private readonly IRepository<SaleInvoice> _repoInvoice;
        private readonly IRepository<Setting> _repoSetting;
        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<SaleInvoiceDetail> _repoInvoiceDetail;
        private readonly IMapper _mapper;

        public SaleReportBll(IRepository<Product> repoProduct,  IRepository<Stock> repoStock, IRepository<Setting> repoSetting, IRepository<SaleInvoice> repoInvoice, IRepository<SaleInvoiceDetail> repoInvoiceDetail, IMapper mapper)
        {
            _repoInvoice = repoInvoice;
            _mapper = mapper;
            _repoInvoiceDetail = repoInvoiceDetail;
            _repoProduct = repoProduct;
            _repoSetting = repoSetting;
            _repoStock = repoStock;
        }

        #region Get
     
        public ResultViewModel GetAllByDate(DateTime? fromDate, DateTime? toDate)
        {
            var result = new ResultViewModel();
            var data = new SaleReportDataDTO();
            result.Status = false;
            var companyData = _repoSetting.GetAllAsNoTracking().Select(x => new BaseReportDTO
            {
                CompanyAddress = x.CompanyAddress,
                CompanyLogo = x.CompanyImage,
                CompanyName = x.CompanyName,
                CompanyPhone = x.CompanyPhone,
                Description = x.Description
            }).FirstOrDefault();

            //var reportData = _repoInvoice.GetAllAsNoTracking().Where(x => x.InvoiceDate.Date >= fromDate.Value.Date && x.InvoiceDate.Date <= toDate.Value.Date).Where(x => !x.IsDeleted && x.IsActive).Select(x => new SaleReportDTO
            var reportData = _repoInvoice.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive).Select(x => new SaleReportDTO
            {
               BuyerName =x.Buyer,
               InvoiceDate = x.InvoiceDate.ToString(),
               InvoiceNumber = x.InvoiceNumber.ToString(),
                InvoiceTotalPrice = x.InvoiceTotalPrice.Value,
                InvoiceType = "فاتورة مبيعات",
                StockName = x.StockName
            }).FirstOrDefault();
            if (reportData != null)
            {
                if(companyData != null)
                {
                    data.CompanyAddress = companyData.CompanyAddress;
                    data.CompanyName = companyData.CompanyName;
                    data.CompanyPhone = companyData.CompanyPhone;
                    data.CompanyLogo = companyData.CompanyLogo;
                }
                //data.Data.Add(reportData);
                //data.Data = reportData;
                result.Status = true;
                result.Data = reportData;
            }
            else
            {
                result.Message = "لا توجد فاواتير مبيعات لهذه المدة";
            }
            return result;
        }
      

        #endregion
       
    }
}
