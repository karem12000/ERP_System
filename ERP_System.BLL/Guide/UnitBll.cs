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

namespace ERP_System.BLL.Guide
{
    public class UnitBll
    {
        private const string _spUnits = "Guide.[spUnits]";
        private readonly IRepository<Unit> _repoUnit;
        private readonly IRepository<ProductUnit> _repoProductUnit;
        private readonly IMapper _mapper;

        public UnitBll(IRepository<Unit> repoUnit, IMapper mapper , IRepository<ProductUnit> repoProductUnit)
        {
            _repoUnit = repoUnit;
            _mapper = mapper;
            _repoProductUnit = repoProductUnit;
        }

        #region Get
        public UnitDTO GetById(Guid id)
        {
           
            return _repoUnit.GetAllAsNoTracking().Where(p => p.ID == id).Select(c=> new UnitDTO
            {
                ID = c.ID,
                Name = c.Name,
                IsActive = c.IsActive
            }).FirstOrDefault();
           
        }

        public List<ProductUnitsDTO> GetAllByProductId(Guid? ProductId)
        {

            return _repoProductUnit.GetAllAsNoTracking().Where(p => p.ProductId==ProductId && p.IsActive && !p.IsDeleted).Select(c => new ProductUnitsDTO
            {
               UnitId = c.UnitId,
               UnitName = c.Unit.Name,
               ID= c.ID
               
            }).ToList();
        }

        public Unit GetByUnitName(string name)
        {
            return _repoUnit.GetAllAsNoTracking().Where(p => name.ToLower().Trim().Contains(p.Name.ToLower().Trim())).FirstOrDefault();
        }

        public IQueryable<SelectListDTO> GetSelect()
        {
            var data = _repoUnit.GetAllAsNoTracking().Where(x => x.IsActive && !x.IsDeleted).Select(p => new SelectListDTO()
            {
                Value = p.ID,
                Text = p.Name
            });
            return data.Distinct();

        }
        //public IQueryable<SelectListDTO> GetMainUnitSelect()
        //{
        //    var data = _repoUnit.GetAllAsNoTracking().Where(x => x.IsActive && !x.IsDeleted && x.UnitType==UnitType.BasicUnit).Select(p => new SelectListDTO()
        //    {
        //        Value = p.ID,
        //        Text = p.Name
        //    });
        //    return data.Distinct();

        //}

        public IQueryable<Unit> GetAll()
        {

            return _repoUnit.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive);
        }

        public DataTableResponse LoadData(DataTableRequest mdl)
        {
            var data = _repoUnit.ExecuteStoredProcedure<UnitTableDTO>
                (_spUnits, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }
        #endregion
        #region Save 
        public ResultViewModel Save(UnitDTO unitDTO)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoUnit.GetAllAsNoTracking().Where(p => p.ID == unitDTO.ID).FirstOrDefault();
            if (data != null)
            {

                if (_repoUnit.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.ID != data.ID && p.Name.Trim().ToLower() == unitDTO.Name.Trim().ToLower()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                    return resultViewModel;

                }

                var tbl = _mapper.Map<Unit>(unitDTO);
                tbl.AddedBy = data.AddedBy;
                tbl.ModifiedDate = AppDateTime.Now;
                tbl.ModifiedBy = _repoUnit.UserId;
                tbl.CreatedDate = data.CreatedDate;

                if (_repoUnit.Update(tbl))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
                if (_repoUnit.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.Name.Trim().ToLower() == unitDTO.Name.Trim().ToLower()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                    return resultViewModel;
                }
                var tbl = _mapper.Map<Unit>(unitDTO);
                if (_repoUnit.UserId != Guid.Empty)
                {
                    tbl.AddedBy = _repoUnit.UserId;
                }
                if (_repoUnit.Insert(tbl))
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
            var tbl = _repoUnit.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

            if (tbl == null)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = AppConstants.Messages.DeletedFailed;
                return resultViewModel;
            }

            tbl.IsDeleted = true;
            if (_repoUnit.UserId != Guid.Empty)
            {
                tbl.DeletedBy = _repoUnit.UserId;
            }
            tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoUnit.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


            return resultViewModel;
        }
        #endregion
    }
}
