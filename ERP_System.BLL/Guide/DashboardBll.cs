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
    public class DashboardBll
    {
        private readonly IRepository<User> _repoUser;
        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<ItemGrpoup> _repoItemGroup;
        private readonly IRepository<SaleInvoice> _repoSaleInvoice;
        private readonly IRepository<SaleInvoiceDetail> _repoSaleInvoiceDetail;
        private readonly IRepository<PurchaseInvoice> _repoPurchaseInvoice;

        private readonly IRepository<Product> _repoProduct;

        public DashboardBll( IRepository<Product> repoProduct, IRepository<SaleInvoiceDetail> repoSaleInvoiceDetail, IRepository<PurchaseInvoice> repoPurchaseInvoice, IRepository<SaleInvoice> repoSaleInvoice ,IRepository<User> repoUser, IRepository<Stock> repoStock, IRepository<ItemGrpoup> repoItemGroup)
        {
            _repoProduct = repoProduct;
            _repoUser = repoUser;
            _repoStock = repoStock;
            _repoItemGroup = repoItemGroup;
            _repoSaleInvoice = repoSaleInvoice;
            _repoPurchaseInvoice = repoPurchaseInvoice;
            _repoSaleInvoiceDetail = repoSaleInvoiceDetail;
        }
        public DashboardDTO DashboardData()
        {
           var data = new DashboardDTO();
            data.ProductsCount = GetProductsCount();
            data.UsersCount = GetUsersCount();
            data.StocksCount = GetStocksCount();
            data.GroupsCount = GetGroupsCount();
            data.MostSaleProductsCount = GetMostProductsSaleCount();
            return data;
        }
        #region Get
        public int GetUsersCount()
        {
            var data = _repoUser.GetAllAsNoTracking().Where(p => p.IsActive && !p.IsDeleted);
            return data.Distinct().Count();
        }
        public int GetProductsCount()
        {
            var data = _repoProduct.GetAllAsNoTracking().Where(p => p.IsActive && !p.IsDeleted);
            return data.Distinct().Count();
        } 
        
        public int GetStocksCount()
        {
            var data = _repoStock.GetAllAsNoTracking().Where(p => p.IsActive && !p.IsDeleted);
            return data.Distinct().Count();
        }

        public int GetGroupsCount()
        {
            var data = _repoItemGroup.GetAllAsNoTracking().Where(p => p.IsActive && !p.IsDeleted);
            return data.Distinct().Count();
        }

        public List<MostSaleProducts> GetMostProductsSaleCount()
        {
            var data = (from s in _repoSaleInvoiceDetail.GetAllAsNoTracking()
                        group s by new { s.ProductId , s.ProductName } into val
                        select new MostSaleProducts()
                        {
                            ProductId = val.Key.ProductId,
                            ProductName=val.Key.ProductName,
                            Qty = val.Sum(s => s.Qty)
                        }).OrderByDescending(i => i.Qty).Take(3).ToList();
            
            return data;
        }

        #endregion

    }
}
