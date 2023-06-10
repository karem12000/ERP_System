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

namespace ERP_System.BLL.Guide
{
    public class SupplierBll
    {
        private const string _spSupplier = "[People].[spSupplier]";
        private readonly IRepository<Supplier> _repoSupplier;
        private readonly IMapper _mapper;

        public SupplierBll(IRepository<Supplier> repoSupplier,  IMapper mapper)
        {
            _repoSupplier = repoSupplier;
            _mapper = mapper;
        }

        #region Get
        public SupplierDTO GetById(Guid id)
        {
            return _repoSupplier.GetAllAsNoTracking().Where(p => p.ID == id).Select(p => new SupplierDTO
            {
                ID = id,
                Address = p.Address,
                IsActive = p.IsActive,
                companyName = p.companyName,
                Name = p.Name,
                Phone = p.Phone,
                ProcessAmount = p.ProcessAmount,
                ProcessTypeInt = p.ProcessType == null ? 0 : (int)p.ProcessType
            }).FirstOrDefault();
        }
       
        public DataTableResponse LoadData(DataTableRequest mdl)
        {
            var data = _repoSupplier.ExecuteStoredProcedure<SupplierTableDTO>
                (_spSupplier, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }
        #endregion
        #region Save 
        public ResultViewModel Save(SupplierDTO SupplierDTO)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoSupplier.GetAllAsNoTracking().Where(p => p.ID == SupplierDTO.ID).FirstOrDefault();
            if (data != null)
            {
                var tbl = _mapper.Map<Supplier>(SupplierDTO);
                if (SupplierDTO.ProcessType == null)
                {
                    tbl.ProcessAmount = 0;
                }
                tbl.AddedBy = data.AddedBy;
                tbl.CreatedDate = data.CreatedDate;
                tbl.ModifiedDate = AppDateTime.Now;
                if (_repoSupplier.UserId != Guid.Empty)
                {
                    tbl.ModifiedBy = _repoSupplier.UserId;
                }
                if (_repoSupplier.Update(tbl))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
                var tbl = _mapper.Map<Supplier>(SupplierDTO);
                if (SupplierDTO.ProcessType == null)
                {
                    tbl.ProcessAmount = 0;
                }
                if (_repoSupplier.UserId != Guid.Empty)
                {
                    tbl.AddedBy = _repoSupplier.UserId;
                }
                if (_repoSupplier.Insert(tbl))
                {
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
            var tbl = _repoSupplier.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

            if (tbl == null)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = AppConstants.Messages.DeletedFailed;
                return resultViewModel;
            }

            tbl.IsDeleted = true;
            if (_repoSupplier.UserId != Guid.Empty)
            {
                tbl.DeletedBy = _repoSupplier.UserId;
            }
            tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoSupplier.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


            return resultViewModel;
        }
        #endregion
    }
}
