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

namespace ERP_System.BLL.Guide
{
    public class StockBll
    {
        private const string _spStock = "[Guide].[spStocks]";

        private readonly IRepository<Stock> _repoStock;
        private readonly IRepository<UserStock> _repoUserStock;
        private readonly IRepository<StockProduct> _repoStockProduct;
        private readonly IMapper _mapper;

        public StockBll(IRepository<Stock> repoStock, IRepository<UserStock> repoUserStock, IMapper mapper, IRepository<StockProduct> repoStockProduct)
        {
            _repoStock = repoStock;
            _mapper = mapper;
            _repoUserStock = repoUserStock;
            _repoStockProduct = repoStockProduct;
        }

        #region Get
        public Stock GetById(Guid id)
        {
            return _repoStock.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();
        }

        public IQueryable<SelectListDTO> GetSelect()
        {
            var data = _repoStock.GetAllAsNoTracking().Where(x => x.IsActive && !x.IsDeleted).Select(p => new SelectListDTO()
            {
                Value = p.ID,
                Text = p.Name
            });
            return data.Distinct();
        }

        public IQueryable<SelectListDTO> GetStocksSelectByUserId(Guid? userId)
        {
            var data = _repoStock.GetAllAsNoTracking().Where(x => x.IsActive && !x.IsDeleted && x.UserStocks.Any(x => x.UserId == userId)).Select(p => new SelectListDTO()
            {
                Value = p.ID,
                Text = p.Name
            });
            return data.Distinct();

        }

        public IQueryable<Stock> GetAll()
        {
            var userId = _repoStock.UserId;
            return _repoStock.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive);
        }

        public DataTableResponse LoadData(DataTableRequest mdl)
        {
            var userId = _repoStock.UserId;
            mdl.UserID = userId;
            var data = _repoStock.ExecuteStoredProcedure<StockTableDTO>
                (_spStock, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }


        #endregion
        #region Save 
        public ResultViewModel Save(StockDto stockDto)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoStock.GetAllAsNoTracking().Where(p => p.ID == stockDto.ID).FirstOrDefault();
            if (data != null)
            {

                if (_repoStock.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.ID != data.ID && p.Name.Trim().ToLower() == stockDto.Name.Trim().ToLower()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                    return resultViewModel;

                }

                var tbl = _mapper.Map<Stock>(stockDto);
                tbl.AddedBy = data.AddedBy;
                tbl.ModifiedDate = AppDateTime.Now;
                tbl.ModifiedBy = _repoStock.UserId;
                tbl.CreatedDate = data.CreatedDate;

                if (_repoStock.Update(tbl))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
                if (_repoStock.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.Name.Trim().ToLower() == stockDto.Name.Trim().ToLower()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                    return resultViewModel;
                }
                var tbl = _mapper.Map<Stock>(stockDto);
                if (_repoStock.UserId != Guid.Empty)
                {
                    tbl.AddedBy = _repoStock.UserId;
                }
                if (_repoStock.Insert(tbl))
                {

                    var StockForSuperAdmin = new UserStock()
                    {
                        UserId = Guid.Parse(AppConstants.SuperAdminId),
                        StockId = tbl.ID,
                        AddedBy = _repoStock.UserId
                    };
                    _repoUserStock.Insert(StockForSuperAdmin);

                    

                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }





            return resultViewModel;
        }
        #endregion


        #region Delete
        public ResultViewModel Delete(Guid id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();

            var haveProducts = _repoStockProduct.GetAllAsNoTracking().Any(x=>x.StockId== id);
            if(haveProducts)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = "لا يمكن حذف المخزن لانه يحتوي علي منتجات";
                return resultViewModel;
                
            }
            else
            {
                var tbl = _repoStock.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

                if (tbl == null)
                {
                    resultViewModel.Status = false;
                    resultViewModel.Message = AppConstants.Messages.DeletedFailed;
                    return resultViewModel;
                }

				tbl.IsDeleted = true;
				tbl.DeletedDate = DateTime.Now;
				tbl.DeletedBy = _repoStock.UserId;

				var IsSuceess = _repoStock.Update(tbl);

                resultViewModel.Status = IsSuceess;
                resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;
            }
            //tbl.IsDeleted = true;
            //if (_repoStock.UserId != Guid.Empty)
            //{
            //    tbl.DeletedBy = _repoStock.UserId;
            //}
            //tbl.DeletedDate = AppDateTime.Now;
            //var IsSuceess = _repoStock.Update(tbl);
            
            return resultViewModel;
        }
        #endregion
    }
}
