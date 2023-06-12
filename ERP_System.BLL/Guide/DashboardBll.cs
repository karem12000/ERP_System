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

        private readonly IRepository<Product> _repoProduct;

        public DashboardBll( IRepository<Product> repoProduct, IRepository<User> repoUser, IRepository<Stock> repoStock, IRepository<ItemGrpoup> repoItemGroup)
        {
            _repoProduct = repoProduct;
            _repoUser = repoUser;
            _repoStock = repoStock;
            _repoItemGroup = repoItemGroup;
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

        #endregion

    }
}
