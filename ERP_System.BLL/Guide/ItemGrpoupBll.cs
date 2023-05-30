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

namespace ERP_System.BLL.Guide
{
    public class ItemGrpoupBll
    {
        private const string _spGroupItems = "[Guide].[spItemGroups]";
        private readonly IRepository<ItemGrpoup> _repoGroup;
        private readonly IMapper _mapper;

        public ItemGrpoupBll(IRepository<ItemGrpoup> repoGroup, IMapper mapper)
        {
            _repoGroup = repoGroup;
            _mapper = mapper;
        }

        #region Get
        public ItemGrpoup GetById(Guid id)
        {
            return _repoGroup.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();
        }

        public IQueryable<SelectListDTO> GetSelect()
        {
            var data = _repoGroup.GetAllAsNoTracking().Where(x => x.IsActive && !x.IsDeleted).Select(p => new SelectListDTO()
            {
                Value = p.ID,
                Text = p.Name
            });
            return data.Distinct();
        }

        public IQueryable<ItemGrpoup> GetAll()
        {
            return _repoGroup.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive);
        }

        public DataTableResponse LoadData(DataTableRequest mdl)
        {
            var data = _repoGroup.ExecuteStoredProcedure<ItemGroupTableDTO>
                (_spGroupItems, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }
        #endregion
        #region Save 
        public ResultViewModel Save(ItemGroupDTO GroupItemDTO)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoGroup.GetAllAsNoTracking().Where(p => p.ID == GroupItemDTO.ID).FirstOrDefault();
            if (data != null)
            {

                if (_repoGroup.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.ID != data.ID && p.Name.Trim().ToLower() == GroupItemDTO.Name.Trim().ToLower()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                    return resultViewModel;

                }

                var tbl = _mapper.Map<ItemGrpoup>(GroupItemDTO);
                tbl.AddedBy = data.AddedBy;

                tbl.ModifiedDate = AppDateTime.Now;
                if (_repoGroup.UserId != Guid.Empty)
                {
                    tbl.ModifiedBy = _repoGroup.UserId;
                }
                if (_repoGroup.Update(tbl))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
                if (_repoGroup.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.Name.Trim().ToLower() == GroupItemDTO.Name.Trim().ToLower()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                    return resultViewModel;
                }
                var tbl = _mapper.Map<ItemGrpoup>(GroupItemDTO);
                
                if (_repoGroup.UserId != Guid.Empty)
                {
                    tbl.AddedBy = _repoGroup.UserId;
                }
                if (_repoGroup.Insert(tbl))
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
            var tbl = _repoGroup.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

            if (tbl == null)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = AppConstants.Messages.DeletedFailed;
                return resultViewModel;
            }

            tbl.IsDeleted = true;
            if (_repoGroup.UserId != Guid.Empty)
            {
                tbl.DeletedBy = _repoGroup.UserId;
            }
            tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoGroup.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


            return resultViewModel;
        }
        #endregion
    }
}
